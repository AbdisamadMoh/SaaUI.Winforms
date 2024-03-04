using System.Windows.Forms;

namespace SaaUI
{
    internal static class SaaSetStyle
    {
        public static ControlStyles GetUserPaint
        {
            get
            {
                return (ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.SupportsTransparentBackColor);
            }
        }
    }
}
