using SaaUI.Properties;
using System.ComponentModel;
using System.Drawing;

namespace SaaUI
{
    internal interface ICommonSaaUI
    {
        //  Padding BorderDepth { get; set; }
        //  Color BorderColor { get; set; }
        [Description("Gets or Sets border radius, the roundness of the control.")]
        int Radius { get; set; }
        [Description("Gets or Sets which corner will be rounded by the 'Radius' specified.")]
        RoundCorners RadiusCorner { get; set; }


    }

    internal interface ICommonPlusSaaUI : ICommonSaaUI
    {
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        Color BackColor2 { get; set; }
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        float BackColorAngle { get; set; }
    }

    internal interface ISaaCommon
    {

        /// <summary>
        /// Gets or Sets the border radius of the control.
        /// </summary>
        [Description("Gets or Sets the border radius of the control."), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        Radius Radius
        {
            get; set;
        }
        /// <summary>
        /// Gets or Sets border thickness of the control.
        /// </summary>
        [Description("Gets or Sets border thickness of the control."), Category("Saa")]
        int Border
        {
            get; set;
        }
        /// <summary>
        /// Gets or Sets first color of the border color gradient.
        /// </summary>
        [Description("Gets or Sets first color of the border color gradient."), Category("Saa")]
        Color BorderColor
        {
            get; set;
        }
        /// <summary>
        /// Gets or Sets first second of the border color gradient.
        /// </summary>
        [Description("Gets or Sets second color of the border color gradient."), Category("Saa")]
        Color BorderColor2
        {
            get; set;
        }
        /// <summary>
        /// Gets or Sets at which angle the color gradients will meet.
        /// </summary>
        [Description("Gets or Sets at which angle the color gradients will meet."), Category("Saa")]
        int BorderColorAngle
        {
            get; set;
        }

        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        Color BackColor2
        {
            get; set;
        }

        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        float BackColorAngle
        {
            get; set;
        }
    }
}
