using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RiotPls.Tools
{
    /// <summary>
    /// Common drawing functions
    /// </summary>
    public abstract class Drawing
    {
        #region Static Members
        private const int WM_SETREDRAW = 11;
        #endregion
        #region Static Methods
        /// <summary>
        /// Resume drawing the control
        /// </summary>
        /// <param name="control">Control to resume drawing</param>
        /// <param name="refresh">True to force refresh, false otherwise</param>
        public static void ResumeDrawing(Control control, bool refresh = true)
        {
            if (control.Handle == null)
                return;
            Drawing.SendMessage(control.Handle, WM_SETREDRAW, true, 0);
            if (refresh)
                control.Refresh();
            return;
        }
        /// <summary>
        /// Suspend drawing updates for the control
        /// </summary>
        /// <param name="control">Control to suspend drawing</param>
        public static void SuspendDrawing(Control control)
        {
            if (control.Handle == null)
                return;
            Drawing.SendMessage(control.Handle, WM_SETREDRAW, false, 0);
            return;
        }
        #endregion
        #region External Methods
        /// <summary>
        /// Send a message to the specified handle
        /// </summary>
        /// <param name="hWnd">Control handle of message recepient</param>
        /// <param name="wMsg">Message data</param>
        /// <param name="wParam">Message data</param>
        /// <param name="lParam">Message data</param>
        /// <returns>Return code</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        /// <summary>
        /// Toggle visibility of the specified form
        /// </summary>
        /// <param name="form">Form to toggle visibility</param>
        /// <param name="value">Desired form visibility</param>
        public static void ToggleWindow(Form form, bool value)
        {
            bool was_visible = form.Visible;
            form.Visible = value;
            if (value)
            {
                if (form.WindowState == FormWindowState.Minimized || !form.ContainsFocus)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                }
                else if (was_visible)
                    form.WindowState = FormWindowState.Minimized;
            }
            return;
        }
        #endregion
    }
}
