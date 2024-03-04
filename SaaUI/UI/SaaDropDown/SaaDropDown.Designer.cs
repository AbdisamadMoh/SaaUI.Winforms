
namespace SaaUI
{
    partial class SaaDropDown
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.saaPictureBox1 = new SaaUI.SaaPictureBox();
            this.saaPictureBox2 = new SaaUI.SaaPictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.saaLabel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.saaPictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.saaPictureBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.saaPictureBox2_Click);
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saaLabel1.Location = new System.Drawing.Point(39, 5);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(108, 30);
            this.saaLabel1.TabIndex = 0;
            this.saaLabel1.Text = "saaLabel1";
            this.saaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saaLabel1.Click += new System.EventHandler(this.saaPictureBox2_Click);
            // 
            // saaPictureBox1
            // 
            this.saaPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saaPictureBox1.Border = 0;
            this.saaPictureBox1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColorAngle = 0;
            this.saaPictureBox1.Image = global::SaaUI.Properties.Resources.InActiveArrowDown_32;
            this.saaPictureBox1.Location = new System.Drawing.Point(153, 8);
            this.saaPictureBox1.Name = "saaPictureBox1";
            this.saaPictureBox1.Size = new System.Drawing.Size(25, 24);
            this.saaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saaPictureBox1.TabIndex = 1;
            this.saaPictureBox1.TabStop = false;
            this.saaPictureBox1.Click += new System.EventHandler(this.saaPictureBox2_Click);
            // 
            // saaPictureBox2
            // 
            this.saaPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saaPictureBox2.Border = 0;
            this.saaPictureBox2.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox2.BorderColorAngle = 0;
            this.saaPictureBox2.Location = new System.Drawing.Point(8, 8);
            this.saaPictureBox2.Name = "saaPictureBox2";
            this.saaPictureBox2.Size = new System.Drawing.Size(25, 24);
            this.saaPictureBox2.TabIndex = 2;
            this.saaPictureBox2.TabStop = false;
            this.saaPictureBox2.Click += new System.EventHandler(this.saaPictureBox2_Click);
            // 
            // SaaDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SaaDropDown";
            this.Size = new System.Drawing.Size(186, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SaaLabel saaLabel1;
        private SaaPictureBox saaPictureBox1;
        private SaaPictureBox saaPictureBox2;
    }
}
