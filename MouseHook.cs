using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowSync
{
    public class MouseHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);

        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        private const int WH_MOUSE_LL = 14;
        

        public delegate void MouseEventHandle(MouseHookStruct param);
        public static event MouseEventHandle OnMouseAction;

        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        private HookProc _hookProc;
        private static int _hHook;

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public Point pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
            public int mouseData;
            public int wParam;
        }

        public void Install()
        {
            if (_hHook == 0)
            {
                _hookProc = HookCallback;
                var hInstance = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
                _hHook = SetWindowsHookEx(WH_MOUSE_LL, _hookProc, hInstance, 0);
            }
        }

        public void Uninstall()
        {
            if (_hHook != 0)
            {
                UnhookWindowsHookEx(_hHook);
                _hHook = 0;
            }
        }

        private int HookCallback(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                hookStruct.wParam = wParam;
                OnMouseAction?.Invoke(hookStruct);
            }
            return CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
    }
}