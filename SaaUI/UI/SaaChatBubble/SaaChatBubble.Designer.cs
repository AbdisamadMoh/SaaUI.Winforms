using System.Windows.Forms;

namespace SaaUI
{
  public sealed  partial class SaaChatBubble
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.imageMainPanel = new System.Windows.Forms.Panel();
            this.msgPanelHolder = new SaaUI.SaaPanel();
            this.MsgPanel = new SaaUI.SaaPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.imagePanel = new SaaUI.SaaPanel();
            this.saaPictureBox1 = new SaaUI.SaaPictureBox();
            this.LeftPanel.SuspendLayout();
            this.imageMainPanel.SuspendLayout();
            this.msgPanelHolder.SuspendLayout();
            this.MsgPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftPanel.Controls.Add(this.imageMainPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(50, 72);
            this.LeftPanel.TabIndex = 1;
            // 
            // imageMainPanel
            // 
            this.imageMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.imageMainPanel.Controls.Add(this.imagePanel);
            this.imageMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageMainPanel.Location = new System.Drawing.Point(0, 0);
            this.imageMainPanel.Name = "imageMainPanel";
            this.imageMainPanel.Size = new System.Drawing.Size(50, 50);
            this.imageMainPanel.TabIndex = 2;
            // 
            // msgPanelHolder
            // 
            this.msgPanelHolder.AutoSize = true;
            this.msgPanelHolder.BackColor = System.Drawing.Color.Transparent;
            this.msgPanelHolder.BackColor2 = System.Drawing.Color.Transparent;
            this.msgPanelHolder.BackColorAngle = 90F;
            this.msgPanelHolder.Border = 0;
            this.msgPanelHolder.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.msgPanelHolder.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.msgPanelHolder.BorderColorAngle = 0;
            this.msgPanelHolder.ColorType = SaaUI.PanelColorType.Default;
            this.msgPanelHolder.Controls.Add(this.MsgPanel);
            this.msgPanelHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgPanelHolder.EnableDoubleBuffering = true;
            this.msgPanelHolder.ForceDrawRegion = true;
            this.msgPanelHolder.Location = new System.Drawing.Point(50, 0);
            this.msgPanelHolder.Name = "msgPanelHolder";
            this.msgPanelHolder.Size = new System.Drawing.Size(183, 72);
            this.msgPanelHolder.TabIndex = 2;
            this.msgPanelHolder.Transparence = 0;
            // 
            // MsgPanel
            // 
            this.MsgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MsgPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MsgPanel.BackColorAngle = 90F;
            this.MsgPanel.Border = 0;
            this.MsgPanel.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.MsgPanel.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.MsgPanel.BorderColorAngle = 0;
            this.MsgPanel.ColorType = SaaUI.PanelColorType.Default;
            this.MsgPanel.Controls.Add(this.label1);
            this.MsgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MsgPanel.EnableDoubleBuffering = true;
            this.MsgPanel.ForceDrawRegion = true;
            this.MsgPanel.Location = new System.Drawing.Point(0, 0);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.Radius.BottomLeft = 10;
            this.MsgPanel.Radius.BottomRight = 10;
            this.MsgPanel.Radius.TopRight = 10;
            this.MsgPanel.Size = new System.Drawing.Size(183, 72);
            this.MsgPanel.TabIndex = 0;
            this.MsgPanel.Transparence = 100;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(183, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "This a testing message.\r\n\r\nIt can be changed.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.BackColor2 = System.Drawing.Color.White;
            this.imagePanel.BackColorAngle = 90F;
            this.imagePanel.Border = 0;
            this.imagePanel.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.imagePanel.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.imagePanel.BorderColorAngle = 0;
            this.imagePanel.ColorType = SaaUI.PanelColorType.Default;
            this.imagePanel.Controls.Add(this.saaPictureBox1);
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.EnableDoubleBuffering = true;
            this.imagePanel.ForceDrawRegion = true;
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Padding = new System.Windows.Forms.Padding(2);
            this.imagePanel.Radius.BottomLeft = 25;
            this.imagePanel.Radius.BottomRight = 25;
            this.imagePanel.Radius.TopLeft = 25;
            this.imagePanel.Radius.TopRight = 25;
            this.imagePanel.Size = new System.Drawing.Size(50, 50);
            this.imagePanel.TabIndex = 1;
            this.imagePanel.Transparence = 100;
            this.imagePanel.Click += new System.EventHandler(this.imagePanel_Click);
            // 
            // saaPictureBox1
            // 
            this.saaPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.saaPictureBox1.Border = 0;
            this.saaPictureBox1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaPictureBox1.BorderColorAngle = 0;
            this.saaPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saaPictureBox1.Image = global::SaaUI.Properties.Resources.icons8_User_32;
            this.saaPictureBox1.Location = new System.Drawing.Point(2, 2);
            this.saaPictureBox1.Name = "saaPictureBox1";
            this.saaPictureBox1.Radius.BottomLeft = 23;
            this.saaPictureBox1.Radius.BottomRight = 23;
            this.saaPictureBox1.Radius.TopLeft = 23;
            this.saaPictureBox1.Radius.TopRight = 23;
            this.saaPictureBox1.Size = new System.Drawing.Size(46, 46);
            this.saaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.saaPictureBox1.TabIndex = 0;
            this.saaPictureBox1.TabStop = false;
            this.saaPictureBox1.Click += new System.EventHandler(this.imagePanel_Click);
            // 
            // SaaChatBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.msgPanelHolder);
            this.Controls.Add(this.LeftPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 52);
            this.Name = "SaaChatBubble";
            this.Size = new System.Drawing.Size(233, 72);
            this.LeftPanel.ResumeLayout(false);
            this.imageMainPanel.ResumeLayout(false);
            this.msgPanelHolder.ResumeLayout(false);
            this.MsgPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SaaUI.SaaPanel MsgPanel;
        private Panel LeftPanel;
        private SaaUI.SaaPanel imagePanel;
        private SaaPictureBox saaPictureBox1;
        private System.Windows.Forms.Label label1;
        private SaaUI.SaaPanel msgPanelHolder;
        private Panel imageMainPanel;
    }
}
