using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable saaCard.
    /// </summary>
    [Description("Beautiful and customizable saaCard.")]
    [DefaultEvent("Click")]
    [ToolboxBitmap(typeof(SaaCard), "icons.SaaCard_16.bmp")]
    public partial class SaaCard : UserControl
    {
        public SaaCard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Radius.Change += Radius1_Change;
        }

        private void Radius1_Change()
        {

            Invalidate();
        }

        Pen BorderPen;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            var rec = new BorderPath(0, 0, Width, Height, _Radius);
            this.Region = new Region(rec.Path);


            LinearGradientBrush BGColor = new LinearGradientBrush(rec.RectangleF, _BorderColor, _BorderColor2, _BorderColorAngle);

            //Recreate radius like of Padding..but backup first
            using (LinearGradientBrush inactiveGB = new LinearGradientBrush(rec.RectangleF, BackColor, _BackColor2, _BackColorAngle))
            {

                e.Graphics.FillPath(inactiveGB, rec.Path);
                if (_Border > 0)
                {
                    BorderPen = new Pen(BGColor, _Border);
                    e.Graphics.DrawPath(BorderPen, rec.PathBorder);

                }
            }



            try
            {
                BGColor.Dispose();
                rec.PathBorder.Dispose();
                rec.Path.Dispose();
            }
            catch { }
        }

        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets the border radius of the control.
        /// </summary>
        [Description("Gets or Sets the border radius of the control."), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                Invalidate();
            }
        }
        int _Border = 0;
        /// <summary>
        /// Gets or Sets border thickness of the control.
        /// </summary>
        [Description("Gets or Sets border thickness of the control."), Category("Saa")]
        public int Border
        {
            get
            {
                return _Border;
            }
            set
            {
                _Border = value;
                Invalidate();
            }
        }
        Color _BorderColor = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets first color of the border color gradient.
        /// </summary>
        [Description("Gets or Sets first color of the border color gradient."), Category("Saa")]
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }
        Color _BorderColor2 = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets first second of the border color gradient.
        /// </summary>
        [Description("Gets or Sets second color of the border color gradient."), Category("Saa")]
        public Color BorderColor2
        {
            get
            {
                return _BorderColor2;
            }
            set
            {
                _BorderColor2 = value;
                Invalidate();
            }
        }
        int _BorderColorAngle = 0;
        /// <summary>
        /// Gets or Sets at which angle the color gradients will meet.
        /// </summary>
        [Description("Gets or Sets at which angle the color gradients will meet."), Category("Saa")]
        public int BorderColorAngle
        {
            get
            {
                return _BorderColorAngle;
            }
            set
            {
                _BorderColorAngle = value;
                Invalidate();
            }
        }
        Color _BackColor2 = Color.FromArgb(255, 192, 255);
        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color BackColor2
        {
            get
            {
                return _BackColor2;
            }

            set
            {
                _BackColor2 = value;
                Invalidate();
            }
        }
        float _BackColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        public float BackColorAngle
        {
            get
            {
                return _BackColorAngle;
            }

            set
            {
                _BackColorAngle = value;
                Invalidate();
            }
        }
        private void SaaCard_Load(object sender, EventArgs e)
        {

        }
    }
}
