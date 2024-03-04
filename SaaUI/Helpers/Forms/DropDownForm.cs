using SaaUI.Paint;
using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{

    internal partial class SaaDropDownForm : Form
    {
        internal SaaBaseControl panel1;
        Timer _Updater = new Timer();
        public SaaDropDownForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            panel1 = new SaaBaseControl();
            panel1.BackColor = Color.Transparent;
            this.Controls.Add(panel1);
            _Radius.Change += _Radius_Change;

            _Updater.Interval = 500;
            _Updater.Tick += (object sender, EventArgs e) =>
            {
                UpdatePosition();
                updateContainer();
            };
            _Updater.Start();

        }
        public SaaBaseControl Content
        {
            get { return this.panel1; }
        }

        private void _Radius_Change()
        {
            Invalidate();
        }

        protected override bool ShowWithoutActivation => true;
        private void DropDownForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);
            base.OnPaint(e);
        }
        private void Draw(Graphics g)
        {
            var h = this.Height - 3;
            var w = this.Width -3;

            var x = _Position == DropDownPosition.Right ? _ArrowSize.Height : 1;
            var y = _Position == DropDownPosition.Bottom ? _ArrowSize.Height : 1;
            if (!_showArrow)
            {
                x = y = 1;
            }
            var _dw = w;
            var _dh = h;
            if(_Position == DropDownPosition.Left || _Position ==  DropDownPosition.Right)
            {
                _dw -= _showArrow? _ArrowSize.Height:1;
            }
            if (_Position == DropDownPosition.Bottom || _Position == DropDownPosition.Top)
            {
                _dh -= _showArrow ? _ArrowSize.Height:1;
            }
            containerX =  x + 2;
            containerY = y + 2;
            containerH = _dh - 4;
            containerW = _dw - 4;

            DrawPaint paint = new DrawPaint()
            {
                Options = new DrawPaintOptions()
                {
                    BackColor1 = _BackColor,
                    BackColor2 = _BackColor,
                    BackColorAngle = (int)_BackColorAngle,
                    BorderColor1 = _BorderColor,
                    BorderColor2 = _BorderColor,
                    BorderColorAngle = _BorderColorAngle,
                    BorderThickness = _Border,
                    Radius = _Radius,
                    X = x,
                    Y = y,
                    Tranparency = 100,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Width = _dw,
                    Height = _dh,
                    AutoDispose = false
                }
            };
            
            paint.PaintGradient(g, this, false);
           
            g.FillPolygon(paint.GardientBackColor, ArrowPoints(w,h));

            if (_Border > 0)
            {
                g.DrawPolygon(paint.BorderColorPen, ArrowPoints(w, h));
                g.FillRectangle(paint.GardientBackColor, _arrRec);
            }
            paint.Dispose();
            updateContainer();
        }
        private RectangleF _arrRec;
        private PointF[] ArrowPoints( float w, float h)
        {
            if (_Position == DropDownPosition.Bottom)
            {
                var px = _ArrowOffset == null ? w / 2 +1.5f: _ArrowOffset.Value + _ArrowSize.Width / 2 + 1.5f;
                var py = 1;
                var px1 = _ArrowOffset == null ? px - _ArrowSize.Width / 2 : px - _ArrowSize.Width / 2;
                var py1 = py + _ArrowSize.Height;
                var px2 = px + _ArrowSize.Width / 2;
                var py2 = py1;
                _arrRec = new RectangleF(px1 - .5f, py1-1, _ArrowSize.Width + 1f, _Border + 2);
                return new PointF[] { new PointF(px, py), new PointF(px1, py1), new PointF(px2, py2) };

            } else if (_Position == DropDownPosition.Top)
            {
                var px = _ArrowOffset == null ? w / 2 : _ArrowOffset.Value + _ArrowSize.Width / 2 + 1.5f;
                var py = h-1;
                var px1 = _ArrowOffset == null ? px - _ArrowSize.Width / 2 : px - _ArrowSize.Width / 2;
                var py1 = py - _ArrowSize.Height;
                var px2 = px + _ArrowSize.Width / 2;
                var py2 = py1;
                _arrRec = new RectangleF(px1 - .5f, py1 - 2f, _ArrowSize.Width + 1f, _Border + 2);
                return new PointF[] { new PointF(px, py), new PointF(px1, py1), new PointF(px2, py2) };
            }
            else if (_Position == DropDownPosition.Right)
            {
                var px = 1;
                var py = _ArrowOffset == null ? h / 2 + _ArrowSize.Width/2 -7f : _ArrowOffset.Value + _ArrowSize.Width / 2+1.5f;
                var px1 = px + _ArrowSize.Height;
                var py1 = py - _ArrowSize.Width / 2;
                var px2 = px1;
                var py2 = py + _ArrowSize.Width / 2;
                _arrRec = new RectangleF(px1 - 1.5f, py1, _Border + 2, _ArrowSize.Width);
                return new PointF[] { new PointF(px, py), new PointF(px1, py1), new PointF(px2, py2) };
            }
            else 
            {
                var px = w-1;
                var py = _ArrowOffset == null ? h / 2 + _ArrowSize.Width / 2 - 7f : _ArrowOffset.Value + _ArrowSize.Width / 2 + 1.5f;
                var px1 = px - _ArrowSize.Height;
                var py1 = py - _ArrowSize.Width / 2;
                var px2 = px1;
                var py2 = py + _ArrowSize.Width / 2;
                _arrRec = new RectangleF(px1 - 1.5f, py1, _Border + 2, _ArrowSize.Width);
                return new PointF[] { new PointF(px, py), new PointF(px1, py1), new PointF(px2, py2) };
            }

        }
        int containerX = 0;
        int containerY = 0;
        int containerH = 0;
        int containerW = 0;
        private void updateContainer()
        {
            panel1.Dock = DockStyle.None;
            panel1.Location = new Point(containerX, containerY);
             panel1.Size = new Size(containerW, containerH);
            panel1.Padding = Padding.Empty;
            panel1.Margin = Padding.Empty;
            using (BorderPath rg = new BorderPath(1, 1,containerW, containerH, _Radius))
            {
                panel1.Region = new Region(rg.Path);
            }
            UpdatePosition();
        }
        internal void UpdatePosition()
        {
            _Updater.Stop();
            if (_target != null)
            {
                var cl = _target.LocationRelativeToForm();
                var fl = _target.FindForm() != null ? _target.FindForm().PointToScreen(cl) : Point.Empty;
                var x = 0;
                var y = 0;
               if(_Position == DropDownPosition.Top)
                {
                    x = fl.X + _target.Width / 2 - this.Width / 2 + _Offset.X;
                    y = fl.Y - this.Height - _Offset.Y;
                }else if (_Position == DropDownPosition.Bottom)
                {
                    x = fl.X + _target.Width / 2 - this.Width / 2 + _Offset.X;
                    y = fl.Y + _target.Height + _Offset.Y;
                }
                else if (_Position == DropDownPosition.Left)
                {
                    x = fl.X - this.Width - _Offset.X;
                    y = fl.Y - this.Height / 2 + _target.Height / 2 + _Offset.Y;
                }
                else //right
                {
                    x = fl.X +_target.Width + _Offset.X;
                    y = fl.Y - this.Height / 2 + _target.Height / 2 + _Offset.Y;
                }
                this.Location = new Point(x,y);
            }
            _Updater.Start();
        }

        public Size BodySize
        {
            get
            {
                if (_Position == DropDownPosition.Left || _Position == DropDownPosition.Right)
                {
                    return new Size(this.Width  - _ArrowSize.Height, this.Height);
                }
                else
                {
                    return new Size(this.Width , this.Height - _ArrowSize.Height);
                }
            }
        }

        public void SetHeight(int height)
        {
            if (height <= 20) { height = 20; };
            if(_Position == DropDownPosition.Left || _Position == DropDownPosition.Right)
            {
                this.Height = height;
            }
            else
            {
                this.Height = height + _ArrowSize.Height;
            }
            Invalidate();
        }
        public void SetWidth(int width)
        {
            if (width <= 20) { width = 20; };
            if (_Position == DropDownPosition.Top || _Position == DropDownPosition.Bottom)
            {
                this.Width = width;
            }
            else
            {
                this.Width = width + _ArrowSize.Height;
            }
            Invalidate();
        }
        bool _showArrow = true;
        public bool ShowArrow
        {
            get
            {
                return _showArrow;
            }
            set
            {
                _showArrow = value;
                Invalidate();
            }
        }
        Control _target = null;
        public Control TargetControl
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
        
        DropDownPosition _Position = DropDownPosition.Top;
        public DropDownPosition Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
                Invalidate();
            }
        }

        Point _Offset = Point.Empty;
        public Point Offset
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
                Invalidate();
            }
        }

        int? _ArrowOffset = null;
        public int? ArrowOffset
        {
            get
            {
                return _ArrowOffset;
            }
            set
            {
                _ArrowOffset = value;
                Invalidate();
            }
        }
        Size _ArrowSize = new Size(14,15);
        public Size ArrowSize
        {
            get
            {
                return _ArrowSize;
            }
            set
            {
                _ArrowSize = value;
                Invalidate();
            }
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

        Color _BackColor = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets BackColor of the control.
        /// </summary>
        [Description("Gets or Sets BackColor of the control")]
        [Category("Saa")]
        public  Color BackgroundColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
               // base.BackColor = Color.Transparent;
                _BackColor = value;
                Invalidate();
            }
        }

        Color _BackColor2 = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        private Color BackColor2
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
        private float BackColorAngle
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
        bool _isborder = false;
        /// <summary>
        /// Gets or Sets border thickness of the control.
        /// </summary>
        [Description("Gets or Sets border thickness of the control."), Category("Saa")]
        public bool Border
        {
            get
            {
                return _isborder;
            }
            set
            {
                _isborder = value;
                if (_isborder)
                {
                    _Border = 1;
                }
                else
                {
                    _Border = 0;
                }
                Invalidate();
            }
        }
        //internal int Border
        //{
        //    get
        //    {
        //        return _Border;
        //    }
        //    set
        //    {
        //        _Border = value;
        //        Invalidate();
        //    }
        //}
        Color _BorderColor = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets color of the border.
        /// </summary>
        [Description("Gets or Sets color of the border."), Category("Saa")]
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
        private Color BorderColor2
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
        private int BorderColorAngle
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

        #region Hidden Properties
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor { get => base.BackColor; set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text { get => base.Text; set { } }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage { get => base.BackgroundImage; set { } }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
