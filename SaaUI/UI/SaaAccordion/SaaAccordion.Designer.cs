
namespace SaaUI
{
    partial class SaaAccordion
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
            SaaUI.Properties.Radius radius1 = new SaaUI.Properties.Radius();
            SaaUI.Properties.Radius radius2 = new SaaUI.Properties.Radius();
            this.Header = new System.Windows.Forms.Panel();
            this.saaAccordionHead1 = new SaaUI.SaaAccordionHead();
            this.Shadow = new SaaUI.SaaShadow();
            this.Body = new SaaUI.AccTb();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Controls.Add(this.saaAccordionHead1);
            this.Header.Controls.Add(this.Shadow);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(236, 50);
            this.Header.TabIndex = 4;
            // 
            // saaAccordionHead1
            // 
            this.saaAccordionHead1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saaAccordionHead1.BackColor = System.Drawing.Color.White;
            this.saaAccordionHead1.CollapsedRadius = radius1;
            this.saaAccordionHead1.ExapandedRadius = radius2;
            this.saaAccordionHead1.Expanded = false;
            this.saaAccordionHead1.HoverColor = System.Drawing.Color.White;
            this.saaAccordionHead1.Location = new System.Drawing.Point(4, 6);
            this.saaAccordionHead1.Name = "saaAccordionHead1";
            this.saaAccordionHead1.Size = new System.Drawing.Size(227, 38);
            this.saaAccordionHead1.TabIndex = 2;
            this.saaAccordionHead1.Clicked += new SaaUI.SaaAccordionHead.OnClick(this.saaAccordionHead1_Clicked);
            this.saaAccordionHead1.Load += new System.EventHandler(this.saaAccordionHead1_Load);
            this.saaAccordionHead1.MouseEnter += new System.EventHandler(this.saaAccordionHead1_MouseEnter);
            this.saaAccordionHead1.MouseLeave += new System.EventHandler(this.saaAccordionHead1_MouseLeave);
            // 
            // Shadow
            // 
            this.Shadow.AutoSet = true;
            this.Shadow.BackColor = System.Drawing.Color.Transparent;
            this.Shadow.Control = this.saaAccordionHead1;
            this.Shadow.InnerColor = System.Drawing.Color.Gainsboro;
            this.Shadow.Location = new System.Drawing.Point(1, 5);
            this.Shadow.Name = "Shadow";
            this.Shadow.OffsetHeight = 4;
            this.Shadow.OffsetWidth = 4;
            this.Shadow.OffsetX = -3;
            this.Shadow.OffsetY = -1;
            this.Shadow.OuterColor = System.Drawing.Color.Transparent;
            this.Shadow.Size = new System.Drawing.Size(236, 47);
            this.Shadow.Spread = 85;
            this.Shadow.TabIndex = 1;
            // 
            // Body
            // 
            this.Body.BackColor = System.Drawing.Color.Transparent;
            this.Body.ColumnCount = 3;
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 50);
            this.Body.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Body.Name = "Body";
            this.Body.RowCount = 3;
            this.Body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.Body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.Body.Size = new System.Drawing.Size(236, 150);
            this.Body.TabIndex = 3;
            // 
            // SaaAccordion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Body);
            this.Controls.Add(this.Header);
            this.Name = "SaaAccordion";
            this.Size = new System.Drawing.Size(236, 200);
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AccTb Body;
        private System.Windows.Forms.Panel Header;
        private SaaAccordionHead saaAccordionHead1;
        public SaaShadow Shadow;
    }
}
