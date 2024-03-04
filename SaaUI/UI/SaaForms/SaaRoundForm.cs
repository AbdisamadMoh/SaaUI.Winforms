using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable SaaRoundForm.
    /// </summary>
    [Description("Beautiful and customizable SaaRoundForm.")]
    internal class SaaRoundForm : Form, IEquatable<SaaRoundForm>
    {
        public SaaRoundForm()
        {


            Radius.Change += Radius1_Change;
            DoubleBuffered = true;

        }
        internal string Id { get; set; } = SaaExtensions.NewID;
        private void Radius1_Change()
        {

            Invalidate();
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





        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new BorderPath(0, 0, Width, Height, _Radius);
            this.Region = new Region(rec.Path);
            if (ColorType == PanelColorType.Gradient)
            {
                using (LinearGradientBrush inactiveGB = new LinearGradientBrush(rec.RectangleF, BackColor, _BackColor2, _BackColorAngle))
                {
                    e.Graphics.FillPath(inactiveGB, rec.Path);
                }
            }
            else
            {
                using (SolidBrush backColor = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(backColor, rec.Path);
                }
            }
            base.OnPaint(e);
        }

        PanelColorType _ColorType = PanelColorType.Default;
        public PanelColorType ColorType
        {
            get
            {
                return _ColorType;
            }
            set
            {
                _ColorType = value;
                Invalidate();
            }
        }
        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets the border radius of the control.
        /// </summary>
        [Description("Gets or Sets the border radius of the control."), Category("Saa")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                Invalidate();
            }
        }
        Color _BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));

        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        public Color BackColor2
        {
            get
            {
                return _BackColor2;
            }

            set
            {
                _BackColor2 = value;
                Invalidate();
            }
        }
        float _BackColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Category("Saa")]
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        public float BackColorAngle
        {
            get
            {
                return _BackColorAngle;
            }

            set
            {
                _BackColorAngle = value;
                Invalidate();
            }
        }

        public bool Equals(SaaRoundForm other)
        {
            if (other == null) return false;
            if (other.Id == this.Id) return true; else return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            SaaRoundForm sc = obj as SaaRoundForm;
            if (sc == null) return false;
            else return Equals(sc);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(SaaRoundForm s1, SaaRoundForm s2)
        {
            if (((object)s1) == null || ((object)s2) == null) return Object.Equals(s1, s2);
            return s1.Equals(s2);
        }
        public static bool operator !=(SaaRoundForm s1, SaaRoundForm s2)
        {
            if (((object)s1) == null || ((object)s2) == null) return !Object.Equals(s1, s2);
            return !s1.Equals(s2);
        }
    }
}
