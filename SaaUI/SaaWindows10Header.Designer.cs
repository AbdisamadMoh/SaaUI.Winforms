namespace SaaUI
{
    partial class SaaWindows10Header
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.Minimize = new SaaUI.SaaPictureBox();
            this.Maximize = new SaaUI.SaaPictureBox();
            this.CloseIcon = new SaaUI.SaaPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 34);
            this.panel1.TabIndex = 0;
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Title_DragEnter);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(388, 34);
            this.Title.TabIndex = 0;
            this.Title.Text = "label1";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Title.DragEnter += new System.Windows.Forms.DragEventHandler(this.Title_DragEnter);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.Border = 0;
            this.Minimize.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Minimize.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.Minimize.BorderColorAngle = 0;
            this.Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.Minimize.Image = global::SaaUI.Properties.Resources.Minimize_16;
            this.Minimize.Location = new System.Drawing.Point(388, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Padding = new System.Windows.Forms.Padding(5);
            this.Minimize.Size = new System.Drawing.Size(34, 34);
            this.Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Minimize.TabIndex = 2;
            this.Minimize.TabStop = false;
            this.Minimize.DragEnter += new System.Windows.Forms.DragEventHandler(this.Title_DragEnter);
            // 
            // Maximize
            // 
            this.Maximize.BackColor = System.Drawing.Color.Transparent;
            this.Maximize.Border = 0;
            this.Maximize.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Maximize.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.Maximize.BorderColorAngle = 0;
            this.Maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.Maximize.Image = global::SaaUI.Properties.Resources.mini1;
            this.Maximize.Location = new System.Drawing.Point(422, 0);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(34, 34);
            this.Maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Maximize.TabIndex = 1;
            this.Maximize.TabStop = false;
            this.Maximize.DragEnter += new System.Windows.Forms.DragEventHandler(this.Title_DragEnter);
            // 
            // CloseIcon
            // 
            this.CloseIcon.BackColor = System.Drawing.Color.Transparent;
            this.CloseIcon.Border = 0;
            this.CloseIcon.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.CloseIcon.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.CloseIcon.BorderColorAngle = 0;
            this.CloseIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseIcon.Image = global::SaaUI.Properties.Resources.X_16;
            this.CloseIcon.Location = new System.Drawing.Point(456, 0);
            this.CloseIcon.Name = "CloseIcon";
            this.CloseIcon.Size = new System.Drawing.Size(34, 34);
            this.CloseIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CloseIcon.TabIndex = 0;
            this.CloseIcon.TabStop = false;
            this.CloseIcon.Click += new System.EventHandler(this.CloseIcon_Click);
            this.CloseIcon.DragEnter += new System.Windows.Forms.DragEventHandler(this.Title_DragEnter);
            // 
            // SaaWindows10Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.CloseIcon);
            this.Name = "SaaWindows10Header";
            this.Size = new System.Drawing.Size(490, 34);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SaaPictureBox CloseIcon;
        private SaaPictureBox Maximize;
        private SaaPictureBox Minimize;
        private System.Windows.Forms.Label Title;
    }
}
