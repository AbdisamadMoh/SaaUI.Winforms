using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    [DefaultEvent("TextChanged")]
    public partial class SaaCustomTextBox : UserControl
    {
        private TextBox textBox1;
        private Panel panel1;
        private Panel panel2;
        Label lb = new Label();
        public new delegate void OnTextChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when text of the control is changed.
        /// </summary>
        [Description("Fires when text of the control is changed.")]
        [Browsable(true)]
        public new event OnTextChanged TextChanged;

        public SaaCustomTextBox()
        {
            InitializeComponent();
            // AutoSize = false;

            lb.Dock = DockStyle.Bottom;
            lb.Size = new System.Drawing.Size(3, 2);
            lb.BackColor = "#505050".FromHex();
            this.Controls.Add(lb);
            SaaPictureBox pic = new SaaPictureBox();
            pic.Image = Resources.icons8_Checked_32;
            pic.Dock = DockStyle.Left;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Padding = new Padding(3);
            pic.Size = new Size(this.Height, this.Height);
            this.panel2.Controls.Add(pic);
            if (this.Parent != null)
            {
                this.BackColor = this.Parent.BackColor;
            }
            MessageBox.Show(did.ToString());
            did = false;
        }
        bool did = true;
        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new RoundedRectangleF(Width, Height, _Radius, _RadiusCorner);
            this.Region = new Region(rec.Path);
            e.Graphics.DrawString(_WaterMarkText, Font, Brushes.Red, textBox1.Location.X, textBox1.Location.Y);
            UpdateControls();
            base.OnPaint(e);
        }
        string _WaterMarkText = "Water Mark";
        public string WaterMarkText
        {
            get
            {
                return _WaterMarkText;
            }
            set
            {
                _WaterMarkText = value;
                Invalidate();
            }
        }


        private void UpdateControls()
        {
            textBox1.BackColor = this.panel1.BackColor = panel2.BackColor = this.BackColor;
            textBox1.Font = this.Font;
            textBox1.Text = this._Text;

        }
        string _Text = "";
        /// <summary>
        /// Gets or Sets Text of the control.
        /// </summary>
        [Description("Gets or Sets Text of the control.")]
        [Category("Saa")]
        [Browsable(true)]
        public new string Text
        {
            get
            {
                return _Text;
            }

            set
            {
                _Text = value;
            }
        }
        int _Radius = 0;
        [Description("Gets or Sets border radius, the roundness of the control.")]
        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value; Invalidate(); }
        }

        RoundCorners _RadiusCorner = RoundCorners.All;
        [Description("Gets or Set which corner will be rounded by the 'Radius' specified")]
        public RoundCorners RadiusCorner
        {
            get { return _RadiusCorner; }
            set { _RadiusCorner = value; Invalidate(); }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }

    }
    partial class SaaCustomTextBox
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
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(4, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 11);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.panel1.Size = new System.Drawing.Size(180, 18);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 29);
            this.panel2.TabIndex = 2;
            // 
            // SaaCustomTextBox
            // 
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.Name = "SaaCustomTextBox";
            this.Size = new System.Drawing.Size(180, 29);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }

}











  

