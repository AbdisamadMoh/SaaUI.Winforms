using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable SaaTexbox.
    /// </summary>
    [Description("Beautiful and customizable SaaTexbox.")]
    [ToolboxBitmap(typeof(SaaTextBox), "icons.SaaTextBox_16.bmp")]
    public class SaaTextBox : TextBox
    {
        Timer timer = new Timer();
        public SaaTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            if (_AutoSize != AutoSize)
            {
                AutoSize = _AutoSize;
                Invalidate();
            }
            // this.SetStyle(ControlStyles.UserPaint, true);
            // timer.Tick += Timer_Tick;
            //  timer.Interval = 2;
            // timer.Start();

        }
        public static bool SetStyle1(Control c, ControlStyles Style, bool value)
        {
            bool retval = false;
            Type typeTB = typeof(Control);
            System.Reflection.MethodInfo misSetStyle = typeTB.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (misSetStyle != null && c != null) { misSetStyle.Invoke(c, new object[] { Style, value }); retval = true; }
            return retval;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_AutoSize != AutoSize)
            {
                AutoSize = _AutoSize;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Transparenter tra = new Transparenter();
            tra.MakeTransparent(e.Graphics, this);
            base.OnPaint(e);

        }

        bool _AutoSize = false;
        /// <summary>
        /// Gets or Sets whether the control will resize its height to fit its content.
        /// </summary>
        [Description("Gets or Sets whether the control will resize its height to fit its content.")]
        [Category("Saa")]
        [Browsable(true)]
        public bool AutoSizing
        {
            get
            {
                return _AutoSize;
            }

            set
            {
                AutoSize = _AutoSize = value;
                Invalidate();
            }
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            if (_AutoSize != AutoSize)
            {
                AutoSize = _AutoSize;
                Invalidate();
            }
            base.OnAutoSizeChanged(e);
        }



    }
}
