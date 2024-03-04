using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaDropDown : UserControl
    {
        public SaaDropDown()
        {
            InitializeComponent();
            base.BackColor = Color.Transparent;
            this.LeftImageVisible = false;
            
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
           
        }
        public void InvalidateBubbles()
        {
            var styles = tableLayoutPanel1.ColumnStyles;
            styles[0].SizeType = SizeType.AutoSize;
            styles[1].SizeType = SizeType.Percent;
            styles[1].Width = 100;
            styles[2].SizeType = SizeType.AutoSize;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Transparenter t = new Transparenter();
            t.MakeTransparent(e.Graphics, this);
            Radius r = _round ? new Radius(5, 5, 5, 5) : new Radius();
            Brush b = new SolidBrush(_BackgroundColor);
            using(var bx = new BorderPath(0,0,this.Width-2, this.Height-2, r))
            {
                e.Graphics.FillPath(b, bx.Path);
                if (_border)
                {
                    Pen p = new Pen(_borderColor);
                    e.Graphics.DrawPath(p, bx.PathBorder);
                    p.Dispose();
                }
            }
            b.Dispose();
            base.OnPaint(e);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }







        #region properties


        /// <summary>
        /// Gets or Sets which mouse button click does this control accept.
        /// </summary>
        [Description("Gets or Sets which mouse button click does this control accept."), Category("Saa")]
        public SaaMouseClicks MouseClicks { get; set; } = SaaMouseClicks.LeftClick;

      

        bool _expand = true;
        /// <summary>
        /// Gets or Sets whether to accordion is expanded. <c>true</c> if expanded, otherwife <c>false</c>
        /// </summary>
        [Description("Gets or Sets whether to accordion is expanded. TRUE if expanded, otherwise FALSE."), Category("Saa")]
        public bool Expanded
        {
            get { return _expand; }
            set
            {

                //   ExpandChanging?.Invoke(this, _clickevent);
                //  this.saaAccordionHead1.Expanded = _expand = value;
                //  _timer.Start();
                Invalidate(true);
            }
        }

        bool _round = false;
        /// <summary>
        /// Gets or Sets whether the progressbar border is rounded.
        /// </summary>
        [Description("Gets or Sets whether the progressbar border is rounded."), Category("Saa")]
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

        bool _border = false;
        /// <summary>
        /// Gets or Sets whether the progressbar border is rounded.
        /// </summary>
        [Description("Gets or Sets whether the progressbar border is rounded."), Category("Saa")]
        public bool Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                Invalidate();
            }
        }

        Color _borderColor = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets background color of the body.
        /// </summary>
        [Description("Gets or Sets background color of the body."), Category("Saa")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(true);
                // this.panel2.Invalidate();
            }
        }

        Color _BackgroundColor = Color.White;
        /// <summary>
        /// Gets or Sets background color of the body.
        /// </summary>
        [Description("Gets or Sets background color of the body."), Category("Saa")]
        public Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                Invalidate(true);
                // this.panel2.Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets background color of the body.
        /// </summary>
        [Description("Gets or Sets background color of the body."), Category("Saa")]
        public Color ActiveBackgroundColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                Invalidate(true);
                // this.panel2.Invalidate();
            }
        }




        /// <summary>
        /// Gets or Sets right head image icon.
        /// </summary>
        [Description("Gets or Sets right head image icon."), Category("Saa")]
        public Image RightImage
        {
            get
            {
                return saaPictureBox1.Image;
            }
            set
            {
                saaPictureBox1.Image = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets left head image icon.
        /// </summary>
        [Description("Gets or Sets left head image icon."), Category("Saa")]
        public Image LeftImage
        {
            get
            {
                return saaPictureBox2.Image;
            }
            set
            {
                saaPictureBox2.Image = value;
                Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or Sets whether left head image icon is visible.
        /// </summary>
        [Description("Gets or Sets whether left head image icon is visible."), Category("Saa")]
        public bool LeftImageVisible
        {
            get
            {
                return saaPictureBox2.Visible;
            }
            set
            {
                saaPictureBox2.Visible = value;
                Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or Sets whether right head image icon is visible.
        /// </summary>
        [Description("Gets or Sets whether right head image icon is visible."), Category("Saa")]
        public bool RightImageVisible
        {
            get
            {
                return saaPictureBox1.Visible;
            }
            set
            {
                saaPictureBox1.Visible = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets right head image icon sizing mode.
        /// </summary>
        [Description("Gets or Sets right head image icon sizing mode."), Category("Saa")]
        public PictureBoxSizeMode RightImageSizeMode
        {
            get
            {
                return saaPictureBox1.SizeMode;
            }
            set
            {
                saaPictureBox1.SizeMode = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets left head image icon sizing mode.
        /// </summary>
        [Description("Gets or Sets left head image icon sizing mode."), Category("Saa")]
        public PictureBoxSizeMode LeftImageSizeMode
        {
            get
            {
                return saaPictureBox2.SizeMode;
            }
            set
            {
                saaPictureBox2.SizeMode = value;
                Invalidate(true);
            }
        }
       

        /// <summary>
        /// Gets or Sets text of the head.
        /// </summary>
        [Description("Gets or Sets text of the head."), Category("Saa")]
        public string Value
        {
            get
            {
                return saaLabel1.Text;
            }
            set
            {
                saaLabel1.Text = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets text color of the head.
        /// </summary>
        [Description("Gets or Sets text color of the head."), Category("Saa")]
        public Color TextColor
        {
            get
            {
                return saaLabel1.ForeColor;
            }
            set
            {
                saaLabel1.ForeColor = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets text font of the head.
        /// </summary>
        [Description("Gets or Sets text font of the head."), Category("Saa")]
        public Font TextFont
        {
            get
            {
                return saaLabel1.Font;
            }
            set
            {
                saaLabel1.Font = value;
                Invalidate(true);
            }
        }
        /// <summary>
        /// Gets or Sets text alignment of the head.
        /// </summary>
        [Description("Gets or Sets text alignment of the head."), Category("Saa")]
        public ContentAlignment TextPosition
        {
            get
            {
                return saaLabel1.TextAlign;
            }
            set
            {
                saaLabel1.TextAlign = value;
                Invalidate(true);
            }
        }






        #endregion

        private void saaPictureBox2_Click(object sender, EventArgs e)
        {
            DropwDownForm d = new DropwDownForm();
            d.Items = new SaaDropDownItem[]
            {
                new SaaDropDownItem()
                {
                    Value = "1"
                },
                new SaaDropDownItem()
                {
                    Value = "2"
                },
                new SaaDropDownItem()
                {
                    Value = "3"
                },
                new SaaDropDownItem()
                {
                    Value = "4"
                },
                new SaaDropDownItem()
                {
                    Value = "5"
                },
                new SaaDropDownItem()
                {
                    Value = "6"
                }
            };
            d.Loc = this.FindForm().PointToScreen(this.LocationRelativeToForm());
            d.FormSize = new Size(this.Width, 300);
            d.DrawTranspancy();
            d.Show();

        }
    }
}
