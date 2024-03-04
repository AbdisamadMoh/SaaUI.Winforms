using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class ToolTipForm : Form
    {
        Timer _timer = new Timer();
        public ToolTipForm(string t, SidePositions p)
        {
            DoubleBuffered = true;
            InitializeComponent();
            Position = p;
            switch (Position)
            {
                case SidePositions.Top:
                    {
                        this.label1.Dock = DockStyle.Top;
                        break;
                    }
                case SidePositions.Bottom:
                    {
                        this.label1.Dock = DockStyle.Bottom;
                        break;
                    }
                case SidePositions.Right:
                    {
                        this.label1.Dock = DockStyle.Right;
                        break;
                    }
                case SidePositions.Left:
                    {
                        this.label1.Dock = DockStyle.Left;
                        break;
                    }
            }
            Tip = t;
            tx = Tip;
            Size s = this.CreateGraphics().MeasureString(tx, Font).ToSize();
            if (Position == SidePositions.Top || Position == SidePositions.Bottom)
            {
                var sh = s.Height + ArrowHeight + 5;
                var sw = s.Width + 5;
                this.Size = new Size(sw, sh);
                ArrowStart = this.Width / 2;
                this.label1.Height = this.Height - ArrowHeight;
            }
            else if (Position == SidePositions.Right || Position == SidePositions.Left)
            {
                var sh = s.Height + 5;
                var sw = s.Width + ArrowHeight + 5;
                this.Size = new Size(sw, sh);
                ArrowStart = this.Height / 2;
                this.label1.Width = this.Width - ArrowHeight;
            }

            if (ArrowStart == null)
            {
                ArrowStart = 0;
            }

            using (var bx = new BorderPath(0, 0, this.Width, this.Height, new Properties.Radius(5, 5, 5, 5)))
            {
                this.Region = new Region(bx.Path);
            }

            this.label1.Text = tx;

        }
        internal Size getSize(string tip, Font f)
        {
            return this.CreateGraphics().MeasureString(tip, f).ToSize();
        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        const int WS_EX_NOACTIVATE = 0x8000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                ret.ExStyle |= WS_EX_NOACTIVATE;
                return ret;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawArrow(g);
            base.OnPaint(e);
        }
        string tx = "";
        private void DrawArrow(Graphics g)
        {
            int w = this.Width;
            int h = this.Height;
            Brush b = new SolidBrush(BackgroundColor);
            Point[] points = new Point[]
            {
                new Point((int)ArrowStart, 0),
                new Point((int)ArrowStart +ArrowWidth/2, ArrowHeight),
                new Point((int)ArrowStart -ArrowWidth/2, ArrowHeight)
            };
            g.FillPolygon(b, GetPeakPoints());

            using (var bx = new BorderPath(pathX, pathY, pathW, pathH, new Properties.Radius(5, 5, 5, 5)))
            {
                g.FillPath(b, bx.Path);
            }

            b.Dispose();

        }

        int pathX = 0;
        int pathY = 0;
        int pathH = 0;
        int pathW = 0;
        private Point[] GetPeakPoints()
        {
            Point[] points = { };
            switch (Position)
            {
                case SidePositions.Bottom:
                    {
                        points = new Point[]
                                {
                                    new Point((int)ArrowStart, 0),
                                    new Point((int)ArrowStart +ArrowWidth/2, ArrowHeight+1),
                                    new Point((int)ArrowStart -ArrowWidth/2, ArrowHeight+1)
                                };
                        pathX = 1;
                        pathY = ArrowHeight;
                        pathH = this.Height - ArrowHeight - 1;
                        pathW = this.Width - 1;
                        break;
                    }
                case SidePositions.Top:
                    {
                        points = new Point[]
                                {
                                    new Point((int)ArrowStart, this.Height),
                                    new Point((int)ArrowStart +ArrowWidth/2, this.Height-ArrowHeight-1),
                                    new Point((int)ArrowStart -ArrowWidth/2, this.Height-ArrowHeight-1)
                                };
                        pathX = 1;
                        pathY = 1;
                        pathH = this.Height - ArrowHeight;
                        pathW = this.Width - 1;
                        break;
                    }
                case SidePositions.Right:
                    {
                        points = new Point[]
                                {
                                    new Point(0, (int)ArrowStart),
                                    new Point(ArrowHeight,(int)ArrowStart -ArrowWidth/2),
                                    new Point(ArrowHeight, (int)ArrowStart +ArrowWidth/2)
                                };
                        pathX = ArrowHeight - 1;
                        pathY = 1;
                        pathH = this.Height - 1;
                        pathW = this.Width - ArrowHeight - 1;
                        break;
                    }
                case SidePositions.Left:
                    {
                        points = new Point[]
                                {
                                    new Point(this.Width, (int)ArrowStart),
                                    new Point(this.Width-ArrowHeight,(int)ArrowStart +ArrowWidth/2),
                                    new Point(this.Width-ArrowHeight, (int)ArrowStart -ArrowWidth/2)
                                };
                        pathX = 1;
                        pathY = 1;
                        pathH = this.Height - 1;
                        pathW = this.Width - ArrowHeight + 1;
                        break;
                    }
            }

            return points;
        }
        public int ArrowHeight { get; set; } = 10;
        public int ArrowWidth { get; set; } = 20;
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public int? ArrowStart { get; set; } = null;
        public Color BackgroundColor { get; set; } = SaaInternalColors.PrimaryColor;
        public SidePositions Position { get; set; } = SidePositions.Bottom;
        public string Tip = "";
    }
}
