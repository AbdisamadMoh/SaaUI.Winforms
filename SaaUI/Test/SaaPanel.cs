using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    class SaaPanel:Panel
    {
      
        RoundCorners _Corners = RoundCorners.All;
        public RoundCorners CornerRadius
        {
            get
            {
                return _Corners;
            }
            set
            {
                _Corners = value;
                Invalidate();
            }
        }
        int _radius = 10;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                Invalidate();
            }
        }
        bool isAdded = false;
        protected override void OnPaint(PaintEventArgs e)
        {

            var rec = new RoundedRectangleF(Width, Height, _radius, _Corners);
            this.Region = new Region(rec.Path);
                
            
            if (!isAdded)
            {
                //this.DoubleBuffered = true;
                this.innerPanel.AutoSize = true;
                this.innerPanel.Dock = DockStyle.Fill;
                this.Controls.Add(innerPanel);
                isAdded = true;
            }
            //using (Pen pen = new Pen(Color.Black, 2))
            //{
            //    using (GraphicsPath path = new RoundedRectangleF(Width - (_radius > 0 ? 0 : 1), Height - (_radius > 0 ? 0 : 1), _radius).Path)
            //    {
            //        e.Graphics.DrawPath(pen, path);
            //    }
            //}
            base.OnPaint(e);
        }

        int _borderdepth = 2;
        public int BorderDepth {
            get
            {
                return _borderdepth;
            }
            set
            {
                _borderdepth = value;
                Invalidate();
            }
        }

        Padding _PrevPadding = new Padding();
        Panel innerPanel = new Panel();
        
      
       
        private void UpdatePadding()
        {
            //add Adjust padding with border... it is avoid looping
           
        }
    }
    public class CollectionEditor : UITypeEditor
    {

    }
}
