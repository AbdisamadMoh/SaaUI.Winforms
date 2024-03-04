using SaaUI;
using SaaUI.Properties;

namespace Using
{
    partial class SaaHTMLEditor
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
            this.saaRichTextBox1 = new SaaUI.SaaHtmlBox();
            this.saaButton2 = new SaaUI.SaaButton();
            this.saaButton1 = new SaaUI.SaaButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.saaLabel2 = new SaaUI.SaaHtmlLabel();
            this.SuspendLayout();
            // 
            // saaRichTextBox1
            // 
            this.saaRichTextBox1.AutoScroll = true;
            this.saaRichTextBox1.AutoScrollMinSize = new System.Drawing.Size(356, 20);
            this.saaRichTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.saaRichTextBox1.BaseStylesheet = null;
            this.saaRichTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.saaRichTextBox1.Location = new System.Drawing.Point(5, 238);
            this.saaRichTextBox1.Name = "saaRichTextBox1";
            this.saaRichTextBox1.Size = new System.Drawing.Size(356, 139);
            this.saaRichTextBox1.TabIndex = 3;
            this.saaRichTextBox1.Text = "saaRichTextBox1";
            // 
            // saaButton2
            // 
            this.saaButton2.BackColor = System.Drawing.Color.Pink;
            this.saaButton2.ClickBackColor = System.Drawing.Color.Empty;
            this.saaButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saaButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.FlatAppearance.BorderSize = 0;
            this.saaButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saaButton2.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton2.Location = new System.Drawing.Point(154, 387);
            this.saaButton2.Name = "saaButton2";
            this.saaButton2.Radius = new SaaUI.Properties.Radius(5,5,0,0);
            this.saaButton2.Size = new System.Drawing.Size(102, 27);
            this.saaButton2.TabIndex = 2;
            this.saaButton2.Text = "Cancel";
            this.saaButton2.UseVisualStyleBackColor = false;
            // 
            // saaButton1
            // 
            this.saaButton1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.saaButton1.ClickBackColor = System.Drawing.Color.Empty;
            this.saaButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatAppearance.BorderSize = 0;
            this.saaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saaButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.Location = new System.Drawing.Point(260, 387);
            this.saaButton1.Name = "saaButton1";
            this.saaButton1.Radius = new Radius(5, 5, 0, 0);
            this.saaButton1.Size = new System.Drawing.Size(102, 27);
            this.saaButton1.TabIndex = 1;
            this.saaButton1.Text = "OK";
            this.saaButton1.UseVisualStyleBackColor = false;
            this.saaButton1.Click += new System.EventHandler(this.saaButton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(5, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(356, 180);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Location = new System.Drawing.Point(5, 217);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(51, 20);
            this.saaLabel1.TabIndex = 5;
            this.saaLabel1.Text = "Preview";
            // 
            // saaLabel2
            // 
            this.saaLabel2.AutoSize = false;
            this.saaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel2.IsSelectionEnabled = false;
            this.saaLabel2.Location = new System.Drawing.Point(8, 10);
            this.saaLabel2.Name = "saaLabel2";
            this.saaLabel2.Size = new System.Drawing.Size(214, 20);
            this.saaLabel2.TabIndex = 6;
            this.saaLabel2.Text = "Text (<b style=\"color:blue;\">HTML</b> and <b style=\"color:green;\">CSS</b> support" +
    "ed)";
            // 
            // SaaHTMLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(367, 415);
            this.Controls.Add(this.saaLabel2);
            this.Controls.Add(this.saaLabel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.saaRichTextBox1);
            this.Controls.Add(this.saaButton2);
            this.Controls.Add(this.saaButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaaHTMLEditor";
            this.Radius = 4;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaaHTMLEditor_FormClosing);
            this.Load += new System.EventHandler(this.SaaHTMLiWin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            this.ResumeLayout(false);

        }

        #endregion
        private SaaButton saaButton1;
        private SaaButton saaButton2;
        private SaaUI.SaaHtmlBox saaRichTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private SaaUI.SaaLabel saaLabel1;
        private SaaUI.SaaHtmlLabel saaLabel2;
    }
}
