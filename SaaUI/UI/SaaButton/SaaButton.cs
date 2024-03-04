using SaaUI.Paint;
using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{

    // [Designer(typeof(SaaButtonTag))]
    internal class SaaButton1 : Button
    {
        Timer _timer = new Timer();
        public SaaButton1()
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(102, 27);
            Radius.Change += Radius1_Change;
            _timer.Interval = 1;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (!this.DesignMode || ForceAnimate)
            {
                if (_BorderAnimation)
                {
                    if (_BorderColorAngle < 360)
                    {
                        _BorderColorAngle += _Speed;
                    }
                    else
                    {
                        _BorderColorAngle = 0;
                    }
                    Invalidate();
                }

            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool ForceAnimate { get; set; } = false;
        int _Interval = 1;
        public int SpeedIntervalInMilliseconds
        {
            get
            {
                return _Interval;
            }
            set
            {
                if (value > 0)
                {
                    _Interval = value;
                    _timer.Interval = value;
                }
            }
        }

        int _Speed = 10;
        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                if (value > 0)
                {
                    _Speed = value;
                }
            }
        }

        bool _BorderAnimation = false;
        public bool BorderAnimation
        {
            get
            {
                return _BorderAnimation;
            }
            set
            {
                _BorderAnimation = value;
            }
        }
        private void Radius1_Change()
        {

            Invalidate();
        }
        Pen BorderPen;
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            var rec = new BorderPath(0, 0, Width, Height, _Radius);
            this.Region = new Region(rec.Path);

            base.OnPaint(e);
            if (_Border > 0)
            {
                LinearGradientBrush BGColor = new LinearGradientBrush(rec.RectangleF, _BorderColor, _BorderColor2, _BorderColorAngle);

                BorderPen = new Pen(BGColor, _Border);
                e.Graphics.DrawPath(BorderPen, rec.PathBorder);
                BGColor.Dispose();
            }
            try
            {
                rec.PathBorder.Dispose();
                rec.Path.Dispose();
            }
            catch { }

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
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

        [Description("Gets or Sets background color when the mouse pointer is over the control.")]
        [Category("Saa")]
        public Color HoverBackColor
        {
            get
            {
                return this.FlatAppearance.MouseOverBackColor;
            }
            set
            {
                this.FlatAppearance.MouseOverBackColor = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets background color when the control is clicked and yet not released.
        /// </summary>
        [Description("Gets or Sets background color when the control is clicked and yet not released.")]
        [Category("Saa")]
        public Color ClickBackColor
        {
            get
            {
                return this.FlatAppearance.MouseDownBackColor;
            }
            set
            {
                this.FlatAppearance.MouseDownBackColor = value;
                Invalidate();
            }
        }
    }
    /// <summary>
    /// Beautiful  and customizable saaButton.
    /// </summary>
    [Description("Beautiful  and customizable saaButton.")]
    [ToolboxBitmap(typeof(SaaButton), "icons.SaaButton_16.bmp")]
    [DefaultEvent("Click")]
    public class SaaButton : UserControl
    {
        string _text = "";
        bool ischanged = false;
        public SaaButton()
        {


            this.BackColor = SaaInternalColors.PrimaryColor;

            Radius.Change += Radius1_Change;
            DoubleBuffered = true;
            Size = new Size(130, 30);
          //  Value = this.Name;

            this.MouseEnter += SaaButton_MouseEnter;
            this.MouseLeave += SaaButton_MouseLeave;
            this.MouseDown += SaaButton_MouseDown;
            this.MouseUp += SaaButton_MouseUp;
        }


        private void SaaButton_MouseUp(object sender, MouseEventArgs e)
        {
            _isdown = false;
            Invalidate();
        }

        private void SaaButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isdown = true;
            Invalidate();
        }

        bool _ishover = false;
        bool _isdown = false;
        private void SaaButton_MouseLeave(object sender, EventArgs e)
        {
            _ishover = false;
            Invalidate();
        }

        private void SaaButton_MouseEnter(object sender, EventArgs e)
        {
            _ishover = true;
            Invalidate();
        }
        /// <summary>
        /// Creates a virtual click for the button. It is similar if the user has clicked the button.
        /// </summary>
        public void PerformClick()
        {
            this.OnClick(EventArgs.Empty);
        }
        private void Radius1_Change()
        {

            Invalidate();
        }
        bool _isfirst = true;
        private IComponentChangeService _changeService;

        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                _changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (_changeService != null)
                    _changeService.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
                base.Site = value;
                if (!DesignMode)
                    return;
                _changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (_changeService != null)
                    _changeService.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
            }
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs ce)
        {
            SaaButton aBtn = ce.Component as SaaButton;
            if (aBtn == null || !aBtn.DesignMode)
                return;
            if (((IComponent)ce.Component).Site == null || ce.Member == null || ce.Member.Name != "Text")
                return;
            // if (aBtn.Text == aBtn.Name)
            // aBtn.Text = aBtn.Name.Replace("SaaButton", "button");
            Value = this.Name;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            _text = _isfirst && string.IsNullOrEmpty(_text) ? this.Name : _text;
            _isfirst = false;

            // e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawPaint paint = new DrawPaint()
            {
                Options = new DrawPaintOptions()
                {
                    BackColor1 = _isdown ? _ClickColor1 : !_ishover ? _BackColor : _HoveColor1,
                    BackColor2 = _isdown ? _ClickColor2 : !_ishover ? _BackColor2 : _HoveColor2,
                    BackColorAngle = (int)_BackColorAngle,
                    BorderColor1 = _BorderColor,
                    BorderColor2 = _BorderColor2,
                    BorderColorAngle = _BorderColorAngle,
                    BorderThickness = _Border,
                    Radius = _Radius,
                    X = 1,
                    Y = 1,
                    Tranparency = _Transparence,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Width = this.Width - 3,
                    Height = this.Height - 3
                }
            };
            paint.PaintGradient(e.Graphics, this, false);
            using (Brush b = new SolidBrush(ForeColor))
            {
                var _x = this.Width / 2 - _text.GetSize(Font).Width / 2;
                var _y = this.Height / 2 - _text.GetSize(Font).Height / 2;
                e.Graphics.DrawString(_text, Font, b, _x + _tX, _y + _tY);
            }
            if (_icon != null)
            {
                e.Graphics.DrawImage(_icon, new RectangleF(_iX, _iY, _icSize.Width, _icSize.Height), new Rectangle(0, 0, _icon.Width, _icon.Height), GraphicsUnit.Pixel);
            }
            base.OnPaint(e);

        }
        Image _icon = null;
        /// <summary>
        /// Gets or Sets the icon of the control.
        /// </summary>
        [Description("Gets or Sets the icon of the control."), Category("Saa")]
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                Invalidate();
            }
        }
        Size _icSize = new Size(20, 20);
        /// <summary>
        /// Gets or Sets the size of the icon.
        /// </summary>
        [Description("Gets or Sets the size of the icon."), Category("Saa")]
        public Size IconSize
        {
            get { return _icSize; }
            set
            {
                _icSize = value;
                Invalidate();
            }
        }
        float _iX = 5;
        float _iY = 5;
        /// <summary>
        /// Gets or Sets in pixels, how far the icon is from the left side.
        /// </summary>
        [Description("Gets or Sets in pixels, how far the icon is from the left side."), Category("Saa")]
        public float IconOffsetX
        {
            get { return _iX; }
            set
            {
                _iX = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets in pixels, how far the icon is from top.
        /// </summary>
        [Description("Gets or Sets in pixels, how far the icon is from top."), Category("Saa")]
        public float IconOffsetY
        {
            get { return _iY; }
            set
            {
                _iY = value;
                Invalidate();
            }
        }
        float _tX, _tY = 0;
        /// <summary>
        /// Gets or Sets in pixels, how far the text is from the left side.
        /// </summary>
        [Description("Gets or Sets in pixels, how far the text is from the left side."), Category("Saa")]
        public float TextOffsetX
        {
            get { return _tX; }
            set
            {
                _tX = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets in pixels, how far the text is from top.
        /// </summary>
        [Description("Gets or Sets in pixels, how far the text is from top."), Category("Saa")]
        public float TextOffsetY
        {
            get { return _tY; }
            set
            {
                _tY = value;
                Invalidate();
            }
        }
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        /// <summary>
        /// Gets or Sets associated text with this control.
        /// </summary>
        [Description("Gets or Sets associated text with this control."), Category("Saa")]
        public string Value
        {
            get
            {
                return _text;
            }
            set
            {
                _isfirst = false;
                _text = value;
                Invalidate();
            }
        }
        Color _ClickColor1 = SaaInternalColors.DarkPrimary;
        /// <summary>
        /// Gets or Sets first Click Color of the LinearGradient. This is when mouse pointer is over the control and mouse button is pressed.
        /// </summary>
        [Description("Gets or Sets first Click Color of the LinearGradient. This is when mouse pointer is over the control and mouse button is pressed."), Category("Saa")]
        public Color ClickColor1
        {
            get
            {
                return _ClickColor1;
            }
            set
            {
                _ClickColor1 = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }
        Color _ClickColor2 = SaaInternalColors.LightPrimary;
        /// <summary>
        /// Gets or Sets second Click Color of the LinearGradient. This is when mouse pointer is over the control and mouse button is pressed.
        /// </summary>
        [Description("Gets or Sets second Click Color of the LinearGradient. This is when mouse pointer is over the control and mouse button is pressed."), Category("Saa")]
        public Color ClickColor2
        {
            get
            {
                return _ClickColor2;
            }
            set
            {
                _ClickColor2 = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }
        //----
        Color _HoveColor1 = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets first Hover Color of the LinearGradient. This is when mouse pointer is over the control.
        /// </summary>
        [Description("Gets or Sets first Hover Color of the LinearGradient. This is when mouse pointer is over the control."), Category("Saa")]
        public Color HoverColor1
        {
            get
            {
                return _HoveColor1;
            }
            set
            {
                _HoveColor1 = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }
        Color _HoveColor2 = SaaInternalColors.LightPrimary;
        /// <summary>
        /// Gets or Sets second Hover Color of the LinearGradient. This is when mouse pointer is over the control.
        /// </summary>
        [Description("Gets or Sets second Hover Color of the LinearGradient. This is when mouse pointer is over the control."), Category("Saa")]
        public Color HoverColor2
        {
            get
            {
                return _HoveColor2;
            }
            set
            {
                _HoveColor2 = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }

        Color _BackColor = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets first BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets first BackColor of the LinearGradient."), Category("Saa")]
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

        int _Transparence = 100;
        Radius _Radius = new Radius(2, 2, 2, 2);
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
        int _Border = 1;
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
        Color _BorderColor = SaaInternalColors.DarkPrimary;
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
        Color _BorderColor2 = SaaInternalColors.DarkPrimary;
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



        /// <summary>
        /// Gets or Sets whether to enable double buffering for this control
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
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

        Color _BackColor2 = SaaInternalColors.PrimaryColor;
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
