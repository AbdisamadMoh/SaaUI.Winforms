using SaaUI.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaToolTipHost : ToolTip
    {
        public SaaToolTipHost()
        {
            IsBalloon = false;
            OwnerDraw = true;
            Popup += SaaToolTip1_Popup;
            Draw += SaaToolTip1_Draw;
            UseAnimation = false;
            BackColor = Color.Transparent;
        }
        Size _requiredSize;
        Control _activeControl;
        public string _TipText = "";
        private void SaaToolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            _TipText = e.ToolTipText;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // e.Graphics.FillRectangle(Brushes.Red, e.Graphics.ClipBounds);
            e.Graphics.DrawImage(bck, 0, 0);
            DrawArrow(e.Graphics);

            //  e.DrawText();
        }

        public const int GCL_STYLE = -26;
        public const int CS_DROPSHADOW = 0x20000;

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        public static extern int GetClassLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetClassLong")]
        public static extern int SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);



        Bitmap bck;
        private void SaaToolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (IsMeasuring)
            {
                e.Cancel = true;
            }
            using (Graphics gr = Graphics.FromHwnd(IntPtr.Zero))
            {
                _requiredSize = /*e.ToolTipSize*/gr.MeasureString(_TipText, Font).ToSize() + new Size(2, ArrowHeight + 2) + OffSize;
                if (!NoLimitSize)
                {
                    _requiredSize.Width = _requiredSize.Width < 60 + ArrowHeight ? 60 + ArrowHeight : _requiredSize.Width;
                    _requiredSize.Height = _requiredSize.Height < 30 ? 30 : _requiredSize.Height;
                }
                if (Position == SidePositions.Left || Position == SidePositions.Right)
                {
                    _requiredSize.Width += 4;
                    if (ArrowWidth + 2 > _requiredSize.Height) { ArrowWidth = _requiredSize.Height - 2; }
                }
                else
                {
                    _requiredSize.Height += 4;
                    if (ArrowWidth + 2 > _requiredSize.Width) { ArrowWidth = _requiredSize.Width - 2; }
                }
            }
            e.ToolTipSize = _requiredSize;
            RequiredSize = _requiredSize;
            var hwnd = (IntPtr)typeof(ToolTip).GetProperty("Handle",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance).GetValue(this, null);
            var cs = GetClassLong(hwnd, GCL_STYLE);
            if ((cs & CS_DROPSHADOW) == CS_DROPSHADOW)
            {
                cs = cs & ~CS_DROPSHADOW;
                SetClassLong(hwnd, GCL_STYLE, cs);
            }
            _activeControl = e.AssociatedControl;
            bck = new Bitmap(_requiredSize.Width, _requiredSize.Height);
            var g = Graphics.FromImage(bck);
            g.CopyFromScreen(CaptureLocation, Point.Empty, _requiredSize);
            if (!IsMeasuring)
            {
                if (Position == SidePositions.Top || Position == SidePositions.Bottom)
                {

                    if (ArrowStart == null)
                    {

                        ArrowStart = _requiredSize.Width / 2;
                    }
                    else
                    {
                        ArrowStart += ArrowWidth / 2 + 4;
                    }
                }
                else if (Position == SidePositions.Right || Position == SidePositions.Left)
                {
                    if (ArrowStart == null)
                    {
                        ArrowStart = _requiredSize.Height / 2;
                    }
                    else
                    {
                        ArrowStart = ArrowStart + ArrowWidth / 2 + 4;
                    }
                }
            }


        }

        private void DrawArrow(Graphics g)
        {
            int w = _requiredSize.Width;
            int h = _requiredSize.Height;

            Brush b = new SolidBrush(BackgroundColor);
            g.FillPolygon(b, GetPeakPoints());

            using (var bx = new BorderPath(pathX, pathY, pathW, pathH, Radius))
            {
                g.FillPath(b, bx.Path);
            }
            using (Brush br = new SolidBrush(TextColor))
            {
                g.DrawString(_TipText, Font, br, new Point(pathX + 2 + TextOffsetX, pathY + 2 + TextOffsetY));
            }
            b.Dispose();
        }

        int pathX = 0;
        int pathY = 0;
        int pathH = 0;
        int pathW = 0;
        int textX = 0;
        int textY = 0;
        private Point[] GetPeakPoints()
        {
            Point[] points = { };
            switch (Position)
            {
                case SidePositions.Bottom:
                    {
                        points = new Point[]
                                {
                                    new Point((int)ArrowStart, 0),
                                    new Point((int)ArrowStart +ArrowWidth/2, ArrowHeight+1),
                                    new Point((int)ArrowStart -ArrowWidth/2, ArrowHeight+1)
                                };
                        pathX = 1;
                        pathY = ArrowHeight;
                        textX = pathX + 2;
                        textY = pathY + 2;
                        pathH = _requiredSize.Height - ArrowHeight - 1;
                        pathW = _requiredSize.Width - 1;
                        break;
                    }
                case SidePositions.Top:
                    {
                        points = new Point[]
                                {
                                    new Point((int)ArrowStart, _requiredSize.Height),
                                    new Point((int)ArrowStart +ArrowWidth/2, _requiredSize.Height-ArrowHeight-1),
                                    new Point((int)ArrowStart -ArrowWidth/2, _requiredSize.Height-ArrowHeight-1)
                                };
                        pathX = 1;
                        pathY = 1;
                        textX = pathX + 2;
                        textY = pathY + 2;
                        pathH = _requiredSize.Height - ArrowHeight;
                        pathW = _requiredSize.Width - 1;
                        break;
                    }
                case SidePositions.Right:
                    {
                        points = new Point[]
                                {
                                    new Point(0, (int)ArrowStart),
                                    new Point(ArrowHeight,(int)ArrowStart -ArrowWidth/2),
                                    new Point(ArrowHeight, (int)ArrowStart +ArrowWidth/2)
                                };
                        pathX = ArrowHeight - 1;
                        pathY = 1;
                        textX = pathX + 2;
                        textY = pathY + 2;
                        pathH = _requiredSize.Height - 1;
                        pathW = _requiredSize.Width - ArrowHeight - 1;
                        break;
                    }
                case SidePositions.Left:
                    {
                        points = new Point[]
                                {
                                    new Point(_requiredSize.Width, (int)ArrowStart),
                                    new Point(_requiredSize.Width-ArrowHeight,(int)ArrowStart +ArrowWidth/2),
                                    new Point(_requiredSize.Width-ArrowHeight, (int)ArrowStart -ArrowWidth/2)
                                };
                        pathX = 1;
                        pathY = 1;
                        textX = pathX + 2;
                        textY = pathY + 2;
                        pathH = _requiredSize.Height - 1;
                        pathW = _requiredSize.Width - ArrowHeight + 1;
                        break;
                    }
            }

            return points;
        }

        internal bool NoLimitSize { get; set; } = false;
        internal bool IsMeasuring { get; set; } = false;
        internal Point CaptureLocation { get; set; } = Point.Empty;
        public Size RequiredSize { get; private set; }
        public Radius Radius { get; set; } = new Radius(5, 5, 5, 5);
        public int ArrowHeight { get; set; } = 10;
        public int ArrowWidth { get; set; } = 20;
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public Size OffSize { get; set; } = Size.Empty;
        public int? ArrowStart { get; set; } = null;
        public Color BackgroundColor { get; set; } = SaaInternalColors.PrimaryColor;
        public Color TextColor { get; set; } = Color.White;
        public int TextOffsetX { get; set; } = 0;
        public int TextOffsetY { get; set; } = 0;
        public SidePositions Position { get; set; } = SidePositions.Bottom;
        public Font Font { get; set; } = new Font(FontFamily.GenericSerif, 10);

    }
}
