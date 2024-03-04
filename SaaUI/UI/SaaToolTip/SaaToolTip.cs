using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Customizable tooltip that shows information when user moves the pointer over an associated control.
    /// </summary>
    [Description("Customizable tooltip that shows information when user moves the pointer over an associated control.")]
    [ToolboxBitmap(typeof(SaaToolTip), "icons.SaaToolTip.bmp")]
    [ProvideProperty("ToolTip", typeof(Control))]
    public class SaaToolTip : Component, IExtenderProvider
    {
        Timer _timer = new Timer();
        public SaaToolTip()
        {

            _timer.Tick += _timer_Tick;
            _timer.Interval = 500;

        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            ShowTip(_activeControl);
        }

        Dictionary<Control, string> _controls = new Dictionary<Control, string>();
        ToolTipForm tipForm;
        /// <summary>
        /// Indicates whether a control is supported by the tooltip.
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        public bool CanExtend(object extendee)
        {
            return !(extendee == null || extendee is SaaToolTip || extendee is Form);
        }
        /// <summary>
        /// Sets tooltip text associated with the specified control.
        /// </summary>
        /// <param name="control">target control</param>
        /// <param name="tip">text associated with</param>
        [Description("Gets or Sets tooltip text associated with this control. Leave empty if you don't want tooltip for this control.")]
        [Category("SaaToolTip")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public void SetToolTip(Control control, string tip)
        {
            if (control == null) return;
            if (_controls.ContainsKey(control))
            {
                if (!string.IsNullOrEmpty(tip))
                {
                    _controls[control] = tip;
                    control.MouseEnter += Control_MouseEnter;
                    control.MouseLeave += Control_MouseLeave;
                }
                else
                {
                    _controls.Remove(control);
                    control.MouseEnter -= Control_MouseEnter;
                    control.MouseLeave -= Control_MouseLeave;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(tip))
                {
                    _controls.Add(control, tip);
                    control.MouseEnter += Control_MouseEnter;
                    control.MouseLeave += Control_MouseLeave;
                }
            }
        }

        /// <summary>
        /// Gets tooltip text associated with the specified control.
        /// </summary>
        /// <param name="control">target control</param>
        /// <returns>tooltip text</returns>
        [Description("Gets or Sets tooltip text associated with this control.")]
        [Category("SaaToolTip")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string GetToolTip(Control control)
        {
            if (_controls.ContainsKey(control)) return _controls[control];
            else return "";
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            //if (tipForm != null)
            //{
            //    tipForm.Close();
            //    tipForm = null;
            //}
            tp.Hide(_activeControl);
            _activeControl = null;
        }
        Control _activeControl = null;
        SaaToolTipHost tp = new SaaToolTipHost();
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            _activeControl = (Control)sender;
            _timer.Start();
            // ShowTip(_activeControl);
        }

        /// <summary>
        /// Shows tooltip for a control.
        /// </summary>
        /// <param name="control">target control</param>
        /// <param name="tipText">text to display</param>
        public void Show(Control control, string tipText)
        {
            if (control == null) throw new ArgumentNullException();
            ShowTip(control, tipText, true);
        }

        /// <summary>
        /// Hides tooltip for the specified control.
        /// </summary>
        /// <param name="control"></param>
        public void Hide(Control control)
        {
            tp.Hide(control);
        }
        private void ShowTip(Control c, string t = "", bool iscustom = false)
        {
            if (c != null)
            {
                if (_controls.ContainsKey(c) || iscustom)
                {

                    var tip = t;
                    if (!iscustom)
                    {
                        tip = _controls[c];
                    }
                    if (!string.IsNullOrEmpty(tip))
                    {
                        var loc = Point.Empty;
                        if (c.FindForm() != null)
                        {
                            loc = c.FindForm().PointToScreen(c.LocationRelativeToForm());
                        }
                        else
                        {
                            loc = c.PointToScreen(c.Location);
                            var ofsz = new Size(c.Width - c.ClientSize.Width, c.Height - c.ClientSize.Height);
                            loc = new Point(loc.X - ofsz.Width, loc.Y - ofsz.Height);
                        }
                        tp.BackgroundColor = BackgroundColor;
                        tp.TextColor = TextColor;
                        tp.ArrowHeight = ArrowHeight;
                        tp.ArrowStart = ArrowStart;
                        tp.ArrowWidth = ArrowWidth;
                        tp.OffsetX = OffsetX;
                        tp.OffsetY = OffsetY;
                        tp.TextOffsetX = TextOffsetX;
                        tp.TextOffsetY = TextOffsetY;
                        tp.Position = Position;
                        tp.Font = Font;
                        tp.OffSize = OffSize;
                        tp.Radius = Radius;
                        if (!ShowArrow)
                        {
                            tp.ArrowWidth = 0;
                            tp.ArrowHeight = 0;
                        }
                        tp._TipText = tip;
                        tp.NoLimitSize = NoLimitSize;

                        var tempP = new Point(c.Width / 2, c.Height);
                        tp.IsMeasuring = true;
                        tp.Show(tip, c, tempP);



                        var _reqSize = tp.RequiredSize;
                        var offset = getOffset(_reqSize, c, loc);
                        tp.CaptureLocation = getCaptureLoc(c, _reqSize, loc);
                        tp.IsMeasuring = false;
                        if (!ShowAlways)
                        {
                            tp.Show(tip, c, offset, Duration);
                        }
                        else
                        {
                            tp.Show(tip, c, offset);
                        }
                    }

                }
            }
        }


        private Point getOffset(Size reqSize, Control c, Point loc)
        {
            switch (Position)
            {
                case SidePositions.Bottom:
                    {
                        return new Point(c.Width / 2 - reqSize.Width / 2 + OffsetX, c.Height + OffsetY);
                    }
                case SidePositions.Top:
                    {
                        return new Point(c.Width / 2 - reqSize.Width / 2 + OffsetX, -(reqSize.Height + OffsetY));
                    }
                case SidePositions.Left:
                    {
                        return new Point(-(reqSize.Width + OffsetX), (c.Height / 2 - reqSize.Height / 2 + OffsetY));
                    }
                case SidePositions.Right:
                    {
                        return new Point(c.Width + OffsetX, (c.Height / 2 - reqSize.Height / 2 + OffsetY));
                    }
                default:
                    {
                        return Point.Empty;
                    }
            }
        }
        private Point getCaptureLoc(Control c, Size reqSize, Point loc)
        {
            Point p = Point.Empty;
            var cX = loc.X;
            var cY = loc.Y;
            var cH = c.Height;
            var cW = c.Width;
            var offset = new Point(c.Width / 2 - reqSize.Width / 2 + OffsetX, c.Height + OffsetY);
            var rqH = reqSize.Height;
            var rqW = reqSize.Width;
            switch (Position)
            {
                case SidePositions.Bottom:
                    {
                        var arrX = cX + cW / 2;
                        var arrY = cY + cH;
                        var tpX = arrX - rqW / 2;
                        var tpY = arrY;
                        p = new Point(tpX + OffsetX, tpY + OffsetY);
                        break;
                    }
                case SidePositions.Top:
                    {
                        var arrX = cX + cW / 2;
                        var arrY = cY;
                        var tpX = arrX - rqW / 2;
                        var tpY = arrY - rqH;
                        p = new Point(tpX - OffsetX, tpY - OffsetY);
                        break;
                    }
                case SidePositions.Left:
                    {
                        var arrX = cX - rqW;
                        var arrY = cY + cH / 2 - rqH / 2;
                        var tpX = arrX;
                        var tpY = arrY;
                        p = new Point(tpX - OffsetX, tpY + OffsetY);
                        break;
                    }
                case SidePositions.Right:
                    {
                        var arrX = cX + cW;
                        var arrY = cY + cH / 2 - rqH / 2;
                        var tpX = arrX;
                        var tpY = arrY;
                        p = new Point(tpX + OffsetX, tpY + OffsetY);
                        break;
                    }
            }

            return p;
        }
        private Point getLocation(Point loc, Control c)
        {
            throw new NotImplementedException();
            //var p = loc;
            //var s = tipForm.getSize(GetToolTip(c), Font);
            //var _x = loc.X + c.Width / 2 - s.Width / 2;
            //var _y = loc.Y + c.Height + OffsetY;
            //p.X = _x;
            //p.Y = _y;
            return Point.Empty;
        }

        internal bool NoLimitSize { get; set; } = false;

        /// <summary>
        /// Gets or Sets height of the tooltip arrow.
        /// </summary>
        [Description("Gets or Sets height of the tooltip arrow."), Category("Saa")]
        public int ArrowHeight { get; set; } = 10;
        /// <summary>
        /// Gets or Sets width of the tooltip arrow.
        /// </summary>
        [Description("Gets or Sets width of the tooltip arrow."), Category("Saa")]
        public int ArrowWidth { get; set; } = 20;

        /// <summary>
        /// Gets or Sets how far the tooltip will move away horizontally from the target control.
        /// </summary>
        [Description("Gets or Sets how far the tooltip will move away horizontally from the target control."), Category("Saa")]
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Gets or Sets how far the tooltip will move away vertically from the target control.
        /// </summary>
        [Description("Gets or Sets how far the tooltip will move away vertically from the target control."), Category("Saa")]
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// Gets or Sets extra size to be added to the tooltip.
        /// </summary>
        [Description("Gets or Sets extra size to be added to the tooltip."), Category("Saa")]
        public Size OffSize { get; set; } = Size.Empty;

        /// <summary>
        /// Gets or Sets the location of the tooltip arrow. Empty means center.
        /// </summary>
        [Description("Gets or Sets the location of the tooltip arrow. Empty means center."), Category("Saa")]
        public int? ArrowStart { get; set; } = null;

        /// <summary>
        /// Gets or Sets background color of the tooltip.
        /// </summary>
        [Description("Gets or Sets background color of the tooltip."), Category("Saa")]
        public Color BackgroundColor { get; set; } = SaaInternalColors.PrimaryColor;

        /// <summary>
        /// Gets or Sets where the tooltip is placed relative to the associated control.
        /// </summary>
        [Description("Gets or Sets where the tooltip is placed relative to the associated control."), Category("Saa")]
        public SidePositions Position { get; set; } = SidePositions.Bottom;

        /// <summary>
        /// Gets or Sets in milliseconds, the time the tooltip will be visible to the user after it has been shown.
        /// </summary>
        [Description("Gets or Sets in milliseconds, the time the tooltip will be visible to the user after it has been shown."), Category("Saa")]
        public int Duration { get; set; } = 15000;

        /// <summary>
        /// Gets or Sets in milliseconds, the time the pointer should be on the associated control before the tooltip is shown.
        /// </summary>
        [Description("Gets or Sets in milliseconds, the time the pointer should be on the associated control before the tooltip is shown."), Category("Saa")]
        public int Delay
        {
            get
            {
                return _timer.Interval;
            }
            set
            {
                if (value > 0)
                {
                    _timer.Interval = value;
                }
                else
                {
                    throw new Exception("Interval can not be less than 1 millisecond");
                }
            }
        }

        /// <summary>
        /// Gets or Sets whether the tooltip is enabled. 
        /// </summary>
        [Description("Gets or Sets whether the tooltip is enabled."), Category("Saa")]
        public bool Active
        {
            get
            {
                return tp.Active;
            }
            set
            {
                tp.Active = value;
            }
        }
        private int ReshowDelay
        {
            get
            {
                return tp.ReshowDelay;
            }
            set
            {
                tp.ReshowDelay = value;
            }
        }

        /// <summary>
        /// Gets or Sets whether the tooltip will always be visible as long as the pointer is over the associated control. If TRUE, 'Duration' will be ignored.
        /// </summary>
        [Description("Gets or Sets whether the tooltip will always be visible as long as the pointer is over the associated control. If TRUE, 'Duration' will be ignored."), Category("Saa")]
        public bool ShowAlways
        {
            get
            {
                return tp.ShowAlways;
            }
            set
            {
                tp.ShowAlways = value;
            }
        }

        /// <summary>
        /// Gets or Sets color of the text.
        /// </summary>
        [Description("Gets or Sets color of the text."), Category("Saa")]
        public Color TextColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or Sets how far the text will be moved from left to right side.
        /// </summary>
        [Description("Gets or Sets how far the text will be moved from left to right side."), Category("Saa")]
        public int TextOffsetX { get; set; } = 0;

        /// <summary>
        /// Gets or Sets how far the text will be moved from top to bottom.
        /// </summary>
        [Description("Gets or Sets how far the text will be moved from top to bottom."), Category("Saa")]
        public int TextOffsetY { get; set; } = 0;

        /// <summary>
        /// Gets or Sets the font of the tooltip.
        /// </summary>
        [Description("Gets or Sets the font of the tooltip."), Category("Saa")]
        public Font Font { get; set; } = new Font(FontFamily.GenericSerif, 10);

        /// <summary>
        /// Gets or Sets the radius of the tooltip. This is the roundness of the tooltip edges.
        /// </summary>
        [Description("Gets or Sets the radius of the tooltip. This is the roundness of the tooltip edges."), Category("Saa")]
        public Radius Radius { get; set; } = new Radius(5, 5, 5, 5);

        /// <summary>
        /// Gets or Sets whether the tooltip arrow is visible.
        /// </summary>
        [Description("Gets or Sets whether the tooltip arrow is visible."), Category("Saa")]
        public bool ShowArrow { get; set; } = true;

    }
}
