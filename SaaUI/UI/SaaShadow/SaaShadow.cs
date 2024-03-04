using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Creates a customizable shadow behind any control.
    /// </summary>
    [Description("Creates a customizable shadow behind any control.")]
    [ToolboxBitmap(typeof(SaaShadow), "icons.SaaShadow.bmp")]
    [DefaultEvent("Click")]
    public class SaaShadow : Control
    {
        public SaaShadow()
        {

            Radius.Change += Radius1_Change;
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void Radius1_Change()
        {

            Invalidate();
        }
        bool isClearShadow = true;
        protected override void OnPaint(PaintEventArgs e)
        {


            var _Isradius = (Radius.TopLeft | Radius.TopRight | Radius.BottomRight | Radius.BottomLeft) > 0 ? true : false;
            Transparenter tra = new Transparenter();
            tra.MakeTransparent(e.Graphics, this);
            BorderPath rec = new BorderPath(0, 0, Width, Height, _Radius);
            if (_Control != null && !_Control.IsDisposed)
            {
                if (_AutoSet)
                {
                    rec.PathBorder.Dispose();
                    rec.Path.Dispose();
                    rec = ControlCast.GetControlPath(_Control, _Radius, _OffsetWidth, _OffsetHeight, _Isradius);
                }
            }

            using (PathGradientBrush _Brush = new PathGradientBrush(rec.Path))
            {

                _Brush.WrapMode = WrapMode.Clamp;
                ColorBlend _ColorBlend = new ColorBlend(3);
                _ColorBlend.Colors = new Color[] { _OuterColor, _InnerColor, _InnerColor };
                _ColorBlend.Positions = new float[] { 0f, (1.0f - (((float)_spread) / 100f)), 1 };
                _Brush.InterpolationColors = _ColorBlend;
                e.Graphics.FillPath(_Brush, rec.Path);
            }

            try
            {
                rec.PathBorder.Dispose();
                rec.Path.Dispose();
            }
            catch { }
            if (_Control != null && !_Control.IsDisposed && _Control.Parent != null)
            {

                _Control.Parent.Controls.Add(this);
                int ind = _Control.Parent.Controls.GetChildIndex(_Control);
                _Control.Parent.Controls.SetChildIndex(this, ind + 1);
                this.Location = new Point(_Control.Location.X + _OffsetX, _Control.Location.Y + _OffsetY);
                this.Size = new Size(_Control.Width + _OffsetWidth + 5, _Control.Size.Height + _OffsetHeight + 5);

            }
            base.OnPaint(e);
        }

        int _spread = 85;
        /// <summary>
        /// Gets or Sets shadow spread of the control.
        /// </summary>
        [Description("Gets or Sets shadow spread of the control.")]
        [Category("Saa")]
        public int Spread
        {
            get
            {
                return _spread;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _spread = value;
                    Invalidate();
                }
                else
                {
                    throw new Exception("Value must fall between 0 and 100");
                }
            }
        }

        bool _AutoSet = true;
        /// <summary>
        /// Gets or Sets whether this shadow will take properties of the control set to.  Custom properties may need to manually set.
        /// </summary>
        [Description("Gets or Sets whether this shadow will take properties of the control set to.  Custom properties may need to manually set.")]
        [Category("Saa")]
        public bool AutoSet
        {
            get
            {
                return _AutoSet;
            }
            set
            {
                _AutoSet = value;
                Invalidate();
            }
        }
        Color _OuterColor = Color.Transparent;
        /// <summary>
        /// Gets or Sets outermost color of the shadow.
        /// </summary>
        [Description("Gets or Sets outermost color of the shadow.")]
        [Category("Saa")]
        public Color OuterColor
        {
            get
            {
                return _OuterColor;
            }
            set
            {
                _OuterColor = value;
                Invalidate();
            }
        }



        Color _InnerColor = Color.DimGray;
        /// <summary>
        /// Gets or Sets inner color of the shadow.
        /// </summary>
        [Description("Gets or Sets inner color of the shadow.")]
        [Category("Saa")]
        public Color InnerColor
        {
            get
            {
                return _InnerColor;
            }
            set
            {
                _InnerColor = value;
                Invalidate();
            }
        }

        int _OffsetX = 4;
        /// <summary>
        /// Gets or Sets how far the shadow will be moved on X-axis.
        /// </summary>
        [Description("Gets or Sets how far the shadow will be moved on X-axis.")]
        [Category("Saa")]
        public int OffsetX
        {
            get
            {
                return _OffsetX;
            }
            set
            {
                _OffsetX = value;
                Invalidate();
            }
        }
        int _OffsetY = 4;
        /// <summary>
        /// Gets or Sets how far the shadow will be moved on Y-axis.
        /// </summary>
        [Description("Gets or Sets how far the shadow will be moved on Y-axis.")]
        [Category("Saa")]
        public int OffsetY
        {
            get
            {
                return _OffsetY;
            }
            set
            {
                _OffsetY = value;
                Invalidate();
            }
        }

        int _OffsetHeight = 2;
        /// <summary>
        /// Gets or Sets extra height to be added to the control.
        /// </summary>
        [Description("Gets or Sets extra height to be added to the control.")]
        [Category("Saa")]
        public int OffsetHeight
        {
            get
            {
                return _OffsetHeight;
            }
            set
            {
                _OffsetHeight = value;
                Invalidate();
            }
        }

        int _OffsetWidth = 2;
        /// <summary>
        /// Gets or Sets extra width to be added to the control.
        /// </summary>
        [Description("Gets or Sets extra width to be added to the control.")]
        [Category("Saa")]
        public int OffsetWidth
        {
            get
            {
                return _OffsetWidth;
            }
            set
            {
                _OffsetWidth = value;
                Invalidate();
            }
        }

        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets the border radius of the control.
        /// </summary>
        [Description("Gets or Sets the border radius of the control. If you want the shadow to take the radius of the owner then set this radius to 0."), Category("Saa")]
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

        Control _Control;
        /// <summary>
        /// Gets or Sets the control that will own this shadow.
        /// </summary>
        [Description("Gets or Sets the control that will own this shadow.")]
        [Category("Saa")]
        public Control Control
        {
            get
            {
                return _Control;
            }
            set
            {


                if (value != null && !value.IsDisposed)
                {
                    if (value.GetType() != typeof(Form) && value.GetType() != typeof(SaaShadow))
                    {
                        _Control = value;
                        _Control.Paint -= _Control_Paint;
                        _Control.Paint += _Control_Paint;

                        _Control.Disposed -= _Control_Disposed;
                        _Control.Disposed += _Control_Disposed;
                    }
                }
                else if (value == null)
                {
                    _Control = null;
                }
                Invalidate();
            }
        }

        private void _Control_Move(object sender, EventArgs e)
        {
            Invalidate();
        }

        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        private void _Control_Disposed(object sender, EventArgs e)
        {
            this._Control = null;
            Invalidate();
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override string Text { get => base.Text; set => base.Text = value; }
        private void _Control_Paint(object sender, PaintEventArgs e)
        {

            Invalidate();
        }
        private const int WS_EX_COMPOSITED = 0x02000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }
    }
}
