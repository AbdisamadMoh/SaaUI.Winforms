namespace TableTest
{
    partial class UserControl1
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new TableTest.pnl();
            this.saaScroller1 = new SaaUI.SaaScroller();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 276);
            this.panel2.TabIndex = 0;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // saaScroller1
            // 
            this.saaScroller1.Dock = System.Windows.Forms.DockStyle.Right;
            this.saaScroller1.LargeChange = 80;
            this.saaScroller1.Location = new System.Drawing.Point(412, 0);
            this.saaScroller1.Name = "saaScroller1";
            this.saaScroller1.Size = new System.Drawing.Size(19, 276);
            this.saaScroller1.SmallChange = 20;
            this.saaScroller1.TabIndex = 0;
            this.saaScroller1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.saaScroller1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(431, 276);
            this.ResumeLayout(false);

        }

        #endregion

        private pnl panel2;
        private SaaUI.SaaScroller saaScroller1;
    }
}
