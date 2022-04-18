using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public class AutoClosingMessageBox 
    { 
        System.Threading.Timer _timeoutTimer; 
        string _caption;
        MessageBoxButtons _button;
        MessageBoxIcon _icon;
        AutoClosingMessageBox(string text, string caption, int timeout,MessageBoxButtons button,MessageBoxIcon icon)
        { 
            _caption = caption;
            _button = button;
            _icon = icon;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed, null, timeout, System.Threading.Timeout.Infinite);
            MessageBox.Show(text, caption,button,icon); } 
        public static void Show(string text, string caption, MessageBoxButtons button, MessageBoxIcon icon, int timeout) 
        { new AutoClosingMessageBox(text, caption, timeout,button,icon); } 
        void OnTimerElapsed(object state) 
        { IntPtr mbWnd = FindWindow(null, _caption); 
            if (mbWnd != IntPtr.Zero) SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero); _timeoutTimer.Dispose(); } 
        const int WM_CLOSE = 0x0010;[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)] static extern IntPtr FindWindow(string lpClassName, string lpWindowName);[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)] static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam); }

   
}
