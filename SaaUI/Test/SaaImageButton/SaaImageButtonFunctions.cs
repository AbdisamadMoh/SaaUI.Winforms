
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    partial class SaaImageButton
    {
        private void UpdateRadius()
        {
            switch (_RadiusType)
            {
                case RadiusType.Circle:
                    {
                        _RadiusWith = this.Height / 2;
                        this.Width = this.Height;

                        _InnerRadiusWith = this.panel1.Height / 2;
                      //  this.panel1.Width = this.Height;
                        SetRadius();
                        break;
                    }
                case RadiusType.Rectangle:
                    {
                        _RadiusWith = 1;
                        _InnerRadiusWith = 1;
                        SetRadius();
                        break;
                    }
                case RadiusType.RoundedEdge:
                    {
                        _RadiusWith = this.Height / 2;

                        _InnerRadiusWith = this.panel1.Height / 2;
                        SetRadius();
                        break;
                    }
                case RadiusType.Custom:
                    {
                        
                        SetRadius();
                        break;
                    }
            }
        }
        private void SetRadius()
        {
            if (_RadiusType != RadiusType.Custom)
            {
               
                GraphicsPath path = RoundedRectangle.Create(this.ClientRectangle, GetRadius(_RadiusWith), RoundedRectangle.RectangleCorners.All);
                this.Region = new Region(path);

                GraphicsPath path1 = RoundedRectangle.Create(this.panel1.ClientRectangle, GetRadius(_InnerRadiusWith), RoundedRectangle.RectangleCorners.All);
                this.panel1.Region = new Region(path1);
            }
            else
            {
                UpdateCustomRadius();
            }

        }
       
        private void UpdateCustomRadius()
        {
            if(_RadiusType == RadiusType.Custom)
            {

                GraphicsPath path = RoundedRectangle.Create(this.ClientRectangle, GetRadius(_RadiusWith), _BorderRadiusTarget);
                this.Region = new Region(path);

                GraphicsPath path1 = RoundedRectangle.Create(this.panel1.ClientRectangle, GetRadius(GetInnerRadius()), _BorderRadiusTarget);
                this.panel1.Region = new Region(path1);
            }
        }

        private int GetRadius(int radius)
        {
            int r = 1;
            if (radius > 0)
            {
                r = radius;
            }
            return r;
        }
        private int GetInnerRadius()
        {
            int r = 0;
            try
            {
                int i = (GetRadius(_RadiusWith) - this.Padding.Vertical+1);
                if (i > 1)
                {
                    r = i;
                }
                else
                {
                    r = 0;
                }
            }
            catch { r = 0; }

            return r;
        }

        //-------------------------
        private void PositionImage()
        {
            if(_ImagePosition == ButtonImagePosition.Left)
            {
                this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            }
            else
            {
                this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            }
        }

        private void UpdateBorder()
        {

            // Invalidate();
            if (_ShowBorder)
            {
                this.BackColor = _BorderColor;
            }
            else
            {
                this.BackColor = panel1.BackColor;
            }

            if (ShowBorder)
            {
                this.Padding = new Padding(_BorderThickness);
            }
            else
            {
                this.Padding = new Padding(0);
            }
           // _Padding = this.Padding;


        }

        private void UpdateOnMove()
        {
            if (this.panel1.BackColor == Color.Transparent)
            {
                if (this.Parent != null)
                {
                    this.panel1.BackColor = this.Parent.BackColor;
                }
            }
        }

    }
}
