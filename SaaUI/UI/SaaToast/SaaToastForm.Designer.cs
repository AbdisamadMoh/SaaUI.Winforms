namespace SaaUI
{
    partial class SaaToastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saaPanel1 = new SaaUI.SaaPanel();
            this.saaLabel2 = new SaaUI.SaaLabel();
            this.saaPictureBox2 = new SaaUI.SaaPictureBox();
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.saaPictureBox1 = new SaaUI.SaaPictureBox();
            this.saaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saaPanel1
            // 
            this.saaPanel1.BackColor = System.Drawing.Color.Transparent;
            this.saaPanel1.BackColor2 = System.Drawing.Color.Transparent;
            this.saaPanel1.BackColorAngle = 90F;
            this.saaPanel1.Border = 0;
            this.saaPanel1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPanel1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPanel1.BorderColorAngle = 0;
            this.saaPanel1.ColorType = SaaUI.PanelColorType.Default;
            this.saaPanel1.Controls.Add(this.saaLabel2);
            this.saaPanel1.Controls.Add(this.saaPictureBox2);
            this.saaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saaPanel1.EnableDoubleBuffering = false;
            this.saaPanel1.ForceDrawRegion = true;
            this.saaPanel1.Location = new System.Drawing.Point(0, 0);
            this.saaPanel1.Name = "saaPanel1";
            this.saaPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.saaPanel1.Size = new System.Drawing.Size(270, 30);
            this.saaPanel1.TabIndex = 1;
            this.saaPanel1.Transparence = 100;
            this.saaPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            this.saaPanel1.MouseEnter += new System.EventHandler(this.saaLabel1_MouseEnter_1);
            this.saaPanel1.MouseLeave += new System.EventHandler(this.saaPictureBox2_MouseLeave);
            // 
            // saaLabel2
            // 
            this.saaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaLabel2.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saaLabel2.Location = new System.Drawing.Point(5, 0);
            this.saaLabel2.Name = "saaLabel2";
            this.saaLabel2.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.saaLabel2.Size = new System.Drawing.Size(238, 25);
            this.saaLabel2.TabIndex = 1;
            this.saaLabel2.Text = "Notice!";
            this.saaLabel2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.saaLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            this.saaLabel2.MouseEnter += new System.EventHandler(this.saaLabel1_MouseEnter_1);
            this.saaLabel2.MouseLeave += new System.EventHandler(this.saaPictureBox2_MouseLeave);
            // 
            // saaPictureBox2
            // 
            this.saaPictureBox2.Border = 0;
            this.saaPictureBox2.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColorAngle = 0;
            this.saaPictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.saaPictureBox2.Image = global::SaaUI.Properties.Resources.icons8_Multiply_32;
            this.saaPictureBox2.Location = new System.Drawing.Point(243, 0);
            this.saaPictureBox2.Name = "saaPictureBox2";
            this.saaPictureBox2.Padding = new System.Windows.Forms.Padding(5);
            this.saaPictureBox2.Size = new System.Drawing.Size(27, 25);
            this.saaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saaPictureBox2.TabIndex = 2;
            this.saaPictureBox2.TabStop = false;
            this.saaPictureBox2.Click += new System.EventHandler(this.saaPictureBox2_Click);
            this.saaPictureBox2.MouseEnter += new System.EventHandler(this.saaLabel1_MouseEnter_1);
            this.saaPictureBox2.MouseLeave += new System.EventHandler(this.saaPictureBox2_MouseLeave);
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel1.Location = new System.Drawing.Point(32, 30);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(238, 50);
            this.saaLabel1.TabIndex = 2;
            this.saaLabel1.Text = "Your request is being processed and we will \r\nnotify you once done.";
            this.saaLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            this.saaLabel1.MouseEnter += new System.EventHandler(this.saaLabel1_MouseEnter_1);
            this.saaLabel1.MouseLeave += new System.EventHandler(this.saaPictureBox2_MouseLeave);
            // 
            // saaPictureBox1
            // 
            this.saaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.saaPictureBox1.Border = 0;
            this.saaPictureBox1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColorAngle = 0;
            this.saaPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.saaPictureBox1.Image = global::SaaUI.Properties.Resources.icons8_Ok_32;
            this.saaPictureBox1.Location = new System.Drawing.Point(0, 30);
            this.saaPictureBox1.Name = "saaPictureBox1";
            this.saaPictureBox1.Size = new System.Drawing.Size(32, 50);
            this.saaPictureBox1.TabIndex = 3;
            this.saaPictureBox1.TabStop = false;
            this.saaPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            this.saaPictureBox1.MouseEnter += new System.EventHandler(this.saaLabel1_MouseEnter_1);
            this.saaPictureBox1.MouseLeave += new System.EventHandler(this.saaPictureBox2_MouseLeave);
            // 
            // SaaToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(270, 80);
            this.ControlBox = false;
            this.Controls.Add(this.saaLabel1);
            this.Controls.Add(this.saaPictureBox1);
            this.Controls.Add(this.saaPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaaToastForm";
            this.Radius.BottomLeft = 3;
            this.Radius.BottomRight = 3;
            this.Radius.TopLeft = 3;
            this.Radius.TopRight = 3;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaaToast";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SaaToastForm_Load);
            this.saaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public SaaPanel saaPanel1;
        public SaaLabel saaLabel2;
        public SaaLabel saaLabel1;
        public SaaPictureBox saaPictureBox1;
        public SaaPictureBox saaPictureBox2;
    }
}
