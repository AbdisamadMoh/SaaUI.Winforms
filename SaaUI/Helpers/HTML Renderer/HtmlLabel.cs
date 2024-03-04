// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using SaaUI;
using SaaUI.Adapters;
using SaaUI.Utilities;
using System.Drawing.Design;

namespace SaaUI
{
    /// <summary>
    /// Html and Css supported SaaLabel.
    /// </summary>
    //[ToolboxItem(false)]
    [Description("Html and Css supported SaaLabel.")]
    [ToolboxBitmap(typeof(SaaHtmlLabel), "icons.SaaLabel_16.bmp")]
    public class SaaHtmlLabel : Control
    {
        #region Fields and Consts

        /// <summary>
        /// Underline html container instance.
        /// </summary>
        protected SaaHtmlContainer _htmlContainer;

        /// <summary>
        /// The current border style of the control
        /// </summary>
        protected BorderStyle _borderStyle;

        /// <summary>
        /// the raw base stylesheet data used in the control
        /// </summary>
        protected string _baseRawCssData;

        /// <summary>
        /// the base stylesheet data used in the panel
        /// </summary>
        protected CssData _baseCssData;

        /// <summary>
        /// the current html text set in the control
        /// </summary>
        protected string _text;

        /// <summary>
        /// is to handle auto size of the control height only
        /// </summary>
        protected bool _autoSizeHight;

        /// <summary>
        /// If to use cursors defined by the operating system or .NET cursors
        /// </summary>
        protected bool _useSystemCursors;

        /// <summary>
        /// The text rendering hint to be used for text rendering.
        /// </summary>
        protected TextRenderingHint _textRenderingHint = TextRenderingHint.SystemDefault;

        #endregion


        /// <summary>
        /// Creates a new SaaLabel with html and css support
        /// </summary>
        public SaaHtmlLabel()
        {
            SuspendLayout();

            AutoSize = false;
            BackColor = (Parent != null ? this.Parent.BackColor : SystemColors.Window);
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, false);
            try
            {
                BackColor = Color.Transparent;
            }
            catch { }
            


             _htmlContainer = new SaaHtmlContainer();
            _htmlContainer.AvoidImagesLateLoading = true;
            _htmlContainer.MaxSize = MaximumSize;
            _htmlContainer.LoadComplete += OnLoadComplete;
            _htmlContainer.LinkClicked += OnLinkClicked;
            _htmlContainer.RenderError += OnRenderError;
            _htmlContainer.Refresh += OnRefresh;
            _htmlContainer.StylesheetLoad += OnStylesheetLoad;
            _htmlContainer.ImageLoad += OnImageLoad;

            ResumeLayout(false);
        }

        /// <summary>
        ///   Raised when the BorderStyle property value changes.
        /// </summary>
        [Category("Saa")]
        public event EventHandler BorderStyleChanged;

        /// <summary>
        /// Raised when the set html document has been fully loaded.<br/>
        /// Allows manipulation of the html dom, scroll position, etc.
        /// </summary>
        public event EventHandler LoadComplete;

        /// <summary>
        /// Raised when the user clicks on a link in the html.<br/>
        /// Allows canceling the execution of the link.
        /// </summary>
        public event EventHandler<HtmlLinkClickedEventArgs> LinkClicked;

        /// <summary>
        /// Raised when an error occurred during html rendering.<br/>
        /// </summary>
        public event EventHandler<HtmlRenderErrorEventArgs> RenderError;

        /// <summary>
        /// Raised when an stylesheet is about to be loaded by file path or URI by link element.<br/>
        /// This event allows to provide the stylesheet manually or provide new source (file or uri) to load from.<br/>
        /// If no alternative data is provided the original source will be used.<br/>
        /// </summary>
        public event EventHandler<HtmlStylesheetLoadEventArgs> StylesheetLoad;

        /// <summary>
        /// Raised when an image is about to be loaded by file path or URI.<br/>
        /// This event allows to provide the image manually, if not handled the image will be loaded from file or download from URI.
        /// </summary>
        public event EventHandler<HtmlImageLoadEventArgs> ImageLoad;

