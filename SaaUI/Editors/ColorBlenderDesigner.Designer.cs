namespace SaaUI.SaaUse
{
    partial class ColorBlenderDesigner
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saaButton1 = new SaaUI.SaaButton1();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saaButton2 = new SaaUI.SaaButton1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(323, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            // 
            // saaButton1
            // 
            this.saaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.saaButton1.ClickBackColor = System.Drawing.Color.Empty;
            this.saaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatAppearance.BorderSize = 0;
            this.saaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saaButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.Location = new System.Drawing.Point(463, 35);
            this.saaButton1.Name = "saaButton1";
            this.saaButton1.Size = new System.Drawing.Size(71, 23);
            this.saaButton1.TabIndex = 2;
            this.saaButton1.Text = "Add";
            this.saaButton1.UseVisualStyleBackColor = false;
            this.saaButton1.Click += new System.EventHandler(this.saaButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(323, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(211, 240);
            this.dataGridView1.TabIndex = 3;
            // 
            // saaButton2
            // 
            this.saaButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.ClickBackColor = System.Drawing.Color.Empty;
            this.saaButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.FlatAppearance.BorderSize = 0;
            this.saaButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saaButton2.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.Location = new System.Drawing.Point(146, 214);
            this.saaButton2.Name = "saaButton2";
            this.saaButton2.Size = new System.Drawing.Size(85, 42);
            this.saaButton2.TabIndex = 4;
            this.saaButton2.Text = "saaButton2";
            this.saaButton2.UseVisualStyleBackColor = false;
            this.saaButton2.Click += new System.EventHandler(this.saaButton2_Click);
            // 
            // ColorBlenderDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(558, 335);
            this.Controls.Add(this.saaButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saaButton1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ColorBlenderDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorBlenderDesigner";
            this.Load += new System.EventHandler(this.ColorBlenderDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private SaaButton1 saaButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SaaButton1 saaButton2;
    }
}
