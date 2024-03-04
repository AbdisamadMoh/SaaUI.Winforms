using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class DropwDownForm : SaaNonFocusForm
    {
        public DropwDownForm()
        {
            InitializeComponent();
            tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
            Init();
        }
        private void Init()
        {
            this.Size = FormSize;
            tableLayoutPanel1.RowStyles.Clear();
            if (Items != null)
            {
                foreach(var item in Items)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, GetMaxHeight(item)));
                }
                LayoutRows();
            }
        }
        private void LayoutRows()
        {
            foreach(RowStyle row in tableLayoutPanel1.RowStyles)
            {
                row.SizeType = SizeType.Absolute;
            }
            var cols = tableLayoutPanel1.ColumnStyles;
            cols[0].Width = LeftImageWidth;
            cols[0].SizeType = SizeType.Absolute;
            cols[1].Width = 100;
            cols[1].SizeType = SizeType.Percent;
            cols[2].Width = RightImageWidth;
            cols[2].SizeType = SizeType.Absolute;
        }
        private float GetMaxHeight(SaaDropDownItem item)
        {
            float mh = RowHeight;
            if (RowHeight < 1)
            {
                
                if(item != null)
                {
                    if (item.Value != "")
                    {
                        var g = this.CreateGraphics();
                        mh = g.MeasureString(item.Value, this.Font).Height;
                    }
                }
            }

            return mh;
        }
        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(Items!=null && Items.Length > 0)
            {
                var item = Items[e.Row];
                if (item != null)
                {
                    var g = e.Graphics;
                    if (e.Column == 0)
                    {
                        if (item.LeftImage != null && LeftImageWidth>0)
                        {
                            g.DrawImage(item.LeftImage, 0, 0, LeftImageWidth, RowHeight);
                        }
                    }
                    if (e.Column == 2)
                    {
                        if (item.RightImage != null && RightImageWidth > 0)
                        {
                            g.DrawImage(item.RightImage, 0, 0, RightImageWidth, RowHeight);
                        }
                    }
                    if (e.Column == 1)
                    {
                        var sz = g.MeasureString(item.Value, this.Font);
                        var x = 3;
                        var y = e.CellBounds.Height / 2 - sz.Height / 2;
                        g.DrawString(item.Value,this.Font,Brushes.Blue, x, y);

                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, this.FormSize));
        }
        private void DropwDownForm_Load(object sender, EventArgs e)
        {

        }

        public SaaDropDownItem[] Items { get; set; }
        public float RowHeight { get; set; } = 30;
        public float LeftImageWidth { get; set; } = 30;
        public float RightImageWidth { get; set; } = 30;
       
    }

    internal class SaaDropDownItem
    {
        public Image LeftImage { get; set; }
        public Image RightImage { get; set; }
        public string Value { get; set; }
    }
}
