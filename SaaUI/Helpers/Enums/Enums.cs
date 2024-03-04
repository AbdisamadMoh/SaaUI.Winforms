using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    public enum ToggleStyle
    {
        iOS = 0,
        Skewed = 1,
        Flat = 2
    }

    public enum ToggleRadius
    {
        Round = 0,
        Custom = 1
    }

    public enum ToggleFlatHeadColorType
    {
        BackColor = 0,
        HeadColor = 1
    }
    public enum PanelColorType
    {
        Default = 0,
        Gradient = 1
    }
    public enum CheckType
    {
        Tick = 0,
        Circle = 1
    }
    public enum CheckBoxMouseClick
    {
        RightClick = 0,
        LeftClick = 1,
        AnyClick = 2,
        NoClick = 3
    }
    public enum SaaMouseClicks
    {
        RightClick = 0,
        LeftClick = 1,
        AnyClick = 2,
        NoClick = 3
    }
    public enum RadiusType
    {
        Rectangle,
        RoundedEdge,
        Circle,
        Custom
    }
    public enum ButtonImagePosition
    {
        Right,
        Left
    }

    public enum SaaCircularProgressDisplayValue
    {
        /// <summary>
        /// Value is displayed in the CircularProgress
        /// </summary>
        Value = 0,
        /// <summary>
        /// Percentage is displayed in the CircularProgress.
        /// </summary>
        Percent = 1,
        /// <summary>
        /// Nothing is displayed in the CircularProgress except <see cref="SaaCircularProgress.Prefix"/> and <see cref="SaaCircularProgress.Suffix"/>
        /// </summary>
        None = 2
    }
    public enum RoundCorners
    {
        None = 0,
        TopLeft = 6,
        TopRight = 5,
        BottomLeft = 8,
        BottomRight = 7,
        Right = 3,
        Left = 4,
        Bottom = 2,
        Top = 1,

        AllExceptTopLeft = 11,
        AllExceptTopRight = 10,
        AllExceptBottomLeft = 13,
        AllExceptBottomRight = 12,

        TopRightBottonLeft = 14,
        BottomRightTopLeft = 15,
        All = 16
    }
    public enum LineAlign
    {
        Start = 0,
        Center = 1,
        End = 2,
        Custom = 3
    }
    public enum ToastPosition
    {
        TopRight = 0,
        TopLeft = 1,
        BottomRight = 2,
        BottomLeft = 3,
        Center = 4
    }
    public enum RightLeftPositions
    {
        Right = 0,
        Left = 1
    }
    public enum RightLeftCenterPositions
    {
        Right = 0,
        Left = 1,
        Center
    }
    public enum TopBottomPositions
    {
        Top = 0,
        Bottom = 1
    }
    public enum TopBottomCenterPositions
    {
        Top = 0,
        Bottom = 1,
        Center
    }
    public enum SidePositions
    {
        Top = 0,
        Bottom = 1,
        Right = 2,
        Left = 3
    }
    public enum SideAutoPositions
    {
        Top = 0,
        Bottom = 1,
        Right = 2,
        Left = 3,
        Auto = 4
    }
    public enum PeakPositions
    {
        TopLeft = 1,
        TopRight = 0,
        BottomRight = 2,
        BottomLeft = 3

    }
    public enum BubbleImagePosition
    {
        Top = 0,
        Bottom = 1
    }
    public enum BubbleProfilePosition
    {
        Right = 0,
        Left = 1
    }
    class BorderStyle1
    {
        public Color ColorLeft { get; set; } = Color.Black;
        public int LeftWidth { get; set; } = 1;
        public ButtonBorderStyle LeftStyle { get; set; } = ButtonBorderStyle.Solid;

        public Color ColorTop { get; set; } = Color.Black;
        public int TopWidth { get; set; } = 1;
        public ButtonBorderStyle TopStyle { get; set; } = ButtonBorderStyle.Solid;

        public Color ColorRight { get; set; } = Color.Black;
        public int RightWidth { get; set; } = 1;
        public ButtonBorderStyle RightStyle { get; set; } = ButtonBorderStyle.Solid;

        public Color ColorBotton { get; set; } = Color.Black;
        public int BottomWidth { get; set; } = 1;
        public ButtonBorderStyle BottomStyle { get; set; } = ButtonBorderStyle.Solid;
    }

    public enum SaaBubbleBorderStyle
    {
        Solid,
        Dash,
        Dot,
        None
    }
    public enum SaaBubbleWordBreak
    {
        BreakAll,
        BreakWord
    }
    public enum SaaSizePercentOrPixel
    {
        Percent,
        Pixel
    }

    public enum SaaIntroTipPosition
    {
        Top,
        Bottom,
        Left,
        Right,
        Auto
    }
    public enum TopLeftCenterPosition
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft,
        Center

    }
    public enum TopLeftCenterAutoPosition
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft,
        Center,
        Auto

    }
    public enum TopLeftPosition
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft
    }
    public enum TopLeftAutoPosition
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft,
        Auto
    }
    public enum IntroTipTrigger
    {
        TargetClick,
        NonTargetClick,
        BothClick,
        None
    }

    public enum DropDownPosition
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public enum SaaBorderStyle
    {
        Solid, Dash, Dot, None
    }
    public enum SaaImageResizing
    {
        AutoSize, Fit, Contain
    }
    public enum SaaComboBoxVerticalScrollOptions
    {
        Top,
        Bottom
    }
    public enum SaaComboBoxVHorizontalScrollOptions
    {
        Left,
        Right
    }
    public enum SaaTextPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
    }
    public enum SaaTextWordBreak
    {
        Wrap,
        Ellipsis,
        None
    }
}
