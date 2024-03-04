using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaIntroTipControl : UserControl
    {
        public EventHandler TargetClick;
        public EventHandler AllClick;
        public SaaIntroTipControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // this.ResizeRedraw = true;

        }
        Form owner;
        bool _isbackground = true;
        protected override void OnParentChanged(EventArgs e)
        {
            if (owner != null)
            {
                owner.Resize -= Owner_Resize;
            }

            owner = ParentForm;
            if (owner != null)
            {
                if (_isbackground)
                {
                    this.BackColor = this.ParentForm.BackColor;
                    _isbackground = false;
                }
                owner.Resize += Owner_Resize;
            }
        }
        private void Owner_Resize(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = owner.Size;
            this.BringToFront();
            Invalidate();
        }

        Point _textoffset = new Point(10, 10);
        public Point TextOffset
        {
            get
            {
                return _textoffset;
            }
            set
            {
                _textoffset = value;
                Invalidate();
            }
        }
        float _arrowthickness = 1.5f;
        public float ArrowThickness
        {
            get
            {
                return _arrowthickness;
            }
            set
            {
                _arrowthickness = value;
                Invalidate();
            }
        }
        Color _arrowcolor = Color.LightSkyBlue;
        public Color ArrowColor
        {
            get
            {
                return _arrowcolor;
            }
            set
            {
                _arrowcolor = value;
                Invalidate();
            }
        }
        int _arrowHeight = 70;
        public int ArrowHeight
        {
            get
            {
                return _arrowHeight;
            }
            set
            {
                _arrowHeight = value;
                Invalidate();
            }
        }

        int _arrowBend = 25;
        public int ArrowBend
        {
            get
            {
                return _arrowBend;
            }
            set
            {
                _arrowBend = value;
                Invalidate();
            }
        }
        Point _arrowoffset = new Point(10, 10);
        public Point ArrowOffset
        {
            get
            {
                return _arrowoffset;
            }
            set
            {
                _arrowoffset = value;
                Invalidate();
            }
        }

        LineCap _arrowheadStyle = LineCap.ArrowAnchor;
        public LineCap ArrowHeadStyle
        {
            get
            {
                return _arrowheadStyle;
            }
            set
            {
                _arrowheadStyle = value;
                Invalidate();
            }
        }
        LineCap _arrowtailStyle = LineCap.Round;
        public LineCap ArrowTailStyle
        {
            get
            {
                return _arrowtailStyle;
            }
            set
            {
                _arrowtailStyle = value;
                Invalidate();
            }
        }
        DashStyle _arrowlinestyle = DashStyle.Dash;
        public DashStyle ArrowLineStyle
        {
            get
            {
                return _arrowlinestyle;
            }
            set
            {
                _arrowlinestyle = value;
                Invalidate();
            }
        }

        string _text = "";
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string Value
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Invalidate();
            }
        }
        Control _contrl;
        Bitmap btm;
        public Control Control
        {
            get
            {
                return _contrl;
            }
            set
            {
                if (!(_contrl is SaaIntroTipControl && _contrl is Form))
                {
                    _contrl = value;

                    Invalidate();
                }
            }
        }

        Color _regcolor = Color.Transparent;
        public Color RegionColor
        {
            get
            {
                return _regcolor;
            }
            set
            {
                _regcolor = value;
                Invalidate();
            }
        }
        Padding _regionoffset = new Padding(2, 2, 0, 0);
        public Padding RegionOffSet
        {
            get
            {
                return _regionoffset;
            }
            set
            {

                _regionoffset = value;
                Invalidate();

            }
        }
        SaaIntroTipPosition _position = SaaIntroTipPosition.Auto;
        public SaaIntroTipPosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                Invalidate();
            }
        }
        int _transparency = 90;
        public int Transparency
        {
            get { return _transparency; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _transparency = value;
                    Invalidate();
                }
                else
                {
                    throw new Exception("Value must be betweem 0 and 100");
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.BringToFront();
            if (_contrl != null)
            {
                Transparenter tra = new Transparenter();
                tra.MakeTransparent(e.Graphics, this);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                using (var b = new SolidBrush(this.BackColor.GetTransparency(_transparency)))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(0, 0, this.Width, this.Height));
                }
                var pos = _position == SaaIntroTipPosition.Auto ? GetPosition(e.Graphics) : _position;
                DesignLayoutAngles(pos);
                DrawControl(e.Graphics, pos);
                DrawPointer(e.Graphics, pos);
                DrawText(e.Graphics, pos);
            }
            base.OnPaint(e);
        }

        private void DrawControl(Graphics gr, SaaIntroTipPosition _pos)
        {
            if (_contrl != null)
            {
                var _rw = this._contrl.Width + _regionoffset.Size.Width;
                var _rh = this._contrl.Height + _regionoffset.Size.Height;
                var _rx = this._contrl.LocationRelativeToForm().X - _regionoffset.Left;
                var _ry = this._contrl.LocationRelativeToForm().Y - _regionoffset.Top;
                btm = new Bitmap(this._contrl.Width, this._contrl.Height);

                // gr.Clear(_regcolor);
                using (var rec = new BorderPath(_rx, _ry, _rw, _rh, _Radius))
                {
                    using (SolidBrush backColor = new SolidBrush(_regcolor))
                    {
                        gr.FillPath(backColor, rec.Path);
                        this._contrl.DrawToBitmap(btm, new Rectangle(0, 0, this._contrl.Width, this._contrl.Height));

                        var l = this._contrl.LocationRelativeToForm();
                        gr.DrawImage(btm, new PointF(l.X, l.Y));

                        if (_Border > 0)
                        {
                            using (var BorderPen = new Pen(_BorderColor, _Border))
                            {
                                BorderPen.DashStyle = _borderStyle;
                                gr.DrawPath(BorderPen, rec.PathBorder);
                            }
                        }
                    }

                }

            }
        }
        int _arrX = 0;
        int _arrY = 0;
        int _arrX2 = 0;
        int _arrY2 = 0;
        private void DrawPointer(Graphics gr, SaaIntroTipPosition _pos)
        {
            var _cw = this._contrl.Width;
            var _ch = this._contrl.Height;
            var _lx = this._contrl.LocationRelativeToForm().X + _arrowoffset.X + _cw / 2;
            var _ly = this._contrl.LocationRelativeToForm().Y + _arrowoffset.Y + _ch + 10;
            using (var lpen = new Pen(_arrowcolor, _arrowthickness))
            {
                lpen.StartCap = _arrowheadStyle;
                lpen.EndCap = _arrowtailStyle;
                lpen.DashStyle = _arrowlinestyle;
                lpen.DashCap = DashCap.Round;
                gr.DrawLine(lpen, _arrX, _arrY, _arrX2, _arrY2);
                //gr.DrawArc(arcpen, new Rectangle(_arrX, _arrY, _arrWidth, _arrHeight), _arrstartAngle, _arrsweepangle);

            }
        }
        int _textX = 0;
        int _textY = 0;
        private void DrawText(Graphics gr, SaaIntroTipPosition _pos)
        {
            using (var br = new SolidBrush(this.ForeColor))
            {
                gr.DrawString(this._text, Font, br, _textX, _textY);
            }
        }

        private void DesignLayoutAngles(SaaIntroTipPosition _pos)
        {
            var _cw = this._contrl.Width;
            var _ch = this._contrl.Height;
            var _cX = this._contrl.LocationRelativeToForm().X;
            var _cY = this._contrl.LocationRelativeToForm().Y;
            var _tz = this._text.GetSize(this.Font);
            var _tw = _tz.Width;
            var _th = _tz.Height;
            if (_pos == SaaIntroTipPosition.Bottom)
            {

                _arrX = _cX + _arrowoffset.X + _cw / 2;
                bool _isright = canRight(_tz, _arrX + _arrowBend + _textoffset.X);
                _arrX2 = _arrX + (_isright ? _arrowBend : -_arrowBend);
                _arrY = _cY + _arrowoffset.Y + _ch;
                _arrY2 = this._arrowHeight + _arrY;

                _textX = _arrX2 + (!_isright ? -_tw / 2 - _textoffset.X : _textoffset.X);
                _textY = _arrY2 + _textoffset.Y;

            }
            else if (_pos == SaaIntroTipPosition.Right)
            {

                _arrY = _cY + _ch / 2 + _arrowoffset.Y;
                bool _istop = canTop(_tz, _arrY - _arrowBend - _textoffset.Y);
                _arrY2 = _arrY + (_istop ? -_arrowBend : _arrowBend);
                _arrX = _cX + _arrowoffset.X + _cw;
                _arrX2 = _arrX + this._arrowHeight;

                _textX = _arrX2 + _textoffset.X;
                _textY = _arrY2 + (_istop ? -_th - _textoffset.Y : _textoffset.Y);

            }
            else if (_pos == SaaIntroTipPosition.Left)
            {
                _arrY = _cY + _ch / 2 + _arrowoffset.Y;
                bool _istop = canTop(_tz, _arrY - _arrowBend - _textoffset.Y);
                _arrY2 = _arrY + (_istop ? -_arrowBend : _arrowBend);
                _arrX = _cX - _arrowoffset.X;
                _arrX2 = _arrX - this._arrowHeight;

                _textX = _arrX2 - _textoffset.X - _tw;
                _textY = _arrY2 + (_istop ? -_th - _textoffset.Y : _textoffset.Y);
            }
            else if (_pos == SaaIntroTipPosition.Top)
            {
                _arrX = _cX + _arrowoffset.X + _cw / 2;
                bool _isright = canRight(_tz, _arrX + _arrowBend + _textoffset.X);
                _arrX2 = _arrX + (_isright ? _arrowBend : -_arrowBend);
                _arrY = _cY - _arrowoffset.Y;
                _arrY2 = _arrY - this._arrowHeight;

                _textX = _arrX2 + (!_isright ? -_tw / 2 - _textoffset.X : _textoffset.X);
                _textY = _arrY2 - _textoffset.Y - _th;
            }
        }
        private SaaIntroTipPosition GetPosition(Graphics gr)
        {
            SaaIntroTipPosition pos = SaaIntroTipPosition.Bottom;
            if (_contrl != null)
            {
                var parent = this.FindForm();
                var _h = parent.ClientSize.Height;
                var _w = parent.ClientSize.Width;
                var _ch = _contrl.Height;
                var _cw = _contrl.Width;
                var _cx = _contrl.LocationRelativeToForm().X;
                var _cy = _contrl.LocationRelativeToForm().Y;
                var _lh = _arrowHeight;
                var _lx = this.ArrowOffset.X;
                var _ly = this.ArrowOffset.Y;
                var _tsz = gr.MeasureString(this._text, this.Font);
                var _th = _tsz.Height;
                var _tw = _tsz.Width;
                var _tx = this.TextOffset.X;
                var _ty = this.TextOffset.Y;

                var _reqH = _lh + _ly + _th + _ty + 35;//required height
                var _reqW = _lh + _lx + _tw + _tx + 35;//required width

                //remaining heights
                var remHb = _h - (_cy + _ch + this.RegionOffSet.Bottom); //height - unused top height = bottom remaining
                var remHt = _cy - this.RegionOffSet.Top; //unused height top
                var remWl = _cx - this.RegionOffSet.Left;// unused width leftside
                var remWr = _w - (_cx + _cw + this.RegionOffSet.Right);//unused width rightside

                if (remHb > _reqH)
                {
                    pos = SaaIntroTipPosition.Bottom;
                }
                else if (remHt > _reqH)
                {
                    pos = SaaIntroTipPosition.Top;
                }
                else if (remWl > _reqW)
                {
                    pos = SaaIntroTipPosition.Left;
                }
                else if (remWr > _reqW)
                {
                    pos = SaaIntroTipPosition.Right;
                }


            }

            return pos;
        }

        private bool canRight(Size txtSize, int x)
        {
            if (this.Width - x > txtSize.Width + 10) return true; else return false;
        }
        private bool isMoreRight(int x)
        {
            var left = this.Width - x;
            var right = x;
            if (right > left) return true; else return false;
        }
        private bool canLeft(Size txtSize, int x)
        {
            if (x > txtSize.Width + 10) return true; else return false;
        }
        private bool canBottom(Size txtSize, int y)
        {
            if (this.Height - y > txtSize.Height + 10) return true; else return false;
        }
        private bool canTop(Size txtSize, int y)
        {
            if (y > txtSize.Height + 10) return true; else return false;
        }
        private void SaaIntroTipControl_MouseDown(object sender, MouseEventArgs e)
        {

            var mx = e.Location.X;
            var my = e.Location.Y;
            if (IsTarget(mx, my))
            {
                TargetClick?.Invoke(_contrl, e);
            }
            AllClick?.Invoke(this, e);
        }
        public bool IsTarget(int X, int Y, bool includeOffSet = false)
        {
            bool _ret = false;
            if (_contrl != null)
            {
                var _x1 = this._contrl.LocationRelativeToForm().X + (includeOffSet ? -_regionoffset.Left : 0);
                var _y1 = this._contrl.LocationRelativeToForm().Y + (includeOffSet ? -_regionoffset.Top : 0); ;
                var _x2 = _x1 + this._contrl.Width + (includeOffSet ? _regionoffset.Right + _regionoffset.Left : 0);
                var _y2 = _y1 + this._contrl.Height + (includeOffSet ? _regionoffset.Bottom + _regionoffset.Top : 0); ;

                var mx = X;
                var my = Y;
                if ((mx > _x1 && mx < _x2) && (my > _y1 && my < _y2))
                {
                    _ret = true;
                }
            }

            return _ret;
        }
        public bool IsTarget(Point p, bool includeOffSet = false)
        {
            bool _ret = false;
            if (_contrl != null)
            {
                var _x1 = this._contrl.LocationRelativeToForm().X + (includeOffSet ? -_regionoffset.Left : 0);
                var _y1 = this._contrl.LocationRelativeToForm().Y + (includeOffSet ? -_regionoffset.Top : 0); ;
                var _x2 = _x1 + this._contrl.Width + (includeOffSet ? _regionoffset.Right + _regionoffset.Left : 0);
                var _y2 = _y1 + this._contrl.Height + (includeOffSet ? _regionoffset.Bottom + _regionoffset.Top : 0); ;

                var mx = p.X;
                var my = p.Y;
                if ((mx > _x1 && mx < _x2) && (my > _y1 && my < _y2))
                {
                    _ret = true;
                }
            }

            return _ret;
        }

        Radius _Radius = new Radius();
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
        int _Border = 2;
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

        DashStyle _borderStyle = DashStyle.Dot;
        public DashStyle BorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }


    }
    //public class IntroTipButton :SaaButton
    //{
    //    internal EventHandler Change;
    //    public IntroTipButton()
    //    {
    //        Value = "button";
    //    }
    //    Point _OffSet = new Point(0, 0);
    //    public Point OffSet
    //    {
    //        get
    //        {
    //            return _OffSet;
    //        }
    //        set
    //        {
    //            _OffSet = value;
    //            Change?.Invoke(this, EventArgs.Empty);
    //        }
    //    }
    //    TopLeftCenterAutoPosition _Position = TopLeftCenterAutoPosition.Auto;
    //    public TopLeftCenterAutoPosition Position
    //    {
    //        get
    //        {
    //            return _Position;
    //        }
    //        set
    //        {
    //            _Position = value;
    //            Change?.Invoke(this, EventArgs.Empty);
    //        }
    //    }
    //}
}
