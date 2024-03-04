using System;
using System.ComponentModel;
using System.Drawing;

namespace SaaUI.Properties
{
    /// <summary>
    /// iOS style options
    /// </summary>
    [Description("Gets or Sets iOS style options"), Category("Saa")]
    [TypeConverter(typeof(SaaToggleStylesObjectConverter))]
    public class iOS
    {
        public delegate void OnChange();
        public event OnChange Change;

        public delegate void OnOffSizeChange(Size OldSize, Size NewSize);
        public event OnOffSizeChange OffSizeChange;
        public iOS()
        {
            Radius.Change += Radius_Change;
            HeadRadius.Change += Radius_Change;
        }

        private void Radius_Change()
        {
            Change?.Invoke();
        }

        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets radius of the iOS toggle. This to work, <see cref="RadiusStyle"/> should be set to 'Custom'.
        /// </summary>
        [Description("Gets or Sets radius of the iOS toggle. This to work, 'RadiusStyle' should be set to 'Custom'."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {

                _Radius = value;
                Change?.Invoke();

            }
        }

        Radius _HeadRadius = new Radius();
        /// <summary>
        /// Gets or Sets radius of the iOS toggle head. This to work, <see cref="RadiusStyle"/> should be set to 'Custom'.
        /// </summary>
        [Description("Gets or Sets radius of the iOS toggle head. This to work, 'RadiusStyle' should be set to 'Custom'."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Radius HeadRadius
        {
            get
            {
                return _HeadRadius;
            }
            set
            {

                _HeadRadius = value;
                Change?.Invoke();


            }
        }

        Point _Offset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how the far the iOS Toggle should move from left (X) and from top (Y).
        /// </summary>
        [Description("Gets or Sets how the far the iOS Toggle should move from left (X) and from top (Y)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point Offset
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
                Change?.Invoke();
            }
        }



        Point _OnHeadOffset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how the far the iOS Toggle head should move from left (X) and from top (Y) when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets how the far the iOS Toggle head should move from left (X) and from top (Y) when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point OnHeadOffset
        {
            get
            {
                return _OnHeadOffset;
            }
            set
            {
                _OnHeadOffset = value;
                Change?.Invoke();
            }
        }

        Point _OffHeadOffset = new Point(1, 0);
        /// <summary>
        /// Gets or Sets how the far the iOS Toggle head should move from left (X) and from top (Y) when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets how the far the iOS Toggle head should move from left (X) and from top (Y) when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point OffHeadOffset
        {
            get
            {
                return _OffHeadOffset;
            }
            set
            {
                _OffHeadOffset = value;
                Change?.Invoke();
            }
        }

        Size _OffSize = new Size(0, 1);
        /// <summary>
        /// Gets or Sets extra empty height and width to be added to the iOS toggle.
        /// </summary>
        [Description("Gets or Sets extra empty height and width to be added to the iOS toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Size OffSize
        {
            get
            {
                return _OffSize;
            }
            set
            {
                OffSizeChange?.Invoke(_OffSize, value);
                _OffSize = value;
                // Change?.Invoke();

            }
        }

        Size _HeadOffSize = new Size(0, 0);
        /// <summary>
        /// Gets or Sets extra height and width to be added to the iOS toggle head.
        /// </summary>
        [Description("Gets or Sets extra height and width to be added to the iOS toggle head."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Size HeadOffSize
        {
            get
            {
                return _HeadOffSize;
            }
            set
            {
                _HeadOffSize = value;
                Change?.Invoke();
            }
        }

        ToggleRadius _RadiusStyle = ToggleRadius.Round;
        /// <summary>
        /// Gets or Sets whether the radius of the iOS toggle is round or custom.
        /// </summary>
        [Description("Gets or Sets whether the radius of the iOS toggle is round or custom."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public ToggleRadius RadiusStyle
        {
            get
            {
                return _RadiusStyle;
            }
            set
            {
                _RadiusStyle = value;
                Change?.Invoke();
            }
        }

        int _Speed = 5;
        /// <summary>
        /// Gets or Sets animation speed of the iOS toggle.
        /// </summary>
        [Description("Gets or Sets animation speed of the iOS toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                _Speed = value;
                Change?.Invoke();
            }
        }

    }

    /// <summary>
    /// Flat style options
    /// </summary>
    [Description("Gets or Sets Flat style options"), Category("Saa")]
    [TypeConverter(typeof(SaaToggleStylesObjectConverter))]
    public class Flat
    {
        public delegate void OnChange();
        public event OnChange Change;

        public delegate void OnOffSizeChange(Size OldSize, Size NewSize);
        public event OnOffSizeChange OffSizeChange;
        public Flat()
        {
            Radius.Change += Radius_Change;
            HeadRadius.Change += Radius_Change;
        }

        private void Radius_Change()
        {
            Change?.Invoke();
        }

        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets radius of the flat toggle. This to work, <see cref="RadiusStyle"/> should be set to 'Custom'.
        /// </summary>
        [Description("Gets or Sets radius of the flat toggle. This to work, 'RadiusStyle' should be set to 'Custom'."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {

                _Radius = value;
                Change?.Invoke();

            }
        }

        Radius _HeadRadius = new Radius();
        /// <summary>
        /// Gets or Sets head radius of the flat toggle. This to work, <see cref="RadiusStyle"/> should be set to 'Custom'.
        /// </summary>
        [Description("Gets or Sets head radius of the flat toggle. This to work, 'RadiusStyle' should be set to 'Custom'."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Radius HeadRadius
        {
            get
            {
                return _HeadRadius;
            }
            set
            {

                _HeadRadius = value;
                Change?.Invoke();


            }
        }

        Point _Offset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how far the flat toggle will move from left(X) and from top(Y).
        /// </summary>
        [Description("Gets or Sets how far the flat toggle will move from left(X) and from top(Y)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point Offset
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
                Change?.Invoke();
            }
        }



        Point _OnHeadOffset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how far the flat toggle head will move from left(X) and from top(Y) when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets how far the flat toggle head will move from left(X) and from top(Y) when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point OnHeadOffset
        {
            get
            {
                return _OnHeadOffset;
            }
            set
            {
                _OnHeadOffset = value;
                Change?.Invoke();
            }
        }

        Point _OffHeadOffset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how far the flat toggle head will move from left(X) and from top(Y) when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets how far the flat toggle head will move from left(X) and from top(Y) when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point OffHeadOffset
        {
            get
            {
                return _OffHeadOffset;
            }
            set
            {
                _OffHeadOffset = value;
                Change?.Invoke();
            }
        }

        Size _OffSize = new Size(0, 0);
        /// <summary>
        /// Gets or Sets extra empty height or width to be added to the flat toggle.
        /// </summary>
        [Description("Gets or Sets extra empty height or width to be added to the flat toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Size OffSize
        {
            get
            {
                return _OffSize;
            }
            set
            {
                OffSizeChange?.Invoke(_OffSize, value);
                _OffSize = value;
                // Change?.Invoke();

            }
        }

        Size _HeadOffSize = new Size(0, 0);
        /// <summary>
        /// Gets or Sets extra height or width to be added to the flat toggle head.
        /// </summary>
        [Description("Gets or Sets extra height or width to be added to the flat toggle head."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Size HeadOffSize
        {
            get
            {
                return _HeadOffSize;
            }
            set
            {
                _HeadOffSize = value;
                Change?.Invoke();
            }
        }

        ToggleRadius _RadiusStyle = ToggleRadius.Round;
        /// <summary>
        /// Gets or Sets whether radius of the flat toggle is rounded or custom.
        /// </summary>
        [Description("Gets or Sets whether radius of the flat toggle is rounded or custom."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public ToggleRadius RadiusStyle
        {
            get
            {
                return _RadiusStyle;
            }
            set
            {
                _RadiusStyle = value;
                Change?.Invoke();
            }
        }

        ToggleFlatHeadColorType _HeadColor = ToggleFlatHeadColorType.BackColor;
        /// <summary>
        /// Gets or Sets whether the flat toggle head will take the color of the 'BackColor' or 'HeadColor'.
        /// </summary>
        [Description("Gets or Sets whether the flat toggle head will take the color of the 'BackColor' or 'HeadColor'."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public ToggleFlatHeadColorType HeadColorType
        {
            get
            {
                return _HeadColor;
            }
            set
            {
                _HeadColor = value;
                Change?.Invoke();
            }
        }

        int _Speed = 5;
        /// <summary>
        /// Gets or Sets the animation speed of the flat toggle.
        /// </summary>
        [Description("Gets or Sets the animation speed of the flat toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                _Speed = value;
                Change?.Invoke();
            }
        }

        int _Border = 5;
        /// <summary>
        /// Gets or Sets the thickness of the flat toggle border.
        /// </summary>
        [Description("Gets or Sets the thickness of the flat toggle border."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public int Border
        {
            get
            {
                return _Border;
            }
            set
            {
                _Border = value;
                Change?.Invoke();
            }
        }

    }

    /// <summary>
    /// Skewed style options
    /// </summary>
    [Description("Gets or Sets Skewed style options"), Category("Saa")]
    [TypeConverter(typeof(SaaToggleStylesObjectConverter))]
    public class Skewed : IDisposable
    {
        public delegate void OnChange();
        public event OnChange Change;

        public delegate void OnOffSizeChange(Size OldSize, Size NewSize);
        public event OnOffSizeChange OffSizeChange;
        public Skewed()
        {
            Coordinates.Change += Radius_Change;
        }

        private void Radius_Change()
        {
            Change?.Invoke();
        }


        ToggleSkewedCoordinates _Coordinates = new ToggleSkewedCoordinates();
        /// <summary>
        /// Gets or Sets coordinates of the skewed style. These coordinates dictate how Skewed toggle is drawn.
        /// </summary>
        [Description("Gets or Sets coordinates of the skewed style. These coordinates dictate how Skewed toggle is drawn."), Category("Saa")]

        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public ToggleSkewedCoordinates Coordinates
        {
            get
            {
                return _Coordinates;
            }
            set
            {
                _Coordinates = value;
                Change?.Invoke();
            }
        }


        Point _Offset = new Point(0, 0);
        /// <summary>
        /// Gets or Sets how far the toggle should move from left to right and from top to bottom. X and Y respectively.
        /// </summary>
        [Description("Gets or Sets how far the toggle should move from left to right and from top to bottom. X and Y respectively."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point OffSet
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
                Change?.Invoke();
            }
        }


        string _OnText = "ON";
        /// <summary>
        /// Gets or Sets Text of the skewed toggle when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets Text of the skewed toggle when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public string OnText
        {
            get
            {
                return _OnText;
            }
            set
            {
                _OnText = value;
                Change?.Invoke();
            }
        }

        string _OffText = "OFF";
        /// <summary>
        /// Gets or Sets Text of the skewed toggle when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets Text of the skewed toggle when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public string OffText
        {
            get
            {
                return _OffText;
            }
            set
            {
                _OffText = value;
                Change?.Invoke();
            }
        }

        Font _OffFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        /// <summary>
        /// Gets or Sets Font of the skewed toggle when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets Font of the skewed toggle when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Font OffFont
        {
            get
            {
                return _OffFont;
            }
            set
            {
                _OffFont = value;
                Change?.Invoke();
            }
        }

        Font _OnFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        /// <summary>
        /// Gets or Sets Font of the skewed toggle when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets Font of the skewed toggle when it is On (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Font OnFont
        {
            get
            {
                return _OnFont;
            }
            set
            {
                _OnFont = value;
                Change?.Invoke();
            }
        }


        Size _OffSize = new Size(0, 0);
        /// <summary>
        /// Gets or Sets extra height to be added to the skewed toggle.
        /// </summary>
        [Description("Gets or Sets extra height to be added to the skewed toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Size SizeOffSet
        {
            get
            {
                return _OffSize;
            }
            set
            {
                OffSizeChange?.Invoke(_OffSize, value);
                _OffSize = value;
                // Change?.Invoke();

            }
        }



        int _Speed = 5;
        /// <summary>
        /// Gets or Sets animation speed of the skewed toggle.
        /// </summary>
        [Description("Gets or Sets animation speed of the skewed toggle."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                _Speed = value;
                Change?.Invoke();
            }
        }

        public void Dispose()
        {
            _OnFont.Dispose();
            _OffFont.Dispose();
        }
    }

    /// <summary>
    /// SaaToggle Color options
    /// </summary>
    [Description("Gets or Sets color options"), Category("Saa")]
    [TypeConverter(typeof(SaaToggleStylesObjectConverter))]
    public class SaaToggleColors
    {
        public SaaToggleColors()
        {

        }

        public delegate void OnChange();
        public event OnChange Change;

        Color _OnBackColor = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets Toggle background color when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets Toggle background color when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OnBackColor
        {
            get
            {
                return _OnBackColor;
            }
            set
            {
                _OnBackColor = value;
                Change?.Invoke();
            }
        }

        Color _OffBackColor = Color.LightGray;
        /// <summary>
        /// Gets or Sets Toggle background color when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets Toggle background color when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OffBackColor
        {
            get
            {
                return _OffBackColor;
            }
            set
            {
                _OffBackColor = value;
                Change?.Invoke();
            }
        }





        Color _OnHeadColor = Color.White;
        /// <summary>
        /// Gets or Sets Toggle head (for iOS and Flat styles) color when it is ON (Checked =true).
        /// </summary>
        [Description("Gets or Sets Toggle head color (for iOS and Flat styles) when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OnHeadColor
        {
            get
            {
                return _OnHeadColor;
            }
            set
            {
                _OnHeadColor = value;
                Change?.Invoke();
            }
        }

        Color _OffHeadColor = Color.WhiteSmoke;
        /// <summary>
        /// Gets or Sets Toggle head (for iOS and Flat styles) color when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets Toggle head color (for iOS and Flat styles) when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OffHeadColor
        {
            get
            {
                return _OffHeadColor;
            }
            set
            {
                _OffHeadColor = value;
                Change?.Invoke();
            }
        }



        Color _OnForeColor = Color.White;
        /// <summary>
        /// Gets or Sets Toggle text color (for Skewed style) when it is ON (Checked = true).
        /// </summary>
        [Description("Gets or Sets Toggle text color (for Skewed style) when it is ON (Checked = true)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OnForeColor
        {
            get
            {
                return _OnForeColor;
            }
            set
            {
                _OnForeColor = value;
                Change?.Invoke();
            }
        }
        Color _OffForeColor = Color.White;
        /// <summary>
        /// Gets or Sets Toggle text color (for Skewed style) when it is OFF (Checked = false).
        /// </summary>
        [Description("Gets or Sets Toggle text color (for Skewed style) when it is OFF (Checked = false)."), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Color OffForeColor
        {
            get
            {
                return _OffForeColor;
            }
            set
            {
                _OffForeColor = value;
                Change?.Invoke();
            }
        }
    }

    /// <summary>
    /// These are coordinates dictating how Skewed toggle is drawn.
    /// </summary>
    [Description("These are coordinates dictating how Skewed toggle is drawn."), Category("Saa")]
    [TypeConverter(typeof(SaaToggleStylesObjectConverter))]
    public class ToggleSkewedCoordinates
    {

        public delegate void OnChange();
        public event OnChange Change;
        public ToggleSkewedCoordinates()
        {

        }
        Point _TopLeft, _TopRight, _BottomRight, _BottomLeft, _BottomXY1, _BottomXY2, _LeftXY1, _LeftXY2 = new Point();

        /// <summary>
        /// Gets or Sets Top Left XY coordinates
        /// </summary>
        [Description("Gets or Sets Top Left XY coordinates"), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point TopLeft
        {
            get
            {
                return _TopLeft;
            }
            set
            {
                _TopLeft = value;
                Change?.Invoke();
            }
        }

        /// <summary>
        /// Gets or Sets Top Right XY coordinates
        /// </summary>
        [Description("Gets or Sets Top Righ XY coordinates"), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point TopRight
        {
            get
            {
                return _TopRight;
            }
            set
            {
                _TopRight = value;
                Change?.Invoke();
            }
        }

        /// <summary>
        /// Gets or Sets Bottom Right XY coordinates
        /// </summary>
        [Description("Gets or Sets Bottom Right XY coordinates"), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point BottomRight
        {
            get
            {
                return _BottomRight;
            }
            set
            {
                _BottomRight = value;
                Change?.Invoke();
            }
        }
        /// <summary>
        /// Gets or Sets Bottom Left XY coordinates
        /// </summary>
        [Description("Gets or Sets Bottom Left XY coordinates"), Category("Saa")]
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), RefreshProperties(RefreshProperties.Repaint)]
        public Point BottomLeft
        {
            get
            {
                return _BottomLeft;
            }
            set
            {
                _BottomLeft = value;
                Change?.Invoke();
            }
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ToggleSkewedPoints
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Point XY1 { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Point XY2 { get; set; }
    }
}
