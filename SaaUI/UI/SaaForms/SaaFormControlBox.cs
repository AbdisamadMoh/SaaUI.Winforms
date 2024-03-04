

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
	/// Customizable controlbox for forms.
	/// </summary>
	[Description("Customizable controlbox for forms.")]
    [ToolboxBitmap(typeof(SaaFormControlBox), "icons.SaaControlBox.bmp")]
    [DefaultEvent("Click")]
    public class SaaFormControlBox : UserControl
    {
        ToolTip ToolTip = new ToolTip();
        public SaaFormControlBox()
        {
            InitializeComponent();
        }






        //------------------------------------
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;




        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(90, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::SaaUI.Properties.Resources.icons8_macos_close_90_inActive;
            this.pictureBox3.Location = new System.Drawing.Point(63, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SaaUI.Properties.Resources.icons8_macos_minimize_90_inActive;
            this.pictureBox2.Location = new System.Drawing.Point(33, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SaaUI.Properties.Resources.icons8_macos_maximize_90_inActive;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // SaaFormControlBox
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SaaFormControlBox";
            this.Size = new System.Drawing.Size(90, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Gets Tooltip control associated with this ControlBox.
        /// </summary>
        [Description("Gets Tooltip control associated with this ControlBox."), Category("Saa")]
        public ToolTip ControlToolTip
        {
            get
            {
                return ToolTip;
            }
        }

        Image _closeImage = (Properties.Resources.icons8_macos_close_90_inActive);
        Image _closeImageActive = (Properties.Resources.icons8_macos_close_90_Active);
        Image _minImage = (Properties.Resources.icons8_macos_minimize_90_inActive);
        Image _minImageActive = (Properties.Resources.icons8_macos_minimize_90_Active);
        Image _maxImage = (Properties.Resources.icons8_macos_maximize_90_inActive);
        Image _maxImageActive = (Properties.Resources.icons8_macos_maximize_90_Active);
        /// <summary>
        /// Gets or Sets Image for Close button when inactive
        /// </summary>
        [Description("Gets or Sets Image for Close button when inactive."), Category("Saa")]
        public Image CloseInActive
        {
            get
            {
                return _closeImage;
            }
            set
            {
                pictureBox3.Image = _closeImage = value;
            }
        }

        /// <summary>
        /// Gets or Sets Image for Close button when active
        /// </summary>
        [Description("Gets or Sets Image for Close button when active."), Category("Saa")]
        public Image CloseActive
        {
            get
            {
                return _closeImageActive;
            }
            set
            {
                _closeImageActive = value;
            }
        }

        /// <summary>
        /// Gets or Sets Image for Minimize button when inactive
        /// </summary>
        [Description("Gets or Sets Image for Minimize button when inactive."), Category("Saa")]
        public Image MinimizeInActive
        {
            get
            {
                return _minImage;
            }
            set
            {
                pictureBox2.Image = _minImage = value;
            }
        }
        /// <summary>
        /// Gets or Sets Image for Minimize button when active
        /// </summary>
        [Description("Gets or Sets Image for Minimize button when active."), Category("Saa")]
        public Image MinimizeActive
        {
            get
            {
                return _minImageActive;
            }
            set
            {
                _minImageActive = value;
            }
        }
        /// <summary>
        /// Gets or Sets Image for Maximize button when inactive
        /// </summary>
        [Description("Gets or Sets Image for Maximize button when inactive."), Category("Saa")]
        public Image MaximizeInActive
        {
            get
            {
                return _maxImage;
            }
            set
            {
                pictureBox1.Image = _maxImage = value;
            }
        }
        /// <summary>
        /// Gets or Sets Image for Maximize button when active
        /// </summary>
        [Description("Gets or Sets Image for Maximize button when active."), Category("Saa")]
        public Image MaximizeActive
        {
            get
            {
                return _maxImageActive;
            }
            set
            {
                _maxImageActive = value;
            }
        }
        /// <summary>
        /// Gets or Sets Tooltip for Close button
        /// </summary>
        [Description("Gets or Sets Tooltip for Close button."), Category("Saa")]
        public string CloseTip { get; set; } = "Close";
        /// <summary>
        /// Gets or Sets Tooltip for Minimize button
        /// </summary>
        [Description("Gets or Sets Tooltip for Minimize button."), Category("Saa")]
        public string MinimizeTip { get; set; } = "Minimize";
        /// <summary>
        /// Gets or Sets Tooltip for Maximize button
        /// </summary>
        [Description("Gets or Sets Tooltip for Maximize button."), Category("Saa")]
        public string MaximizeTip { get; set; } = "Maximize";
        /// <summary>
        /// Gets or Sets whether Maximize button is disabled
        /// </summary>
        [Description("Gets or Sets whether Maximize button is disabled."), Category("Saa")]
        public bool DisableMaximize { get; set; } = false;
        /// <summary>
        /// Gets or Sets whether Minimize button is disabled
        /// </summary>
        [Description("Gets or Sets whether Minimize button is disabled."), Category("Saa")]
        public bool DisableMinimize { get; set; } = false;
        /// <summary>
        /// Gets or Sets whether Minimize button is disabled
        /// </summary>
        [Description("Gets or Sets whether Close button is disabled."), Category("Saa")]
        public bool DisableClose { get; set; } = false;
        bool _cV = true;
        bool _minV = true;
        bool _mxV = true;
        /// <summary>
        /// Gets or Sets whether Close button is hidden
        /// </summary>
        [Description("Gets or Sets whether Close button is hidden"), Category("Saa")]
        public bool ShowClose { get { return _cV; } set { _cV = value; HideControl(2, value); } }

        /// <summary>
        /// Gets or Sets whether Minimize button is hidden
        /// </summary>
        [Description("Gets or Sets whether Minimize button is hidden"), Category("Saa")]
        public bool ShowMinimize { get { return _minV; } set { _minV = value; HideControl(1, value); } }

        /// <summary>
        /// Gets or Sets whether Maximize button is hidden
        /// </summary>
        [Description("Gets or Sets whether Maximize button is hidden"), Category("Saa")]
        public bool ShowMaximize { get { return _mxV; } set { _mxV = value; HideControl(0, value); } }
        private void HideControl(int index, bool value)
        {
            if (value)
            {
                tableLayoutPanel1.ColumnStyles[index].SizeType = SizeType.Percent;
                tableLayoutPanel1.ColumnStyles[index].Width = 50;
            }
            else
            {
                tableLayoutPanel1.ColumnStyles[index].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[index].Width = 0;
            }
        }
        private void pictureBox3_Click(object sender, System.EventArgs e)
        {
            if (DisableClose) return;
            FindForm().Close();
        }

        private void pictureBox2_Click(object sender, System.EventArgs e)
        {
            if (DisableMinimize) return;
            FindForm().WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            if (DisableMaximize) return;
            if (FindForm().WindowState == FormWindowState.Maximized)
            {
                FindForm().WindowState = FormWindowState.Normal;
            }
            else
            {
                FindForm().WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox1_MouseEnter(object sender, System.EventArgs e)
        {
            var img = (PictureBox)sender;
            ToolTip.RemoveAll();
            if (img == pictureBox3)
            {
                if (DisableClose) return;
                pictureBox3.Image = CloseActive;
                ToolTip.Show(CloseTip, pictureBox3);
            }
            else if (img == pictureBox2)
            {
                if (DisableMinimize) return;
                pictureBox2.Image = MinimizeActive;
                ToolTip.Show(MinimizeTip, pictureBox2);
            }
            else if (img == pictureBox1)
            {
                if (DisableMaximize) return;
                pictureBox1.Image = MaximizeActive;
                ToolTip.Show(MaximizeTip, pictureBox1);
            }
        }

        private void pictureBox1_MouseLeave(object sender, System.EventArgs e)
        {
            pictureBox1.Image = MaximizeInActive;
        }
        private void pictureBox2_MouseLeave(object sender, System.EventArgs e)
        {
            pictureBox2.Image = MinimizeInActive;
        }
        private void pictureBox3_MouseLeave(object sender, System.EventArgs e)
        {
            pictureBox3.Image = CloseInActive;
        }
    }
}