        /// <summary>
        /// Gets or sets a value indicating if anti-aliasing should be avoided for geometry like backgrounds and borders (default - false).
        /// </summary>
        [Category("Saa")]
        [DefaultValue(false)]
        [Description("If anti-aliasing should be avoided for geometry like backgrounds and borders")]
        private bool AvoidGeometryAntialias
        {
            get { return _htmlContainer.AvoidGeometryAntialias; }
            set { _htmlContainer.AvoidGeometryAntialias = value; }
        }

        /// <summary>
        /// Use GDI+ text rendering to measure/draw text.<br/>
        /// </summary>
        /// <remarks>
        /// <para>
        /// GDI+ text rendering is less smooth than GDI text rendering but it natively supports alpha channel
        /// thus allows creating transparent images.
        /// </para>
        /// <para>
        /// While using GDI+ text rendering you can control the text rendering using <see cref="Graphics.TextRenderingHint"/>, note that
        /// using <see cref="System.Drawing.Text.TextRenderingHint.ClearTypeGridFit"/> doesn't work well with transparent background.
        /// </para>
        /// </remarks>
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [Description("If to use GDI+ text rendering to measure/draw text, false - use GDI")]
        private bool UseGdiPlusTextRendering
        {
            get { return _htmlContainer.UseGdiPlusTextRendering; }
            set { _htmlContainer.UseGdiPlusTextRendering = value; }
        }

