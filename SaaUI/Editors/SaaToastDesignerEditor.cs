using SaaUI;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Using
{
    class SaaToastDesignerEditor : UITypeEditor
    {
        public SaaToastDesignerEditor()
        {

        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
           
            SaaToast ci = ((SaaToast)context.Instance);
            if (svc != null && ci != null)
            {
                using (SaaToastDesigner form = new SaaToastDesigner())
                {
                    form.SaaToast = ci;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        ci = form.SaaToast; // update object

                    }
                }
            }

            return base.EditValue(context, provider, value);

        }
    }
}
