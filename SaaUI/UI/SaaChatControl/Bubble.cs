using System.Drawing;
using System;
using System.Text;
using System.Drawing.Drawing2D;
using SaaUI.Properties;
using System.Windows.Forms;

namespace SaaUI
{
    public class SaaBubble
    {
       public SaaBubble()
        {

        }
        public string ID { get; set; }
        public string Style { get; set; }
        public SaaSize MinimumSize { get; set; } = new SaaSize(45, 20, SaaSizePercentOrPixel.Pixel, SaaSizePercentOrPixel.Percent);
        public SaaSize MaximumSize { get; set; } = new SaaSize(0, 80, SaaSizePercentOrPixel.Pixel, SaaSizePercentOrPixel.Percent);
        public Color BackColor { get; set; } = Color.Blue;
        public Color ForeColor { get; set; } = Color.White;
        public Font Font { get; set; } = new Font("serif", 14);
        public Point Position { get; set; } = new Point(56, 10);
        public Radius Radius { get; set; } = new Radius(10, 10, 10, 10);
        public Color BorderColor { get; set; } = Color.Transparent;
        public int BordThickness { get; set; } = 1;
        public SaaBubbleWordBreak WordBreak { get; set; } = SaaBubbleWordBreak.BreakWord;
        public SaaBubbleBorderStyle BorderStyle { get; set; } = SaaBubbleBorderStyle.None;
        public Padding Padding { get; set; } = new Padding(10, 10, 10, 10);
        public Padding Margin { get; set; } = new Padding(1);
        public string Text { get; set; }
        public SaaBubbleProfile Profile { get; set; } = new SaaBubbleProfile()
        {
            Size = new Size(40,40),
            Radius = new Radius(20,20,20,20),
            BordThickness = 1,
            BorderColor = Color.SkyBlue,
            BorderStyle = SaaBubbleBorderStyle.Solid,
            BackColor = Color.Transparent
        };
        public SaaBubbleStatus Status { get; set; } = new SaaBubbleStatus()
        {
            Size = new Size(13,13),
            Position = new Point(8,20),
            Image = Resources.icons8_Ok_32
        };
        public SaaBubbleTime Time { get; set; } = new SaaBubbleTime()
        {
            Font = new Font("serif", 11),
            ForeColor = Color.White,
            Position = new Point(65,8)
        };

    }
    public class SaaBubbleProfile
    {
        public Image Image { get; set; }
        public Radius Radius { get; set; }
        public Color BorderColor { get; set; }
        public int BordThickness { get; set; }
        public Size Size { get; set; }
        public SaaBubbleBorderStyle BorderStyle { get; set; } = SaaBubbleBorderStyle.Solid;
        public Color BackColor { get; set; }
    }
    public class SaaBubbleStatus
    {
        public Size Size { get; set; }
        public Image Image { get; set; }
        public Point Position { get; set; }

    }
    public class SaaBubbleTime
    {
        public string Time { get; set; }
        public Color ForeColor { get; set; }
        public Point Position { get; set; }
        public Font Font { get; set; }

    }
    public class SaaSize
    {
        public SaaSize()
        {

        }
        public SaaSize(int Height, int Width, SaaSizePercentOrPixel SizeIn)
        {
            this.Height = Height;
            this.Width = Width;
            this.WidthIn = this.HeightIn = SizeIn;
        }
        public SaaSize(int Height, int Width, SaaSizePercentOrPixel HeightIn, SaaSizePercentOrPixel WidthIn)
        {
            this.Height = Height;
            this.Width = Width;
            this.WidthIn = WidthIn;
            this.HeightIn = HeightIn;
        }
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public SaaSizePercentOrPixel WidthIn { get; set; } = SaaSizePercentOrPixel.Pixel;
        public SaaSizePercentOrPixel HeightIn { get; set; } = SaaSizePercentOrPixel.Pixel;
    }
}
