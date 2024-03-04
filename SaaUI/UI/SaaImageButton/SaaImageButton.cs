using SaaUI.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    [ToolboxBitmap(typeof(SaaImageButton), "icons.SaaImageButton_16.bmp")]
    internal class SaaImageButton : SaaButton1
    {
        SaaPictureBox _picture = new SaaPictureBox();
        public SaaImageButton()
        {
            this.Image = Resources.icons8_Checked_32;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Size = new Size(188, 51);
        }


        bool isAdded = false;
        protected override void OnPaint(PaintEventArgs pevent)
        {

            base.OnPaint(pevent);
        }

        /// <summary>
        /// Gets or Sets position of image on the control.
        /// </summary>
        [Description("Gets or Sets position of image on the control.")]
        [Category("Saa")]
        public ContentAlignment ImagePosition
        {
            get { return this.ImageAlign; }
            set { this.ImageAlign = value; Invalidate(); }
        }


    }
}
