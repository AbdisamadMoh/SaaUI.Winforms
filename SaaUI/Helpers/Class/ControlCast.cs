using SaaUI.Properties;
using System.Windows.Forms;

namespace SaaUI
{
    internal static class ControlCast
    {

        public static BorderPath GetControlPath(Control control, Radius radius, int OffsetWidth = 0, int OffsetHeight = 0, bool isR = false)
        {
            BorderPath rec = null;
            if (control != null && !control.IsDisposed)
            {
                if (control.GetType() == typeof(SaaButton))
                {

                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaButton)control).Radius);

                }
                else if (control.GetType() == typeof(SaaImageButton))
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaImageButton)control).Radius);

                }
                else if (control.GetType() == typeof(SaaFlowLayoutPanel))
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaFlowLayoutPanel)control).Radius);

                }
                else if (control.GetType() == typeof(SaaPictureBox))
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaPictureBox)control).Radius);

                }
                else if (control.GetType() == typeof(SaaCard))
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaCard)control).Radius);

                }
                else if (control.GetType() == typeof(SaaPanel))
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, isR ? radius : ((SaaPanel)control).Radius);

                }
                else
                {
                    rec = new BorderPath(0, 0, control.Width + OffsetWidth,
                        control.Height + OffsetHeight, radius);

                }

            }
            return rec;
        }
    }
}
