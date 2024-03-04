using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Shows glowing animations informing user that there is a process going on.
    /// </summary>
    [Description("Shows glowing animations informing user that there is a process going on.")]
    [ToolboxBitmap(typeof(SaaGlowing), "icons.SaaGlowing.bmp")]
    [DefaultEvent("Click")]
    public class SaaGlowing : Control
    {
        Timer _timer = new Timer();
        BackgroundWorker _bgWorker = new BackgroundWorker();
        public SaaGlowing()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            _thisHeight = this.Height;
            _thisWidth = this.Width;

            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        float x, y = 0;
        int alpha = 254;
        int _width, _height, _thisWidth, _thisHeight = 0;
        bool _AtFading = false;
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (Stop) return;
            if (!_AtFading)
            {
                if (_width < _thisWidth / 2)
                {
                    int _distance = _thisWidth / 2;
                    int _speed = GrowingSpeed >= _distance ? _distance : GrowingSpeed <= 0 ? 1 : GrowingSpeed;

                    _width += _distance / _speed;
                    y = x = _thisHeight / 2 - _width / 2;

                }
                else
                {
                    _AtFading = true;
                }
            }
            else
            {
                if (alpha > 12)
                {
                    alpha -= 10;
                }
                else
                {
                    _width = 0;
                    y = x = _thisHeight / 2;
                    _AtFading = false;
                    alpha = 254;
                }
            }
            Invalidate();
        }








        protected override void OnPaint(PaintEventArgs e)
        {

            _thisHeight = this.Height;
            _thisWidth = this.Width;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (ForceTransparence)
            {
                Transparenter tra = new Transparenter();
                tra.MakeTransparent(e.Graphics, this);
            }

            Brush brush = new SolidBrush(Color.FromArgb(alpha, Color));
            e.Graphics.FillEllipse(brush, x, y, _width, _width);
            // e.Graphics.DrawString("x:" + x + ",:y:" + y + "w:" + _width + ":h:" +_thisHeight , Font, brush, 0, 0);
            base.OnPaint(e);
            brush.Dispose();
        }
        Size _OldSize;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_OldSize != null)
            {
                if (_OldSize.Height != this.Size.Height)
                {
                    this.Width = this.Height;
                }
                else
                {
                    this.Height = this.Width;
                }
            }
            _OldSize = this.Size;
        }
        Color _color = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets the color of the glowing point.
        /// </summary>
        [Description("Gets or Sets the color of the glowing point.")]
        [Category("Saa")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets in milliseconds, the time it takes the glow to grow. The bigger the number the slower the growth.
        /// </summary>
        [Description("Gets or Sets in milliseconds, the time it takes the glow to grow. The bigger the number the slower the growth.")]
        [Category("Saa")]
        public int GrowingSpeed
        {
            get; set;
        } = 5;
        /// <summary>
        /// Gets or Sets whether the growing is stopped.
        /// </summary>
        [Description("Gets or Sets whether the growing is stopped.")]
        [Category("Saa")]
        public bool Stop
        {
            get; set;
        } = false;
        bool _forceTransparence = false;
        /// <summary>
        /// Gets or Sets whether the control will be forced to have opacity 0. PLEASE TURN OFF THIS OPTION, IT WILL HAVE CATASTROPHIC IMPACT ON THE PERFORMANCE.
        /// </summary>
        [Description("Gets or Sets whether the control will be forced to have opacity 0. PLEASE TURN OFF THIS OPTION, IT WILL HAVE CATASTROPHIC IMPACT ON THE PERFORMANCE.")]
        [Category("Saa")]
        public bool ForceTransparence
        {
            get
            {
                return _forceTransparence;
            }
            set
            {
                _forceTransparence = value;
                Invalidate();
            }
        }
    }
}
