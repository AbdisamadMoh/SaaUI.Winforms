using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaToastForm : SaaRoundForm
    {

        public delegate void OnHide();
        public event OnHide OnHided;
        public Label lb = new Label();
        SaaPanel pn = new SaaPanel();
        Timer _timer;
        public Image CloseActiveImage { get; set; }
        public Image CloseInActiveImage { get; set; }
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public int PW { get; set; } = 0;
        public int PH { get; set; } = 0;
        public bool LoaderVisible { get; set; }
        public bool AutoClose { get; set; }
        public int OffHeight { get; set; } = 5;
        public int OffWidth { get; set; } = 0;
        public int IntervalInMilliseconds { get; set; }
        public bool ApplyShadow { get; set; } = false;




        public SaaToastForm()
        {

            InitializeComponent();

            // Shadow();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Shadow()
        {
            if (ApplyShadow)
            {
                (new DropShadow()).ApplyShadows(this);
            }
        }


        private void _timer_Tick(object sender, EventArgs e)
        {

            if (pn.Width > lb.Width)
            {
                lb.Width++;

            }
            else
            {
                _timer.Stop();
                lb.Width = pn.Width;
                if (AutoClose)
                {
                    this.Close();
                }
            }
        }
        public bool isPreview { get; set; } = false;
        public ToastPosition position { get; set; } = ToastPosition.BottomRight;
        public bool isCustom { get; set; } = false;
        public bool isCustomXY { get; set; } = false;
        public Point point { get; set; }
        public Image IconImage
        {
            get { return saaPictureBox1.Image; }
            set { saaPictureBox1.Image = value; }
        }
        public bool AutoSizing { get; set; } = true;
        public int LoaderHeight { get; set; } = 3;
        public Size MinSize { get; set; }
        public bool StopOnHover { get; set; }
        public bool Movable { get; set; }
        protected override void OnLoad(EventArgs e)
        {

            SetUp();
            if (!isCustom)
            {
                switch (position)
                {
                    case ToastPosition.BottomRight:
                        {
                            PlaceLowerRight();
                            break;
                        }
                    case ToastPosition.BottomLeft:
                        {
                            PlaceLowerLeft();
                            break;
                        }
                    case ToastPosition.TopRight:
                        {
                            PlaceTopRight();
                            break;
                        }
                    case ToastPosition.TopLeft:
                        {
                            PlaceTopLeft();
                            break;
                        }
                    case ToastPosition.Center:
                        {
                            PlaceCenter();
                            break;
                        }
                }
            }
            else
            {
                if (!isCustomXY)
                {
                    this.Location = GetPoints(point, this.Width, this.Height);
                }
                else
                {
                    this.Location = point;
                }
            }
            base.OnLoad(e);

        }
        internal void Preview()
        {

            pn.Height = LoaderHeight;
            lb.Width = 0;
            if (LoaderVisible)
            {
                try
                {
                    this.pn.Controls.Add(lb);
                    this.Controls.Add(pn);
                }
                catch { }
            }
            else
            {
                try
                {
                    this.pn.Controls.Remove(lb);
                    this.Controls.Remove(pn);
                }
                catch { }

            }
            _timer.Stop();
            _timer.Interval = IntervalInMilliseconds;

            _timer.Start();
            saaPictureBox1.Image = IconImage;

            // SetResize();
        }
        private Size getTextSize(string text)
        {
            Font font = saaLabel1.Font;
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(text, font);
            fakeImage.Dispose();
            graphics.Dispose();
            return new Size((int)size.Width, (int)size.Height);
        }
        private void SetUp()
        {
            //  lb = new Label();
            // lb.Dock = DockStyle.Left;
            // lb.BackColor = Color.White;

            pn.Height = LoaderHeight;
            pn.Dock = DockStyle.Bottom;
            pn.BackColor = Color.Transparent;
            pn.BackColor2 = Color.Transparent;
            lb.Width = 0;
            if (LoaderVisible)
            {
                this.pn.Controls.Add(lb);
                this.Controls.Add(pn);
            }
            // saaLabel1.ForeColor = this.ForeColor;

            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = IntervalInMilliseconds;
            _timer.Start();
            saaPictureBox1.Image = IconImage;
            // this.MinimumSize = MinSize;
            SetResize();

        }

        public void SetResize()
        {
            if (AutoSizing)
            {
                var header = 0;
                var loader = 0;
                var leftIcon = 0;

                var sz = getTextSize(saaLabel1.Text);
                var w = sz.Width;
                var h = sz.Height;

                if (saaPanel1.Visible) { header = saaPanel1.Height; } else { header = 0; }
                if (saaPictureBox1.Visible) { leftIcon = saaPictureBox1.Width; } else { leftIcon = 0; }
                if (pn.Visible) { loader = pn.Height; } else { loader = 0; }

                this.Height = h + header + loader + OffHeight + (saaLabel1.Padding.Top + saaLabel1.Padding.Bottom);
                this.Width = w + leftIcon + OffWidth + (saaLabel1.Padding.Left + saaLabel1.Padding.Right);
                // MessageBox.Show($"h: {h}, hr: {this.Height}, w: {w}, wr: {this.Width}");

            }
        }

        //public void SetResize()
        //{
        //    if (AutoSizing)
        //    {

        //        //  var sz = getTextSize(saaLabel1.Text);
        //        // var w = sz.Width; //(int)TextRenderer.MeasureText(Value, saaLabel1.Font).Width ;
        //        //  var h = sz.Height; //(int)TextRenderer.MeasureText(Value, saaLabel1.Font).Height;

        //        var w = (int)TextRenderer.MeasureText(Value, saaLabel1.Font).Width ;
        //        var h =(int)TextRenderer.MeasureText(Value, saaLabel1.Font).Height;

        //        this.Width = w > MinSize.Width ? w + (saaPictureBox1.Visible? saaPictureBox1.Width:0) + OffWidth : MinSize.Width;
        //        this.Height = h > MinSize.Height ? h + (saaPanel1.Visible? saaPanel1.Height:0) + (LoaderVisible? pn.Height:0) + OffHeight : MinSize.Height;
        //       // this.Size = new Size(rw, rh);
        //       MessageBox.Show($"h: {h}, hr: {this.Height}, w: {w}, wr: {this.Width}");
        //        //   saaLabel1.Width = w < MinSize.Width - ((saaPictureBox1.Visible?saaPictureBox1.Width:0) + OffWidth) ? MinSize.Width - ((saaPictureBox1.Visible? saaPictureBox1.Width:0) + OffWidth) : saaLabel1.Width;
        //      //  saaLabel1.Height = h < MinSize.Height - ((saaPanel1.Visible ? saaPanel1.Height : 0) + OffHeight) ? MinSize.Height - ((saaPanel1.Visible ? saaPanel1.Height : 0) + OffHeight) : saaLabel1.Height;
        //    }
        //}

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }
        protected override void OnMouseDownMoveForm(object sender, MouseEventArgs e)
        {
            if (Movable)
            {
                base.OnMouseDownMoveForm(sender, e);
            }
        }
        public string Value
        {
            get
            {
                return this.saaLabel1.Text;
            }
            set
            {
                this.saaLabel1.Text = value;
                //SetResize();
            }
        }
        Screen rightmost;

        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width - 1 - OffsetX;
            this.Top = rightmost.WorkingArea.Bottom - this.Height - 2 - OffsetY/*- FormList.GetHeight(position)*/;
        }
        int h = 0;
        private void PlaceTopRight()
        {
            //Determine "rightmost" screen
            rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width - 1 - OffsetX;
            this.Top = rightmost.WorkingArea.Top + 2 + OffsetY/*+ FormList.GetHeight(position)*/;// - this.Height;
        }
        private void PlaceTopLeft()
        {
            //Determine "rightmost" screen
            rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Left + 2 + OffsetX;
            this.Top = rightmost.WorkingArea.Top + 2 + OffsetY/*+ FormList.GetHeight(position)*/;
        }
        private void PlaceCenter()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Top = this.Top - (this.Height / 2) + OffsetY;
            this.Left = this.Left - (this.Width / 2) + OffsetX;
        }
        int x, y = 0;


        private void PlaceLowerLeft()
        {
            //Determine "rightmost" screen
            rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Left + 2 + OffsetX;// - this.Width;
            this.Top = (rightmost.WorkingArea.Bottom - (this.Height + 2 + OffsetY)/*-FormList.GetHeight(position)*/);// - FormList.GetHeight();

        }
        private void saaButton1_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void saaLabel1_MouseEnter_1(object sender, EventArgs e)
        {
            if (StopOnHover)
            {
                _timer.Stop();
            }
            this.saaPictureBox2.Image = CloseActiveImage;
        }

        private void saaPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (StopOnHover)
            {
                _timer.Start();
            }
            this.saaPictureBox2.Image = CloseInActiveImage;
        }
        private Point GetPoints(Point p, int w, int h)
        {
            Point pt = new Point(0, 0);

            switch (position)
            {
                case ToastPosition.BottomLeft:
                    {
                        pt = new Point(p.X + OffsetX, p.Y + OffsetY + PH - h);
                        break;
                    }
                case ToastPosition.BottomRight:
                    {
                        pt = new Point(p.X + OffsetX + PW - w, p.Y + OffsetY + PH - h);
                        break;
                    }
                case ToastPosition.TopRight:
                    {
                        pt = new Point(p.X + OffsetX + PW - w, p.Y + OffsetY);
                        break;
                    }
                case ToastPosition.TopLeft:
                    {
                        pt = new Point(p.X + OffsetX, p.Y + OffsetY);
                        break;
                    }
                case ToastPosition.Center:
                    {
                        pt = new Point(p.X + OffsetX + PW / 2, p.Y + OffsetY + PH / 2);
                        break;
                    }
            }
            return pt;
        }

        private void saaPictureBox2_Click(object sender, EventArgs e)
        {
            if (isPreview) { Hide(); OnHided?.Invoke(); } else { Close(); }

        }

        private void SaaToastForm_Load(object sender, EventArgs e)
        {
            // PlaceLowerRight();
        }





    }

}
