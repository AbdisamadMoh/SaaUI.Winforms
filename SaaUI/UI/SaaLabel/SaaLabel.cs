using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace SaaUI
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SaaLabel), "icons.SaaLabel_16.bmp")]
    public class SaaLabel : Label
    {
        public SaaLabel()
        {
            BackColor = Color.Transparent;
        }



        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }


    }
}
