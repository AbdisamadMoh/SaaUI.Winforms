using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SaaUI.Properties;

namespace SaaUI
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SaaUI.SaaButton), "SaaUI.SaaButton.png")]
    [DefaultEvent("OnClick")]
    public partial class SaaImageButton : UserControl
    {
        public SaaImageButton()
        {
            InitializeComponent();
        }
        Graphics MainGraphic;

        protected override void OnPaint(PaintEventArgs e)
        {
            //GraphicsPath path = RoundedRectangle.Create(this.ClientRectangle, _RadiusWith, RoundedRectangle.RectangleCorners.All);
            //this.Region = new Region(path);
            UpdateRadius();
            UpdateBorder();
            UpdateOnMove();
            base.OnPaint(e);
        }

        private void SaaButton_SizeChanged(object sender, EventArgs e)
        {
            if (RadiusType != RadiusType.Custom)
            {
                if (RadiusType == RadiusType.Circle)
                {
                    if (this.Width > this.Height)
                    {
                        this.Height = this.Width;
                        _RadiusWith = this.Height / 2;
                    }
                    else if (this.Height > this.Width)
                    {
                        this.Width = this.Height;
                        _RadiusWith = this.Height / 2;
                    }
                }
                else if (RadiusType == RadiusType.Rectangle)
                {
                    _RadiusWith = 1;
                    SetRadius();
                }
                else if (_RadiusType == RadiusType.RoundedEdge)
                {
                    _RadiusWith = this.Height / 2;
                    SetRadius();
                }
            }
            else
            {
                UpdateCustomRadius();
            }

        }

        private void SaaButton_MouseEnter(object sender, EventArgs e)
        {
            //Choose beautiful hover color and Click Color
            this.panel1.BackColor = _HoverBackColor;
            //label1.BackColor = _HoverTextColor;
        }

        private void SaaButton_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = _BackColor;
            //pictureBox1.BackColor = label1.BackColor;
            // label1.BackColor = _TextBackColor;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel1.BackColor = _ClickColor;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            this.panel1.BackColor = _HoverBackColor;

        }

        private void panel1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.panel1.BackColor == Color.Transparent)
            {
                if (this.Parent != null)
                {
                    this.panel1.BackColor = this.Parent.BackColor;
                }
            }
        }

        private void SaaButton_Move(object sender, EventArgs e)
        {
            //  Invalidate();
            UpdateOnMove();
        }

        private void SaaButton_LocationChanged(object sender, EventArgs e)
        {
            UpdateOnMove();
        }
    }
}
