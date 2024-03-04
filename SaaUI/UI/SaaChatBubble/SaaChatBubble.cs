using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable saaChatBubble.
    /// </summary>
    [Description("Beautiful and customizable saaChatBubble.")]
    [DefaultEvent("Click")]
    [ToolboxBitmap(typeof(SaaChatBubble), "icons.SaaChatBubble_16.bmp")]
    public partial class SaaChatBubble : UserControl, IEquatable<SaaChatBubble>
    {
        public SaaChatBubble()
        {

            InitializeComponent();
            // Note the >>> Optimized <<< DoubleBuffer
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            MsgPanel.Paint += MsgPanel_Paint;
            this.AutoSize = true;
        }
        public delegate void OnBodyClicked(object sender, EventArgs e);
        /// <summary>
        /// Fires when body of the control is clicked.
        /// </summary>
        [Description("Fires when body of the control is clicked.")]
        [Category("Saa")]
        public event OnBodyClicked BodyClicked;


        public delegate void OnImageClicked(object sender, EventArgs e);
        /// <summary>
        /// Fires when image of the control is clicked.
        /// </summary>
        [Description("Fires when image of the control is clicked.")]
        [Category("Saa")]
        public event OnImageClicked ImageClicked;

        public delegate void OnBodyChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when text in the body gets changed.
        /// </summary>
        [Description("Fires when text in the body gets changed.")]
        [Category("Saa")]
        public event OnBodyChanged BodyChanged;

        internal string Id { get; set; } = SaaExtensions.NewID;
        private void MsgPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            CreatePeak(e);
            if (AutoSize)
            {
                ResizeHeight();
            }




            base.OnPaint(e);
        }
        int x1;
        int y1;
        int x2;
        int y2;
        int x3;
        int y3;
        private void CreatePeak(PaintEventArgs e)
        {

            if (_Peak)
            {

                switch (_PeakPosition)
                {
                    case PeakPositions.TopLeft:
                        {


                            x1 = msgPanelHolder.Location.X + 20 + this.msgPanelHolder.Padding.Left - (_PeakOffX1);
                            y1 = msgPanelHolder.Location.Y + _PeakOffY1;

                            x2 = msgPanelHolder.Location.X - 10 + this.msgPanelHolder.Padding.Left - (_PeakOffX2);
                            y2 = msgPanelHolder.Location.Y + _PeakOffY2;

                            x3 = msgPanelHolder.Location.X + 20 + this.msgPanelHolder.Padding.Left - (_PeakOffX3);
                            y3 = msgPanelHolder.Location.Y + 20 + _PeakOffY3;

                            Point[] points2 = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                            e.Graphics.FillPolygon(new SolidBrush(MsgPanel.BackColor), points2);
                            if ((_Profile && _ProfilePosition != BubbleProfilePosition.Left) || !_Profile)
                            {
                                this.msgPanelHolder.Padding = new Padding(10 + _PeakOffX2, 0, 0, 0);

                            }
                            else
                            {
                                this.msgPanelHolder.Padding = new Padding(3, 0, 0, 0);
                            }
                            break;
                        }
                    case PeakPositions.TopRight:
                        {


                            x1 = msgPanelHolder.Location.X - 20 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX1;
                            y1 = msgPanelHolder.Location.Y + _PeakOffY1;

                            x2 = msgPanelHolder.Location.X + 10 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX2;
                            y2 = msgPanelHolder.Location.Y + _PeakOffY2;

                            x3 = msgPanelHolder.Location.X - 20 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX3;
                            y3 = msgPanelHolder.Location.Y + 20 + _PeakOffY3;

                            Point[] points2 = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                            e.Graphics.FillPolygon(new SolidBrush(MsgPanel.BackColor), points2);
                            if ((_Profile && _ProfilePosition != BubbleProfilePosition.Right) || !_Profile)
                            {

                                this.msgPanelHolder.Padding = new Padding(0, 0, 10 + _PeakOffX2, 0);

                            }
                            else
                            {
                                this.msgPanelHolder.Padding = new Padding(0, 0, 3, 0);
                            }
                            break;
                        }
                    case PeakPositions.BottomRight:
                        {
                            var _radius = (Radius.TopLeft | Radius.TopRight | Radius.BottomRight | Radius.BottomLeft) > 0 ? 2 : 0;

                            x1 = msgPanelHolder.Location.X - 20 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX1;
                            y1 = msgPanelHolder.Location.Y + this.msgPanelHolder.Height - (_radius) - _PeakOffY1;

                            x2 = msgPanelHolder.Location.X + 10 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX2;
                            y2 = msgPanelHolder.Location.Y + this.msgPanelHolder.Height - (_radius) - _PeakOffY2;

                            x3 = msgPanelHolder.Location.X - 20 + msgPanelHolder.Width - this.msgPanelHolder.Padding.Right + _PeakOffX3;
                            y3 = msgPanelHolder.Location.Y + this.msgPanelHolder.Height - (_radius) - 20 - _PeakOffY3;

                            Point[] points2 = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                            e.Graphics.FillPolygon(new SolidBrush(MsgPanel.BackColor), points2);

                            if ((_Profile && _ProfilePosition != BubbleProfilePosition.Right) || !_Profile)
                            {

                                this.msgPanelHolder.Padding = new Padding(0, 0, 10 + _PeakOffX2, 0);

                            }
                            else
                            {
                                this.msgPanelHolder.Padding = new Padding(0, 0, 3, 0);
                            }
                            break;
                        }

                    case PeakPositions.BottomLeft:
                        {
                            var _radius = (Radius.TopLeft | Radius.TopRight | Radius.BottomRight | Radius.BottomLeft) > 0 ? 2 : 0;

                            x1 = msgPanelHolder.Location.X + 20 + this.msgPanelHolder.Padding.Left - (_PeakOffX1);
                            y1 = msgPanelHolder.Location.Y + this.msgPanelHolder.Height - (_radius) - _PeakOffY1;

                            x2 = msgPanelHolder.Location.X - 10 + this.msgPanelHolder.Padding.Left - (_PeakOffX2);
                            y2 = msgPanelHolder.Location.Y + this.msgPanelHolder.Height - (_radius) - _PeakOffY2;

                            x3 = msgPanelHolder.Location.X + 20 + this.msgPanelHolder.Padding.Left - (_PeakOffX3);
                            y3 = msgPanelHolder.Location.Y - 20 + this.msgPanelHolder.Height - (_radius) - _PeakOffY3;

                            Point[] points2 = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                            e.Graphics.FillPolygon(new SolidBrush(MsgPanel.BackColor), points2);
                            if ((_Profile && _ProfilePosition != BubbleProfilePosition.Left) || !_Profile)
                            {

                                this.msgPanelHolder.Padding = new Padding(10 + _PeakOffX2, 0, 0, 0);

                            }
                            else
                            {
                                this.msgPanelHolder.Padding = new Padding(3, 0, 0, 0);
                            }

                            break;
                        }
                }

            }
            else
            {
                this.msgPanelHolder.Padding = new Padding(0, 0, 0, 0);
            }
        }

        private void Modify(bool force = true)
        {
            Invalidate(force);
            LeftPanel.Visible = _Profile;

            if (_ProfilePosition == BubbleProfilePosition.Left)
            {
                LeftPanel.Dock = DockStyle.Left;
            }
            else
            {
                LeftPanel.Dock = DockStyle.Right;
            }

            if (_ImagePosition == BubbleImagePosition.Top)
            {
                imageMainPanel.Dock = DockStyle.Top;
            }
            else
            {
                imageMainPanel.Dock = DockStyle.Bottom;
            }
            imageMainPanel.Padding = new Padding(_ImagePadding);
            LeftPanel.Width = _ProfileSize.Width;
            imageMainPanel.Height = _ProfileSize.Height;

            imagePanel.Radius = _ImageRadius;

            saaPictureBox1.Radius = new Radius(_ImageRadius.TopLeft - _ImageBorderThickness,
                _ImageRadius.TopRight - _ImageBorderThickness,
                _ImageRadius.BottomLeft - _ImageBorderThickness,
                _ImageRadius.BottomRight - _ImageBorderThickness);
            imagePanel.Padding = new Padding(_ImageBorderThickness);

            msgPanelHolder.BackColor = msgPanelHolder.BackColor2 = Color.Transparent;
        }

        private void ResizeHeight()
        {
            var _radius = (Radius.TopLeft | Radius.TopRight | Radius.BottomRight | Radius.BottomLeft) > 0 ? 2 : 0;
            var height = TextRenderer.MeasureText(label1.Text, label1.Font).Height + (_radius) + BodyPadding.Bottom + BodyPadding.Top;

            this.Height = height > this.MinimumSize.Height ? height : this.Height;
        }

        /// <summary>
        /// Gets Actual height required for the control to show its content fully.
        /// </summary>
        /// <param name="OnlyBody">'true' if you want to get only the text part, otherwise 'false' to get full height.</param>
        /// <returns>Returns Required height for the control.</returns>
        public int MeasureHeight(bool OnlyBody = false)
        {
            var _radius = (Radius.TopLeft | Radius.TopRight | Radius.BottomRight | Radius.BottomLeft) > 0 ? 2 : 0;
            var height = TextRenderer.MeasureText(label1.Text, label1.Font).Height + (_radius) + (!OnlyBody ? BodyPadding.Bottom + BodyPadding.Top : 0);
            return height;
        }

        /// <summary>
        /// Gets Actual width required for the control to show its content fully.
        /// </summary>
        /// <param name="OnlyBody">'true' if you want to get only the text part, otherwise 'false' to get full width.</param>
        /// <returns>Returns Required width for the control.</returns>
        public int MeasureWidth(bool OnlyBody = false)
        {
            var height = TextRenderer.MeasureText(label1.Text, label1.Font).Width + (!OnlyBody ? BodyPadding.Left + BodyPadding.Right + LeftPanel.Width : 0);
            return height;
        }

        #region MsgStyle

        #region Peak
        int _PeakOffX1 = 0;
        int _PeakOffY1 = 0;

        /// <summary>
        /// Gets or Sets offset position of X1 relative to X from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of X1 relative to X from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffX1
        {
            get { return _PeakOffX1; }
            set { _PeakOffX1 = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets offset position of Y1 relative to Y from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of Y1 relative to Y from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffY1
        {
            get { return _PeakOffY1; }
            set { _PeakOffY1 = value; Invalidate(); }
        }

        int _PeakOffX2 = 0;
        int _PeakOffY2 = 0;

        /// <summary>
        /// Gets or Sets offset position of X2 relative to X from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of X2 relative to X from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffX2
        {
            get { return _PeakOffX2; }
            set { _PeakOffX2 = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets offset position of Y2 relative to Y from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of Y2 relative to Y from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffY2
        {
            get { return _PeakOffY2; }
            set { _PeakOffY2 = value; Invalidate(); }
        }

        int _PeakOffX3 = 0;
        int _PeakOffY3 = 0;

        /// <summary>
        /// Gets or Sets offset position of X3 relative to X from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of X3 relative to X from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffX3
        {
            get { return _PeakOffX3; }
            set { _PeakOffX3 = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets offset position of Y3 relative to Y from point 0 of the body.
        /// </summary>
        [Description("Gets or Sets offset position of Y3 relative to Y from point 0 of the body.")]
        [Category("Saa")]
        public int PeakOffY3
        {
            get { return _PeakOffY3; }
            set { _PeakOffY3 = value; Invalidate(); }
        }

        bool _Peak = true;

        /// <summary>
        /// Gets or Sets whether peak of the bubble to be drawn.
        /// </summary>
        [Description("Gets or Sets whether peak of the bubble to be drawn.")]
        [Category("Saa")]
        public bool Peak
        {
            get { return _Peak; }
            set { _Peak = value; Invalidate(); }
        }

        PeakPositions _PeakPosition = PeakPositions.TopLeft;
        /// <summary>
        /// Gets or Sets where peak of the bubble to be drawn.
        /// </summary>
        [Description("Gets or Sets where peak of the bubble to be drawn.")]
        [Category("Saa")]
        public PeakPositions PeakPosition
        {
            get { return _PeakPosition; }
            set { _PeakPosition = value; Invalidate(); }
        }
        #endregion

        BubbleImagePosition _ImagePosition = BubbleImagePosition.Top;
        /// <summary>
        /// Gets or Sets image position of the control.
        /// </summary>
        [Description("Gets or Sets image position of the control.")]
        [Category("Saa")]
        public BubbleImagePosition ImagePosition
        {
            get
            {
                return _ImagePosition;
            }
            set
            {
                _ImagePosition = value;
                Modify();
            }
        }


        BubbleProfilePosition _ProfilePosition = BubbleProfilePosition.Left;
        /// <summary>
        /// Gets or Sets profile position of the control.
        /// </summary>
        [Description("Gets or Sets profile position of the control.")]
        [Category("Saa")]
        public BubbleProfilePosition ProfilePosition
        {
            get
            {
                return _ProfilePosition;
            }
            set
            {
                _ProfilePosition = value;
                Modify();
            }
        }

        bool _Profile = true;
        /// <summary>
        /// Gets or Sets whether profile of the bubble to be shown.
        /// </summary>
        [Description("Gets or Sets whether profile of the bubble to be shown.")]
        [Category("Saa")]
        public bool Profile
        {
            get
            {
                return _Profile;
            }
            set
            {
                _Profile = value; Modify();
            }
        }
        int _ImagePadding = 0;


        Radius _ImageRadius = new Radius(25, 25, 25, 25);
        /// <summary>
        /// Gets or Sets radius of the image. To make it full circle, equalize both height and width of the image and give radius of half the height.
        /// </summary>
        [Description("Gets or Sets radius of the image. To make it full circle, equalize both height and width of the image and give radius of half the height.")]
        [Category("Saa")]
        public Radius ImageRadius
        {
            get
            {
                return _ImageRadius;
            }
            set
            {
                _ImageRadius = value;
                Modify();
            }
        }


        Size _ProfileSize = new Size(50, 50);
        /// <summary>
        /// Gets or Sets size of the profile of the control.
        /// </summary>
        [Description("Gets or Sets size of the profile of the control.")]
        [Category("Saa")]
        public Size ProfileSize
        {
            get
            {
                return _ProfileSize;
            }
            set
            {
                _ProfileSize = value;
                Modify();
            }
        }

        /// <summary>
        /// Gets or Sets background color of the body.
        /// </summary>
        [Description("Gets or Sets background color of the body.")]
        [Category("Saa")]
        public Color MsgBackground
        {
            get
            {
                return MsgPanel.BackColor;
            }
            set
            {
                MsgPanel.BackColor = MsgPanel.BackColor2 = value;
                Invalidate();
            }
        }
        public override Color ForeColor { get => base.ForeColor; set => label1.ForeColor = base.ForeColor = value; }
        public override Font Font { get => base.Font; set { label1.Font = base.Font = value; Invalidate(); } }
        public override bool AutoSize { get => base.AutoSize; set { base.AutoSize = value; Invalidate(); } }


        /// <summary>
        /// Gets or Sets text alignment of the control.
        /// </summary>
        [Description("Gets or Sets text alignment of the control.")]
        [Category("Saa")]
        public ContentAlignment TextAlign
        {
            get
            {

                return label1.TextAlign;
            }
            set
            {
                label1.TextAlign = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets whether text will be right to left for RTL languages.
        /// </summary>
        [Description("Gets or Sets whether text will be right to left for RTL languages.")]
        [Category("Saa")]
        public RightToLeft RightToLeftRTL
        {
            get { return label1.RightToLeft; }
            set { label1.RightToLeft = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets body text of the control.
        /// </summary>
        [Description("Gets or Sets body text of the control.")]
        [Category("Saa")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string Body
        {
            get => label1.Text;
            set
            {
                label1.Text = value; Invalidate();

            }
        }

        /// <summary>
        /// Gets or Sets body padding of the control.
        /// </summary>
        [Description("Gets or Sets body padding of the control.")]
        [Category("Saa")]
        public Padding BodyPadding
        {
            get => label1.Padding;
            set { label1.Padding = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets radius of the body.
        /// </summary>
        [Description("Gets or Sets radius of the body.")]
        [Category("Saa")]
        public Radius Radius
        {
            get
            {
                return MsgPanel.Radius;
            }
            set
            {

                this.MsgPanel.Radius = value;
                Invalidate();
            }
        }



        /// <summary>
        /// Gets or Sets image of the control.
        /// </summary>
        [Description("Gets or Sets image of the control.")]
        [Category("Saa")]
        public Image Image
        {
            get
            {
                return saaPictureBox1.Image;
            }
            set
            {
                saaPictureBox1.Image = value;
            }
        }


        /// <summary>
        /// Gets or Sets image sizing mode of the image of the control.
        /// </summary>
        [Description("Gets or Sets image sizing mode of the image of the control.")]
        [Category("Saa")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get
            {
                return saaPictureBox1.SizeMode;
            }
            set
            {
                saaPictureBox1.SizeMode = value;
            }
        }
        int _ImageBorderThickness = 2;

        /// <summary>
        /// Gets or Sets image border thickness.
        /// </summary>
        [Description("Gets or Sets image border thickness.")]
        [Category("Saa")]
        public int ImageBorderThickness
        {
            get
            {
                return _ImageBorderThickness;
            }
            set
            {
                _ImageBorderThickness = value;
                Modify();
            }
        }

        /// <summary>
        /// Gets or Sets background color of the image.
        /// </summary>
        [Description("Gets or Sets background color of the image.")]
        [Category("Saa")]
        public Color ImageBackColor
        {
            get
            {
                return saaPictureBox1.BackColor;
            }
            set
            {
                saaPictureBox1.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets image border color.
        /// </summary>
        [Description("Gets or Sets image border color.")]
        [Category("Saa")]
        public Color ImageBorderColor
        {
            get
            {
                return imagePanel.BackColor;
            }
            set
            {
                imagePanel.BackColor = imagePanel.BackColor2 = value;
            }
        }


        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            BodyClicked?.Invoke(sender, e);
        }

        private void imagePanel_Click(object sender, EventArgs e)
        {
            ImageClicked?.Invoke(saaPictureBox1, EventArgs.Empty);
        }

        public bool Equals(SaaChatBubble other)
        {
            if (other == null) return false;
            if (other.Id == this.Id) return true; else return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            SaaChatBubble sc = obj as SaaChatBubble;
            if (sc == null) return false;
            else return Equals(sc);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(SaaChatBubble s1, SaaChatBubble s2)
        {
            if (((object)s1) == null || ((object)s2) == null) return Object.Equals(s1, s2);
            return s1.Equals(s2);
        }
        public static bool operator !=(SaaChatBubble s1, SaaChatBubble s2)
        {
            if (((object)s1) == null || ((object)s2) == null) return !Object.Equals(s1, s2);
            return !s1.Equals(s2);
        }
    }
}
