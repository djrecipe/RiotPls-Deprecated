using System.Drawing;
using System.IO;
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
        public static void LoadWindowSettings(Form form)
        {
            WindowsRow row = GeneralSettings.settings.Windows.Rows.Find(form.Name) as WindowsRow;
            if (row != null && row.Width != 0 && row.Height != 0)
            {
                form.Location = new Point(row.Left, row.Top);
                form.Size = new Size(row.Width, row.Height);
            }
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
        public static void SaveWindowSettings(Form form)
        {
            if (form.WindowState == FormWindowState.Normal && form.Width != 0 && form.Height != 0)
            {
                WindowsRow row = GeneralSettings.settings.Windows.Rows.Find(form.Name) as WindowsRow;
                if (row != null)
                    GeneralSettings.settings.Windows.RemoveWindowsRow(row);
                GeneralSettings.settings.Windows.AddWindowsRow(form.Name, form.Left, form.Top, form.Width, form.Height);
            }
            return;
        }
    }
}
