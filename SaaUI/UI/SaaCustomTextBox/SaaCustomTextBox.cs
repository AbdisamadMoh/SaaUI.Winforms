using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautifully designed and customizable custom SaaTextBox.
    /// </summary>
    [Description("Beautifully designed and customizable custom SaaTextBox.")]
    [DefaultEvent("TextChanged")]
    [ToolboxBitmap(typeof(SaaCustomTextBox), "icons.SaaCustomTextBox_16.bmp")]
    public partial class SaaCustomTextBox : UserControl
    {

        Label lb = new Label();
        SaaPictureBox pic = new SaaPictureBox();
        public new delegate void OnTextChanged(object sender, EventArgs e);
        /// <summary>
        /// Event raised when image on the control is clicked.
        /// </summary>
        /// <param name="sender">object of type <see cref="SaaPictureBox"/></param>
        /// <param name="e"><see cref="EventArgs"/></param>
        public delegate void OnImageClick(object sender, EventArgs e);

        /// <summary>
        /// Fires when text of the control is changed.
        /// </summary>
        [Description("Event raised when text of the control is changed.")]
        [Category("Saa")]
        [Browsable(true)]
        public new event OnTextChanged TextChanged;

        /// <summary>
        /// Event raised when image on the control is clicked.
        /// </summary>
        [Description("Event raised when image on the control is clicked.")]
        [Category("Saa")]
        [Browsable(true)]
        public event OnImageClick ImageClick;

        Timer timer = new Timer();
        public SaaCustomTextBox()
        {
            InitializeComponent();
            // AutoSize = false;

            lb.Dock = DockStyle.Bottom;
            lb.Size = new System.Drawing.Size(3, _LineSize);
            lb.BackColor = "#505050".FromHex();
            this.Controls.Add(lb);

            pic.Image = _ActiveImage;
            pic.Dock = DockStyle.Left;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Padding = new Padding(3);
            pic.Size = new Size(this.Height, this.Height);
            pic.Click += Pic_Click;
            this.panel2.Controls.Add(pic);
            if (this.Parent != null)
            {
                this.BackColor = this.Parent.BackColor;
                // this.Parent.BackColorChanged += Parent_BackColorChanged;
            }
            //timer.Tick += Timer_Tick;
            //timer.Interval = 20;
            //timer.Start();
            //ShowWaterMark(textBox1.Text);
            this.textBox1.OnHasFocus += () =>
            {
                this.lb.BackColor = _LineActiveColor;
                textBox1.ForeColor = _ActiveTextColor;
                pic.Image = _ActiveImage;
            };

            this.textBox1.OnHasNoFocus += () =>
            {
                this.lb.BackColor = _LineInActiveColor;
                textBox1.ForeColor = _InActiveTextColor;
                pic.Image = _InActiveImage;
            };

            try
            {
                //if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                //{

                //    if (!this.Focused)
                //    {
                //        this.ActiveControl = textBox1;
                //        this.ActiveControl = null;
                //    }
                //}
                //else
                //{
                //    this.ActiveControl = textBox1;
                //}
                if (!this.DesignMode)
                {

                }
            }
            catch { }

        }

        private void Pic_Click(object sender, EventArgs e)
        {
            if (ImageClick != null)
            {
                ImageClick.Invoke(sender, e);
            }
            else
            {
                textBox1.Focus();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            //if (this.Focused)
            //{
            //    this.textBox1.Visible = true;
            //}
            //else
            //{
            //    ShowWaterMark(textBox1.Text);
            //}
        }

        private void Init()
        {
            //GotFocus += (object sender, EventArgs e) =>
            // {
            //     ShowWaterMark(textBox1.Text);
            // };
            //LostFocus += (object sender, EventArgs e) =>
            //{
            //    ShowWaterMark(textBox1.Text);
            //};
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new RoundedRectangleF(Width, Height, _Radius, _RadiusCorner);
            this.Region = new Region(rec.Path);
            UpdateControls();
            base.OnPaint(e);
        }
        private void UpdateControls()
        {
            #region BackColor Validation


            #endregion
            if (this.DesignMode)
            {
                textBox1.ForeColor = _InActiveTextColor;
                pic.Image = _InActiveImage;
            }
            try
            {
                textBox1.Font = this.Font;
            }
            catch { }
            // textBox1.Text = this._Text;

            #region Line
            this.lb.Visible = _Line;
            this.lb.BackColor = _LineInActiveColor;
            if (_LineImage)
            {
                lb.BringToFront();
                try
                {
                    this.panel1.Controls.Remove(lb);
                    panel1.Size = new Size(0, 20);
                }
                catch { }
                try
                {
                    this.Controls.Add(lb);
                    textBox1.Margin = new Padding(0, 0, 0, 5);
                }
                catch { }
            }
            else
            {
                try
                {
                    this.panel1.Controls.Add(lb);
                    textBox1.Margin = new Padding(0);
                    panel1.Size = new Size(0, _LineSize + 20);
                }
                catch { }
                try
                {
                    this.Controls.Remove(lb);
                }
                catch { }

            }
            #endregion

        }

        /// <summary>
        /// Gets or Sets  cursor of the control.
        /// </summary>
        [Description("Gets or Sets  cursor of the control.")]
        [Category("Saa")]
        public override Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }

            set
            {
                base.Cursor = value;
                panel1.Cursor = panel2.Cursor = textBox1.Cursor = value;
            }
        }
        /// <summary>
        /// Gets or Sets image cursor of the control.
        /// </summary>
        [Description("Gets or Sets image cursor of the control.")]
        [Category("Saa")]
        public Cursor ImageCursor
        {
            get
            {
                return pic.Cursor;
            }
            set
            {
                pic.Cursor = value;
            }
        }

        /// <summary>
        /// Gets or Sets image sizing mode of the control.
        /// </summary>
        [Description("Gets or Sets image sizing mode of the control.")]
        [Category("Saa")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get
            {
                return pic.SizeMode;
            }
            set
            {
                pic.SizeMode = value;
            }
        }

        /// <summary>
        /// Gets or Sets image of the control.
        /// </summary>
        [Description("Gets or Sets image of the control.")]
        [Category("Saa")]
        public bool Image
        {
            get
            {
                return pic.Visible;
            }
            set
            {
                pic.Visible = value;
                Invalidate();
            }
        }

        ButtonImagePosition _ImagePosition = ButtonImagePosition.Left;
        /// <summary>
        /// Gets or Sets image position of the control.
        /// </summary>
        [Description("Gets or Sets image position of the control.")]
        [Category("Saa")]
        public ButtonImagePosition ImagePosition
        {
            get
            {
                return _ImagePosition;
            }
            set
            {
                _ImagePosition = value;
                if (value == ButtonImagePosition.Left)
                {

                    pic.Dock = DockStyle.Left;
                }
                else
                {
                    pic.Dock = DockStyle.Right;
                }
                Invalidate();
            }
        }
        Image _ActiveImage = Resources.icons8_User_32;
        /// <summary>
        /// Gets or Sets image when control is active.
        /// </summary>
        [Description("Gets or Sets image when control is active.")]
        [Category("Saa")]
        public Image ActiveImage
        {
            get
            {
                return _ActiveImage;
            }
            set
            {
                _ActiveImage = value;
                Invalidate();
            }
        }

        Image _InActiveImage = Resources.icons8_UserInActive_32;
        /// <summary>
        /// Gets or Sets image when control is inactive.
        /// </summary>
        [Description("Gets or Sets image when control is inactive.")]
        [Category("Saa")]
        public Image InActiveImage
        {
            get
            {
                return _InActiveImage;
            }
            set
            {
                _InActiveImage = value;
                Invalidate();
            }
        }
        Color _InActiveTextColor = "#ABABAB".FromHex();
        /// <summary>
        /// Gets or Sets text color when control is inactive.
        /// </summary>
        [Description("Gets or Sets text color when control is inactive.")]
        [Category("Saa")]
        public Color InActiveTextColor
        {
            get
            {
                return _InActiveTextColor;
            }
            set
            {
                _InActiveTextColor = value;
                Invalidate();
            }
        }
        Color _ActiveTextColor = "#505050".FromHex();
        /// <summary>
        /// Gets or Sets text color when control is active.
        /// </summary>
        [Description("Gets or Sets text color when control is active.")]
        [Category("Saa")]
        public Color ActiveTextColor
        {
            get
            {
                return _ActiveTextColor;
            }
            set
            {
                _ActiveTextColor = value;
                Invalidate();
            }
        }
        int _LineSize = 2;
        /// <summary>
        /// Gets or Sets size of the line.
        /// </summary>
        [Description("Gets or Sets size of the line.")]
        [Category("Saa")]
        public int LineSize
        {
            get
            {
                return _LineSize;
            }
            set
            {
                _LineSize = value;
                lb.Size = new Size(3, _LineSize);
            }
        }

        Color _LineActiveColor = "#505050".FromHex();
        /// <summary>
        /// Gets or Sets line color when the control is active.
        /// </summary>
        [Description("Gets or Sets line color when the control is active.")]
        [Category("Saa")]
        public Color LineActiveColor
        {
            get
            {
                return _LineActiveColor;
            }
            set
            {
                _LineActiveColor = value;
                Invalidate();
            }
        }
        bool _LineImage = true;
        /// <summary>
        /// Gets or Sets whether the image of the control will also be underlined.
        /// </summary>
        [Description("Gets or Sets whether the image of the control will also be underlined.")]
        [Category("Saa")]
        public bool LineImage
        {
            get
            {
                return _LineImage;
            }
            set
            {
                _LineImage = value;
                Invalidate();
            }
        }
        Color _LineInActiveColor = "#ABABAB".FromHex();
        /// <summary>
        /// Gets or Sets line color when the control is inactive.
        /// </summary>
        [Description("Gets or Sets line color when the control is inactive.")]
        [Category("Saa")]
        public Color LineInActiveColor
        {
            get
            {
                return _LineInActiveColor;
            }
            set
            {
                _LineInActiveColor = value;
                Invalidate();
            }
        }

        bool _Line = true;
        /// <summary>
        /// Gets or Sets whether to show the line.
        /// </summary>
        [Description("Gets or Sets whether to show the line.")]
        [Category("Saa")]
        public bool Line
        {
            get
            {
                return _Line;
            }
            set
            {
                _Line = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets whether to allow wordwrapping.
        /// </summary>
        [Description("Gets or Sets whether to allow wordwrapping.")]
        [Category("Saa")]
        public bool WordWrap
        {
            get
            {
                return textBox1.WordWrap;
            }
            set
            {
                textBox1.WordWrap = value;
            }
        }

        /// <summary>
        /// Gets or Sets whether this control will behave like password textbox.
        /// </summary>
        [Description("Gets or Sets whether this control will behave like password textbox.")]
        [Category("Saa")]
        public bool Password
        {
            get
            {
                return textBox1.UseSystemPasswordChar;
            }
            set
            {
                textBox1.UseSystemPasswordChar = value;
                if (value) { this.textBox1.PasswordChar = new char(); }
            }
        }
        /// <summary>
        /// Gets or Sets text alignment of the control.
        /// </summary>
        [Description("Gets or Sets text alignment of the control.")]
        [Category("Saa")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return textBox1.TextAlign;
            }
            set
            {
                textBox1.TextAlign = value;
            }
        }

        /// <summary>
        /// Gets or Sets current text length.
        /// </summary>
        [Description("Gets or Sets current text length.")]
        [Category("Saa")]
        [Browsable(false)]
        public int TextLength
        {
            get
            {
                return textBox1.TextLength;
            }
        }
        public ScrollBars ScrollBarOption
        {
            get
            {
                return textBox1.ScrollBars;
            }
            set
            {
                textBox1.ScrollBars = value;
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public ScrollBars ScrollBar
        {
            get; set;
        }
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[Browsable(false)]
        //public new RightToLeft RightToLeft
        //{
        //    get;set;
        //}

        public RightToLeft RightToLeftOption
        {
            get
            {
                return textBox1.RightToLeft;
            }
            set
            {
                textBox1.RightToLeft = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
            }
        }

        /// <summary>
        /// Gets or Sets character will be used as password display.
        /// </summary>
        [Description("Gets or Sets character will be used as password display.")]
        [Category("Saa")]
        public char PasswordChar
        {
            get
            {
                return textBox1.PasswordChar;
            }
            set
            {
                textBox1.PasswordChar = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public bool MultiLine
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return textBox1.MaxLength;
            }
            set
            {
                textBox1.MaxLength = value;
            }
        }
        public CharacterCasing CharacterCasing
        {
            get
            {
                return textBox1.CharacterCasing;
            }
            set
            {
                textBox1.CharacterCasing = value;
            }
        }

        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return textBox1.AutoCompleteSource;
            }
            set
            {
                textBox1.AutoCompleteSource = value;
            }
        }
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return textBox1.AutoCompleteMode;
            }
            set
            {
                textBox1.AutoCompleteMode = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]

        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return textBox1.AutoCompleteCustomSource;
            }
            set
            {
                textBox1.AutoCompleteCustomSource = value;
            }
        }
        /// <summary>
        /// Gets or Sets whether to hide selection.
        /// </summary>
        [Description("Gets or Sets whether to hide selection.")]
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public bool HideSelection
        {
            get
            {
                return textBox1.HideSelection;
            }
            set
            {
                textBox1.HideSelection = value;
            }
        }


        bool _Transparent = true;
        /// <summary>
        /// Gets or Sets background color of the control.
        /// </summary>
        [Description("Gets or Sets background color of the control.")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                if (value == Color.Transparent)
                {
                    throw new Exception("Transparent color not supported. To give tramsparent color give same BackColor as that of parent BackColor.");
                }
                else
                {
                    this.textBox1.BackColor = base.BackColor = value;
                    Invalidate();
                }


            }
        }

        string _Text = "";
        /// <summary>
        /// Gets or Sets Text of the control.
        /// </summary>
        [Description("Gets or Sets Text of the control.")]
        [Category("Saa")]
        [Browsable(true)]
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or Sets watermarkText.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets watermarkText.")]
        public string WatermarkText
        {
            get { return this.textBox1.WaterMarkText; }
            set
            {
                this.textBox1.WaterMarkText = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or Sets Watermark color when control is active.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets Watermark color when control is active.")]
        public Color WatermarkActiveColor
        {
            get { return this.textBox1.WaterMarkActiveColor; }

            set
            {
                this.textBox1.WaterMarkActiveColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets Watermark color.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets Watermark color.")]
        public Color WatermarkColor
        {
            get { return this.textBox1.WaterMarkInActiveColor; }

            set
            {
                this.textBox1.WaterMarkInActiveColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets watermark font.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets watermark font.")]
        public Font WatermarkFont
        {
            get
            {
                return this.textBox1.WaterMarkFont;
            }

            set
            {
                this.textBox1.WaterMarkFont = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets border radius, the roundness of the control.
        /// </summary>
        int _Radius = 0;
        [Description("Gets or Sets border radius, the roundness of the control.")]
        [Category("Saa")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value; Invalidate(); }
        }
        /// <summary>
        /// Gets or Set which corner will be rounded by the 'Radius' specified.
        /// </summary>
        RoundCorners _RadiusCorner = RoundCorners.All;
        [Description("Gets or Set which corner will be rounded by the 'Radius' specified.")]
        [Category("Saa")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public RoundCorners RadiusCorner
        {
            get { return _RadiusCorner; }
            set { _RadiusCorner = value; Invalidate(); }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }














    }
}
