using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RiotPls.Tools
{
    partial class GeneralSettings
    {

        private const string FILENAME = "GeneralSettings.rpxml";
        private static GeneralSettings settings = null;
        public static string Path => System.IO.Path.Combine(Tools.Paths.AppData, GeneralSettings.FILENAME);
        static GeneralSettings()
        {
            GeneralSettings.Load();
        }

        public static void ClearOpenWindows()
        {
            GeneralSettings.settings.VisibleWindows.Clear();
        }
        public static void Create()
        {
            try
            {
                GeneralSettings.settings = new GeneralSettings();
            }
            catch
            {
                // ignored
            }
        }

        public static bool GetWindowWasOpen(Form form)
        {
            bool value = GeneralSettings.settings.VisibleWindows.FindByName(form.Name) != null;
            return value;
        }
        public static void Load()
        {
            try
            {
                GeneralSettings.Create();
                if (File.Exists(GeneralSettings.Path))
                    GeneralSettings.settings.ReadXml(GeneralSettings.Path);
            }
            catch
            {
                // ignored
            }
            return;
        }
        public static void LoadStatColumnVisibility(DataGridViewColumn column)
        {
            StatColumnsRow row = GeneralSettings.settings.StatColumns.Rows.Find(column.Name) as StatColumnsRow;
            column.Visible = row?.Visible ?? true;
            return;
        }
        public static void LoadWindowSettings(Form form)
        {
            WindowsRow row = GeneralSettings.settings.Windows.Rows.Find(form.Name) as WindowsRow;
            if (row != null && row.Width != 0 && row.Height != 0)
            {
                form.Location = new Point(row.Left, row.Top);
                if (form.FormBorderStyle == FormBorderStyle.Sizable ||
                    form.FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    if ((FormWindowState)row.State == FormWindowState.Normal)
                        form.Size = new Size(row.Width, row.Height);
                    form.WindowState = (FormWindowState)row.State;
                }
            }
            if (GeneralSettings.GetWindowWasOpen(form))
                form.Visible = true;
            return;
        }
        public static void Save()
        {
            try
            {

                GeneralSettings.settings.WriteXml(GeneralSettings.Path);
            }
            catch
            {
                // ignored
            }
            return;
        }

        public static void SaveOpenWindow(Form form)
        {
            if (form.Visible)
            {
                VisibleWindowsRow row = GeneralSettings.settings.VisibleWindows.NewVisibleWindowsRow();
                row.Name = form.Name;
                GeneralSettings.settings.VisibleWindows.AddVisibleWindowsRow(row);
            }
            return;
        }
        public static void SaveOpenWindows(List<Form> forms)
        {
            foreach (Form form in forms)
                GeneralSettings.SaveOpenWindow(form);
            return;
        }
        public static void SaveStatColumnVisibility(DataGridViewColumn column)
        {
            StatColumnsRow row = GeneralSettings.settings.StatColumns.Rows.Find(column.Name) as StatColumnsRow;
            if (row != null)
                GeneralSettings.settings.StatColumns.RemoveStatColumnsRow(row);
            GeneralSettings.settings.StatColumns.AddStatColumnsRow(column.Name, column.Visible);
            return;
        }
        public static void SaveWindowSettings(Form form)
        {
            if (form.WindowState != FormWindowState.Minimized && form.Width != 0 && form.Height != 0)
            {
                WindowsRow row = GeneralSettings.settings.Windows.Rows.Find(form.Name) as WindowsRow;
                if (row != null)
                    GeneralSettings.settings.Windows.RemoveWindowsRow(row);
                GeneralSettings.settings.Windows.AddWindowsRow(form.Name, form.Left, form.Top, form.Width, form.Height, (int)form.WindowState);
            }
            return;
        }
    }
}
