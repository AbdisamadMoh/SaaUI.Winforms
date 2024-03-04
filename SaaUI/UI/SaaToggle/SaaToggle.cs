using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable SaaToggle.
    /// </summary>
    [Description("Beautiful  and customizable SaaToggle.")]
    [ToolboxBitmap(typeof(SaaToggle), "icons.SaaToggle.bmp")]
    [DefaultEvent("CheckChanged")]
    public class SaaToggle : Control
    {
        /// <summary>
        /// Fires when Checked status is changed.
        /// </summary>
        [Description("Fires when Checked status is changed."), Category("Saa")]
        public delegate void OnCheckChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when Checked status is changed.
        /// </summary>
        [Description("Fires when Checked status is changed."), Category("Saa")]
        public event OnCheckChanged CheckChanged;
        public SaaToggle()
        {

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.SupportsTransparentBackColor, true);
            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;
            this.Click += SaaToggle_Click;
            this.Size = new Size(88, 30);
            _iOsDotwidth = this.x = this.Width - 1 - this.Height - _iOS.OffSize.Height;
            _iOsDotheight = this.Height - _iOS.OffSize.Height;

            iOSStyle.OffSizeChange += IOSStyle_OffSizeChange;
            FlatStyle.OffSizeChange += IOSStyle_OffSizeChange;
            Colors.Change += Radius_Change;
            iOSStyle.Change += Radius_Change;
            FlatStyle.Change += Radius_Change;
            SkewedStyle.Change += Radius_Change;
            SkewedStyle.OffSizeChange += IOSStyle_OffSizeChange;
        }



        EventArgs _clickEvent = EventArgs.Empty;
        private void SaaToggle_Click(object sender, EventArgs e)
        {
            _clickEvent = e;
            switch (MouseClicks)
            {
                case CheckBoxMouseClick.LeftClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Left)
                        {

                            this.Checked = !this.Checked;
                        }
                        break;
                    }
                case CheckBoxMouseClick.RightClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Right)
                        {
                            this.Checked = !this.Checked;
                        }
                        break;
                    }
                case CheckBoxMouseClick.AnyClick:
                    {
                        this.Checked = !this.Checked;
                        break;
                    }
            }

        }
        private void IOSStyle_OffSizeChange(Size OldSize, Size NewSize)
        {
            this.Size = this.Size - OldSize;
            this.Size = this.Size + NewSize;
        }



        int x, _iOsDotwidth, _iOsDotheight, _MainHeight, _MainWidth;
        int DotAnimWidth = 0;
        bool SkewReset = false;
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_ToggleStyle == ToggleStyle.iOS)
            {
                int distance = GetiOSSize().Width - GetiOSDotSize().Width;
                int _speed = _iOS.Speed >= distance ? distance : _iOS.Speed <= 0 ? 1 : _iOS.Speed;
                if (!_Checked)
                {
                    if (x > 0 + _iOS.OffHeadOffset.X)
                    {
                        x -= distance / _speed;
                        _iOsDotwidth = _iOsDotheight + _iOsDotheight / 2;
                    }
                    else
                    {
                        _timer.Stop();
                        _iOsDotwidth = this.Height - _iOS.OffSize.Height + _iOS.HeadOffSize.Height;
                    }
                }
                else if (_Checked)
                {
                    if (x < GetiOSSize().Width - GetiOSDotSize().Width + _iOS.OnHeadOffset.X)
                    {
                        x += distance / _speed;
                        _iOsDotwidth = _iOsDotheight + _iOsDotheight / 2;
                    }
                    else
                    {
                        _timer.Stop();
                        _iOsDotwidth = this.Height - _iOS.OffSize.Height + _iOS.HeadOffSize.Height;
                    }
                }
            }
            else if (_ToggleStyle == ToggleStyle.Flat)
            {
                //Flat Toggle

                int distance = GetiOSSize().Width - GetiOSDotSize().Width;
                int _speed = _Flat.Speed >= distance ? distance : _Flat.Speed <= 0 ? 1 : _Flat.Speed;
                if (!_Checked)
                {
                    if (x > 0 + _Flat.OffHeadOffset.X)
                    {
                        x -= distance / _speed;
                    }
                    else
                    {
                        _timer.Stop();
                    }
                }
                else if (_Checked)
                {

                    if (x < GetiOSSize().Width - GetiOSDotSize().Width + _Flat.OnHeadOffset.X)
                    {
                        x += distance / _speed;
                    }
                    else
                    {
                        _timer.Stop();
                    }
                }
            }

            else if (_ToggleStyle == ToggleStyle.Skewed)
            {
                //Skewed Toggle
                var _distance = _SkewWidth;
                float _speed = _Skewed.Speed >= _distance ? _distance : _Skewed.Speed <= 0 ? 1 : _Skewed.Speed;

                if (_Checked)
                {
                    if (!SkewReset)
                    {
                        _TextX = _SkewXStart;
                        SkewReset = true;
                    }
                    if (_TextX < _SkewTargetX)
                    {
                        _TextX += _distance / _speed;
                    }
                    else
                    {
                        _timer.Stop();
                    }
                }
                else
                {
                    if (!SkewReset)
                    {
                        _TextX = _SkewXEnd;
                        SkewReset = true;
                    }
                    if (_TextX > _SkewTargetX)
                    {
                        _TextX -= _distance / _speed;
                    }
                    else
                    {

                        _timer.Stop();
                    }
                }
            }
            Invalidate();
        }

        private void Radius_Change()
        {
            Invalidate(true);
        }
        Timer _timer = new Timer();
        protected override void OnPaint(PaintEventArgs e)
        {
            var ctx = e.Graphics;
            ctx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Transparenter tra = new Transparenter();
            tra.MakeTransparent(ctx, this);


            switch (_ToggleStyle)
            {
                case ToggleStyle.iOS:
                    {
                        CreateiOSTogggle(ctx);
                        break;
                    }
                case ToggleStyle.Flat:
                    {
                        CreateFlatTogggle(ctx);
                        break;
                    }
                case ToggleStyle.Skewed:
                    {
                        CreateSkewedTogggle(ctx);
                        break;
                    }
            }


            base.OnPaint(e);
        }

        //-------------------Create iOS Toggle----------------------------
        private void CreateiOSTogggle(Graphics ctx)
        {
            Radius r = _iOS.RadiusStyle == ToggleRadius.Round ? new Radius((this.Height - _iOS.OffSize.Height) / 2, (this.Height - _iOS.OffSize.Height) / 2, (this.Height - _iOS.OffSize.Height) / 2, (this.Height - _iOS.OffSize.Height) / 2) : _iOS.Radius;

            var boxF = new BorderPath(_iOS.Offset.X, _iOS.Offset.Y, this.Width - _iOS.OffSize.Width - 1, this.Height - _iOS.OffSize.Height, r);


            //  this.Region = new Region(boxF.Path);
            if (!_timer.Enabled)
            {
                _iOsDotwidth = this.Height - _iOS.OffSize.Height + _iOS.HeadOffSize.Width;
                _iOsDotheight = this.Height - _iOS.OffSize.Height + _iOS.HeadOffSize.Height;
            }


            if (_Checked && !_timer.Enabled)
            {
                x = GetiOSSize().Width - GetiOSDotSize().Width + _iOS.OnHeadOffset.X;
            }
            if (!_Checked && !_timer.Enabled)
            {
                x = 0 + _iOS.OffHeadOffset.X;
            }

            int headWidth = GetiOSDotSize().Width;
            int headHeight = GetiOSDotSize().Height;
            int offX = _Checked ? _iOS.OnHeadOffset.X : _iOS.OffHeadOffset.X;
            int offY = _Checked ? _iOS.OnHeadOffset.Y : _iOS.OffHeadOffset.Y;
            Radius r2 = _iOS.RadiusStyle == ToggleRadius.Round ? new Radius(headHeight / 2, headHeight / 2, headHeight / 2, headHeight / 2) : _iOS.HeadRadius;
            var Dot = new BorderPath(x + offX, (1 + offY), (_timer.Enabled ? headWidth + headWidth / 2 : headWidth - 2), headHeight - 2, r2);


            if (_Checked)
            {
                SolidBrush bc = new SolidBrush(_Colors.OnBackColor); //On
                ctx.FillPath(bc, boxF.Path);

                SolidBrush dc = new SolidBrush(_Colors.OnHeadColor);//On
                ctx.FillPath(dc, Dot.Path);

                bc.Dispose();
                dc.Dispose();
            }
            else
            {
                SolidBrush bc = new SolidBrush(_Colors.OffBackColor); //Off
                ctx.FillPath(bc, boxF.Path);

                SolidBrush dc = new SolidBrush(_Colors.OffHeadColor);//Off
                ctx.FillPath(dc, Dot.Path);

                bc.Dispose();
                dc.Dispose();

            }

            try
            {
                boxF.Path.Dispose();
                boxF.PathBorder.Dispose();
                Dot.Path.Dispose();
                Dot.PathBorder.Dispose();
            }
            catch { }
        }

        //-------------------Create Flat Toggle---------------------------

        private void CreateFlatTogggle(Graphics ctx)
        {
            var h = ((this.Height - _Flat.OffSize.Height - 5) / 2);
            Radius r = _Flat.RadiusStyle == ToggleRadius.Round ? new Radius(h, h, h, h) : _Flat.Radius;

            var boxF = new BorderPath(_Flat.Offset.X + 2, _Flat.Offset.Y + 2, this.Width - _Flat.OffSize.Width - 5, this.Height - 5 - _Flat.OffSize.Height, r);





            int headWidth = (int)boxF.RectangleF.Height + _Flat.HeadOffSize.Width; //GetiOSDotSize().Width;
            int headHeight = (int)boxF.RectangleF.Height - 2 - _Flat.Border * 2 + _Flat.HeadOffSize.Height;// GetiOSDotSize().Height;

            if (_Checked && !_timer.Enabled)
            {
                x = (int)boxF.RectangleF.X + (int)boxF.RectangleF.Width - (headWidth + headWidth / 3) - _Flat.Border + _Flat.OnHeadOffset.X; //GetiOSSize().Width - GetiOSDotSize().Width + _Flat.OnHeadOffset.X;
            }
            if (!_Checked && !_timer.Enabled)
            {
                x = (int)boxF.RectangleF.X + _Flat.OffHeadOffset.X + _Flat.Border;
            }
            int y = ((int)boxF.RectangleF.Y + (int)boxF.RectangleF.Height / 2) - headHeight / 2;

            int offX = _Checked ? _Flat.OnHeadOffset.X : _Flat.OffHeadOffset.X;
            int offY = _Checked ? _Flat.OnHeadOffset.Y : _Flat.OffHeadOffset.Y;
            Radius r2 = _Flat.RadiusStyle == ToggleRadius.Round ? new Radius(headHeight / 2, headHeight / 2, headHeight / 2, headHeight / 2) : _Flat.HeadRadius;
            var Dot = new BorderPath(x + offX, (y + offY), headWidth + headWidth / 3, headHeight, r2);


            if (_Checked)
            {

                Pen bc = new Pen(_Colors.OnBackColor, _Flat.Border); //Off
                if (_Flat.Border > 0)
                {
                    ctx.DrawPath(bc, boxF.Path);
                }
                SolidBrush dc = new SolidBrush(_Flat.HeadColorType == ToggleFlatHeadColorType.HeadColor ? _Colors.OnHeadColor : _Colors.OnBackColor);//On
                ctx.FillPath(dc, Dot.Path);

                bc.Dispose();
                dc.Dispose();
            }
            else
            {
                Pen bc = new Pen(_Colors.OffBackColor, _Flat.Border); //Off
                if (_Flat.Border > 0)
                {
                    ctx.DrawPath(bc, boxF.Path);
                };

                SolidBrush dc = new SolidBrush(_Flat.HeadColorType == ToggleFlatHeadColorType.HeadColor ? _Colors.OffHeadColor : _Colors.OffBackColor);//Off
                ctx.FillPath(dc, Dot.Path);

                bc.Dispose();
                dc.Dispose();

            }

            try
            {
                // boxF.Path.Dispose();
                // boxF.PathBorder.Dispose();
                // Dot.Path.Dispose();
                // Dot.PathBorder.Dispose();
                boxF.Dispose();
                Dot.Dispose();
            }
            catch { }
        }

        //-------------------Create Skewed Toggle-------------------------

        float _TextHeight, _TextWidth, _TextX, _TextY, _SkewWidth, _SkewHeight, _SkewXStart, _SkewXEnd, _SkewTargetX = 0;
        Point _LeftXY1, _LeftXY2, _RightXY1, _RightXY2 = new Point();
        private void CreateSkewedTogggle(Graphics ctx)
        {
            int offx = _Skewed.OffSet.X;
            int offy = _Skewed.OffSet.Y;
            int offH = _Skewed.SizeOffSet.Height;
            int offW = _Skewed.SizeOffSet.Width;
            Point[] _top = new Point[]
            {
                new Point(offW+15 + _Skewed.Coordinates.TopLeft.X+offx, 0 + _Skewed.Coordinates.TopLeft.Y+offy),
                new Point(offW+this.Width - 5 + _Skewed.Coordinates.TopRight.X+offx, 0 + _Skewed.Coordinates.TopRight.Y+offy)
            };
            Point[] _right = new Point[]
           {
                new Point(offW+this.Width-5 + _Skewed.Coordinates.TopRight.X+offx, 0 + _Skewed.Coordinates.TopRight.Y+offy),
                new Point(offW+this.Width-15+ _Skewed.Coordinates.BottomRight.X+offx,this.Height-2+ _Skewed.Coordinates.BottomRight.Y+offy+offH)
           };
            Point[] _bottom = new Point[]
          {
                new Point(offW+this.Width - 15+ _Skewed.Coordinates.BottomRight.X+offx, this.Height-2+ _Skewed.Coordinates.BottomRight.Y+offy+offH),
                new Point(offW+15+ _Skewed.Coordinates.BottomLeft.X+offx, this.Height - 2+ _Skewed.Coordinates.BottomLeft.Y+offy+offH)
          };
            Point[] _left = new Point[]
        {
                new Point(5+ _Skewed.Coordinates.BottomLeft.X+offx, this.Height-2+ _Skewed.Coordinates.BottomLeft.Y+offy+offH),
                new Point(15+ _Skewed.Coordinates.TopLeft.X+offx, 0+ _Skewed.Coordinates.TopLeft.Y+offy)
        };


            using (GraphicsPath g = new GraphicsPath())
            {

                g.AddLines(_top);
                g.AddLines(_right);
                g.AddLines(_bottom);
                g.AddLines(_left);
                g.CloseAllFigures();

                Brush bc = new SolidBrush(_Checked ? _Colors.OnBackColor : _Colors.OffBackColor);
                ctx.FillPath(bc, g);

                string s = _Checked ? _Skewed.OnText : _Skewed.OffText;
                var textSize = ctx.MeasureString(s, (_Checked ? _Skewed.OnFont : _Skewed.OffFont));

                _TextHeight = textSize.Height;
                _TextWidth = textSize.Width;

                var textX = _SkewTargetX = (_top[1].X + _Skewed.OffSet.X) / 2 - textSize.Width / 2;
                var textY = (_left[0].Y + _Skewed.OffSet.Y) / 2 - textSize.Height / 2;

                _LeftXY1 = _left[0];
                _LeftXY2 = _left[1];
                _RightXY1 = _right[0];
                _RightXY2 = _right[1];
                if (_top[1].X > _bottom[0].X)
                {
                    _SkewWidth = _top[1].X;

                    _SkewXEnd = _bottom[0].X - _TextWidth;

                    // _SkewXStart = _bottom[1].X;
                }
                else
                {
                    _SkewWidth = _bottom[0].X;
                    _SkewXEnd = _top[1].X - _TextWidth;

                    // _SkewXStart = _top[1].X;
                }
                //------------
                if (_top[0].X > _bottom[1].X)
                {
                    _SkewXStart = _top[0].X + _Skewed.OffSet.X;
                }
                else
                {
                    _SkewXStart = _bottom[1].X + _Skewed.OffSet.X;
                }

                //-------------
                if (_right[1].X > _left[0].X)
                {
                    _SkewHeight = _right[1].X;
                }
                else
                {
                    _SkewHeight = _left[0].X;
                }

                if (_Checked && !_timer.Enabled)
                {
                    _TextX = textX;
                    _TextY = textY;
                }
                else if (!_Checked && !_timer.Enabled)
                {
                    _TextX = textX;
                    _TextY = textY;

                }
                Brush brush = new SolidBrush(_Checked ? _Colors.OnForeColor : _Colors.OffForeColor);
                ctx.DrawString(s, (_Checked ? _Skewed.OnFont : _Skewed.OffFont), brush, _TextX, _TextY);

                brush.Dispose();
                bc.Dispose();
            }
        }
        
        private Size GetFlatSize(RectangleF rec)
        {
            return new Size((int)rec.Size.Width, (int)rec.Height);
        }
        private Size GetFlatDotSize(RectangleF rec)
        {
            return (new Size(GetFlatSize(rec).Height, GetFlatSize(rec).Height)) + _Flat.HeadOffSize;
        }
        private Size GetiOSSize()
        {
            return this.Size - _iOS.OffSize;
        }
        private Size GetiOSDotSize()
        {
            return (new Size(GetiOSSize().Height, GetiOSSize().Height)) + _iOS.HeadOffSize;
        }

        /// <summary>
        /// Gets or Sets which mouse button does the control accepts.
        /// </summary>
        [Description("Gets or Sets which mouse button does the control accepts."), Category("Saa")]
        public CheckBoxMouseClick MouseClicks { get; set; } = CheckBoxMouseClick.LeftClick;

        ToggleStyle _ToggleStyle = ToggleStyle.iOS;
        /// <summary>
        /// Gets or Sets Toggle style. You can redesign each style with its respective design options e.g. iOS will take values in iOSStyle options.
        /// </summary>
        [Description("Gets or Sets Toggle style. You can redesign each style with its respective design options e.g. iOS will take values in iOSStyle options."), Category("Saa")]
        public ToggleStyle ToggleStyle
        {
            get
            {
                return _ToggleStyle;
            }
            set
            {
                _ToggleStyle = value;
                Invalidate();
            }
        }

        Skewed _Skewed = new Skewed();
        /// <summary>
        /// Gets or Sets options related to Skewed Style.
        /// </summary>
        [Description("Gets or Sets options related to Skewed Style."), Category("Saa")]
        public Skewed SkewedStyle
        {
            get
            {
                return _Skewed;
            }
            set
            {
                _Skewed = value;
                Invalidate();
            }
        }

        iOS _iOS = new iOS();
        /// <summary>
        /// Gets or Sets options related to iOS Style.
        /// </summary>
        [Description("Gets or Sets options related to iOS Style."), Category("Saa")]
        public iOS iOSStyle
        {
            get
            {
                return _iOS;
            }
            set
            {
                _iOS = value;
                Invalidate();
            }
        }

        Flat _Flat = new Flat();
        /// <summary>
        /// Gets or Sets options related to Flat Style.
        /// </summary>
        [Description("Gets or Sets options related to Flat Style."), Category("Saa")]
        public Flat FlatStyle
        {
            get
            {
                return _Flat;
            }
            set
            {
                _Flat = value;
                Invalidate();
            }
        }
        SaaToggleColors _Colors = new SaaToggleColors();
        /// <summary>
        /// Gets or Sets color options.
        /// </summary>
        [Description("Gets or Sets color options"), Category("Saa")]
        public SaaToggleColors Colors
        {
            get
            {
                return _Colors;
            }
            set
            {
                _Colors = value;
                Invalidate();
            }
        }


        bool _Checked = true;
        /// <summary>
        /// Gets or Sets whether the toggle is checked.
        /// </summary>
        [Description("Gets or Sets whether the toggle is checked."), Category("Saa")]
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                SkewReset = false;
                CheckChanged?.Invoke(this, _clickEvent);
                _clickEvent = EventArgs.Empty;
                _timer.Start();

            }
        }



    }
}