        /// <summary>
        /// The text rendering hint to be used for text rendering.
        /// </summary>
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(TextRenderingHint.SystemDefault)]
        [Description("The text rendering hint to be used for text rendering.")]
        private TextRenderingHint TextRenderingHint
        {
            get { return _textRenderingHint; }
            set { _textRenderingHint = value; }
        }

        /// <summary>
        /// If to use cursors defined by the operating system or .NET cursors
        /// </summary>
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [Description("If to use cursors defined by the operating system or .NET cursors")]
        private bool UseSystemCursors
        {
            get { return _useSystemCursors; }
            set { _useSystemCursors = value; }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Category("Saa")]
        [DefaultValue(typeof(BorderStyle), "None")]
        public virtual BorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                if (BorderStyle != value)
                {
                    _borderStyle = value;
                    OnBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Is content selection is enabled for the rendered html (default - true).<br/>
        /// If set to 'false' the rendered html will be static only with ability to click on links.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Is content selection is enabled for the rendered html.")]
        public virtual bool IsSelectionEnabled
        {
            get { return _htmlContainer.IsSelectionEnabled; }
            set { _htmlContainer.IsSelectionEnabled = value; }
        }

        /// <summary>
        /// Is the build-in context menu enabled and will be shown on mouse right click (default - true)
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Saa")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Is the build-in context menu enabled and will be shown on mouse right click.")]
        private bool IsContextMenuEnabled
        {
            get { return _htmlContainer.IsContextMenuEnabled; }
            set { _htmlContainer.IsContextMenuEnabled = value; }
        }

        /// <summary>
        /// Set base stylesheet to be used by html rendered in the panel.
        /// </summary>
        [Browsable(false)]
        [Description("Set base stylesheet to be used by html rendered in the control.")]
        [Category("Saa")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        private  string BaseStylesheet
        {
            get { return _baseRawCssData; }
            set
            {
                _baseRawCssData = value;
                _baseCssData = SaaHtmlRender.ParseStyleSheet(value);
                _htmlContainer.SetHtml(_text, _baseCssData);
            }
        }

        /// <summary>
        /// Automatically sets the size of the label by content size
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Automatically sets the size of the label by content size.")]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                base.AutoSize = value;
                if (value)
                {
                    _autoSizeHight = false;
                    PerformLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Automatically sets the height of the label by content height (width is not effected).
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Saa")]
        [Description("Automatically sets the height of the label by content height (width is not effected)")]
        public virtual bool AutoSizeHeightOnly
        {
            get { return _autoSizeHight; }
            set
            {
                _autoSizeHight = value;
                if (value)
                {
                    AutoSize = false;
                    PerformLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the max size the control get be set by <see cref="AutoSize"/> or <see cref="AutoSizeHeightOnly"/>.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
        [Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the max size of the control (0 is not restricted)")]
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = value;
                if (_htmlContainer != null)
                {
                    _htmlContainer.MaxSize = value;
                    PerformLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the min size the control get be set by <see cref="AutoSize"/> or <see cref="AutoSizeHeightOnly"/>.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
        [Description("If AutoSize or AutoSizeHeightOnly is set this will restrict the min size of the control (0 is not restricted)")]
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        /// <summary>
        /// Gets or sets the Text(html and css included) of this control.
        /// </summary>
        [Description("Gets or Sets the Text(html and css included) of this control.")]
        [Editor(typeof(Using.SaaLabelEditor), typeof(UITypeEditor))]
        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                base.Text = value;
                if (!IsDisposed)
                {
                    _htmlContainer.SetHtml(_text, _baseCssData);
                    PerformLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets selected text of the control without html.
        /// </summary>
        [Browsable(false)]
        public virtual string SelectedText
        {
            get { return _htmlContainer.SelectedText; }
        }

        /// <summary>
        /// Gets selected text with html.
        /// </summary>
        [Browsable(false)]
        public virtual string SelectedHtml
        {
            get { return _htmlContainer.SelectedHtml; }
        }

        /// <summary>
        /// Returns with html from the current DOM tree with inline style.
        /// </summary>
        /// <returns>generated html</returns>
        public virtual string GetHtml()
        {
            return _htmlContainer != null ? _htmlContainer.GetHtml() : null;
        }

        /// <summary>
        /// Get the rectangle of html element as calculated by html layout.<br/>
        /// Element if found by id (id attribute on the html element).<br/>
        /// Note: to get the screen rectangle you need to adjust by the hosting control.<br/>
        /// </summary>
        /// <param name="elementId">the id of the element to get its rectangle</param>
        /// <returns>the rectangle of the element or null if not found</returns>
        public virtual RectangleF? GetElementRectangle(string elementId)
        {
            return _htmlContainer != null ? _htmlContainer.GetElementRectangle(elementId) : null;
        }

        /// <summary>
        /// Clear the current selection.
        /// </summary>
        public void ClearSelection()
        {
            if (_htmlContainer != null)
                _htmlContainer.ClearSelection();
        }


        #region Private methods

#if !MONO
        /// <summary>
        /// Override to support border for the control.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;

                switch (_borderStyle)
                {
                    case BorderStyle.FixedSingle:
                        createParams.Style |= Win32Utils.WsBorder;
                        break;

                    case BorderStyle.Fixed3D:
                        createParams.ExStyle |= Win32Utils.WsExClientEdge;
                        break;
                }

                return createParams;
            }
        }
#endif

        /// <summary>
        /// Perform the layout of the html in the control.
        /// </summary>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (_htmlContainer != null)
            {
                Graphics g = Utils.CreateGraphics(this);
                if (g != null)
                {
                    using (g)
                    using (var ig = new GraphicsAdapter(g, _htmlContainer.UseGdiPlusTextRendering))
                    {
                        var newSize = HtmlRendererUtils.Layout(ig,
                            _htmlContainer.HtmlContainerInt,
                            new RSize(ClientSize.Width - Padding.Horizontal, ClientSize.Height - Padding.Vertical),
                            new RSize(MinimumSize.Width - Padding.Horizontal, MinimumSize.Height - Padding.Vertical),
                            new RSize(MaximumSize.Width - Padding.Horizontal, MaximumSize.Height - Padding.Vertical),
                            AutoSize,
                            AutoSizeHeightOnly);
                        ClientSize = Utils.ConvertRound(new RSize(newSize.Width + Padding.Horizontal, newSize.Height + Padding.Vertical));
                    }
                }
            }
            base.OnLayout(levent);
        }

        /// <summary>
        /// Perform paint of the html in the control.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_htmlContainer != null)
            {
                e.Graphics.TextRenderingHint = _textRenderingHint;

                _htmlContainer.Location = new PointF(Padding.Left, Padding.Top);
                _htmlContainer.PerformPaint(e.Graphics);
            }
        }

        /// <summary>
        /// Handle mouse move to handle hover cursor and text selection. 
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_htmlContainer != null)
                _htmlContainer.HandleMouseMove(this, e);
        }

        /// <summary>
        /// Handle mouse down to handle selection. 
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_htmlContainer != null)
                _htmlContainer.HandleMouseDown(this, e);
        }

        /// <summary>
        /// Handle mouse leave to handle cursor change.
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_htmlContainer != null)
                _htmlContainer.HandleMouseLeave(this);
        }

        /// <summary>
        /// Handle mouse up to handle selection and link click. 
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_htmlContainer != null)
                _htmlContainer.HandleMouseUp(this, e);
        }

        /// <summary>
        /// Handle mouse double click to select word under the mouse. 
        /// </summary>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (_htmlContainer != null)
                _htmlContainer.HandleMouseDoubleClick(this, e);
        }

        /// <summary>
        ///   Raises the <see cref="BorderStyleChanged" /> event.
        /// </summary>
        protected virtual void OnBorderStyleChanged(EventArgs e)
        {
            UpdateStyles();

            var handler = BorderStyleChanged;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Propagate the LoadComplete event from root container.
        /// </summary>
        protected virtual void OnLoadComplete(EventArgs e)
        {
            var handler = LoadComplete;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Propagate the LinkClicked event from root container.
        /// </summary>
        protected virtual void OnLinkClicked(HtmlLinkClickedEventArgs e)
        {
            var handler = LinkClicked;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Propagate the Render Error event from root container.
        /// </summary>
        protected virtual void OnRenderError(HtmlRenderErrorEventArgs e)
        {
            var handler = RenderError;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Propagate the stylesheet load event from root container.
        /// </summary>
        protected virtual void OnStylesheetLoad(HtmlStylesheetLoadEventArgs e)
        {
            var handler = StylesheetLoad;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Propagate the image load event from root container.
        /// </summary>
        protected virtual void OnImageLoad(HtmlImageLoadEventArgs e)
        {
            var handler = ImageLoad;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Handle html renderer invalidate and re-layout as requested.
        /// </summary>
        protected virtual void OnRefresh(HtmlRefreshEventArgs e)
        {
            if (e.Layout)
                PerformLayout();
            Invalidate();
        }

#if !MONO
        /// <summary>
        /// Override the proc processing method to set OS specific hand cursor.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process. </param>
        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            if (_useSystemCursors && m.Msg == Win32Utils.WmSetCursor && Cursor == Cursors.Hand)
            {
                try
                {
                    // Replace .NET's hand cursor with the OS cursor
                    Win32Utils.SetCursor(Win32Utils.LoadCursor(0, Win32Utils.IdcHand));
                    m.Result = IntPtr.Zero;
                    return;
                }
                catch (Exception ex)
                {
                    OnRenderError(this, new HtmlRenderErrorEventArgs(HtmlRenderErrorType.General, "Failed to set OS hand cursor", ex));
                }
            }
            base.WndProc(ref m);
        }
#endif

        /// <summary>
        /// Release the html container resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_htmlContainer != null)
            {
                _htmlContainer.LoadComplete -= OnLoadComplete;
                _htmlContainer.LinkClicked -= OnLinkClicked;
                _htmlContainer.RenderError -= OnRenderError;
                _htmlContainer.Refresh -= OnRefresh;
                _htmlContainer.StylesheetLoad -= OnStylesheetLoad;
                _htmlContainer.ImageLoad -= OnImageLoad;
                _htmlContainer.Dispose();
                _htmlContainer = null;
            }
            base.Dispose(disposing);
        }


        #region Private event handlers

        private void OnLoadComplete(object sender, EventArgs e)
        {
            OnLoadComplete(e);
        }

        private void OnLinkClicked(object sender, HtmlLinkClickedEventArgs e)
        {
            OnLinkClicked(e);
        }

        private void OnRenderError(object sender, HtmlRenderErrorEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => OnRenderError(e)));
            else
                OnRenderError(e);
        }

        private void OnStylesheetLoad(object sender, HtmlStylesheetLoadEventArgs e)
        {
            OnStylesheetLoad(e);
        }

        private void OnImageLoad(object sender, HtmlImageLoadEventArgs e)
        {
            OnImageLoad(e);
        }

        private void OnRefresh(object sender, HtmlRefreshEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => OnRefresh(e)));
            else
                OnRefresh(e);
        }

        #endregion


        #region Hide not relevant properties from designer

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public override bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [Browsable(false)]
        public new bool UseWaitCursor
        {
            get { return base.UseWaitCursor; }
            set { base.UseWaitCursor = value; }
        }

        #endregion


        #endregion
    }
}
