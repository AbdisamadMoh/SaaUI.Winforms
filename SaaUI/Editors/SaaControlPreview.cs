using SaaUI;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Using
{
    class SaaControlPreview : UITypeEditor
    {
        public SaaControlPreview()
        {

        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
          
            Control ci = ((Control)context.Instance);
            {
                using (Preview form = new Preview())
                {
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        //

                    }
                }
            }

            return base.EditValue(context, provider, value);

        }
        private object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();

            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o, null), null);
                }
            }

            return p;
        }
    }

}
