using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable Notification.
    /// </summary>
    [Description("Beautiful and customizable Notification.")]
    [ToolboxBitmap(typeof(SaaToast), "icons.SaaToast.bmp")]
    [DefaultEvent("Closed")]
    [Designer(typeof(SaaToastTag))]
    public class SaaToast : Component
    {
        public SaaToast()
        {

        }

        /// <summary>
        /// Gets fired when the toast is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("Gets fired when the toast is closed.")]
        [Category("Saa")]
        public delegate void OnClosed(object sender, EventArgs e);

        /// <summary>
        /// Gets fired when the toast is closed.
        /// </summary>
        [Description("Gets fired when the toast is closed.")]
        [Category("Saa")]
        public event OnClosed Closed;
        string _Text = "Your request is being processed and we will \nnotify you once done.";
        /// <summary>
        /// Gets or Sets text of the control.
        /// </summary>
        [Description("Gets or Sets text of the control.")]
        [Category("Saa")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        /// <summary>
        /// Gets or Sets Title text of the control.
        /// </summary>
        [Description("Gets or Sets Title text of the control.")]
        [Category("Saa")]
        public string TitleText { get; set; } = "Notice";
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
            }
        }


        Color _BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color BackColor2
        {
            get
            {
                return _BackColor2;
            }

            set
            {
                _BackColor2 = value;
            }
        }
        Color _BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
        /// <summary>
        /// Gets or Sets BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;
            }
        }

        Color _HeaderBackColor2 = Color.Transparent;
        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color HeaderBackColor2
        {
            get
            {
                return _HeaderBackColor2;
            }

            set
            {
                _HeaderBackColor2 = value;
            }
        }
        Color _HeaderBackColor = Color.Transparent;
        /// <summary>
        /// Gets or Sets BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color HeaderBackColor
        {
            get
            {
                return _HeaderBackColor;
            }

            set
            {
                _HeaderBackColor = value;
            }
        }
        /// <summary>
        /// Gets or Sets Body text Font.
        /// </summary>
        [Description("Gets or Sets Body text Font.")]
        [Category("Saa")]
        public Font BodyTextFont { get; set; }

        /// <summary>
        /// Gets or Sets Body text color.
        /// </summary>
        [Description("Gets or Sets Body text color.")]
        [Category("Saa")]
        public Color BodyTextColor { get; set; } = SystemColors.ButtonHighlight;

        /// <summary>
        /// Gets or Sets Title text color.
        /// </summary>
        [Description("Gets or Sets Title text color.")]
        [Category("Saa")]
        public Color TitleTextColor { get; set; } = Color.FromArgb(224, 224, 224);

        /// <summary>
        /// Gets or Sets Title text font.
        /// </summary>
        [Description("Gets or Sets Title text font.")]
        [Category("Saa")]
        public Font TitleTextFont { get; set; }

        /// <summary>
        /// Gets or Sets Title back color.
        /// </summary>
        [Description("Gets or Sets Title back color.")]
        [Category("Saa")]
        public Color TitleBackColor { get; set; } = Color.Transparent;

        /// <summary>
        /// Gets or Sets distance between the title and its content.
        /// </summary>
        [Description("Gets or Sets distance between the title and its content.")]
        [Category("Saa")]
        public Padding TitlePadding { get; set; } = new Padding(40, 0, 0, 0);

        /// <summary>
        /// Gets or Sets distance between the body and its content.
        /// </summary>
        [Description("Gets or Sets distance between the body and its content.")]
        [Category("Saa")]
        public Padding BodyPadding { get; set; } = new Padding(0);

        /// <summary>
        /// Gets or Sets distance between the toast and its content.
        /// </summary>
        [Description("Gets or Sets distance between the toast and its content.")]
        [Category("Saa")]
        public Padding Padding { get; set; } = new Padding(0);

        /// <summary>
        /// Gets or Sets distance between the header and its content.
        /// </summary>
        [Description("Gets or Sets distance between the header and its content.")]
        [Category("Saa")]
        public Padding HeaderPadding { get; set; } = new Padding(5, 0, 0, 5);

        /// <summary>
        /// Gets or Sets distance between the close and its content.
        /// </summary>
        [Description("Gets or Sets distance between the close and its content.")]
        [Category("Saa")]
        public Padding ClosePadding { get; set; } = new Padding(5, 5, 5, 5);

        /// <summary>
        /// Gets or Sets distance between the icon and its content.
        /// </summary>
        [Description("Gets or Sets distance between the icon and its content.")]
        [Category("Saa")]
        public Padding IconPadding { get; set; } = new Padding(0);

        /// <summary>
        /// Gets or Sets Back color of the body.
        /// </summary>
        [Description("Gets or Sets Back color of the body.")]
        [Category("Saa")]
        public Color BodyBackColor { get; set; } = Color.Transparent;

        /// <summary>
        /// Gets or Sets Back color of the loader.
        /// </summary>
        [Description("Gets or Sets Back color of the loader.")]
        [Category("Saa")]
        public Color LoaderBackColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or Sets Back color of the close.
        /// </summary>
        [Description("Gets or Sets Back color of the close.")]
        [Category("Saa")]
        public Color CloseBackColor { get; set; } = Color.Transparent;

        /// <summary>
        /// Gets or Sets image when the close is active.
        /// </summary>
        [Description("Gets or Sets image when the close is active.")]
        [Category("Saa")]
        public Image CloseActiveImage { get; set; } = Resources.icons8_Multiply_32;

        /// <summary>
        /// Gets or Sets image when the close is inactive.
        /// </summary>
        [Description("Gets or Sets image when the close is inactive.")]
        [Category("Saa")]
        public Image CloseInActiveImage { get; set; } = Resources.icons8_InActiveClose_32;

        /// <summary>
        ///Gets or Sets image sizing mode of the close image. 
        /// </summary>
        [Description("Gets or Sets image sizing mode of the close image.")]
        [Category("Saa")]
        public PictureBoxSizeMode CloseImageSizeMode { get; set; } = PictureBoxSizeMode.StretchImage;

        /// <summary>
        ///Gets or Sets image sizing mode of the Icon image. 
        /// </summary>
        [Description("Gets or Sets image sizing mode of the Icon image.")]
        [Category("Saa")]
        public PictureBoxSizeMode IconImageSizeMode { get; set; } = PictureBoxSizeMode.Normal;

        float _BackColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        public float BackColorAngle
        {
            get
            {
                return _BackColorAngle;
            }

            set
            {

                _BackColorAngle = value;
            }
        }

        float _HeaderBackColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        public float HeaderBackColorAngle
        {
            get
            {
                return _HeaderBackColorAngle;
            }

            set
            {
                _HeaderBackColorAngle = value;
            }
        }

        /// <summary>
        /// Gets or Sets where the toast will be placed.
        /// </summary>
        [Description("Gets or Sets where the toast will be placed.")]
        [Category("Saa")]
        public ToastPosition Position { get; set; } = ToastPosition.BottomRight;

        /// <summary>
        /// Gets or Sets where the loader will be placed.
        /// </summary>
        [Description("Gets or Sets where the loader will be placed.")]
        [Category("Saa")]
        public RightLeftPositions LoaderPosition { get; set; } = RightLeftPositions.Left;

        /// <summary>
        /// Gets or Sets where the icon will be placed.
        /// </summary>
        [Description("Gets or Sets where the icon will be placed.")]
        [Category("Saa")]
        public RightLeftPositions IconPosition { get; set; } = RightLeftPositions.Left;

        /// <summary>
        /// Gets or Sets where the close will be placed.
        /// </summary>
        [Description("Gets or Sets where the close will be placed.")]
        [Category("Saa")]
        public RightLeftPositions ClosePosition { get; set; } = RightLeftPositions.Right;


        /// <summary>
        /// Gets or Sets Image of the icon.
        /// </summary>
        [Description("Gets or Sets Image of the icon.")]
        [Category("Saa")]
        public Image Icon { get; set; } = Resources.icons8_Ok_32;


        /// <summary>
        /// Gets or Sets how far the x-coordinate of the taost should be relatively to the x-coordinate of the parent.
        /// </summary>
        [Description("Gets or Sets how far the x-coordinate of the taost should be relatively to the x-coordinate of the parent.")]
        [Category("Saa")]
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Gets or Sets how far the y-coordinate of the taost should be relatively to the y-coordinate of the parent.
        /// </summary>
        [Description("Gets or Sets how far the y-coordinate of the taost should be relatively to the y-coordinate of the parent.")]
        [Category("Saa")]
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// Gets or Sets whether the toast will close all other toasts before it appears.
        /// </summary>
        [Description("Gets or Sets whether the toast will close all other toasts before it appears.")]
        [Category("Saa")]
        public bool ClosePreviousTaost { get; set; } = false;

        /// <summary>
        /// Gets or Sets whether the loader is visible.
        /// </summary>
        [Description("Gets or Sets whether the loader is visible.")]
        [Category("Saa")]
        public bool LoaderVisible { get; set; } = true;

        /// <summary>
        /// Gets or Sets whether the toast will close when the loader finishes(even if the loader is hidden).
        /// </summary>
        [Description("Gets or Sets whether the toast will close when the loader finishes(even if the loader is hidden).")]
        [Category("Saa")]
        public bool AutoClose { get; set; } = true;

        /// <summary>
        /// Gets or Sets time interval in milliseconds the loader takes in each step. The bigger the interval the longer the loader will take to complete.
        /// </summary>
        [Description("Gets or Sets time interval in milliseconds the loader takes in each step. The bigger the interval the longer the loader will take to complete.")]
        [Category("Saa")]
        public int IntervalInMilliseconds { get; set; } = 50;

        /// <summary>
        /// Gets or Sets the size of the taost.
        /// </summary>
        [Description("Gets or Sets the size of the taost.")]
        [Category("Saa")]
        public Size Size { get; set; } = new Size(270, 80);

        /// <summary>
        /// Gets or Sets whether the toast will resize itself to display all its content. <see cref="Size"/> won't work if this is set to true.
        /// </summary>
        [Description("Gets or Sets whether the toast will resize itself to display all its content. 'Size' won't work if this is set to true.")]
        [Category("Saa")]
        public bool AutoSize { get; set; } = true;

        /// <summary>
        /// Gets or Sets the minimum size of the toast.
        /// </summary>
        [Description("Gets or Sets the minimum size of the toast.")]
        [Category("Saa")]
        public Size MinSize { get; set; } = new Size(10, 10);

        /// <summary>
        /// Gets or Sets height of the loader.
        /// </summary>
        [Description("Gets or Sets height of the loader.")]
        [Category("Saa")]
        public int LoaderHeight { get; set; } = 3;

        /// <summary>
        /// Gets or Sets extra height to be added to the toast when <see cref="AutoSize"/> is true.
        /// </summary>
        [Description("Gets or Sets extra height to be added to the toast when AutoSize is true.")]
        [Category("Saa")]
        public int OffHeight { get; set; } = 20;

        /// <summary>
        /// Gets or Sets extra width to be added to the toast when <see cref="AutoSize"/> is true.
        /// </summary>
        [Description("Gets or Sets extra width to be added to the toast when AutoSize is true.")]
        [Category("Saa")]
        public int OffWidth { get; set; } = 0;

        /// <summary>
        /// Gets or Sets whether the loader will pause when hovered.
        /// </summary>
        [Description("Gets or Sets whether the loader will pause when hovered.")]
        [Category("Saa")]
        public bool StopOnHover { get; set; } = true;

        /// <summary>
        /// Gets or Sets whether the toast is movable.
        /// </summary>
        [Description("Gets or Sets whether the toast is movable.")]
        [Category("Saa")]
        public bool Movable { get; set; } = true;

        /// <summary>
        /// Gets or Sets whether the body icon will be shown.
        /// </summary>
        [Description("Gets or Sets whether the body icon will be shown.")]
        [Category("Saa")]
        public bool ShowBodyIcon { get; set; } = true;
        /// <summary>
        /// Gets or Sets whether the close icon will be shown.
        /// </summary>
        [Description("Gets or Sets whether the close icon will be shown.")]
        [Category("Saa")]
        public bool ShowCloseIcon { get; set; } = true;
        /// <summary>
        /// Gets or Sets whether the header will be shown.
        /// </summary>
        [Description("Gets or Sets whether the header will be shown.")]
        [Category("Saa")]
        public bool ShowHeader { get; set; } = true;
        /// <summary>
        /// Gets or Sets whether the title will be shown.
        /// </summary>
        [Description("Gets or Sets whether the title will be shown.")]
        [Category("Saa")]
        public bool ShowTitle { get; set; } = true;
        /// <summary>
        /// Gets or Sets whether the body will be shown.
        /// </summary>
        [Description("Gets or Sets whether the body will be shown.")]
        [Category("Saa")]
        public bool ShowBody { get; set; } = true;
        bool _ApplyShadow = false;
        /// <summary>
        /// Gets or Sets whether shadow is drawn around the control. If set true, then radius property will be ignored.
        /// </summary>
        [Description("Gets or Sets whether shadow is drawn around the control. If set true, then radius property will be ignored.")]
        [Category("Saa")]
        private bool ApplyShadow
        {
            get { return _ApplyShadow; }
            set
            {

                if (this.DesignMode)
                {
                    if (value)
                    {
                        var res = MessageBox.Show("If you enable this option, 'Radius' property will be ignored." +
                            "\nDo you want to enable?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            _ApplyShadow = value;
                        }
                    }
                    else
                    {
                        _ApplyShadow = value;
                    }
                }
                else
                {
                    _ApplyShadow = value;
                }
            }
        }
        private void SetUp()
        {

            s.saaPictureBox1.Visible = ShowBodyIcon;
            s.saaLabel2.Visible = ShowTitle;
            s.saaPanel1.Visible = ShowHeader;
            s.saaPictureBox2.Visible = ShowCloseIcon;
            s.saaLabel1.Visible = ShowBody;

            s.Radius = _Radius;
            s.BackColor = _BackColor;
            s.BackColor2 = _BackColor2;
            s.BackColorAngle = _BackColorAngle;
            s.Padding = Padding;
            s.OffWidth = OffWidth;
            s.OffHeight = OffHeight;
            s.StopOnHover = StopOnHover;
            s.Movable = Movable;

            s.saaLabel1.Font = this.BodyTextFont;
            s.saaPanel1.BackColor = HeaderBackColor;
            s.saaLabel1.ForeColor = BodyTextColor;
            s.saaLabel1.BackColor = BodyBackColor;
            s.saaLabel1.Padding = BodyPadding;

            s.saaLabel2.BackColor = TitleBackColor;
            s.saaLabel2.ForeColor = TitleTextColor;
            s.saaLabel2.Font = TitleTextFont;
            s.saaLabel2.Padding = TitlePadding;
            s.saaLabel2.Text = TitleText;

            s.saaPanel1.Padding = HeaderPadding;
            s.saaPanel1.BackColor = _HeaderBackColor;
            s.saaPanel1.BackColor = _HeaderBackColor2;
            s.saaPanel1.BackColorAngle = _HeaderBackColorAngle;

            s.lb.BackColor = LoaderBackColor;
            s.lb.Dock = (LoaderPosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);

            s.LoaderHeight = LoaderHeight;

            s.saaPictureBox1.Dock = (IconPosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);
            s.saaPictureBox1.SizeMode = IconImageSizeMode;
            s.saaPictureBox1.Padding = IconPadding;
            s.saaPictureBox1.Image = Icon;
            //var i = s.saaPictureBox1.Location;
            //s.saaPictureBox1.Location = new Point((IconPosition == RightLeftPositions.Left ? -1 : 1) * OffsetIconX + i.X, OffsetIconY + i.Y);


            s.CloseActiveImage = CloseActiveImage;
            s.CloseInActiveImage = CloseInActiveImage;
            s.saaPictureBox2.Image = CloseInActiveImage;
            s.saaPictureBox2.SizeMode = CloseImageSizeMode;
            s.saaPictureBox2.Dock = (ClosePosition == RightLeftPositions.Left ? DockStyle.Left : DockStyle.Right);
            //var c = s.saaPictureBox2.Location;
            //s.saaPictureBox2.Location = new Point((ClosePosition== RightLeftPositions.Left?-1:1)*OffsetCloseX + c.X, OffsetCloseY+c.Y);

            s.OffsetX = OffsetX;
            s.OffsetY = OffsetY;
            s.position = Position;

            s.LoaderVisible = LoaderVisible;
            s.AutoClose = AutoClose;
            s.IntervalInMilliseconds = IntervalInMilliseconds;

            s.Size = Size;
            s.AutoSizing = AutoSize;
            s.MinSize = MinSize;
            // s.ApplyShadow = _ApplyShadow;
        }

        void SetMod(SaaToast t)
        {
            this.Radius = t.Radius;
            this.BackColor = t.BackColor;
            this.BackColor2 = t.BackColor2;
            this.BackColorAngle = t.BackColorAngle;
            this.Padding = t.Padding;
            this.OffWidth = t.OffWidth;
            this.OffHeight = t.OffHeight;
            this.StopOnHover = t.StopOnHover;
            this.Movable = t.Movable;

            this.BodyTextFont = t.BodyTextFont;
            HeaderBackColor = t.HeaderBackColor;
            BodyTextColor = t.BodyTextColor;
            BodyBackColor = t.BodyBackColor;
            BodyPadding = t.BodyPadding;

            this.TitleBackColor = t.TitleBackColor;
            TitleTextColor = t.TitleTextColor;
            TitleTextFont = t.TitleTextFont;
            TitlePadding = t.TitlePadding;
            TitleText = t.TitleText;

            HeaderPadding = t.HeaderPadding;
            HeaderBackColor = t.HeaderBackColor;
            HeaderBackColor2 = t.HeaderBackColor2;
            HeaderBackColorAngle = t.HeaderBackColorAngle;

            LoaderBackColor = t.LoaderBackColor;
            LoaderPosition = t.LoaderPosition;

            LoaderHeight = t.LoaderHeight;

            IconPosition = t.IconPosition;
            IconImageSizeMode = t.IconImageSizeMode;
            IconPadding = t.IconPadding;
            Icon = t.Icon;



            CloseActiveImage = t.CloseActiveImage;
            CloseInActiveImage = t.CloseInActiveImage;
            CloseImageSizeMode = t.CloseImageSizeMode;
            ClosePosition = t.ClosePosition;

            OffsetX = t.OffsetX;
            OffsetY = t.OffsetY;
            Position = t.Position;

            LoaderVisible = t.LoaderVisible;
            AutoClose = t.AutoClose;
            IntervalInMilliseconds = t.IntervalInMilliseconds;

            Size = t.Size;
            AutoSize = t.AutoSize;

            SetUp();
        }

        [Description("Design with realtime preview")]
        [ListBindable(true), Editor(typeof(Using.SaaToastDesignerEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("ZDesign")]
        private SaaToast ZDesign
        {
            get
            {
                return null;
            }
            set
            {
                // SetMod(value);
            }
        }
        string KeyString = Guid.NewGuid().ToString();
        SaaToastForm s;// = new SaaToastForm();
        /// <summary>
        /// Displays toast on the screen.
        /// </summary>
        public void Show()
        {
            //MessageBox.Show(KeyString);
            s = new SaaToastForm();
            SetUp();

            s.FormClosed += S_FormClosed;
            if (ClosePreviousTaost)
            {
                FormList.Close();
            }

            s.Value = _Text;
            s.position = Position;
            s.Show();
            FormList.Add(KeyString, s);
        }
        internal SaaToastForm GetForm()
        {
            s = new SaaToastForm();

            SetUp();


            return s;
        }
        internal Size GetSize()
        {
            return s.Size;
        }
        /// <summary>
        /// Closes toast.
        /// </summary>
        public void Close()
        {
            s.Close();
        }

        /// <summary>
        /// Closes all toasts owned by this application.
        /// </summary>
        public void CloseAnyAll()
        {
            FormList.Close();
        }


        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormList.Remove(s);
            Closed?.Invoke(this, EventArgs.Empty);
        }


        /// <summary>
        /// Displays toast on specified region on the screen.
        /// </summary>
        /// <param name="point"></param>
        public void Show(Point point)
        {
            s = new SaaToastForm();
            SetUp();
            s.FormClosed += S_FormClosed;
            if (ClosePreviousTaost)
            {
                FormList.Close();
            }

            s.Value = _Text;

            s.isCustom = true;
            s.isCustomXY = true;
            s.point = point;
            s.Show();
            FormList.Add(KeyString, s);
        }

        /// <summary>
        /// Displays toast on the specified form.
        /// </summary>
        /// <param name="form"></param>
        public void Show(Form form)
        {
            s = new SaaToastForm();
            SetUp();
            s.FormClosed += S_FormClosed;
            if (ClosePreviousTaost)
            {
                FormList.Close();
            }

            s.Value = _Text;
            s.isCustom = true;
            s.point = form.Location;
            s.PH = form.Height;
            s.PW = form.Width;
            s.Show();
            FormList.Add(KeyString, s);
        }

    }

    internal static class FormList
    {
        public delegate void OnRemoved();
        public static event OnRemoved Removed;
        static List<SaaToastForm> fmList = new List<SaaToastForm>();
        public static void Add(string key, SaaToastForm f)
        {
            fmList.Add(f);
        }
        public static void Close()
        {
            for (int i = 0; i < fmList.Count; i++)
            {
                try
                {
                    var f = fmList.ElementAt(i);
                    f.Close();
                    Remove(f);

                }
                catch (Exception e) { /*MessageBox.Show(e.ToString());*/ }

            }
            //fmList.Clear();
        }

        public static void Remove(SaaToastForm f)
        {
            f = null;
            for (int i = 0; i < fmList.Count; i++)
            {
                if (fmList[i] == null)
                {
                    fmList.RemoveAt(i);
                }
            }
            //if (fmList.Contains(f))
            //{
            //    MessageBox.Show("1: "+fmList.Count.ToString());
            //    fmList.Remove(f);
            //    Removed?.Invoke();
            //    MessageBox.Show("2: "+fmList.Count.ToString());
            //    //f.Dispose();

            //}

        }
        public static int GetHeight()
        {
            int h = 0;
            foreach (var item in fmList)
            {
                h += item.Height;
            }
            return h;
        }
        public static int GetHeight(ToastPosition pos)
        {
            int h = 0;
            foreach (var item in fmList)
            {
                if (item != null)
                {
                    if (item.position == pos)
                    {
                        h += item.Height + item.OffsetY;
                    }
                }
            }
            return h;
        }
        public static int GetWidth(ToastPosition pos)
        {
            int w = 0;
            foreach (var item in fmList)
            {
                if (item != null)
                {
                    if (item.position == pos)
                    {
                        w += item.Width + item.OffsetX;
                    }
                }
            }
            return w;
        }
        public static int GetWidth()
        {
            int w = 0;
            foreach (var item in fmList)
            {
                w += item.Width;
            }
            return w;
        }
    }
}
