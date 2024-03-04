namespace SaaUI
{
    internal static class LivePreviewer
    {
        static Preview preview;
        public static void Show(SaaButton1 c, SaaButton1 oC)
        {
            preview = new Preview();
            c.Radius = oC.Radius;
            //  c.Border = oC.Border;
            preview._Control = c;
            preview.Show();

        }
    }
}
