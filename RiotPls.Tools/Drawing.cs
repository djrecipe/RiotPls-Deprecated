using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls.Tools
{
    public abstract class Drawing
    {
        private const int WM_SETREDRAW = 11;
        public static void ResumeDrawing(Control parent, bool refresh = true)
        {
            if (parent.Handle == null)
                return;
            Drawing.SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            if (refresh)
                parent.Invalidate();
            return;
        }
        public static void SuspendDrawing(Control parent)
        {
            if (parent.Handle == null)
                return;
            Drawing.SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
    }
}
