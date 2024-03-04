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
using System.IO;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable saaCard.
    /// </summary>
    [Description("Beautiful and customizable saaCard.")]
    [DefaultEvent("Click")]
    [ToolboxBitmap(typeof(SaaCard), "icons.SaaCard_16.bmp")]
    internal partial class SaaChatControl : UserControl
    {
        Dictionary<string, string> _messages = new Dictionary<string, string>();
        public SaaChatControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
           
            webBrowser1.BackColor = Color.Transparent;
        }

        public string AddMessage(SaaBubble message)
        {
            var bubble = ParseMessage(message);
            object[] o = new object[1];
            o[0] = bubble;
            webBrowser1.Document.InvokeScript("AddElement",  o);
            return bubble;
        }
        private string ParseMessage(SaaBubble message)
        {
            var styles = ParseStyles(message);
            var bubble = $"<div {styles.WrapperStyle}> " +
                $"<img src=\" {ImageToBase64(message.Profile.Image)}\" {styles.ImageStyle}/>" +
                $"<div {styles.BubbleStyle}>{message.Text.Replace("\n", "<br/>")}</div>" +
                $"<img {styles.StatusStyle} src=\"{ImageToBase64(message.Status.Image)}\" />" +
                $"<div {styles.TimeStyle}>{message.Time.Time}</div></div>";

            return bubble;
        }
        private string ImageToBase64(Image image)
        {
            if (image == null) return "";
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        private BubbleCss ParseStyles(SaaBubble message)
        {
            BubbleCss b = new BubbleCss();
            var auto = "auto";
            b.WrapperStyle = $"style='max-width:100%; background-color: transparent; position: relative; overflow:hidden; padding: {ParsePadding(message.Margin)}; min-height: {ParseSaaSize(message.MinimumSize, false)}; height: {message.Text.GetSize(message.Font).Height+message.Margin.Size.Height}px'";

           b.BubbleStyle = $"style='font-size: {message.Font.Size}px; font-family: {message.Font.FontFamily.Name}; height: auto; min-height: {ParseSaaSize(message.MinimumSize, false)}; width: auto; word-break:{parseWordBreak(message.WordBreak)}; " +
                $"min-width: {ParseSaaSize(message.MinimumSize, true)}; max-width: {ParseSaaSize(message.MaximumSize, false)}; background-color: blue; border-radius: 10px; " +
                $"padding: {ParsePadding(message.Padding)}; color: {message.ForeColor.ToHEX()}; position: absolute; left: {message.Position.X}px; right: {message.Position.Y}px;'";

            b.ImageStyle = $"style='height: {message.Profile.Size.Height}px; width: {message.Profile.Size.Width}px; border-radius: {ParseRadius(message.Profile.Radius)}; " +
                $"border:{message.Profile.BordThickness}px {ParseBorderStyle(message.Profile.BorderStyle)} {message.Profile.BorderColor.ToHEX()}; position: absolute; background-color:{message.Profile.BackColor.ToHEX()};'";

            b.StatusStyle = $"style='height: {message.Status.Size.Height}px; width: {message.Status.Size.Width}px; position: absolute; bottom: {message.Status.Position.Y}px; right: {message.Status.Position.X}px; z-index: 1;'";

            b.TimeStyle = $"style='font-size: {message.Time.Font.Size}px; font-family: {message.Time.Font.FontFamily.Name}; color: {message.Time.ForeColor}; position: absolute; bottom: {message.Position.Y}px; left: {message.Position.X}px; z-index: 1;'";
            return b;
        }
        private string ParsePadding(Padding pd)
        {
            return $"{pd.Left}px {pd.Top}px {pd.Right}px {pd.Bottom}px";
        }
        private string ParseSaaSize(SaaSize s, bool isWidth)
        {
            return isWidth ? s.Width + (s.WidthIn == SaaSizePercentOrPixel.Pixel ? "px" : "%") : s.Height + (s.HeightIn == SaaSizePercentOrPixel.Pixel ? "px" : "%");
        }
        private string ParseRadius(Radius r)
        {
            return $"{r.TopLeft}px {r.TopRight}px {r.BottomRight}px {r.BottomLeft}px";
        }
        private string  ParseBorderStyle(SaaBubbleBorderStyle b)
        {
            return b == SaaBubbleBorderStyle.Dash ? "dashed" : b == SaaBubbleBorderStyle.Dot ? "dotted" : b == SaaBubbleBorderStyle.Solid ? "solid" : "none";
        }
        private string getSizeAuto(int s)
        {
            return s == 0 ? "auto" : s.ToString();
        }
        private string parseWordBreak(SaaBubbleWordBreak b)
        {
            return b == SaaBubbleWordBreak.BreakAll ? "break-all" : "break-word";
        }
    }
    internal class BubbleCss
    {
        public string BubbleStyle { get; set; }
        public string WrapperStyle { get; set; }
        public string ImageStyle { get; set; }
        public string StatusStyle { get; set; }
        public string TimeStyle { get; set; }
    }
    internal class WeBb : WebBrowser
    {
        public WeBb()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
    public class ViewPoints
    {
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float Y1 { get; set; }
        public float Y2 { get; set; }
    }
}
