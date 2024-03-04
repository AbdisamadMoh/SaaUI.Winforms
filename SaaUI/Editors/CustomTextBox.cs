
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    class CustomTextBox : TextBox
    {
        #region Fields

        #region Protected Fields

        protected string _waterMarkText = "Watermark..."; //The watermark text
        protected Color _waterMarkColor; //Color of the watermark when the control does not have focus
        protected Color _waterMarkActiveColor; //Color of the watermark when the control has focus

        #endregion

        #region Private Fields

        private Panel waterMarkContainer; //Container to hold the watermark
        private Font waterMarkFont; //Font of the watermark
        private SolidBrush waterMarkBrush; //Brush for the watermark

        #endregion

        #endregion

        #region Constructors

        public CustomTextBox()
        {
            Initialize();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes watermark properties and adds CtextBox events
        /// </summary>
        private void Initialize()
        {
            //Sets some default values to the watermark properties
            _waterMarkColor = "#ABABAB".FromHex();
            _waterMarkActiveColor = "#505050".FromHex();
            waterMarkFont = this.Font;
            waterMarkBrush = new SolidBrush(_waterMarkActiveColor);
            waterMarkContainer = null;

            DrawWaterMark();

            this.Enter += new EventHandler(ThisHasFocus);
            this.Leave += new EventHandler(ThisWasLeaved);
            this.TextChanged += new EventHandler(ThisTextChanged);
        }

        /// <summary>
        /// Removes the watermark if it should
        /// </summary>
        private void RemoveWaterMark()
        {
            if (waterMarkContainer != null)
            {
                //causes error
                this.Controls.Remove(waterMarkContainer);
                waterMarkContainer = null;
            }
        }

        /// <summary>
        /// Draws the watermark if the text length is 0
        /// </summary>
        private void DrawWaterMark()
        {
            if (this.waterMarkContainer == null && this.TextLength <= 0)
            {
                waterMarkContainer = new Panel(); // Creates the new panel instance
                waterMarkContainer.Paint += new PaintEventHandler(waterMarkContainer_Paint);
                waterMarkContainer.Invalidate();
                waterMarkContainer.Click += new EventHandler(waterMarkContainer_Click);
                this.Controls.Add(waterMarkContainer); // adds the control
            }
        }

        #endregion

        #region Eventhandlers

        #region WaterMark Events

        private void waterMarkContainer_Click(object sender, EventArgs e)
        {
            this.Focus(); 
        }

        private void waterMarkContainer_Paint(object sender, PaintEventArgs e)
        {
            waterMarkContainer.Location = new Point(2, 0); // sets the location
            waterMarkContainer.Height = this.Height; // Height should be the same as its parent
            waterMarkContainer.Width = this.Width; // same goes for width and the parent
            waterMarkContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right; // makes sure that it resizes with the parent control



            if (this.ContainsFocus)
            {
                waterMarkBrush = new SolidBrush(this._waterMarkActiveColor);
            }

            else
            {
                waterMarkBrush = new SolidBrush(this._waterMarkColor);
            }

            //Drawing the string into the panel 
            Graphics g = e.Graphics;
            g.DrawString(this._waterMarkText, waterMarkFont, waterMarkBrush, new PointF(-2f, 1f));

        }

        #endregion

        #region TextBox Events
        public delegate void HasFocus();
        public delegate void HasNoFocus();

        public event HasFocus OnHasFocus;
        public event HasNoFocus OnHasNoFocus;
        private void ThisHasFocus(object sender, EventArgs e)
        {
            waterMarkBrush = new SolidBrush(this._waterMarkActiveColor);

            if (this.TextLength <= 0)
            {
                RemoveWaterMark();
                DrawWaterMark();
            }
            OnHasFocus?.Invoke();
        }

        private void ThisWasLeaved(object sender, EventArgs e)
        {
            if (this.TextLength > 0)
            {
                RemoveWaterMark();
            }
            else
            {
                this.Invalidate();
            }
            OnHasNoFocus?.Invoke();
        }

        private void ThisTextChanged(object sender, EventArgs e)
        {
            if (this.TextLength > 0)
            {
                RemoveWaterMark();
            }
            else
            {
                DrawWaterMark();
            }
        }

        #region Overrided Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawWaterMark();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            if (waterMarkContainer != null)
                waterMarkContainer.Invalidate();
        }


        #endregion

        #endregion

        #endregion

        #region Properties
        [Category("Saa")]
        [Description("Gets or Sets watermarkText")]
        public string WaterMarkText
        {
            get { return this._waterMarkText; }
            set
            {
                this._waterMarkText = value;
                this.Invalidate();
            }
        }

        [Category("Saa")]
        [Description("Gets or Sets Watermark color when control is active")]
        public Color WaterMarkActiveColor
        {
            get { return this._waterMarkActiveColor; }

            set
            {
                this._waterMarkActiveColor = value;
                this.Invalidate();
            }
        }

        [Category("Saa")]
        [Description("Gets or Sets Watermark color")]
        public Color WaterMarkInActiveColor
        {
            get { return this._waterMarkColor; }

            set
            {
                this._waterMarkColor = value;
                this.Invalidate();
            }
        }

        [Category("Saa")]
        [Description("Gets or Sets watermark font")]
        public Font WaterMarkFont
        {
            get
            {
                return this.waterMarkFont;
            }

            set
            {
                this.waterMarkFont = value;
                this.Invalidate();
            }
        }

        #endregion
    }
}
