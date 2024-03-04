

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace SaaUI
{
    partial class SaaImageButton
    {
        // public delegate void BtnClicked(object sender, EventArgs e);
        public new EventHandler Click;

        //--------------------------------

        #region Button Properties
            public new string Text
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Obsolete("Use 'BackgroundColor' instead. Using 'BackColor' will have conflict with ur border color.")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }
        

        int _BorderThickness = 1;
        public int BorderThickness
        {
            get
            {
                return _BorderThickness;
            }
            set
            {
                _BorderThickness = value;
                UpdateBorder();
            }
        }


        Color _BackColor = Color.FromArgb(44, 188, 210);
        public Color BackgroundColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;
                this.panel1.BackColor = value;
            }
        }

        Color _HoverBackColor = Color.FromArgb(255, 192, 192);
        public Color HoverBackColor
        {
            get
            {
                return _HoverBackColor;

            }
            set
            {
                _HoverBackColor = value;
            }
        }
        Color _HoverTextColor = SystemColors.ControlText;
        public Color HoverTextColor
        {
            get
            {
                return _HoverTextColor;

            }
            set
            {
                _HoverTextColor = value;
            }
        }

        Color _ClickColor = Color.FromArgb(255, 192, 192);
        public Color ClickColor
        {
            get
            {
                return _ClickColor;
            }
            set
            {
                _ClickColor = value;
            }
        }

         bool _ShowBorder= true;
        public bool ShowBorder
        {
            get
            {
                return _ShowBorder;
            }
            set
            {
                _ShowBorder = value;
                UpdateBorder();
            }
        }

        Color _BorderColor = Color.Black;
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                UpdateBorder();
            }
        }

        




        #endregion



        //--------------------------



        #region Radius Properties
        private RadiusType _RadiusType = RadiusType.Custom;
        public RadiusType RadiusType
        {
            get
            {
                return _RadiusType;
            }
            set
            {
                _RadiusType = value;
                UpdateRadius();
            }
        }


        // int _CustomRadius = 1;
        int _RadiusWith = 10;
        int _InnerRadiusWith = 0;
        public int BorderRadius
        {
            get
            {
                return _RadiusWith;
            }
            set
            {
                _RadiusWith = value;
                _RadiusType = RadiusType.Custom;
                UpdateRadius();
            }
        }

        RoundedRectangle.RectangleCorners _BorderRadiusTarget = RoundedRectangle.RectangleCorners.All;

        public RoundedRectangle.RectangleCorners BorderRadiusTarget
        {
            get
            {
                return _BorderRadiusTarget;
            }
            set
            {
                _BorderRadiusTarget = value;
                _RadiusType = RadiusType.Custom;
                UpdateRadius();
            }
        }



        #endregion

        //-------------------------------------------------------------

        #region Image Properties
        public Image Icon
        {
            get
            {
               return this.pictureBox1.Image;
            }
            set
            {
                this.pictureBox1.Image = value;
            }
        }

        public PictureBoxSizeMode IconSizeMode
        {
            get
            {
              return  this.pictureBox1.SizeMode;
            }
            set
            {
                this.pictureBox1.SizeMode = value;
            }
        }
        ButtonImagePosition _ImagePosition = ButtonImagePosition.Left;
       public ButtonImagePosition ImagePosition
        {
            get
            {
                return _ImagePosition;
            }
            set
            {
                _ImagePosition = value;
                PositionImage();
            }
        }

        public bool IconVisibility
        {
            get
            {
              return  this.pictureBox1.Visible;
            }
            set
            {
                this.pictureBox1.Visible = value;
            }
        }


        #endregion


        //-------------------------------

        #region Label Properties

        public Font TextFont
        {
            get
            {
               return this.label1.Font;
            }
            set
            {
                this.label1.Font = value;
            }
        }
         Color _TextBackColor = Color.Transparent;
        private Color TextBackColor
        {
            get
            {
                return _TextBackColor;
            }
            set
            {
                _TextBackColor = value;
                label1.BackColor = value;
            }
        }

        Color _TextColor = SystemColors.ControlText;
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
                this.label1.ForeColor = value;
               
            }
        }

        public ContentAlignment TextPosition
        {
            get
            {
                return label1.TextAlign;
            }
            set
            {
                label1.TextAlign = value;
            }
        }

        public bool TextVisibility
        {
            get
            {
                return this.label1.Visible;
            }
            set
            {
                this.label1.Visible = value;
            }
        }


        #endregion


    }
}
