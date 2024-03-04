using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaIntroTipDesigner : Form
    {
        SaaIntroTip s;
        public SaaIntroTipDesigner(SaaIntroTip sr)
        {
            InitializeComponent();
            s = sr;
            Get();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Set();
            base.OnClosing(e);
        }
        //Moving form with mouse
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// Fires when Form is clicked moved with mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnMouseDownMoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void Get()
        {
            saaIntroTip1.ArrowBend = s.ArrowBend;
            saaIntroTip1.ArrowColor = s.ArrowColor;
            saaIntroTip1.ArrowHeadStyle = s.ArrowHeadStyle;
            saaIntroTip1.ArrowHeight = s.ArrowHeight;
            saaIntroTip1.ArrowLineStyle = s.ArrowLineStyle;
            saaIntroTip1.ArrowOffset = s.ArrowOffset;
            saaIntroTip1.ArrowTailStyle = s.ArrowTailStyle;
            saaIntroTip1.ArrowThickness = s.ArrowThickness;
            saaIntroTip1.BackColor = s.BackColor;
            saaIntroTip1.Border = s.Border;
            saaIntroTip1.BorderColor = s.BorderColor;
            saaIntroTip1.BorderStyle = s.BorderStyle;
            saaIntroTip1.Cursor = s.Cursor;
            saaIntroTip1.Font = s.Font;
            saaIntroTip1.MouseClicks = s.MouseClicks;
            saaIntroTip1.NextTrigger = s.NextTrigger;
            saaIntroTip1.Position = s.Position;
            saaIntroTip1.Radius = s.Radius;
            saaIntroTip1.TargetBackColor = s.TargetBackColor;
            saaIntroTip1.TargetOffSet = s.TargetOffSet;
            saaIntroTip1.TargetCursor = s.TargetCursor;
            saaIntroTip1.TextColor = s.TextColor;
            saaIntroTip1.TextOffset = s.TextOffset;
            saaIntroTip1.Transparency = s.Transparency;
        }
        private void Set()
        {
            s.ArrowBend = saaIntroTip1.ArrowBend;
            s.ArrowColor = saaIntroTip1.ArrowColor;
            s.ArrowHeadStyle = saaIntroTip1.ArrowHeadStyle;
            s.ArrowHeight = saaIntroTip1.ArrowHeight;
            s.ArrowLineStyle = saaIntroTip1.ArrowLineStyle;
            s.ArrowOffset = saaIntroTip1.ArrowOffset;
            s.ArrowTailStyle = saaIntroTip1.ArrowTailStyle;
            s.ArrowThickness = saaIntroTip1.ArrowThickness;
            s.BackColor = saaIntroTip1.BackColor;
            s.Border = saaIntroTip1.Border;
            s.BorderColor = saaIntroTip1.BorderColor;
            s.BorderStyle = saaIntroTip1.BorderStyle;
            s.Cursor = saaIntroTip1.Cursor;
            s.Font = saaIntroTip1.Font;
            s.MouseClicks = saaIntroTip1.MouseClicks;
            s.NextTrigger = saaIntroTip1.NextTrigger;
            s.Position = saaIntroTip1.Position;
            s.Radius = saaIntroTip1.Radius;
            s.TargetBackColor = saaIntroTip1.TargetBackColor;
            s.TargetOffSet = saaIntroTip1.TargetOffSet;
            s.TargetCursor = saaIntroTip1.TargetCursor;
            s.TextColor = saaIntroTip1.TextColor;
            s.TextOffset = saaIntroTip1.TextOffset;
            s.Transparency = saaIntroTip1.Transparency;
        }
        private void saaButton5_Click(object sender, EventArgs e)
        {
            this.saaIntroTip1.ShowAll();
        }

        private void saaIntroTip1_Clicked(object sender, IntroTipClickEventArgs e)
        {
            if (e.IsTarget) return;
            if (e.TargetControl.GetType() == typeof(PropertyGrid)) { saaIntroTip1.ShowNext(); }
            else { saaIntroTip1.Hide(true); }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void SaaIntroTipDesigner_Load(object sender, EventArgs e)
        {
            Get();
        }

        private void saaIntroTip1_TargetClicked(object sender, IntroTipClickEventArgs e)
        {

            //saaIntroTip1.ShowNext();
        }

        private void saaButton6_Click(object sender, EventArgs e)
        {
            saaIntroTip1.Hide(true);
            saaIntroTip1.Show(saaButton6, "IntroTip on this button is shown using\n 'Show(button6, \"[text to display]\");'");
        }
    }
}
