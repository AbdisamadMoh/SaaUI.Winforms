using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace TableTest
{
    public partial class UserControl1 : UserControl
    { 
        ReoGridControl reogrid = new ReoGridControl();
        public UserControl1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            reogrid.Dock = DockStyle.Fill;
            reogrid.BringToFront();
            this.panel2.Controls.Add(reogrid);
            var rgcs = new ControlAppearanceStyle();
            rgcs[ControlAppearanceColors.LeadHeadNormal] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.LeadHeadHover] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.LeadHeadSelected] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.LeadHeadIndicatorStart] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.LeadHeadIndicatorEnd] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.ColHeadSplitter] = Color.FromArgb(255, 176, 196, 222);
            rgcs[ControlAppearanceColors.ColHeadNormalStart] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.ColHeadNormalEnd] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.ColHeadHoverStart] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadHoverEnd] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadSelectedStart] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadSelectedEnd] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadFullSelectedStart] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadFullSelectedEnd] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.ColHeadInvalidStart] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadInvalidEnd] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadText] = Color.FromArgb(255, 0, 0, 139);
            rgcs[ControlAppearanceColors.RowHeadSplitter] = Color.FromArgb(255, 238, 238, 238);
            rgcs[ControlAppearanceColors.RowHeadNormal] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.RowHeadHover] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.RowHeadSelected] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.RowHeadFullSelected] = Color.FromArgb(255, 238, 238, 255);
            rgcs[ControlAppearanceColors.RowHeadInvalid] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.RowHeadText] = Color.FromArgb(255, 0, 0, 139);
            rgcs[ControlAppearanceColors.SelectionBorder] = Color.FromArgb(180, 0, 120, 215);
            rgcs[ControlAppearanceColors.SelectionFill] = Color.FromArgb(118, 210, 210, 255);
            rgcs[ControlAppearanceColors.GridBackground] = Color.FromArgb(255, 255, 255, 255);
            rgcs[ControlAppearanceColors.GridText] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.GridLine] = Color.FromArgb(255, 210, 210, 255);
            rgcs[ControlAppearanceColors.OutlinePanelBorder] = Color.FromArgb(255, 192, 192, 192);
            rgcs[ControlAppearanceColors.OutlinePanelBackground] = Color.FromArgb(255, 240, 240, 240);
            rgcs[ControlAppearanceColors.OutlineButtonBorder] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.OutlineButtonText] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.SheetTabBorder] = Color.FromArgb(255, 0, 120, 215);
            rgcs[ControlAppearanceColors.SheetTabBackground] = Color.FromArgb(255, 255, 255, 255);
            rgcs[ControlAppearanceColors.SheetTabText] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.SheetTabSelected] = Color.FromArgb(255, 255, 255, 255);
            rgcs.SelectionBorderWidth = 1;
            this.reogrid.ControlStyle = rgcs;

        }
        public ReoGridControl reo
        {
            get
            {
                return reogrid;
            }
            set
            {
                reogrid = value;
            }
        }
        bool isd = false;
        int pf = 0;
        int pt = 0;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int prevY = 1;
            // / 20 > 80 ? mx - scrl1.LargeChange - 1 : mx;

            var vh = panel2.DisplayRectangle;
            var scr =saaScroller1;
            int count = 0;
                for (int i = scr.Value; i < scr.Value + this.Height - 20; i += 20)
                {
                    e.Graphics.DrawRectangle(Pens.Black, 1, count, this.panel2.Width - 5, 20);
                    e.Graphics.DrawString(((i/20+1)).ToString(), Font, Brushes.Black, 5, count);
                    count += 20;

                    Parent.Text = "X: " + scr.Value + " Y: " + i + " mx: " + vh.Height + " W:" + vh.Width;

                }
            
        
        }

        public static Rectangle GetVisibleRectangle(ScrollableControl sc, Control child)
        {
            Rectangle work = child.Bounds;
            work.Intersect(sc.ClientRectangle);
            return work;
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
          
            panel2.Invalidate(true);
            OnScroll(e);
        }

        private void scrl1_ValueChanged(object sender, EventArgs e)
        {
            panel2.Invalidate(true);
           
        }
        int scValue = 0;
        protected override void OnScroll(ScrollEventArgs se)
        {
            //if (se.Type == ScrollEventType.LargeIncrement)
            //{
            //    scValue += 80;
            //}
            //else if (se.Type == ScrollEventType.LargeDecrement)
            //{
            //    scValue -= scValue < 80 ? 0 : 80;
            //}
            //else if (se.Type == ScrollEventType.SmallIncrement)
            //{
            //    scValue += 20;
            //}
            //else if (se.Type == ScrollEventType.SmallDecrement)
            //{
            //    scValue -= scValue < 20 ? 0 : 20;
            //}
            //else if (se.Type == ScrollEventType.First)
            //{
            //    scValue = 0;
            //}
            //else if (se.Type == ScrollEventType.ThumbPosition)
            //{
            //    scValue += 80;
            //}
            //else if (se.Type == ScrollEventType.Last)
            //{
            //    scValue = mx;
            //}

            base.OnScroll(se);
        }
        Int32 mx=10;
        public Int32 max
        {
            get
            {
                return mx;
            }
            set
            {
                mx = value;
                this.saaScroller1.Maximum=mx*20;// = new Size(0, mx);
                panel2.Invalidate(true);
            }
        }
    }

    class pnl : Panel
    {
        public pnl()
        {
            DoubleBuffered = true;
        }
    }
    class scrl : VScrollBar
    {

    }
}
