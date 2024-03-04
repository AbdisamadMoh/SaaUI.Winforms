using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class SaaToastDesigner : Form
    {
        public SaaToastDesigner()
        {
            InitializeComponent();

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
        public SaaToast SaaToast
        {
            get; set;
        }
        internal SaaToastForm s;

        //protected override void OnMouseDownMoveForm(object sender, MouseEventArgs e)
        //{
        //    base.OnMouseDownMoveForm(sender, e);
        //}
        private void SaaToastDesigner_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = this.SaaToast;


            propertyGrid1.PropertyValueChanged += PropertyGrid1_PropertyValueChanged;
            load();
            t.Interval = 500;
            t.Tick += T_Tick;
            t.Start();
            //form.Dock = DockStyle.None;

        }
        bool first = true;
        private void T_Tick(object sender, EventArgs e)
        {

            t.Stop();
            this.s.Hide();
            this.s.Show();
            if (first)
            {
                s.Location = new Point(saaPanel3.Location.X + 15, saaPanel3.Location.Y + 15);
            }
            first = false;

        }

        Timer t = new Timer();

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // this.s.Hide();

            SetUp();
            this.s.Preview();

            this.s.SetResize();
            var loc = this.s.Location;
            saaPanel3.Controls.Remove(this.s);
            //  this.s.Location = loc;
            saaPanel3.Controls.Add(this.s);


        }

        void load()
        {
            try
            {

                if (s == null)
                {
                    s = new SaaToastForm();
                    s.OnHided += S_OnHided;
                    SetUp();
                    s.TopLevel = false;
                    s.Parent = saaPanel3;
                    this.saaPanel3.Controls.Add(s);
                    s.Show();

                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void S_OnHided()
        {
            saaPanel4.Visible = true;
        }

        private void SetUp()
        {
            s.isPreview = true;
            s.saaPictureBox1.Visible = this.SaaToast.ShowBodyIcon;
            s.saaLabel2.Visible = this.SaaToast.ShowTitle;
            s.saaPanel1.Visible = this.SaaToast.ShowHeader;
            s.saaPictureBox2.Visible = this.SaaToast.ShowCloseIcon;
            s.saaLabel1.Visible = this.SaaToast.ShowBody;

            s.Radius = this.SaaToast.Radius;
            s.BackColor = this.SaaToast.BackColor;
            s.BackColor2 = this.SaaToast.BackColor2;
            s.BackColorAngle = this.SaaToast.BackColorAngle;
            s.Padding = this.SaaToast.Padding;
            s.OffWidth = this.SaaToast.OffWidth;
            s.OffHeight = this.SaaToast.OffHeight;
            s.StopOnHover = this.SaaToast.StopOnHover;
            s.Movable = this.SaaToast.Movable;

            s.saaLabel1.Font = this.SaaToast.BodyTextFont;
            s.saaPanel1.BackColor = this.SaaToast.HeaderBackColor;
            s.saaLabel1.ForeColor = this.SaaToast.BodyTextColor;
            s.saaLabel1.BackColor = this.SaaToast.BodyBackColor;
            s.saaLabel1.Padding = this.SaaToast.BodyPadding;

            s.saaLabel2.BackColor = this.SaaToast.TitleBackColor;
            s.saaLabel2.ForeColor = this.SaaToast.TitleTextColor;
            s.saaLabel2.Font = this.SaaToast.TitleTextFont;
            s.saaLabel2.Padding = this.SaaToast.TitlePadding;
            s.saaLabel2.Text = this.SaaToast.TitleText;

            s.saaPanel1.Padding = this.SaaToast.HeaderPadding;
            s.saaPanel1.BackColor = this.SaaToast.HeaderBackColor;
            s.saaPanel1.BackColor = this.SaaToast.HeaderBackColor2;
            s.saaPanel1.BackColorAngle = this.SaaToast.HeaderBackColorAngle;

            s.lb.BackColor = this.SaaToast.LoaderBackColor;
            s.lb.Dock = (this.SaaToast.LoaderPosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);

            s.LoaderHeight = this.SaaToast.LoaderHeight;

            s.saaPictureBox1.Dock = (this.SaaToast.IconPosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);
            s.saaPictureBox1.SizeMode = this.SaaToast.IconImageSizeMode;
            s.saaPictureBox1.Padding = this.SaaToast.IconPadding;
            s.saaPictureBox1.Image = this.SaaToast.Icon;



            s.CloseActiveImage = this.SaaToast.CloseActiveImage;
            s.CloseInActiveImage = this.SaaToast.CloseInActiveImage;
            s.saaPictureBox2.Image = this.SaaToast.CloseInActiveImage;
            s.saaPictureBox2.SizeMode = this.SaaToast.CloseImageSizeMode;
            s.saaPictureBox2.Dock = (this.SaaToast.ClosePosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);

            s.OffsetX = this.SaaToast.OffsetX;
            s.OffsetY = this.SaaToast.OffsetY;
            s.position = this.SaaToast.Position;

            s.LoaderVisible = this.SaaToast.LoaderVisible;
            s.AutoClose = false;
            s.isCustom = true;
            s.isCustomXY = true;
            s.point = new Point(0, 0);
            s.IntervalInMilliseconds = this.SaaToast.IntervalInMilliseconds;

            s.Size = this.SaaToast.Size;
            s.AutoSizing = this.SaaToast.AutoSize;
            s.MinSize = this.SaaToast.MinSize;
            s.Value = this.SaaToast.Text;
            // s.ApplyShadow = this.SaaToast.ApplyShadow;

        }



        private void saaButton1_Click(object sender, EventArgs e)
        {

        }

        private void saaButton3_Click(object sender, EventArgs e)
        {
            load();
        }

        private void saaButton1_Click_1(object sender, EventArgs e)
        {
            s.Show();
            saaPanel4.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saaButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
