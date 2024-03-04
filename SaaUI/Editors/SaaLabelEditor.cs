using SaaUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Using
{
    class SaaLabelEditor:UITypeEditor
    {
        public SaaLabelEditor()
        {

        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            // Foo foo = value as Foo;
            SaaHtmlLabel foo = ((SaaHtmlLabel)context.Instance);
            if (svc != null && foo != null)
            {
                using (SaaHTMLEditor form = new SaaHTMLEditor())
                {
                    form.Value = foo.Text;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        foo.Text = form.Value; // update object
                       
                    }
                }
            }
            
            return base.EditValue(context, provider, value);
           /// return value; // can also replace the wrapper object here
        }
    }
}
