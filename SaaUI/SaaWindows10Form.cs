using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    public partial class SaaWindows10Form : Form
    {
       
        string HeaderName = "SaaHeader_yeiuryefnej_cwefuierhueiwf";
        string HeaderPanelName = "SaaHeaderPanel_yeiuryefnej_cwefuierhueiwf";

        string RightPanelName1 = "SaaRight1_yeiuryefnej_cwefuierhueiwf";
        string RightPanelName2 = "SaaRight2_yeiuryefnej_cwefuierhueiwf";

        string LeftPanelName1 = "SaaLeft1_yeiuryefnej_cwefuierhueiwf";
        string LeftPanelName2 = "SaaLeft2_yeiuryefnej_cwefuierhueiwf";

        string BottomPanelName1 = "SaaBottom_yeiuryefnej_cwefuierhueiwf";
        string BottomPanelName2 = "SaaBottom_yeiuryefnej_cwefuierhueiwf";
        public SaaWindows10Form()
        {

            CamFPanSaaPanel HeaderPanel = new CamFPanSaaPanel();
            SaaWindows10Header header = new SaaWindows10Header();

            CamFPanSaaPanel LeftPanel1 = new CamFPanSaaPanel();
            CamFPanSaaPanel LeftPanel2 = new CamFPanSaaPanel();

            LeftPanel1.Name = LeftPanelName1;
            LeftPanel2.Name = LeftPanelName2;

            CamFPanSaaPanel bottomPanel1 = new CamFPanSaaPanel();
            CamFPanSaaPanel bottomPanel2 = new CamFPanSaaPanel();

            bottomPanel1.Name = BottomPanelName1;
            bottomPanel2.Name = BottomPanelName2;

            CamFPanSaaPanel RightPanel1 = new CamFPanSaaPanel();
            RightPanel1.Name = RightPanelName1;
            //RightPanel1.Dock = DockStyle.Right;
            //RightPanel1.Size = new Size(this.Padding.Right, 0);
            //RightPanel1.SendToBack();
            //RightPanel1.BackColor = Color.Transparent;

            CamFPanSaaPanel RightPanel2 = new CamFPanSaaPanel();
            RightPanel2.Name = RightPanelName2;
            //RightPanel2.Size = new Size(this.Padding.Right, this.Height - header.Height);
            //RightPanel2.Location = new Point(this.Width- RightPanel2.Width, header.Height);
            //RightPanel2.BringToFront();
            //RightPanel2.BackColor = Color.Red;





            HeaderPanel.Name = HeaderPanelName;
            HeaderPanel.Dock = DockStyle.Top;

            header.Name = HeaderName;


            this.Controls.Add(header);
            this.Controls.Add(HeaderPanel);

            this.Controls.Add(RightPanel1);
            this.Controls.Add(RightPanel2);

            this.Controls.Add(LeftPanel1);
            this.Controls.Add(LeftPanel2);

            this.Controls.Add(bottomPanel1);
            this.Controls.Add(bottomPanel2);

            InitializeComponent();
            SizableForm();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (_FormBorderStyle)
            {
                case FormBorderStyle.Fixed3D:
                    {

                        break;
                    }
                case FormBorderStyle.FixedDialog:
                    {

                        break;
                    }
                case FormBorderStyle.FixedSingle:
                    {

                        break;
                    }
                case FormBorderStyle.FixedToolWindow:
                    {

                        break;
                    }
                case FormBorderStyle.None:
                    {

                        break;
                    }
                case FormBorderStyle.SizableToolWindow:
                    {

                        break;
                    }
                case FormBorderStyle.Sizable:
                    {
                        SizableForm();
                        break;
                    }
            }
           
        }
        private void SizableForm()
        {
            var header = this.Controls[HeaderName];
            var headerPanel = this.Controls[HeaderPanelName];

            var right1 = this.Controls[RightPanelName1];
            var right2 = this.Controls[RightPanelName2];

            var left1 = this.Controls[LeftPanelName1];
            var left2 = this.Controls[LeftPanelName2];

            var bottom1 = this.Controls[BottomPanelName1];
            var bottom2 = this.Controls[BottomPanelName2];



            right1.Dock = DockStyle.Right;
            right1.Size = new Size(_padding.Right, 0);
            right1.SendToBack();
            right1.BackColor = Color.Transparent;


            right2.Size = new Size(_padding.Right, this.Height - header.Height);
            right2.Location = new Point(this.Width - right2.Width, header.Height);
            right2.BringToFront();
            right2.BackColor = Color.Red;
            //----------------------
           left1.Dock = DockStyle.Left;
           left1.Size = new Size(_padding.Left, 0);
           left1.SendToBack();
           left1.BackColor = Color.Transparent;


            left2.Size = new Size(_padding.Left, this.Height - header.Height);
            left2.Location = new Point(0, header.Height);
            left2.BringToFront();
            left2.BackColor = Color.Red;

            //----------------------
            bottom1.Dock = DockStyle.Bottom;
            bottom1.Size = new Size(0, _padding.Bottom);
            bottom1.SendToBack();
            bottom1.BackColor = Color.Transparent;

            bottom2.Size = new Size(this.Width, _padding.Bottom);
            bottom2.Location = new Point(0, this.Height-_padding.Bottom);
            bottom2.BringToFront();
            bottom2.BackColor = Color.Red;


            headerPanel.Dock = DockStyle.Top;
            headerPanel.SendToBack();
            headerPanel.Size = header.Size;

            header.Width = FindForm().Width;
            header.Location = new Point(0, 0);
            header.BringToFront();
        }
        Padding _Fakepadding = new Padding();
        Padding _padding = new Padding();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new Padding Padding
        {
            get
            {
                return _Fakepadding;
            }
            set
            {
                _Fakepadding = _padding = value;
              //  base.Padding = new Padding();
                Invalidate();
            }
        }
        FormBorderStyle _FormBorderStyle = FormBorderStyle.None;
       //[EditorBrowsable( EditorBrowsableState.Never), Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return _FormBorderStyle;
            }
            set
            {
                base.FormBorderStyle = FormBorderStyle.None;
                _FormBorderStyle = value;
                Invalidate();
            }
        }

       
        public HeaderClose HeaderClose
        {
            get;set;
        }
        private void SaaWindows10Form_Load(object sender, EventArgs e)
        {
          //this.form
        }



    }
    internal class CamFPanSaaPanel : Control
    {
        public CamFPanSaaPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.SupportsTransparentBackColor, true);


        }
    }
}
