namespace SaaUI
{
    partial class SaaFontForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SaaUI.Properties.Colors colors4 = new SaaUI.Properties.Colors();
            SaaUI.Properties.Flat flat4 = new SaaUI.Properties.Flat();
            SaaUI.Properties.Radius radius13 = new SaaUI.Properties.Radius();
            SaaUI.Properties.Radius radius14 = new SaaUI.Properties.Radius();
            SaaUI.Properties.iOS iOS4 = new SaaUI.Properties.iOS();
            SaaUI.Properties.Radius radius15 = new SaaUI.Properties.Radius();
            SaaUI.Properties.Radius radius16 = new SaaUI.Properties.Radius();
            SaaUI.Properties.Skewed skewed4 = new SaaUI.Properties.Skewed();
            SaaUI.Properties.ToggleSkewedCoordinates toggleSkewedCoordinates4 = new SaaUI.Properties.ToggleSkewedCoordinates();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaaFontForm));
            this.saaLabel1 = new SaaUI.SaaLabel();
            this.saaLabel2 = new SaaUI.SaaLabel();
            this.saaLabel3 = new SaaUI.SaaLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saaCircularProgress1 = new SaaUI.SaaCircularProgress();
            this.ElegantPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AwesomePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saaLabel4 = new SaaUI.SaaLabel();
            this.saaToggle1 = new SaaUI.SaaToggle();
            this.SearchWorker = new System.ComponentModel.BackgroundWorker();
            this.saaCustomTextBox1 = new SaaUI.SaaCustomTextBox();
            this.saaButton1 = new SaaUI.SaaButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saaLabel1
            // 
            this.saaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel1.ForeColor = System.Drawing.Color.White;
            this.saaLabel1.Location = new System.Drawing.Point(818, 8);
            this.saaLabel1.Name = "saaLabel1";
            this.saaLabel1.Size = new System.Drawing.Size(26, 23);
            this.saaLabel1.TabIndex = 0;
            this.saaLabel1.Text = "X";
            this.saaLabel1.Click += new System.EventHandler(this.saaLabel1_Click);
            // 
            // saaLabel2
            // 
            this.saaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel2.ForeColor = System.Drawing.Color.White;
            this.saaLabel2.Location = new System.Drawing.Point(795, 4);
            this.saaLabel2.Name = "saaLabel2";
            this.saaLabel2.Size = new System.Drawing.Size(17, 23);
            this.saaLabel2.TabIndex = 1;
            this.saaLabel2.Text = "_";
            // 
            // saaLabel3
            // 
            this.saaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.saaLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaLabel3.ForeColor = System.Drawing.Color.White;
            this.saaLabel3.Location = new System.Drawing.Point(2, 2);
            this.saaLabel3.Name = "saaLabel3";
            this.saaLabel3.Size = new System.Drawing.Size(787, 29);
            this.saaLabel3.TabIndex = 2;
            this.saaLabel3.Text = "Saa Icons";
            this.saaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saaLabel3.Click += new System.EventHandler(this.saaLabel3_Click);
            this.saaLabel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMoveForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.saaCircularProgress1);
            this.panel1.Controls.Add(this.ElegantPanel);
            this.panel1.Controls.Add(this.AwesomePanel);
            this.panel1.Controls.Add(this.SearchPanel);
            this.panel1.Location = new System.Drawing.Point(7, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 395);
            this.panel1.TabIndex = 3;
            // 
            // saaCircularProgress1
            // 
            this.saaCircularProgress1.BackColor = System.Drawing.Color.Transparent;
            this.saaCircularProgress1.Circulate = true;
            this.saaCircularProgress1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.saaCircularProgress1.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            this.saaCircularProgress1.DashOffset = 0F;
            this.saaCircularProgress1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.saaCircularProgress1.DecimalPoints = 2;
            this.saaCircularProgress1.Depth = 1;
            this.saaCircularProgress1.Display = SaaUI.SaaCircularProgressDisplayValue.Percent;
            this.saaCircularProgress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(133)))), ((int)(((byte)(228)))));
            this.saaCircularProgress1.LineEnd = System.Drawing.Drawing2D.LineCap.Flat;
            this.saaCircularProgress1.LineStart = System.Drawing.Drawing2D.LineCap.Flat;
            this.saaCircularProgress1.Location = new System.Drawing.Point(140, 48);
            this.saaCircularProgress1.Maximum = 100;
            this.saaCircularProgress1.Minimum = 0;
            this.saaCircularProgress1.Name = "saaCircularProgress1";
            this.saaCircularProgress1.Path = true;
            this.saaCircularProgress1.PathColor = System.Drawing.Color.Transparent;
            this.saaCircularProgress1.PathDashCap = System.Drawing.Drawing2D.DashCap.Round;
            this.saaCircularProgress1.PathDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.saaCircularProgress1.PathDepth = 1;
            this.saaCircularProgress1.Prefix = "loading ";
            this.saaCircularProgress1.Reverse = false;
            this.saaCircularProgress1.ReverseCirculate = false;
            this.saaCircularProgress1.RotateStep = 4;
            this.saaCircularProgress1.Size = new System.Drawing.Size(314, 314);
            this.saaCircularProgress1.SpeedInMilliSeconds = 20;
            this.saaCircularProgress1.StartAngle = 275;
            this.saaCircularProgress1.Step = 10;
            this.saaCircularProgress1.Suffix = "%";
            this.saaCircularProgress1.TabIndex = 4;
            this.saaCircularProgress1.Value = 0;
            // 
            // ElegantPanel
            // 
            this.ElegantPanel.AutoScroll = true;
            this.ElegantPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElegantPanel.Location = new System.Drawing.Point(0, 0);
            this.ElegantPanel.Name = "ElegantPanel";
            this.ElegantPanel.Size = new System.Drawing.Size(648, 395);
            this.ElegantPanel.TabIndex = 0;
            // 
            // AwesomePanel
            // 
            this.AwesomePanel.AutoScroll = true;
            this.AwesomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AwesomePanel.Location = new System.Drawing.Point(0, 0);
            this.AwesomePanel.Name = "AwesomePanel";
            this.AwesomePanel.Size = new System.Drawing.Size(648, 395);
            this.AwesomePanel.TabIndex = 0;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(648, 395);
            this.SearchPanel.TabIndex = 5;
            this.SearchPanel.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // saaLabel4
            // 
            this.saaLabel4.BackColor = System.Drawing.Color.White;
            this.saaLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(133)))), ((int)(((byte)(228)))));
            this.saaLabel4.Location = new System.Drawing.Point(147, 400);
            this.saaLabel4.Name = "saaLabel4";
            this.saaLabel4.Size = new System.Drawing.Size(314, 23);
            this.saaLabel4.TabIndex = 5;
            this.saaLabel4.Text = "0 of 0 icons";
            this.saaLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saaToggle1
            // 
            this.saaToggle1.Checked = true;
            colors4.OffBackColor = System.Drawing.Color.HotPink;
            colors4.OffForeColor = System.Drawing.Color.White;
            colors4.OffHeadColor = System.Drawing.Color.WhiteSmoke;
            colors4.OnBackColor = System.Drawing.Color.Magenta;
            colors4.OnForeColor = System.Drawing.Color.White;
            colors4.OnHeadColor = System.Drawing.Color.White;
            this.saaToggle1.Colors = colors4;
            flat4.Border = 5;
            flat4.HeadColorType = SaaUI.ToggleFlatHeadColorType.BackColor;
            flat4.HeadOffSize = new System.Drawing.Size(0, 0);
            flat4.HeadRadius = radius13;
            flat4.OffHeadOffset = new System.Drawing.Point(0, 0);
            flat4.Offset = new System.Drawing.Point(0, 0);
            flat4.OffSize = new System.Drawing.Size(0, 0);
            flat4.OnHeadOffset = new System.Drawing.Point(0, 0);
            flat4.Radius = radius14;
            flat4.RadiusStyle = SaaUI.ToggleRadius.Round;
            flat4.Speed = 5;
            this.saaToggle1.FlatStyle = flat4;
            iOS4.HeadOffSize = new System.Drawing.Size(0, 0);
            iOS4.HeadRadius = radius15;
            iOS4.OffHeadOffset = new System.Drawing.Point(1, 0);
            iOS4.Offset = new System.Drawing.Point(0, 0);
            iOS4.OffSize = new System.Drawing.Size(0, 1);
            iOS4.OnHeadOffset = new System.Drawing.Point(0, 0);
            iOS4.Radius = radius16;
            iOS4.RadiusStyle = SaaUI.ToggleRadius.Round;
            iOS4.Speed = 5;
            this.saaToggle1.iOSStyle = iOS4;
            this.saaToggle1.Location = new System.Drawing.Point(661, 58);
            this.saaToggle1.MouseClicks = SaaUI.CheckBoxMouseClick.LeftClick;
            this.saaToggle1.Name = "saaToggle1";
            this.saaToggle1.Size = new System.Drawing.Size(183, 30);
            toggleSkewedCoordinates4.BottomXY1 = new System.Drawing.Point(-10, 0);
            toggleSkewedCoordinates4.BottomXY2 = new System.Drawing.Point(0, 0);
            toggleSkewedCoordinates4.LeftXY1 = new System.Drawing.Point(0, 0);
            toggleSkewedCoordinates4.LeftXY2 = new System.Drawing.Point(-10, 0);
            toggleSkewedCoordinates4.RightXY1 = new System.Drawing.Point(0, 0);
            toggleSkewedCoordinates4.RightXY2 = new System.Drawing.Point(8, 0);
            toggleSkewedCoordinates4.TopXY1 = new System.Drawing.Point(0, 0);
            toggleSkewedCoordinates4.TopXY2 = new System.Drawing.Point(0, 0);
            skewed4.Coordinates = toggleSkewedCoordinates4;
            skewed4.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            skewed4.Offset = new System.Drawing.Point(0, 0);
            skewed4.OffSize = new System.Drawing.Size(0, 0);
            skewed4.OffText = "Elegant fonts";
            skewed4.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            skewed4.OnText = "Awesome fonts";
            skewed4.Speed = 5;
            this.saaToggle1.SkewedStyle = skewed4;
            this.saaToggle1.TabIndex = 6;
            this.saaToggle1.Text = "saaToggle1";
            this.saaToggle1.ToggleStyle = SaaUI.ToggleStyle.Skewed;
            this.saaToggle1.CheckChanged += new SaaUI.SaaToggle.OnCheckChanged(this.saaToggle1_CheckChanged);
            // 
            // SearchWorker
            // 
            this.SearchWorker.WorkerReportsProgress = true;
            this.SearchWorker.WorkerSupportsCancellation = true;
            this.SearchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchWorker_DoWork);
            this.SearchWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SearchWorker_ProgressChanged);
            this.SearchWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SearchWorker_RunWorkerCompleted);
            // 
            // saaCustomTextBox1
            // 
            this.saaCustomTextBox1.ActiveImage = ((System.Drawing.Image)(resources.GetObject("saaCustomTextBox1.ActiveImage")));
            this.saaCustomTextBox1.ActiveTextColor = System.Drawing.Color.White;
            this.saaCustomTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.saaCustomTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.saaCustomTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.saaCustomTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.saaCustomTextBox1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.saaCustomTextBox1.HideSelection = true;
            this.saaCustomTextBox1.Image = false;
            this.saaCustomTextBox1.ImageCursor = System.Windows.Forms.Cursors.IBeam;
            this.saaCustomTextBox1.ImagePosition = SaaUI.ButtonImagePosition.Left;
            this.saaCustomTextBox1.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saaCustomTextBox1.InActiveImage = ((System.Drawing.Image)(resources.GetObject("saaCustomTextBox1.InActiveImage")));
            this.saaCustomTextBox1.InActiveTextColor = System.Drawing.Color.WhiteSmoke;
            this.saaCustomTextBox1.Line = true;
            this.saaCustomTextBox1.LineActiveColor = System.Drawing.Color.White;
            this.saaCustomTextBox1.LineImage = true;
            this.saaCustomTextBox1.LineInActiveColor = System.Drawing.Color.WhiteSmoke;
            this.saaCustomTextBox1.LineSize = 2;
            this.saaCustomTextBox1.Location = new System.Drawing.Point(664, 89);
            this.saaCustomTextBox1.MaxLength = 32767;
            this.saaCustomTextBox1.MultiLine = false;
            this.saaCustomTextBox1.Name = "saaCustomTextBox1";
            this.saaCustomTextBox1.Password = false;
            this.saaCustomTextBox1.PasswordChar = '\0';
            this.saaCustomTextBox1.Radius = 0;
            this.saaCustomTextBox1.RadiusCorner = SaaUI.RoundCorners.All;
            this.saaCustomTextBox1.ReadOnly = false;
            this.saaCustomTextBox1.RightToLeftOption = System.Windows.Forms.RightToLeft.No;
            this.saaCustomTextBox1.ScrollBar = System.Windows.Forms.ScrollBars.None;
            this.saaCustomTextBox1.ScrollBarOption = System.Windows.Forms.ScrollBars.None;
            this.saaCustomTextBox1.Size = new System.Drawing.Size(180, 29);
            this.saaCustomTextBox1.TabIndex = 7;
            this.saaCustomTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.saaCustomTextBox1.Value = "";
            this.saaCustomTextBox1.WatermarkActiveColor = System.Drawing.Color.White;
            this.saaCustomTextBox1.WatermarkColor = System.Drawing.Color.WhiteSmoke;
            this.saaCustomTextBox1.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saaCustomTextBox1.WatermarkText = "Search icon";
            this.saaCustomTextBox1.WordWrap = true;
            this.saaCustomTextBox1.TextChanged += new SaaUI.SaaCustomTextBox.OnTextChanged(this.saaCustomTextBox1_TextChanged);
            // 
            // saaButton1
            // 
            this.saaButton1.BackColor = System.Drawing.Color.White;
            this.saaButton1.Border = 0;
            this.saaButton1.BorderAnimation = false;
            this.saaButton1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.saaButton1.BorderColor2 = System.Drawing.Color.LightSkyBlue;
            this.saaButton1.BorderColorAngle = 0;
            this.saaButton1.ClickBackColor = System.Drawing.Color.Empty;
            this.saaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatAppearance.BorderSize = 0;
            this.saaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saaButton1.ForceAnimate = false;
            this.saaButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.saaButton1.Location = new System.Drawing.Point(664, 124);
            this.saaButton1.Name = "saaButton1";
            this.saaButton1.Size = new System.Drawing.Size(180, 27);
            this.saaButton1.Speed = 10;
            this.saaButton1.SpeedIntervalInMilliseconds = 1;
            this.saaButton1.TabIndex = 8;
            this.saaButton1.Text = "Search";
            this.saaButton1.UseVisualStyleBackColor = false;
            this.saaButton1.Click += new System.EventHandler(this.saaButton1_Click);
            // 
            // SaaFontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(856, 441);
            this.ControlBox = false;
            this.Controls.Add(this.saaButton1);
            this.Controls.Add(this.saaCustomTextBox1);
            this.Controls.Add(this.saaToggle1);
            this.Controls.Add(this.saaLabel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saaLabel3);
            this.Controls.Add(this.saaLabel2);
            this.Controls.Add(this.saaLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaaFontForm";
            this.Radius.BottomLeft = 10;
            this.Radius.BottomRight = 10;
            this.Radius.TopLeft = 10;
            this.Radius.TopRight = 10;
            this.ShowIcon = false;
            this.Text = "SaaFontForm";
            this.Load += new System.EventHandler(this.SaaFontForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SaaLabel saaLabel1;
        private SaaLabel saaLabel2;
        private SaaLabel saaLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel AwesomePanel;
        private System.Windows.Forms.FlowLayoutPanel ElegantPanel;
        private SaaCircularProgress saaCircularProgress1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private SaaLabel saaLabel4;
        private SaaToggle saaToggle1;
        private SaaCustomTextBox saaCustomTextBox1;
        private System.ComponentModel.BackgroundWorker SearchWorker;
        private System.Windows.Forms.FlowLayoutPanel SearchPanel;
        private SaaButton saaButton1;
    }
}
