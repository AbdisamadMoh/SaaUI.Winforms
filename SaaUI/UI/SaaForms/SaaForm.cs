using SaaUI.Paint;
using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaForm : Form
    {
        public SaaForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            DrawPaint paint = new DrawPaint()
            {
                Options = new DrawPaintOptions()
                {
                    BackColor1 = _BackColor,
                    BackColor2 = _BackColor2,
                    BackColorAngle = (int)_BackColorAngle,
                    BorderColor1 = _BorderColor,
                    BorderColor2 = _BorderColor2,
                    BorderColorAngle = _BorderColorAngle,
                    BorderThickness = _Border,
                    Radius = _Radius,
                    X = 0,
                    Y = 0,
                    Tranparency = 100,
                    Width = this.Width,
                    Height = this.Height //adjusting radius and width,height which exceedes
                }
            };

            if (_ColorType == PanelColorType.Gradient)
            {
                paint.PaintGradient(e.Graphics, this, true);
            }
            else
            {
                paint.Paint(e.Graphics, this, true);
            }
            // DrawFormControls(e.Graphics);
            base.OnPaint(e);
        }


        private void SaaForm_Load(object sender, EventArgs e)
        {

        }

        private void DrawFormControls(Graphics g)
        {
            var _w = this.Width;
            var _h = this.Height;
            var _boxWidth = 100;
            var _boxHeight = 30;
            var _boxX1 = _w - (_boxWidth + _bx);
            var _boxY1 = _by;
            var _boxX2 = _w - 15;
            var _boxY2 = _boxHeight;
            g.DrawRectangle(Pens.Red, _boxX1, _boxY1, _boxWidth, _boxHeight);
            //RoundedRectangleF r = new RoundedRectangleF(_boxWidth, _boxHeight, 2, RoundCorners.All, _boxX1, _boxY1);
            //g.DrawPath(Pens.Red, r.Path);
            //r.Path.Dispose();
            //r.BorderPath.Dispose();

        }
        float _bx = 10;
        public float BoxX
        {
            get
            {
                return _bx;
            }
            set
            {
                _bx = value;
                Invalidate();
            }
        }
        float _by = 15;
        public float BoxY
        {
            get
            {
                return _by;
            }
            set
            {
                _by = value;
                Invalidate();
            }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormBorderStyle FormBorderStyle
        {
            get { return FormBorderStyle.None; }
            set { base.FormBorderStyle = value = FormBorderStyle.None; }
        }

        Color _BackColor = SaaInternalColors.PrimaryColor;
        public new Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }


        PanelColorType _ColorType = PanelColorType.Default;
        public PanelColorType ColorType
        {
            get
            {
                return _ColorType;
            }
            set
            {
                _ColorType = value;
                Invalidate();
            }
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
        protected override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]


        /// <summary>
        /// Gets or Sets whether to enable double buffering for this control
        /// </summary>
        [Description("Gets or Sets whether to enable double buffering for this control.")]
        [Category("Saa")]
        public bool EnableDoubleBuffering
        {
            get
            {
                return DoubleBuffered;
            }
            set
            {
                DoubleBuffered = value;
            }
        }

        Color _BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
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


    }
}
