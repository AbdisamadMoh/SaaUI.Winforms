using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// A collapsible panel that orginizes items and controls.
    /// </summary>
    [Description("A collapsible panel that orginizes items and controls.")]
    [ToolboxBitmap(typeof(SaaAccordion), "icons.SaaAccordion.bmp")]
    [Designer(typeof(SaaAccordionParentControlDesigner))]
    [DefaultEvent("ExpandChanged")]
    public sealed partial class SaaAccordion : UserControl
    {
        public delegate void OnExpandChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires after the accordion is expanded or collapsed.
        /// </summary>
        [Description("Fires after the accordion is expanded or collapsed."), Category("Saa")]
        public event OnExpandChanged ExpandChanged;

        public delegate void OnExpandChanging(object sender, EventArgs e);
        /// <summary>
        /// Fires before the accordion starts expanding or collapsing.
        /// </summary>
        [Description("Fires before the accordion starts expanding or collapsing."), Category("Saa")]
        public event OnExpandChanging ExpandChanging;

        public delegate void OnAnimatingChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires as the accordion is expanding or collapsing. This event will be fired several times each collapse or expand.
        /// </summary>
        [Description("Fires as the accordion is expanding or collapsing. This event will be fired several times each collapse or expand."), Category("Saa")]
        public event OnAnimatingChanged Animating;

        /// <summary>
        /// Fires when mouse pointer is over the head of the accordion.
        /// </summary>
        [Description("Fires when mouse pointer is over the head of the accordion."), Category("Saa")]
        public event EventHandler HeadHover;
        /// <summary>
        /// Fires when mouse pointer leaves the head of the accordion.
        /// </summary>
        [Description("Fires when mouse pointer leaves the head of the accordion."), Category("Saa")]
        public event EventHandler HeadHoverLeave;

        private AccordionBody panel2;
        public SaaAccordion()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            panel2 = new AccordionBody()
            {
                Name = "Contents",
                Dock = DockStyle.Fill
            };
            this.Body.Controls.Add(panel2, 1, 1);
            TypeDescriptor.AddAttributes(this.ContentPanel, new DesignerAttribute(typeof(SaaAccordionPanelDesigner)));
            _size = new Size(this.Size.Width, this.Size.Height);
            //BackColor = Color.White;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 2;
            _timer.Stop();
            //tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
            //tableLayoutPanel1.Invalidate();
            panel2.Paint += Panel2_Paint;
            this.BodyRadius.Change += BodyRadius_Change;
        }

        private void BodyRadius_Change()
        {
            this.Invalidate(true);
            //this.panel2.Invalidate();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var back = new BorderPath(0, 0, this.ContentPanel.Width, this.ContentPanel.Height, _bodyradius);
            Brush br = new SolidBrush(_bodycolor);
            g.FillPath(br, back.Path);

            br.Dispose();
            back.Dispose();
        }

        /// <summary>
        /// Use <c>Items</c> instead.
        /// </summary>
        [Obsolete("Use 'Items' instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        internal new ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        /// <summary>
        /// Gets Controls this Accordion hosts
        /// </summary>
        [Description("Gets Controls this Accordion hosts"), Category("Saa")]
        [Browsable(false)]
        public ControlCollection Items
        {
            get
            {
                return this.ContentPanel.Controls;
            }
        }

        /// <summary>
        /// Gets the body panel of this accordion.
        /// </summary>
        [Description("Gets the body panel of this accordion."), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentPanel
        {
            get { return panel2; }
        }
        internal SaaAccordionHead Head
        {
            get
            {
                return this.saaAccordionHead1;
            }
        }
        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 1 && e.Row == 1)
            {
                e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds);
            }
        }

        Size _size;
        bool _isanimation = false;
        private void _timer_Tick(object sender, EventArgs e)
        {
            var _max = this._size.Height;
            var _min = this.Header.Height;
            var _speed = this.Speed < 1 ? (this._size.Height - this.Header.Height) / 4 : this.Speed;
            if (!_expand)
            {

                if (this.Height > _min + _speed)
                {
                    _collapsing = true;
                    _isanimation = true;
                    this.Height -= _speed;
                    Animating?.Invoke(this, _clickevent);
                }
                else
                {
                    this.Height = this.Header.Height;
                    _timer.Stop();
                    _isanimation = false;
                    _collapsing = false;
                    ExpandChanged?.Invoke(this, _clickevent);
                    _clickevent = EventArgs.Empty;
                }
            }
            else
            {
                if (this.Height < _max - _speed)
                {
                    _expanding = true;
                    _isanimation = true;
                    this.Height += _speed;
                    Animating?.Invoke(this, _clickevent);
                }
                else
                {
                    this.Height = this._size.Height;
                    _isanimation = false;
                    _expanding = false;
                    _timer.Stop();
                    ExpandChanged?.Invoke(this, _clickevent);
                    _clickevent = EventArgs.Empty;
                }
            }
        }

        Timer _timer = new Timer();


        protected override void OnPaint(PaintEventArgs e)
        {
            //var ctx = e.Graphics;
            //ctx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //if (this.BackColor == Color.Transparent)
            //{
            //    Transparenter tra = new Transparenter();
            //    tra.MakeTransparent(ctx, this);
            //}

            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
            if (!Expand && !_isanimation)
            {
                this.Height = this.Header.Height;
            }
            if (!_isanimation && Expand)
            {
                this._size = new Size(this.Size.Width, this.Size.Height);
            }
            base.OnResize(e);
        }
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);
            Invalidate(true);
        }
        protected override void OnSizeChanged(EventArgs e)
        {

            base.OnSizeChanged(e);
            //if (!_isanimation && Expand)
            //{
            //    this._size = new Size(this.Width, this.Height);
            //}
        }
        private void saaAccordionHead1_Load(object sender, EventArgs e)
        {

        }
        EventArgs _clickevent = EventArgs.Empty;
        private void saaAccordionHead1_Clicked(object sender, EventArgs e)
        {
            _clickevent = e;
            switch (MouseClicks)
            {
                case SaaMouseClicks.LeftClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Left)
                        {

                            this.Expand = !this.Expand;
                        }
                        break;
                    }
                case SaaMouseClicks.RightClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Right)
                        {
                            this.Expand = !this.Expand;
                        }
                        break;
                    }
                case SaaMouseClicks.AnyClick:
                    {
                        this.Expand = !this.Expand;
                        break;
                    }
            }


        }


        bool _expanding = false;
        /// <summary>
        /// Gets whether the control is expanding. <c>true</c> if the control is expanding, otherwise <c>false</c>
        /// </summary>
        [Browsable(false)]
        public bool Expanding { get { return _expanding; } }

        bool _collapsing = false;
        /// <summary>
        /// Gets whether the control is collapsing. <c>true</c> if the control is collapsing, otherwise <c>false</c>
        /// </summary>
        [Browsable(false)]
        public bool Collapsing { get { return _collapsing; } }

        /// <summary>
        /// Gets or Sets interval in milliseconds of the animation.
        /// </summary>
        [Description("Gets or Sets interval in milliseconds of the animation."), Category("Saa")]
        public int IntervalInMilliseconds
        {
            get
            {
                return this._timer.Interval;
            }
            set
            {
                this._timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets or Sets which mouse button click does this control accept.
        /// </summary>
        [Description("Gets or Sets which mouse button click does this control accept."), Category("Saa")]
        public SaaMouseClicks MouseClicks { get; set; } = SaaMouseClicks.LeftClick;

        /// <summary>
        /// Gets or Sets the size of the head.
        /// </summary>
        [Description("Gets or Sets the size of the head."), Category("Saa")]
        public Size HeadSize
        {
            get
            {
                return this.Head.Size;
            }
            set
            {

                this.Header.Size = value + _offheadsize;
                this.Head.Size = value;
            }
        }

        /// <summary>
        /// Gets or Sets how far will the head move from left and  top.
        /// </summary>
        [Description("Gets or Sets how far will the head move from left and top."), Category("Saa")]
        public Point HeadOffSet
        {
            get
            {
                return this.Head.Location;
            }
            set
            {
                this.Head.Location = value;
            }
        }
        Size _offheadsize = new Size(9, 12);
        /// <summary>
        /// Gets or Sets extra height and width to be added to the head.
        /// </summary>
        [Description("Gets or Sets extra height and width to be added to the head."), Category("Saa")]
        public Size HeadOffSize
        {
            get
            {
                return _offheadsize;
            }
            set
            {
                this._offheadsize = value;
                var _s = this.Head.Size;
                this.Header.Size = HeadSize + _offheadsize;
                this.Head.Size = _s;
            }
        }
        SaaShadow _shadow = new SaaShadow();
        /// <summary>
        /// Gets the shadow of the head. The shadow is <c>typeof</c> <seealso cref="SaaShadow"/>.
        /// </summary>
        [Description("Gets the shadow of the head. The shadow is typeof 'SaaShadow'."), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SaaShadow HeadShadow
        {
            get
            {
                return this.Shadow;
            }
        }

        bool _expand = true;
        /// <summary>
        /// Gets or Sets whether to accordion is expanded. <c>true</c> if expanded, otherwife <c>false</c>
        /// </summary>
        [Description("Gets or Sets whether to accordion is expanded. TRUE if expanded, otherwise FALSE."), Category("Saa")]
        public bool Expand
        {
            get { return _expand; }
            set
            {

                ExpandChanging?.Invoke(this, _clickevent);
                this.saaAccordionHead1.Expanded = _expand = value;
                _timer.Start();
            }
        }
        /// <summary>
        /// Gets or Sets the speed of the animation when expanding or collapsing. '0' means defualt animation speed.
        /// </summary>
        [Description("Gets or Sets the speed of the animation when expanding or collapsing. '0' means defualt animation speed."), Category("Saa")]
        public int Speed { get; set; } = 0;

        Radius _bodyradius = new Radius(1, 1, 1, 1);
        /// <summary>
        /// Gets or Sets radius of the body.
        /// </summary>
        [Description("Gets or Sets radius of the body."), Category("Saa")]
        public Radius BodyRadius
        {
            get { return _bodyradius; }
            set
            {
                _bodyradius = value;
                this.ContentPanel.Invalidate();
            }
        }

        Color _bodycolor = Color.White;
        /// <summary>
        /// Gets or Sets background color of the body.
        /// </summary>
        [Description("Gets or Sets background color of the body."), Category("Saa")]
        public Color BodyColor
        {
            get { return _bodycolor; }
            set
            {
                _bodycolor = value;
                this.panel2.Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets background color of the head.
        /// </summary>
        [Description("Gets or Sets background color of the head."), Category("Saa")]
        public Color HeadBackColor
        {
            get
            {
                return this.Head.BackColor;
            }
            set
            {
                this.Head.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets background color of the head when mouse pointer is over it.
        /// </summary>
        [Description("Gets or Sets background color of the head when mouse pointer is over it."), Category("Saa")]
        public Color HeadHoverBackColor
        {
            get
            {
                return this.Head.HoverColor;
            }
            set
            {
                this.Head.HoverColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets radius of the head when it expanded.
        /// </summary>
        [Description("Gets or Sets radius of the head when it expanded."), Category("Saa")]
        public Radius HeadExpandedRadius
        {
            get
            {
                return this.Head.ExapandedRadius;
            }
            set
            {
                this.Head.ExapandedRadius = value;
            }
        }

        /// <summary>
        /// Gets or Sets radius of the head when it collapsed.
        /// </summary>
        [Description("Gets or Sets radius of the head when it collapsed."), Category("Saa")]
        public Radius HeadCollapsedRadius
        {
            get
            {
                return this.Head.CollapsedRadius;
            }
            set
            {
                this.Head.CollapsedRadius = value;
            }
        }

        /// <summary>
        /// Gets or Sets right head image icon.
        /// </summary>
        [Description("Gets or Sets right head image icon."), Category("Saa")]
        public Image HeadRightImage
        {
            get
            {
                return Head.RightImage.Image;
            }
            set
            {
                Head.RightImage.Image = value;
            }
        }
        /// <summary>
        /// Gets or Sets left head image icon.
        /// </summary>
        [Description("Gets or Sets left head image icon."), Category("Saa")]
        public Image HeadLeftImage
        {
            get
            {
                return Head.LeftImage.Image;
            }
            set
            {
                Head.LeftImage.Image = value;
            }
        }

        /// <summary>
        /// Gets or Sets whether left head image icon is visible.
        /// </summary>
        [Description("Gets or Sets whether left head image icon is visible."), Category("Saa")]
        public bool HeadLeftImageVisible
        {
            get
            {
                return this.Head.LeftImage.Visible;
            }
            set
            {
                this.Head.LeftImage.Visible = value;
            }
        }

        /// <summary>
        /// Gets or Sets whether right head image icon is visible.
        /// </summary>
        [Description("Gets or Sets whether right head image icon is visible."), Category("Saa")]
        public bool HeadRightImageVisible
        {
            get
            {
                return this.Head.RightImage.Visible;
            }
            set
            {
                this.Head.RightImage.Visible = value;
            }
        }
        /// <summary>
        /// Gets or Sets right head image icon sizing mode.
        /// </summary>
        [Description("Gets or Sets right head image icon sizing mode."), Category("Saa")]
        public PictureBoxSizeMode HeadRightImageSizeMode
        {
            get
            {
                return Head.RightImage.SizeMode;
            }
            set
            {
                Head.RightImage.SizeMode = value;
            }
        }
        /// <summary>
        /// Gets or Sets left head image icon sizing mode.
        /// </summary>
        [Description("Gets or Sets left head image icon sizing mode."), Category("Saa")]
        public PictureBoxSizeMode HeadLeftImageSizeMode
        {
            get
            {
                return Head.LeftImage.SizeMode;
            }
            set
            {
                Head.LeftImage.SizeMode = value;
            }
        }
        /// <summary>
        /// Gets head title label
        /// </summary>
        [Description("Gets head title label"), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Label HeadTitle
        {
            get
            {
                return this.Head.Label;
            }
        }

        /// <summary>
        /// Gets or Sets text of the head.
        /// </summary>
        [Description("Gets or Sets text of the head."), Category("Saa")]
        public string HeadText
        {
            get
            {
                return HeadTitle.Text;
            }
            set
            {
                HeadTitle.Text = value;
            }
        }
        /// <summary>
        /// Gets or Sets text color of the head.
        /// </summary>
        [Description("Gets or Sets text color of the head."), Category("Saa")]
        public Color HeadTextColor
        {
            get
            {
                return HeadTitle.ForeColor;
            }
            set
            {
                HeadTitle.ForeColor = value;
            }
        }
        /// <summary>
        /// Gets or Sets text font of the head.
        /// </summary>
        [Description("Gets or Sets text font of the head."), Category("Saa")]
        public Font HeadFont
        {
            get
            {
                return HeadTitle.Font;
            }
            set
            {
                HeadTitle.Font = value;
            }
        }
        /// <summary>
        /// Gets or Sets text alignment of the head.
        /// </summary>
        [Description("Gets or Sets text alignment of the head."), Category("Saa")]
        public ContentAlignment HeadTextPosition
        {
            get
            {
                return HeadTitle.TextAlign;
            }
            set
            {
                HeadTitle.TextAlign = value;
            }
        }


        /// <summary>
        /// Gets or Sets body margins of the accordion.
        /// </summary>
        [Description("Gets or Sets body margins of the accordion."), Category("Saa")]
        public Padding BodyMargin
        {
            get
            {
                return new Padding((int)Body.ColumnStyles[0].Width, (int)Body.RowStyles[0].Height,
                    (int)Body.ColumnStyles[2].Width, (int)Body.RowStyles[2].Height);
            }
            set
            {
                Body.ColumnStyles[0].Width = value.Left;
                Body.ColumnStyles[2].Width = value.Right;

                Body.RowStyles[0].Height = value.Top;
                Body.RowStyles[2].Height = value.Bottom;
            }
        }

        /// <summary>
        /// Gets or Sets body padding of the accordion.
        /// </summary>
        [Description("Gets or Sets body padding of the accordion."), Category("Saa")]
        public Padding BodyPadding
        {
            get
            {
                return this.panel2.Padding;
            }
            set
            {
                this.panel2.Padding = value;
            }
        }

        private void saaAccordionHead1_MouseEnter(object sender, EventArgs e)
        {
            HeadHover?.Invoke(this, e);
        }

        private void saaAccordionHead1_MouseLeave(object sender, EventArgs e)
        {
            HeadHoverLeave?.Invoke(this, e);
        }
    }

    [ToolboxItemAttribute(false)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class AccordionBody : Panel
    {
        public AccordionBody()
        {
            DoubleBuffered = true;
        }
    }
    internal class AccTb : TableLayoutPanel
    {
        public AccTb()
        {
            DoubleBuffered = true;
        }
        protected override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }
    }
}
