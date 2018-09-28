using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Globalization;

namespace GSM2._0
{
    class Language
    {
        public string Lang_set { get; set; }   //語言
        public static void Apply(Form Form, string Language)
        {
            if (string.IsNullOrEmpty(Language))
                return;

            if (Form == null)
                throw new ArgumentNullException("form");

            System.Globalization.CultureInfo info;
            try
            {
                info = new System.Globalization.CultureInfo(Language);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Thread.CurrentThread.CurrentUICulture = info;//變更文化特性            
            ComponentResourceManager Manager = null;

            try
            {
                Manager = new ComponentResourceManager(Form.GetType());
                Manager.ApplyResources(Form, "$this");

                foreach (Control Ctrl in Form.Controls)
                {
                    ApplyLanguage(Ctrl, Manager);
                }
            }
            finally
            {
                Manager = null;
            }
        }

        private static void ApplyLanguage(Control Ctrl, ComponentResourceManager Manager)
        {
            if (Ctrl is StatusStrip)
                return;

            if (Ctrl is ToolStrip)
                return;

            if (Ctrl is MenuStrip)
            {
                MenuStrip menu = Ctrl as MenuStrip;
                Manager.ApplyResources(Ctrl, Ctrl.Name);

                foreach (ToolStripItem item in menu.Items)
                {
                    ApplyLanguage(item, Manager);
                }
            }
            else if (Ctrl is ToolStrip)
            {
                ToolStrip menu = Ctrl as ToolStrip;
                Manager.ApplyResources(Ctrl, Ctrl.Name);

                foreach (ToolStripItem item in menu.Items)
                {
                    ApplyLanguage(item, Manager);
                }
            }
            else
            {
                Manager.ApplyResources(Ctrl, Ctrl.Name);
                foreach (Control item in Ctrl.Controls)
                {
                    ApplyLanguage(item, Manager);
                }
            }
        }
        private static void ApplyLanguage(ToolStripItem Ctrl, ComponentResourceManager Manager)
        {
            Manager.ApplyResources(Ctrl, Ctrl.Name);
            ToolStripMenuItem menu = Ctrl as ToolStripMenuItem;
            foreach (ToolStripItem item in menu.DropDownItems)
            {
                ApplyLanguage(item, Manager);
            }
        }
    }
}
