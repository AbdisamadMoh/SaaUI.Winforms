using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    [DefaultEvent("Clicked")]
    //  [Designer(typeof(SaaControlDesignerAccordion))]
    internal class SaaAccordionHead : UserControl
    {
        internal SaaPictureBox saaPictureBox2;
        internal Label label1;
        internal AccTb tableLayoutPanel1;
        internal SaaPictureBox saaPictureBox1;

        public delegate void OnClick(object sender, EventArgs e);
        public event OnClick Clicked;

        public SaaAccordionHead()
        {
            InitializeComponent();
            BackColor = Color.White;
            DoubleBuffered = true;
            this.CollapsedRadius.Change += CollapsedRadius_Change;
            this.ExapandedRadius.Change += CollapsedRadius_Change;
        }

        private void CollapsedRadius_Change()
        {
            Invalidate();
        }

        public void Call()
        {
            MessageBox.Show("This fired");
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.BackColor = Color.Transparent;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var back = new BorderPath(0, 0, this.Width, this.Height, (!_isexpanded ? _radius : _expradius));
            Brush br = new SolidBrush((_ishover ? _hovercolor : _backcolor));
            g.FillPath(br, back.Path);
            // Pen p = new Pen(_bordercolor, _borderthick);
            //g.DrawPath(p, back.Path);

            //p.Dispose();
            br.Dispose();
            back.Dispose();
            base.OnPaint(e);
        }
        Cursor _cursor = Cursors.Hand;
        bool _ishover = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = _cursor;
            _ishover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            _ishover = false;
            Invalidate();
        }
        Radius _radius = new Radius(1, 1, 1, 1);
        public Radius CollapsedRadius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }
        bool _isexpanded = false;
        public bool Expanded
        {
            get { return _isexpanded; }
            set
            {
                _isexpanded = value;
                Invalidate();
            }
        }
        Radius _expradius = new Radius(1, 1, 0, 0);
        public Radius ExapandedRadius
        {
            get { return _expradius; }
            set
            {
                _expradius = value;
                Invalidate();
            }
        }
        Color _hovercolor = Color.FromArgb(248, 249, 254);
        public Color HoverColor
        {
            get { return _hovercolor; }
            set
            {
                _hovercolor = value;
                Invalidate();
            }
        }
        Color _backcolor = Color.White;
        public new Color BackColor
        {
            get { return _backcolor; }
            set
            {
                _backcolor = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }
        public SaaPictureBox RightImage
        {
            get
            {
                return this.saaPictureBox1;
            }
        }
        public SaaPictureBox LeftImage
        {
            get
            {
                return this.saaPictureBox2;
            }
        }
        public Label Label
        {
            get
            {
                return this.label1;
            }
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new SaaUI.AccTb();
            this.saaPictureBox1 = new SaaUI.SaaPictureBox();
            this.saaPictureBox2 = new SaaUI.SaaPictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "This is header";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.saaPictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.saaPictureBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 54);
            this.tableLayoutPanel1.TabIndex = 4;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.label1_Click);
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // saaPictureBox1
            // 
            this.saaPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.saaPictureBox1.Border = 0;
            this.saaPictureBox1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColorAngle = 0;
            this.saaPictureBox1.Image = global::SaaUI.Properties.Resources.Entypo_e78d_0__32;
            this.saaPictureBox1.Location = new System.Drawing.Point(229, 17);
            this.saaPictureBox1.Name = "saaPictureBox1";
            this.saaPictureBox1.Size = new System.Drawing.Size(20, 20);
            this.saaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saaPictureBox1.TabIndex = 0;
            this.saaPictureBox1.TabStop = false;
            this.saaPictureBox1.Click += new System.EventHandler(this.label1_Click);
            this.saaPictureBox1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.saaPictureBox1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // saaPictureBox2
            // 
            this.saaPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saaPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.saaPictureBox2.Border = 0;
            this.saaPictureBox2.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColorAngle = 0;
            this.saaPictureBox2.Location = new System.Drawing.Point(3, 17);
            this.saaPictureBox2.Name = "saaPictureBox2";
            this.saaPictureBox2.Size = new System.Drawing.Size(19, 20);
            this.saaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saaPictureBox2.TabIndex = 2;
            this.saaPictureBox2.TabStop = false;
            this.saaPictureBox2.Visible = false;
            this.saaPictureBox2.Click += new System.EventHandler(this.label1_Click);
            this.saaPictureBox2.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.saaPictureBox2.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // SaaAccordionHead
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SaaAccordionHead";
            this.Size = new System.Drawing.Size(252, 54);
            this.Click += new System.EventHandler(this.label1_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(sender, e);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
    }
}
