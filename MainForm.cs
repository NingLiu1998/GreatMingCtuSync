using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowSync
{
    public partial class MainForm : Form
    {
        #region Win32 API声明
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] inputs, int size);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetAsyncKeyState(int vKey);


        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const uint LWA_ALPHA = 0x2;
        private const uint LWA_COLORKEY = 0x1;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const int HOTKEY_ID = 0x3000;
        private const int HOTKEYMOUSEEVENTF_ID = 0x1234;
        private const uint VK_F5 = 0x74;
        private const int HOTKEY_F7_ID = 0x4000;
        private const int VK_LSHIFT = 0xA0;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;

        #endregion

        #region 控件状态变量
        private bool isRuning = false;
        private bool _isMouseDown = false;
        private bool _functionEnabled = false;
        private bool isMinFrom = false;
        private int? masterWindowHwnd;
        private List<int> lstIgroneKeys = new List<int>();
        private KeyboardHook? keyboardHook;
        private Size deafultS = new Size();
        private Point deafultL = new Point();
        private MouseHook? mouseHook;
        #endregion

        #region 初始化与窗体生命周期
        public MainForm()
        {
            InitializeComponent();
            InitializeWindowStyle();
        }

        private void InitializeWindowStyle()
        {
            this.TopMost = true;
            int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED);
            SetLayeredWindowAttributes(this.Handle, 0, 255, LWA_ALPHA);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterHotKey(this.Handle, HOTKEY_ID, 0, VK_F5);
            RegisterHotKey(this.Handle, HOTKEYMOUSEEVENTF_ID, 0, (uint)Keys.F6);
            RegisterHotKey(this.Handle, HOTKEY_F7_ID, 0, (uint)Keys.F7);
            StatusChange(isRuning);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanupResources();
            base.OnFormClosing(e);
        }

        private void CleanupResources()
        {
            if (_isMouseDown) SendMouseInput(false);
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            UnregisterHotKey(this.Handle, HOTKEYMOUSEEVENTF_ID);
            UnregisterHotKey(this.Handle, HOTKEY_F7_ID);
            keyboardHook?.Disconnect();
        }

        #endregion


        #region 热键处理模块
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                HandleHotkeyMessage(m.WParam);
            }
            base.WndProc(ref m);
        }

        private void HandleHotkeyMessage(IntPtr wParam)
        {
            switch (wParam.ToInt32())
            {
                case HOTKEY_ID:
                    btnStart_Click(null, EventArgs.Empty);
                    break;
                case HOTKEYMOUSEEVENTF_ID:
                    ToggleMouseFunction();
                    break;
            }
        }

        private void ToggleMouseFunction()
        {
            _functionEnabled = !_functionEnabled;
            UpdateMouseState();
            UpdateStatusLabel();
        }
        #endregion

        #region 鼠标控制模块
        private void UpdateMouseState()
        {
            if (_functionEnabled && !_isMouseDown)
            {
                SendMouseInput(true);
                _isMouseDown = true;
            }
            else if (!_functionEnabled && _isMouseDown)
            {
                SendMouseInput(false);
                _isMouseDown = false;
            }
        }

        private void SendMouseInput(bool press)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = 0;
            inputs[0].mi.dwFlags = press ? MOUSEEVENTF_LEFTDOWN : MOUSEEVENTF_LEFTUP;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
        #endregion

        #region 窗口同步核心功能
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstWindows.Items.Count < 2 && !isRuning)
            {
                MessageBox.Show("需要至少两个窗口才能运行！");
                return;
            }

            ToggleSyncFunction();
            StatusChange(isRuning);
        }

        private void ToggleSyncFunction()
        {
            isRuning = !isRuning;
            if (isRuning)
            {
                StartSync();
            }
            else
            {
                StopSync();
            }
        }

        private void StartSync()
        {
            OutPutLog("开始监听");
            keyboardHook = new KeyboardHook();
            keyboardHook.Connect(this.OnKeyPressProcessHandle);

            //mouseHook = new MouseHook();
            //MouseHook.OnMouseAction += OnMouseEvent; // 静态事件访问
            //mouseHook.Install();

        }

        private void StopSync()
        {
            OutPutLog("停止监听");
            keyboardHook?.Disconnect();

            //mouseHook?.Uninstall();
            //MouseHook.OnMouseAction -= OnMouseEvent; // 取消订阅
        }

        private void OnMouseEvent(MouseHook.MouseHookStruct hookStruct)
        {
            if (GetForegroundWindow() != masterWindowHwnd) return;

            //精确的窗口相对坐标
            //var targetPoint = hookStruct.pt;
            //var hTarget = (IntPtr)hWnd;
            //var clientPoint = targetPoint;
            //ScreenToClient(hTarget, ref clientPoint);
            //int lParam = (clientPoint.Y << 16) | (clientPoint.X & 0xffff);
            //[DllImport("user32.dll")]
            //private static extern int ScreenToClient(IntPtr hWnd, ref Point lpPoint);

            // 过滤非鼠标消息
            switch (hookStruct.wParam)
            {
                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                    break;
                default:
                    return; // 忽略其他类型消息
            }


            // 转换坐标到目标窗口（示例使用屏幕坐标）
            int lParam = (hookStruct.pt.Y << 16) | (hookStruct.pt.X & 0xffff);

            foreach (ListViewItem item in lstWindows.Items)
            {
                int hWnd = int.Parse(item.Text);
                if (hWnd == 0 || hWnd == masterWindowHwnd) continue;

                OutPutLog($"发送鼠标消息到窗口: {hWnd}，消息类型: {hookStruct.wParam}, lParam:{lParam}");

                // 发送完整鼠标消息（含坐标和按键状态）
                SendMessage((IntPtr)hWnd, hookStruct.wParam, 0, lParam);

                //516按下右键，517抬起右键
            }
        }


        public void OnKeyPressProcessHandle(KeyboardHook.HookStruct hookStruct, out bool handle)
        {
            handle = false;

            // 仅处理键盘消息
            if (hookStruct.wParam != WM_KEYDOWN && hookStruct.wParam != WM_KEYUP) return;

            //如果不是主窗口或忽略的按键，则不处理
            if (GetForegroundWindow() != masterWindowHwnd || lstIgroneKeys.Contains(hookStruct.vkCode)) return;

            Keys key = (Keys)hookStruct.vkCode;
            OutPutLog(key.ToString());
            PropagateKeyPress(hookStruct);
        }

        private void PropagateKeyPress(KeyboardHook.HookStruct hookStruct)
        {
            foreach (ListViewItem item in lstWindows.Items)
            {
                int hWnd = int.Parse(item.Text);
                if (hWnd == 0 || hWnd == masterWindowHwnd) continue;
                // 新增鼠标消息处理
                if (hookStruct.wParam == WM_LBUTTONDOWN || hookStruct.wParam == WM_LBUTTONUP ||
                    hookStruct.wParam == WM_RBUTTONDOWN || hookStruct.wParam == WM_RBUTTONUP)
                {
                    // 发送带坐标的鼠标消息
                    var pos = GetMessagePos();
                    SendMessage((IntPtr)hWnd, hookStruct.wParam, 0, pos);
                }
                else
                {
                    SendMessage((IntPtr)hWnd, hookStruct.wParam, hookStruct.vkCode, 0);
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern int GetMessagePos();
        #endregion

        #region UI控制与辅助方法
        void StatusChange(bool runing)
        {
            btnStart.Text = runing ? "停止" : "运行";
            btnGetHandle.Enabled = !runing;
            btnClear.Enabled = !runing;
            btnAddIgrone.Enabled = !runing;
            btnIgroneClear.Enabled = !runing;
        }

        private void OutPutLog(string text)
        {
            textLog.Text += $"{DateTime.Now:HH:mm:ss} {text}{Environment.NewLine}";
            textLog.SelectionStart = textLog.Text.Length;
            textLog.ScrollToCaret();
        }

        private void UpdateStatusLabel()
        {
            OutPutLog(_functionEnabled ? "按住中" : "已释放");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SetLayeredWindowAttributes(this.Handle, 0, (byte)trackBar1.Value, LWA_ALPHA);
        }
        #endregion

        #region 窗口管理事件
        private void btnGetHandle_MouseDown(object sender, MouseEventArgs e) => Cursor = Cursors.Cross;

        private void btnGetHandle_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            CaptureWindowHandle();
        }

        private void CaptureWindowHandle()
        {
            var point = new Point();
            GetCursorPos(ref point);
            int hwnd = WindowFromPoint(point.X, point.Y);

            var title = new StringBuilder(256);
            GetWindowText(hwnd, title, 256);

            var item = lstWindows.Items.Add(new ListViewItem(hwnd.ToString()));
            item.SubItems.Add(title.ToString());
            item.SubItems.Add(lstWindows.Items.Count == 1 ? "V" : "--");

            if (lstWindows.Items.Count == 1) SetMasterWindow(item);
        }

        private void SetMasterWindow(ListViewItem master)
        {
            masterWindowHwnd = int.Parse(master.Text);
            foreach (ListViewItem item in lstWindows.Items)
            {
                item.SubItems[2].Text = item == master ? "V" : "--";
            }
        }
        #endregion

        #region 其他控件事件
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstWindows.Items.Clear();
            masterWindowHwnd = null;
        }

        private void lstWindows_DoubleClick(object sender, EventArgs e)
        {
            if (lstWindows.SelectedItems.Count > 0 && !isRuning)
            {
                SetMasterWindow(lstWindows.SelectedItems[0]);
            }
        }

        private void btnIgroneClear_Click(object sender, EventArgs e)
        {
            txtIgroneKeys.Text = "";
            lstIgroneKeys.Clear();
        }

        private void btnAddIgrone_Click(object sender, EventArgs e)
        {
            KeyboardHook.WaitForKeyPress(btnAddIgrone, (code, text) =>
            {
                txtIgroneKeys.Text += (txtIgroneKeys.Text.Length > 0 ? ", " : "") + text;
                lstIgroneKeys.Add(code);
            });
        }

        private void btnSetFrom_Click(object sender, EventArgs e)
        {
            isMinFrom = !isMinFrom;
            if (isMinFrom) MinimizeUI();
            else RestoreUI();
        }

        private void MinimizeUI()
        {
            deafultS = this.Size;
            deafultL = groupBoxLog.Location;
            groupBox2.Hide();
            groupBox1.Hide();
            this.Size = new Size(300, 190);
            groupBoxLog.Location = new Point(0, 12);
        }

        private void RestoreUI()
        {
            groupBox2.Show();
            groupBox1.Show();
            this.Size = deafultS;
            groupBoxLog.Location = deafultL;
        }
        #endregion
    }

    #region 输入结构体
    public struct INPUT
    {
        public uint type;
        public MouseInput mi;
    }

    public struct MouseInput
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    #endregion
}