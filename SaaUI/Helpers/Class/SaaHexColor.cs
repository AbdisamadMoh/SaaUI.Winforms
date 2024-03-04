using System.Drawing;

namespace SaaUI
{
    static class SaaHexColors
    {
        public static Color FromHex(this string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }
    }
}
