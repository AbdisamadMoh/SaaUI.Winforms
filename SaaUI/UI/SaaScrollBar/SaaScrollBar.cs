using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Customizable scrollbar with binding option.
    /// </summary>
    [Description("Customizable scrollbar with binding option.")]
    [ToolboxBitmap(typeof(SaaScrollBar), "icons.SaaScrollBar.bmp")]
    [DefaultEvent("ScrollChanged")]
    public partial class SaaScrollBar : SaaBaseControl
    {
        /// <summary>
        /// Fires when the <see cref="Value"/> of the ScrollBar is changed
        /// </summary>
        /// <param name="sender">object of type <see cref="SaaScrollBar"/></param>
        /// <param name="e"></param>
        public delegate void OnValueChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when the <see cref="Value"/> of the ScrollBar is changed.
        /// </summary>
        [Description("Fires when the Value of the ScrollBar is changed."), Category("Saa")]
        public event OnValueChanged ScrollChanged;

        /// <summary>
        /// Fires when the control owning this scrollbar needs scrollbars to be shown (becomes scrollable).
        /// <br/> Use "VerticalScrollBarNeeded" and "HorizontalScrollBarNeeded" properties to know which scrollbar is needed
        /// </summary>
        /// <param name="sender">Control that is associated with this scrollbar<see cref="Control"/></param>
        public delegate void OnScrollBarNeeded(object sender);
        /// <summary>
        /// Fires when the control owning this scrollbar needs scrollbars to be shown (becomes scrollable).
        /// <br/> Use "VerticalScrollBarNeeded" and "HorizontalScrollBarNeeded" properties to know which scrollbar is needed
        /// </summary>
        [Description("Fires when the control owning this scrollbar needs scrollbars to be shown (becomes scrollable).\nUse \"VerticalScrollBarNeeded\" and \"HorizontalScrollBarNeeded\" properties to know which scrollbar is needed"), Category("Saa")]
        public event OnScrollBarNeeded ScrollBarNeeded;

        Timer _Updater = new Timer();
        public SaaScrollBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            base.Size = new Size(10, 200);
            base.BackColor = Color.Transparent;
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
            this.ScrollChanged += SaaScrollBar_ScrollChanged;
           
            Timer _t = new Timer();
            _t.Interval = 500;
            _t.Tick += (object sender, EventArgs e) =>
             {
               //  SetScrollToControl();
                 _t.Stop();
             };
            _t.Start();

            _Updater.Interval = 500;
            _Updater.Tick += (object sender, EventArgs e) =>
            {
                ScrollNeedUpdater();
                CheckControlSize();
            };
            _Updater.Start();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!IsArrowAllowed)
                return;

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                this.Value += Change;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                this.Value -= Change;
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!_mouseWheelScroll) return;
            if (e.Delta < 0)
            {
                Value += Change;
            }
            else
            {
                Value -= Change;
            }
        }
        private void _control_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_mouseWheelScroll) return;
            if (!Vertical) return;
            if (e.Delta < 0)
            {
                Value += Change;
            }
            else
            {
                Value -= Change;
            }
        }
        private void SaaScrollBar_ScrollChanged(object sender, EventArgs e)
        {
            if (_vertical)
            {
                if (_control != null)
                {
                    var hor = SaascrollBarRegisterer.GetHorScrollBar(_control);
                    int val = _control.HorizontalScroll.Value;
                    if (hor != null)
                    {
                        val = hor.Value;
                    }
                     _control.AutoScrollPosition = new Point(val, this.Value);

                }
            }
            else
            {
                if (_control != null)
                {
                    var ver = SaascrollBarRegisterer.GetVerScrollBar(_control);
                    int val = _control.VerticalScroll.Value;
                    if (ver != null)
                    {
                        val = ver.Value;
                    }
                    _control.AutoScrollPosition = new Point(this.Value, val);
                }
            }
        }

        Timer _timer = new Timer();
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (isemptyheld && !isThumb(this.InnerMouseLocation()))
            {
                _timer.Interval = ChangeInterval;
                DoChange();
            }
            else
            {
                _timer.Stop();
                
            }
        }

       

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Calculate(false);
            DrawThumb(e.Graphics);
            base.OnPaint(e);

        }
        float scrollY = 0;
        float scrollX = 0;
        bool isheld = false;
        bool isemptyheld = false;
        bool isactive = false;
        bool isheadactive = false;
        int _h = 0;
        int _w = 0;
        int thumbHeight = 17;
        int position = 0;
        float valueRatio = 1;
        const int thumbDefHeight = 17;
        const int thumbMinheigt = 5;
        private void Calculate(bool _isY = true)
        {
            var _tw = this.Width;
            var _th = this.Height;


            if (_vertical)
            {
                if (_tw > _th)
                {
                    this.Size = new Size(_th, _tw);
                }
            }
            else
            {
                if (_tw < _th)
                {
                    this.Size = new Size(_th, _tw);
                }
            }

            var _ch = this.Height;
            var _cw = this.Width;
            int _range = (Maximum - Minimum);
            if (_vertical)
            {
                if (_range > _ch)
                {
                    thumbHeight = thumbDefHeight;

                }
                else
                {
                    thumbHeight = _ch - _range;
                    if (thumbHeight < thumbDefHeight)
                    {
                        thumbHeight = thumbDefHeight;
                    }

                }
            }
            else
            {
                if (_range > _cw)
                {
                    thumbHeight = thumbDefHeight;

                }
                else
                {
                    thumbHeight = _cw - _range;
                    if (thumbHeight < thumbDefHeight)
                    {
                        thumbHeight = thumbDefHeight;
                    }

                }
            }
            if (_isY)
            {
                if (_vertical)
                {
                    valueRatio = (float)(_ch - thumbHeight) / (float)(Maximum - Minimum);
                    scrollY = ((float)_value * valueRatio) - ((float)Minimum * valueRatio);
                }
                else
                {
                    valueRatio = (float)(_cw - thumbHeight) / (float)(Maximum - Minimum);
                    scrollX = ((float)_value * valueRatio) - ((float)Minimum * valueRatio);
                }
            }

           
        }
        private void DoChange()
        {
            var position = this.InnerMouseLocation();
            if (_vertical)
            {
                if (position.Y < scrollY)
                {
                    Value -= Change;
                }
                else if (position.Y > scrollY)
                {
                    Value += Change;
                }
            }
            else
            {
                if (position.X < scrollX)
                {
                    Value -= Change;
                }
                else if (position.X > scrollX)
                {
                    Value += Change;
                }
            }
        }
        internal void SetScrollToControl()
        {

            if (_control == null) return;
            SaascrollBarRegisterer.AddUpdate(_control, this);
            var vm = _control.PreferredSize.Height - _control.ClientSize.Height;
            var hm =_control.PreferredSize.Width - _control.ClientSize.Width;
           // _control.AutoScroll = false;
           // _control.VerticalScroll.Maximum = 0;
           //_control.HorizontalScroll.Maximum = 0;
           // _control.AutoScroll = true;
            // _control.AutoScroll = !_control.AutoScroll;
            // _control.AutoScroll = !_control.AutoScroll;
            if (_vertical)
            {
                if (vm <= this.Minimum)
                {
                    vm = this.Minimum+1;
                }
                this.Maximum = vm;//_control.VerticalScroll.Maximum + 1 - _control.VerticalScroll.LargeChange;
               this.Minimum = _control.VerticalScroll.Minimum;
                this.Value = _control.VerticalScroll.Value;
            }
            else
            {
                if (hm <= this.Minimum)
                {
                    hm = this.Minimum+1;
                }
                this.Maximum = hm; //_control.HorizontalScroll.Maximum + 1 - _control.HorizontalScroll.LargeChange; ;
                this.Minimum = _control.HorizontalScroll.Minimum;
                this.Value = _control.HorizontalScroll.Value;
            }
            _control.Scroll -= _control_Scroll;
            _control.Scroll += _control_Scroll;
            _control.Invalidated -= _control_Invalidated;
            _control.Invalidated += _control_Invalidated;
            _control.MouseWheel -= _control_MouseWheel;
            _control.MouseWheel += _control_MouseWheel;
            _control.Resize -= _control_Resize;
            _control.Resize += _control_Resize;
            Calculate(false);
            Invalidate();
           
        }

        private void _control_Resize(object sender, EventArgs e)
        {
            try
            {
                SetScrollToControl();
            }
            catch { }
        }

        private void _control_Invalidated(object sender, InvalidateEventArgs e)
        {
            try
            {
                SetScrollToControl();
            }
            catch { }
        }

        private void _control_Scroll(object sender, ScrollEventArgs e)
        {
            if (_control == null) return;
            SetScrollToControl();
        }
        Size _OldPrefSize = new Size();
        private void CheckControlSize()
        {
            if (_control == null) return;
            if(_control.PreferredSize != _OldPrefSize)
            {
                _OldPrefSize = _control.PreferredSize;
                try
                {
                    SetScrollToControl();
                }
                catch { }
            }
        }
        private void RemovePrevControl()
        {
            if (_control != null)
            {
                _control.Scroll -= _control_Scroll;
                _control.Invalidated -= _control_Invalidated;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetScrollToControl();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {

            base.OnMouseMove(e);
            if (!isheld)
            {
                if (isThumb(e.Location))
                {
                    isactive = false;
                    isheadactive = true;
                }
                else
                {
                    isactive = true;
                    isheadactive = false;
                }
                Invalidate();
                return;
            }
            if (_vertical)
            {
                var _y = (e.Location.Y - _h);
                _y = _y > 0 ? _y : 0;
                _y = (_y + thumbHeight) >= this.Height ? this.Height - (thumbHeight) : _y;
                scrollY = _y;
            }
            else
            {
                var _x = (e.Location.X - _w);
                _x = _x > 0 ? _x : 0;
                _x = (_x + thumbHeight) >= this.Width ? this.Width - (thumbHeight) : _x;
                scrollX = _x;
            }
            Invalidate();
            FireValueChanged();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right) return;
            if (_vertical)
            {
                if (e.Location.Y > scrollY && e.Location.Y < scrollY + thumbHeight)
                {
                    _h = e.Location.Y - (int)scrollY;
                    isheld = true;
                    isemptyheld = false;
                }
                else
                {
                    isheld = false;
                    isemptyheld = true;
                    DoChange();
                    _timer.Interval = 500;
                    _timer.Start();
                }
            }
            else
            {
                if (e.Location.X > scrollX && e.Location.X < scrollX + thumbHeight)
                {
                    _w = e.Location.X - (int)scrollX;
                    isheld = true;
                    isemptyheld = false;
                }
                else
                {
                    isheld = false;
                    isemptyheld = true;
                    DoChange();
                    _timer.Interval = 500;
                    _timer.Start();
                }
            }

            Invalidate();
        }
        private bool isThumb(Point e)
        {
            var ret = false;
            if (_vertical)
            {
                if (e.Y > scrollY && e.Y < scrollY + thumbHeight)
                {
                    ret = true;
                }
            }
            else
            {
                if (e.X > scrollX && e.X < scrollX + thumbHeight)
                {
                    ret = true;
                }
            }
            return ret;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {

            isheld = false;
            isemptyheld = false;
            base.OnMouseUp(e);
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (isThumb(this.InnerMouseLocation()))
            {
                isheadactive = true;
                isactive = false;
            }
            else
            {
                isactive = true;
                isheadactive = false;
            }

            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isactive = false;
            isheadactive = false;
            Invalidate();
        }


        private void DrawThumb(Graphics g)
        {

            Brush bcpen = null;
            Brush tcpen = null;
            if (isemptyheld)
            {
                bcpen = new SolidBrush(_Clickedbackcolor);

            }
            else if (isactive)
            {
                bcpen = new SolidBrush(_Activebackcolor);

            }
            else
            {
                bcpen = new SolidBrush(_backcolor);
            }

            if (isheld)
            {
                tcpen = new SolidBrush(_Clickedcolor);
            }
            else if (isheadactive)
            {
                tcpen = new SolidBrush(_Activecolor);
            }
            else
            {

                tcpen = new SolidBrush(_color);
            }
            Radius _r = new Radius();
            if (_vertical)
            {
                if (_round)
                {
                    _r.TopLeft = _r.TopRight = _r.BottomLeft = _r.BottomRight = (this.Width - 2) / 2;
                }
                var _sw = (float)this.Width - 1.5f;
                var _sh = thumbHeight;
                scrollX = .5f;
                if (scrollY >= this.Height - thumbHeight) { scrollY -= 1.5f; }
                using (var bx = new BorderPath(0, 0, this.Width - 1, this.Height - 1, _r))
                {
                    g.FillPath(bcpen, bx.Path);
                }
                using (var bx = new BorderPath(scrollX, scrollY, _sw, _sh, _r))
                {
                    g.FillPath(tcpen, bx.Path);
                }
            }
            else
            {
                if (_round)
                {
                    _r.TopLeft = _r.TopRight = _r.BottomLeft = _r.BottomRight = (this.Height - 2) / 2;
                }
                var _sw = (float)this.Height - 1.5f;
                var _sh = thumbHeight;
                scrollY = .5f;
                if (scrollX >= this.Width - thumbHeight) { scrollX -= 1.5f; }
                using (var bx = new BorderPath(0, 0, this.Width - 1, this.Height - 1, _r))
                {
                    g.FillPath(bcpen, bx.Path);
                }
                using (var bx = new BorderPath(scrollX, scrollY, _sh, _sw, _r))
                {
                    g.FillPath(tcpen, bx.Path);
                }
                // g.FillRectangle(pen, scrollX, scrollY, _sh, _sw);
            }
            tcpen.Dispose();
            bcpen.Dispose();
        }
        private void FireValueChanged()
        {
            if (_vertical)
            {
                valueRatio = (float)(this.Height - thumbHeight) / (float)(Maximum - Minimum);
                _value = (int)(scrollY / valueRatio) + _minimum;
            }
            else
            {
                valueRatio = (float)(this.Width - thumbHeight) / (float)(Maximum - Minimum);
                _value = (int)(scrollX / valueRatio) + _minimum;
            }
            ScrollChanged?.Invoke(this, EventArgs.Empty);
        }

        bool scrollUpIsFirst = true;
        private void ScrollNeedUpdater()
        {
            _Updater.Stop();
            bool isInvoke = false;
            if (_control == null) return;
            if (_control.PreferredSize.Height > _control.Height)
            {
                bool b = true;
                if(b != _verticalScrollBarNeeded)
                {
                    _verticalScrollBarNeeded = b;
                    isInvoke = true;
                }
                
            }
            else
            {
                bool b = false;
                if (b != _verticalScrollBarNeeded)
                {
                    _verticalScrollBarNeeded = b;
                    isInvoke = true;
                }
                
            }

            if (_control.PreferredSize.Width > _control.Width)
            {
                bool b = true;
                if (b != _horizontalScrollBarNeeded)
                {
                    _horizontalScrollBarNeeded = b;
                    isInvoke = true;
                }
                
            }
            else
            {
                bool b = false;
                if (b != _horizontalScrollBarNeeded)
                {
                    _horizontalScrollBarNeeded = b;
                    isInvoke = true;
                    
                }
                
            }

            if (isInvoke)
            {
                ScrollBarNeeded?.Invoke(_control);
            }
            _Updater.Start();
        }

        #region Properties
        internal bool IsArrowAllowed
        {
            get; set;
        } = true;
        internal float PositionX
        {
            get
            {
                return scrollX;
            }
        }
        internal float PositionY
        {
            get
            {
                return scrollY;
            }
        }
        bool _horizontalScrollBarNeeded = true;
        /// <summary>
        /// Returns true if horizontal scrollbar is needed.
        /// </summary>
        public bool HorizontalScrollBarNeeded
        {
            get
            {
                return _horizontalScrollBarNeeded;
            }
        }

        bool _verticalScrollBarNeeded = true;
        /// <summary>
        /// Returns true if vertical scrollbar is needed.
        /// </summary>
        public bool VerticalScrollBarNeeded
        {
            get
            {
                return _verticalScrollBarNeeded;
            }
        }

        bool _mouseWheelScroll = true;
        /// <summary>
        /// Gets or Sets whether the mouse wheel will scroll the scrollbar.
        /// </summary>
        [Description("Gets or Sets whether the mouse wheel will scroll the scrollbar."), Category("Saa")]
        public bool MouseWheelScroll
        {
            get
            {
                return _mouseWheelScroll;
            }
            set
            {
                _mouseWheelScroll = value;
            }
        }
        int _maximum = 100;
        /// <summary>
        /// Gets or Sets the maximum value the scrollbar will accept.
        /// </summary>
        [Description("Gets or Sets the maximum value the scrollbar will accept."), Category("Saa")]
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (value < _minimum) throw new Exception("Maximum can not be less than the Minimum");
                _maximum = value;
                if (Value > _maximum)
                {
                    Value = _maximum;

                }
                Calculate();
                Invalidate();

            }
        }

        int _minimum = 0;
        /// <summary>
        /// Gets or Sets the minimum value the scrollbar will accept.
        /// </summary>
        [Description("Gets or Sets the minimum value the scrollbar will accept."), Category("Saa")]
        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                
                if (value >= _maximum )  throw new Exception("Minimum can not be greater than or  equal to the Maximum");
                
                    _minimum = value;
                if (Value < _minimum)
                {
                    Value = _minimum;

                }
                Calculate();
                Invalidate();

            }
        }
        int _value = 0;
        /// <summary>
        /// Gets or Sets the value or the position of the scrollbar.
        /// </summary>
        [Description("Gets or Sets the value or the position of the scrollbar."), Category("Saa")]
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value > _maximum)
                {
                    _value = _maximum;

                }
                else if (value < _minimum)
                {
                    _value = _minimum;
                }
                else
                {
                    _value = value;
                }
                Calculate();
                Invalidate();
                FireValueChanged();
            }
        }

        /// <summary>
        /// Gets or Sets amount the scrollbar will increments or decrements when non-thumb area is clicked or clicked and hold. '0' means no change.
        /// </summary>
        [Description("Gets or Sets amount the scrollbar will increments or decrements when non-thumb area is clicked or clicked and hold. '0' means no change."), Category("Saa")]
        public int Change { get; set; } = 10;
        /// <summary>
        /// Gets or Sets in milliseconds, the interval between increments or decrements when non-thumb area is clicked and hold..
        /// </summary>
        [Description("Gets or Sets in milliseconds, the interval between increments or decrements when non-thumb area is clicked and hold."), Category("Saa")]
        public int ChangeInterval { get; set; } = 100;

        ScrollableControl _control;
        /// <summary>
        /// Gets or Sets control that is associated with the scrollbar.
        /// </summary>
        [Description("Gets or Sets control that is associated with the scrollbar."), Category("Saa")]
        public ScrollableControl TargetControl
        {
            get
            {
                return _control;
            }
            set
            {
                if (value != null && value.GetType() == typeof(SaaScrollBar)) return;
                RemovePrevControl();
                _control = value;
                if (value != null)
                {
                    _control.AutoScroll = false;
                    _control.VerticalScroll.Maximum = 0;
                    _control.HorizontalScroll.Maximum = 0;
                    _control.AutoScroll = true;
                }
                SetScrollToControl();
                Invalidate();
            }
        }

        Color _backcolor = Color.Gainsboro;
        /// <summary>
        /// Gets or Sets background color of the ScrollBar.
        /// </summary>
        [Description("Gets or Sets background color of the ScrollBar."), Category("Saa")]
        public Color BackgroundColor
        {
            get { return _backcolor; }
            set { _backcolor = value; Invalidate(); }
        }
        Color _Activebackcolor = Color.LightGray;
        /// <summary>
        /// Gets or Sets background color of the ScrollBar when mouse pointer is over non-thumb area.
        /// </summary>
        [Description("Gets or Sets background color of the ScrollBar when mouse pointer is over non-thumb area."), Category("Saa")]
        public Color ActiveBackgroundColor
        {
            get { return _Activebackcolor; }
            set { _Activebackcolor = value; Invalidate(); }
        }

        Color _Clickedbackcolor = Color.Silver;
        /// <summary>
        /// Gets or Sets background color of the ScrollBar when clicked non-thumb area.
        /// </summary>
        [Description("Gets or Sets background color of the ScrollBar when clicked non-thumb area."), Category("Saa")]
        public Color ClickedBackgroundColor
        {
            get { return _Clickedbackcolor; }
            set { _Clickedbackcolor = value; Invalidate(); }
        }

        Color _color = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets thumb color of the ScrollBar.
        /// </summary>
        [Description("Gets or Sets thumb color of the ScrollBar."), Category("Saa")]
        public Color Color
        {
            get { return _color; }
            set { _color = value; Invalidate(); }
        }
        Color _Clickedcolor = Color.SteelBlue;
        /// <summary>
        /// Gets or Sets thumb color of the ScrollBar when the thumb is clicked.
        /// </summary>
        [Description("Gets or Sets thumb color of the ScrollBar when the thumb is clicked."), Category("Saa")]
        public Color ClickedColor
        {
            get { return _Clickedcolor; }
            set { _Clickedcolor = value; Invalidate(); }
        }

        Color _Activecolor = Color.DodgerBlue;
        /// <summary>
        /// Gets or Sets thumb color of the ScrollBar when mouse pointer is over the thumb.
        /// </summary>
        [Description("Gets or Sets thumb color of the ScrollBar when mouse pointer is over the thumb."), Category("Saa")]
        public Color ActiveColor
        {
            get { return _Activecolor; }
            set { _Activecolor = value; Invalidate(); }
        }
        bool _vertical = true;
        /// <summary>
        /// Gets or Sets whether the ScrollBar is vertical or horizontal.
        /// </summary>
        [Description("Gets or Sets whether the ScrollBar is vertical or horizontal."), Category("Saa")]
        public bool Vertical
        {
            get
            {
                return _vertical;
            }
            set
            {

                _vertical = value;
                Invalidate();
                try
                {
                    SetScrollToControl();
                }
                catch { }
            }
        }

        bool _round = true;
        /// <summary>
        /// Gets or Sets whether the ScrollBar border is rounded.
        /// </summary>
        [Description("Gets or Sets whether the ScrollBar border is rounded."), Category("Saa")]
        public bool RoundedStyle
        {
            get
            {
                return _round;
            }
            set
            {
                _round = value;
                Invalidate();
            }
        }

        #endregion



        #region Hidden Properties
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor { get => base.BackColor; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage { get => base.BackgroundImage; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor { get => base.ForeColor; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override RightToLeft RightToLeft { get => base.RightToLeft; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoScroll { get => base.AutoScroll; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize { get => base.AutoSize; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font { get => base.Font; set { } }


        #endregion
    }
    internal static class SaascrollBarRegisterer
    {
        static Dictionary<ScrollableControl, SaaScrollBar> _hor = new Dictionary<ScrollableControl, SaaScrollBar>();
        static Dictionary<ScrollableControl, SaaScrollBar> _ver = new Dictionary<ScrollableControl, SaaScrollBar>();
        public static void AddUpdate(ScrollableControl cont, SaaScrollBar scr)
        {
            if (cont == null || scr == null) return;
            if (scr.Vertical)
            {
                RemoveBoth(cont, true);
                if (!_ver.ContainsKey(cont))
                {
                    _ver.Add(cont, scr);
                }
                else
                {
                    _ver[cont] = scr;
                }
            }
            else
            {
                RemoveBoth(cont, false);
                if (!_hor.ContainsKey(cont))
                {
                    _hor.Add(cont, scr);
                }
                else
                {
                    _hor[cont] = scr;
                }
            }
        }
        public static void RemoveHor(ScrollableControl cont)
        {
            if (cont == null) return;
            if (_hor.ContainsKey(cont))
            {
                _hor.Remove(cont);
            }
        }
        public static void RemoveVer(ScrollableControl cont)
        {
            if (cont == null) return;
            if (_ver.ContainsKey(cont))
            {
                _ver.Remove(cont);
            }
        }
        public static void RemoveBoth(ScrollableControl cont, bool isver)
        {
            if (cont == null) return;
            SaaScrollBar hor = null;
            SaaScrollBar ver = null;
            if (_ver.ContainsKey(cont)) ver = _ver[cont];
            if (_hor.ContainsKey(cont)) hor = _hor[cont];
            if (ver == hor && ver != null)
            {
                RemoveHor(cont);
                RemoveVer(cont);
            }
            else
            {
                if (isver)
                {
                    if (ver != null)
                    {
                        RemoveVer(cont);
                    }
                    else if (hor != null)
                    {
                        RemoveHor(cont);
                    }
                }
            }
        }

        public static bool HasVertical(ScrollableControl cont)
        {
            if (cont == null) return false;
            if (_ver.ContainsKey(cont)) return true;
            return false;
        }
        public static bool HasHorizontal(ScrollableControl cont)
        {
            if (cont == null) return false;
            if (_hor.ContainsKey(cont)) return true;
            return false;
        }
        public static SaaScrollBar GetHorScrollBar(ScrollableControl cont)
        {
            if (cont == null) return null;
            if (_hor.ContainsKey(cont)) return _hor[cont];
            return null;
        }
        public static SaaScrollBar GetVerScrollBar(ScrollableControl cont)
        {
            if (cont == null) return null;
            if (_ver.ContainsKey(cont)) return _ver[cont];
            return null;
        }
    }
}
