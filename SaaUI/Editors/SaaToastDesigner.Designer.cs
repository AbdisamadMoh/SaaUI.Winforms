using System.Windows.Forms;

namespace SaaUI
{
    partial class SaaToastDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaaToastDesigner));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saaPanel3 = new System.Windows.Forms.Panel();
            this.saaPanel4 = new Panel();
            this.saaButton1 = new SaaUI.SaaButton();
            this.saaPanel2 = new System.Windows.Forms.Panel();
            this.saaLabel2 = new SaaUI.SaaLabel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.saaPanel1 = new Panel();
            this.saaFormControlBox1 = new SaaUI.SaaFormControlBox();
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.saaPanel3.SuspendLayout();
            this.saaPanel4.SuspendLayout();
            this.saaPanel2.SuspendLayout();
            this.saaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.saaPanel3);
            this.splitContainer1.Panel1.Controls.Add(this.saaPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(706, 369);
            this.splitContainer1.SplitterDistance = 473;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // saaPanel3
            // 
            this.saaPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saaPanel3.Controls.Add(this.saaPanel4);
            this.saaPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaPanel3.Location = new System.Drawing.Point(0, 0);
            this.saaPanel3.Name = "saaPanel3";
            this.saaPanel3.Size = new System.Drawing.Size(473, 326);
            this.saaPanel3.TabIndex = 1;
            // 
            // saaPanel4
            // 
            this.saaPanel4.BackColor = System.Drawing.Color.Transparent;
           
            this.saaPanel4.Controls.Add(this.saaButton1);
            this.saaPanel4.Location = new System.Drawing.Point(185, 143);
            this.saaPanel4.Name = "saaPanel4";
            this.saaPanel4.Padding = new System.Windows.Forms.Padding(3, 2, 2, 3);
            this.saaPanel4.Size = new System.Drawing.Size(102, 40);
            this.saaPanel4.TabIndex = 1;
            this.saaPanel4.Visible = false;
            // 
            // saaButton1
            // 
            this.saaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.saaButton1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.saaButton1.BackColorAngle = 90F;
            this.saaButton1.Border = 0;
            this.saaButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(133)))), ((int)(((byte)(228)))));
            this.saaButton1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(133)))), ((int)(((byte)(228)))));
            this.saaButton1.BorderColorAngle = 0;
            this.saaButton1.ClickColor1 = System.Drawing.Color.Empty;
            this.saaButton1.ClickColor2 = System.Drawing.Color.Empty;
            this.saaButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saaButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaButton1.EnableDoubleBuffering = true;
            this.saaButton1.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saaButton1.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saaButton1.Icon = null;
            this.saaButton1.IconOffsetX = 5F;
            this.saaButton1.IconOffsetY = 5F;
            this.saaButton1.IconSize = new System.Drawing.Size(20, 20);
            this.saaButton1.Location = new System.Drawing.Point(3, 2);
            this.saaButton1.Name = "saaButton1";
            this.saaButton1.Radius.BottomLeft = 17;
            this.saaButton1.Radius.BottomRight = 17;
            this.saaButton1.Radius.TopLeft = 17;
            this.saaButton1.Radius.TopRight = 17;
            this.saaButton1.Size = new System.Drawing.Size(97, 35);
            this.saaButton1.TabIndex = 0;
            this.saaButton1.TextOffsetX = 0F;
            this.saaButton1.TextOffsetY = 0F;
            this.saaButton1.Value = "Preview";
            this.saaButton1.Click += new System.EventHandler(this.saaButton1_Click_1);
            // 
            // saaPanel2
            // 
            this.saaPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saaPanel2.Controls.Add(this.saaLabel2);
            this.saaPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saaPanel2.Location = new System.Drawing.Point(0, 326);
            this.saaPanel2.Name = "saaPanel2";
            this.saaPanel2.Size = new System.Drawing.Size(473, 43);
            this.saaPanel2.TabIndex = 0;
            // 
            // saaLabel2
            // 
            this.saaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel2.ForeColor = System.Drawing.Color.Black;
            this.saaLabel2.Location = new System.Drawing.Point(11, 4);
            this.saaLabel2.Name = "saaLabel2";
            this.saaLabel2.Size = new System.Drawing.Size(457, 40);
            this.saaLabel2.TabIndex = 0;
            this.saaLabel2.Text = "Note: Any changes made here will be reflected to the main Toast";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(189)))));
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(189)))));
            this.propertyGrid1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(189)))));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(232, 369);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(189)))));
            // 
            // saaPanel1
            // 
            this.saaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
          
            this.saaPanel1.Controls.Add(this.saaFormControlBox1);
            this.saaPanel1.Controls.Add(this.saaLabel1);
            this.saaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saaPanel1.Location = new System.Drawing.Point(0, 0);
            this.saaPanel1.Name = "saaPanel1";
            this.saaPanel1.Size = new System.Drawing.Size(706, 29);
            this.saaPanel1.TabIndex = 1;
            this.saaPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            // 
            // saaFormControlBox1
            // 
            this.saaFormControlBox1.CloseActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.CloseActive")));
            this.saaFormControlBox1.CloseInActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.CloseInActive")));
            this.saaFormControlBox1.CloseTip = "Close";
            this.saaFormControlBox1.DisableClose = false;
            this.saaFormControlBox1.DisableMaximize = true;
            this.saaFormControlBox1.DisableMinimize = true;
            this.saaFormControlBox1.Location = new System.Drawing.Point(604, 0);
            this.saaFormControlBox1.MaximizeActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.MaximizeActive")));
            this.saaFormControlBox1.MaximizeInActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.MaximizeInActive")));
            this.saaFormControlBox1.MaximizeTip = "Maximize";
            this.saaFormControlBox1.MinimizeActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.MinimizeActive")));
            this.saaFormControlBox1.MinimizeInActive = ((System.Drawing.Image)(resources.GetObject("saaFormControlBox1.MinimizeInActive")));
            this.saaFormControlBox1.MinimizeTip = "Minimize";
            this.saaFormControlBox1.Name = "saaFormControlBox1";
            this.saaFormControlBox1.ShowClose = true;
            this.saaFormControlBox1.ShowMaximize = true;
            this.saaFormControlBox1.ShowMinimize = true;
            this.saaFormControlBox1.Size = new System.Drawing.Size(90, 30);
            this.saaFormControlBox1.TabIndex = 3;
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.saaLabel1.Location = new System.Drawing.Point(17, 1);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(305, 23);
            this.saaLabel1.TabIndex = 2;
            this.saaLabel1.Text = "SaaToast Designer";
            this.saaLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            // 
            // SaaToastDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 398);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.saaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaaToastDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaaToastDesigner";
            this.Load += new System.EventHandler(this.SaaToastDesigner_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.saaPanel3.ResumeLayout(false);
            this.saaPanel4.ResumeLayout(false);
            this.saaPanel2.ResumeLayout(false);
            this.saaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Panel saaPanel1;
        private Panel saaPanel3;
        private Panel saaPanel2;
        private SaaButton saaButton1;
        private SaaLabel saaLabel1;
        private SaaLabel saaLabel2;
        private Panel saaPanel4;
        private SaaFormControlBox saaFormControlBox1;
    }
}
