
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using SaaUI;
using SaaUI.Adapters;
using SaaUI.Utilities;

namespace SaaUI
{
    
    [ToolboxItem(false)]
    static class SaaHtmlRender
    {
        /// <summary>
        /// Adds a font family to be used in html rendering.<br/>
        /// The added font will be used by all rendering function including <see cref="HtmlContainer"/> and all WinForms controls.
        /// </summary>
        /// <remarks>
        /// The given font family instance must be remain alive while the renderer is in use.<br/>
        /// If loaded to <see cref="PrivateFontCollection"/> then the collection must be alive.<br/>
        /// If loaded from file then the file must not be deleted.
        /// </remarks>
        /// <param name="fontFamily">The font family to add.</param>
        public static void AddFontFamily(FontFamily fontFamily)
        {
            ArgChecker.AssertArgNotNull(fontFamily, "fontFamily");

            WinFormsAdapter.Instance.AddFontFamily(new FontFamilyAdapter(fontFamily));
        }

        /// <summary>
        /// Adds a font mapping from <paramref name="fromFamily"/> to <paramref name="toFamily"/> iff the <paramref name="fromFamily"/> is not found.<br/>
        /// When the <paramref name="fromFamily"/> font is used in rendered html and is not found in existing 
        /// fonts (installed or added) it will be replaced by <paramref name="toFamily"/>.<br/>
        /// </summary>
        /// <remarks>
        /// This fonts mapping can be used as a fallback in case the requested font is not installed in the client system.
        /// </remarks>
        /// <param name="fromFamily">the font family to replace</param>
        /// <param name="toFamily">the font family to replace with</param>
        public static void AddFontFamilyMapping(string fromFamily, string toFamily)
        {
            ArgChecker.AssertArgNotNullOrEmpty(fromFamily, "fromFamily");
            ArgChecker.AssertArgNotNullOrEmpty(toFamily, "toFamily");

            WinFormsAdapter.Instance.AddFontFamilyMapping(fromFamily, toFamily);
        }

        /// <summary>
        /// Parse the given stylesheet to <see cref="CssData"/> object.<br/>
        /// If <paramref name="combineWithDefault"/> is true the parsed css blocks are added to the 
        /// default css data (as defined by W3), merged if class name already exists. If false only the data in the given stylesheet is returned.
        /// </summary>
        /// <seealso cref="http://www.w3.org/TR/CSS21/sample.html"/>
        /// <param name="stylesheet">the stylesheet source to parse</param>
        /// <param name="combineWithDefault">true - combine the parsed css data with default css data, false - return only the parsed css data</param>
        /// <returns>the parsed css data</returns>
        public static CssData ParseStyleSheet(string stylesheet, bool combineWithDefault = true)
        {
            return CssData.Parse(WinFormsAdapter.Instance, stylesheet, combineWithDefault);
        }

#if !MONO
        /// <summary>
        /// Measure the size (width and height) required to draw the given html under given max width restriction.<br/>
        /// If no max width restriction is given the layout will use the maximum possible width required by the content,
        /// it can be the longest text line or full image width.<br/>
        /// Use GDI text rendering, note <see cref="Graphics.TextRenderingHint"/> has no effect.
        /// </summary>
        /// <param name="g">Device to use for measure</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="maxWidth">optional: bound the width of the html to render in (default - 0, unlimited)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the size required for the html</returns>
        public static SizeF Measure(Graphics g, string html, float maxWidth = 0, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return Measure(g, html, maxWidth, cssData, false, stylesheetLoad, imageLoad);
        }
#endif

        /// <summary>
        /// Measure the size (width and height) required to draw the given html under given max width restriction.<br/>
        /// If no max width restriction is given the layout will use the maximum possible width required by the content,
        /// it can be the longest text line or full image width.<br/>
        /// Use GDI+ text rending, use <see cref="Graphics.TextRenderingHint"/> to control text rendering.
        /// </summary>
        /// <param name="g">Device to use for measure</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="maxWidth">optional: bound the width of the html to render in (default - 0, unlimited)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the size required for the html</returns>
        public static SizeF MeasureGdiPlus(Graphics g, string html, float maxWidth = 0, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return Measure(g, html, maxWidth, cssData, true, stylesheetLoad, imageLoad);
        }

#if !MONO
        /// <summary>
        /// Renders the specified HTML source on the specified location and max width restriction.<br/>
        /// Use GDI text rendering, note <see cref="Graphics.TextRenderingHint"/> has no effect.<br/>
        /// If <paramref name="maxWidth"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="left">optional: the left most location to start render the html at (default - 0)</param>
        /// <param name="top">optional: the top most location to start render the html at (default - 0)</param>
        /// <param name="maxWidth">optional: bound the width of the html to render in (default - 0, unlimited)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        public static SizeF Render(Graphics g, string html, float left = 0, float top = 0, float maxWidth = 0, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return RenderClip(g, html, new PointF(left, top), new SizeF(maxWidth, 0), cssData, false, stylesheetLoad, imageLoad);
        }

        /// <summary>
        /// Renders the specified HTML source on the specified location and max size restriction.<br/>
        /// Use GDI text rendering, note <see cref="Graphics.TextRenderingHint"/> has no effect.<br/>
        /// If <paramref name="maxSize"/>.Width is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize"/>.Height is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">the top-left most location to start render the html at</param>
        /// <param name="maxSize">the max size of the rendered html (if height above zero it will be clipped)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        public static SizeF Render(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return RenderClip(g, html, location, maxSize, cssData, false, stylesheetLoad, imageLoad);
        }
#endif

        /// <summary>
        /// Renders the specified HTML source on the specified location and max size restriction.<br/>
        /// Use GDI+ text rending, use <see cref="Graphics.TextRenderingHint"/> to control text rendering.<br/>
        /// If <paramref name="maxWidth"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="left">optional: the left most location to start render the html at (default - 0)</param>
        /// <param name="top">optional: the top most location to start render the html at (default - 0)</param>
        /// <param name="maxWidth">optional: bound the width of the html to render in (default - 0, unlimited)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        public static SizeF RenderGdiPlus(Graphics g, string html, float left = 0, float top = 0, float maxWidth = 0, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return RenderClip(g, html, new PointF(left, top), new SizeF(maxWidth, 0), cssData, true, stylesheetLoad, imageLoad);
        }

        /// <summary>
        /// Renders the specified HTML source on the specified location and max size restriction.<br/>
        /// Use GDI+ text rending, use <see cref="Graphics.TextRenderingHint"/> to control text rendering.<br/>
        /// If <paramref name="maxSize"/>.Width is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize"/>.Height is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">the top-left most location to start render the html at</param>
        /// <param name="maxSize">the max size of the rendered html (if height above zero it will be clipped)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        public static SizeF RenderGdiPlus(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return RenderClip(g, html, location, maxSize, cssData, true, stylesheetLoad, imageLoad);
        }

#if !MONO

        public static Metafile RenderToMetafile(string html, float left = 0, float top = 0, float maxWidth = 0, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            Metafile image;
            IntPtr dib;
            var memoryHdc = Win32Utils.CreateMemoryHdc(IntPtr.Zero, 1, 1, out dib);
            try
            {
                image = new Metafile(memoryHdc, EmfType.EmfPlusDual, "..");

                using (var g = Graphics.FromImage(image))
                {
                    Render(g, html, left, top, maxWidth, cssData, stylesheetLoad, imageLoad);
                }
            }
            finally
            {
                Win32Utils.ReleaseMemoryHdc(memoryHdc, dib);
            }
            return image;
        }

        /// <summary>
        /// Renders the specified HTML on top of the given image.<br/>
        /// <paramref name="image"/> will contain the rendered html in it on top of original content.<br/>
        /// <paramref name="image"/> must not contain transparent pixels as it will corrupt the rendered html text.<br/>
        /// The HTML will be layout by the given image size but may be clipped if cannot fit.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </summary>
        /// <param name="image">the image to render the html on</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">optional: the top-left most location to start render the html at (default - 0,0)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        public static void RenderToImage(Image image, string html, PointF location = new PointF(), CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(image, "image");
            var maxSize = new SizeF(image.Size.Width - location.X, image.Size.Height - location.Y);
            RenderToImage(image, html, location, maxSize, cssData, stylesheetLoad, imageLoad);
        }

        /// <summary>
        /// Renders the specified HTML on top of the given image.<br/>
        /// <paramref name="image"/> will contain the rendered html in it on top of original content.<br/>
        /// <paramref name="image"/> must not contain transparent pixels as it will corrupt the rendered html text.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </summary>
        /// <param name="image">the image to render the html on</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">the top-left most location to start render the html at</param>
        /// <param name="maxSize">the max size of the rendered html (if height above zero it will be clipped)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        public static void RenderToImage(Image image, string html, PointF location, SizeF maxSize, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(image, "image");

            if (!string.IsNullOrEmpty(html))
            {
                // create memory buffer from desktop handle that supports alpha channel
                IntPtr dib;
                var memoryHdc = Win32Utils.CreateMemoryHdc(IntPtr.Zero, image.Width, image.Height, out dib);
                try
                {
                    // create memory buffer graphics to use for HTML rendering
                    using (var memoryGraphics = Graphics.FromHdc(memoryHdc))
                    {
                        // draw the image to the memory buffer to be the background of the rendered html
                        memoryGraphics.DrawImageUnscaled(image, 0, 0);

                        // render HTML into the memory buffer
                        RenderHtml(memoryGraphics, html, location, maxSize, cssData, false, stylesheetLoad, imageLoad);
                    }

                    // copy from memory buffer to image
                    CopyBufferToImage(memoryHdc, image);
                }
                finally
                {
                    Win32Utils.ReleaseMemoryHdc(memoryHdc, dib);
                }
            }
        }

        /// <summary>
        /// Renders the specified HTML into a new image of the requested size.<br/>
        /// The HTML will be layout by the given size but will be clipped if cannot fit.<br/>
        /// <p>
        /// Limitation: The image cannot have transparent background, by default it will be white.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </p>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="size">The size of the image to render into, layout html by width and clipped by height</param>
        /// <param name="backgroundColor">optional: the color to fill the image with (default - white)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        /// <exception cref="ArgumentOutOfRangeException">if <paramref name="backgroundColor"/> is <see cref="Color.Transparent"/></exception>.
        public static Image RenderToImage(string html, Size size, Color backgroundColor = new Color(), CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (backgroundColor == Color.Transparent)
                throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");

            // create the final image to render into
            var image = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

            if (!string.IsNullOrEmpty(html))
            {
                // create memory buffer from desktop handle that supports alpha channel
                IntPtr dib;
                var memoryHdc = Win32Utils.CreateMemoryHdc(IntPtr.Zero, image.Width, image.Height, out dib);
                try
                {
                    // create memory buffer graphics to use for HTML rendering
                    using (var memoryGraphics = Graphics.FromHdc(memoryHdc))
                    {
                        memoryGraphics.Clear(backgroundColor != Color.Empty ? backgroundColor : Color.White);

                        // render HTML into the memory buffer
                        RenderHtml(memoryGraphics, html, PointF.Empty, size, cssData, true, stylesheetLoad, imageLoad);
                    }

                    // copy from memory buffer to image
                    CopyBufferToImage(memoryHdc, image);
                }
                finally
                {
                    Win32Utils.ReleaseMemoryHdc(memoryHdc, dib);
                }
            }

            return image;
        }

        /// <summary>
        /// Renders the specified HTML into a new image of unknown size that will be determined by max width/height and HTML layout.<br/>
        /// If <paramref name="maxWidth"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxHeight"/> is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// <p>
        /// Limitation: The image cannot have transparent background, by default it will be white.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </p>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="maxWidth">optional: the max width of the rendered html, if not zero and html cannot be layout within the limit it will be clipped</param>
        /// <param name="maxHeight">optional: the max height of the rendered html, if not zero and html cannot be layout within the limit it will be clipped</param>
        /// <param name="backgroundColor">optional: the color to fill the image with (default - white)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        /// <exception cref="ArgumentOutOfRangeException">if <paramref name="backgroundColor"/> is <see cref="Color.Transparent"/></exception>.
        public static Image RenderToImage(string html, int maxWidth = 0, int maxHeight = 0, Color backgroundColor = new Color(), CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            return RenderToImage(html, Size.Empty, new Size(maxWidth, maxHeight), backgroundColor, cssData, stylesheetLoad, imageLoad);
        }

        /// <summary>
        /// Renders the specified HTML into a new image of unknown size that will be determined by min/max width/height and HTML layout.<br/>
        /// If <paramref name="maxSize.Width"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize.Height"/> is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// If <paramref name="minSize"/> (Width/Height) is above zero the rendered image will not be smaller than the given min size.<br/>
        /// <p>
        /// Limitation: The image cannot have transparent background, by default it will be white.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </p>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="minSize">optional: the min size of the rendered html (zero - not limit the width/height)</param>
        /// <param name="maxSize">optional: the max size of the rendered html, if not zero and html cannot be layout within the limit it will be clipped (zero - not limit the width/height)</param>
        /// <param name="backgroundColor">optional: the color to fill the image with (default - white)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        /// <exception cref="ArgumentOutOfRangeException">if <paramref name="backgroundColor"/> is <see cref="Color.Transparent"/></exception>.
        public static Image RenderToImage(string html, Size minSize, Size maxSize, Color backgroundColor = new Color(), CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (backgroundColor == Color.Transparent)
                throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");

            if (string.IsNullOrEmpty(html))
                return new Bitmap(0, 0, PixelFormat.Format32bppArgb);

            using (var container = new SaaHtmlContainer())
            {
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;

                if (stylesheetLoad != null)
                    container.StylesheetLoad += stylesheetLoad;
                if (imageLoad != null)
                    container.ImageLoad += imageLoad;
                container.SetHtml(html, cssData);

                var finalSize = MeasureHtmlByRestrictions(container, minSize, maxSize);
                container.MaxSize = finalSize;

                // create the final image to render into by measured size
                var image = new Bitmap(finalSize.Width, finalSize.Height, PixelFormat.Format32bppArgb);

                // create memory buffer from desktop handle that supports alpha channel
                IntPtr dib;
                var memoryHdc = Win32Utils.CreateMemoryHdc(IntPtr.Zero, image.Width, image.Height, out dib);
                try
                {
                    // render HTML into the memory buffer
                    using (var memoryGraphics = Graphics.FromHdc(memoryHdc))
                    {
                        memoryGraphics.Clear(backgroundColor != Color.Empty ? backgroundColor : Color.White);
                        container.PerformPaint(memoryGraphics);
                    }

                    // copy from memory buffer to image
                    CopyBufferToImage(memoryHdc, image);
                }
                finally
                {
                    Win32Utils.ReleaseMemoryHdc(memoryHdc, dib);
                }

                return image;
            }
        }
#endif

        /// <summary>
        /// Renders the specified HTML into a new image of the requested size.<br/>
        /// The HTML will be layout by the given size but will be clipped if cannot fit.<br/>
        /// The generated image have transparent background that the html is rendered on.<br/>
        /// GDI+ text rending can be controlled by providing <see cref="TextRenderingHint"/>.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="size">The size of the image to render into, layout html by width and clipped by height</param>
        /// <param name="textRenderingHint">optional: (default - SingleBitPerPixelGridFit)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        public static Image RenderToImageGdiPlus(string html, Size size, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            var image = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

            using (var g = Graphics.FromImage(image))
            {
                g.TextRenderingHint = textRenderingHint;
                RenderHtml(g, html, PointF.Empty, size, cssData, true, stylesheetLoad, imageLoad);
            }

            return image;
        }

        /// <summary>
        /// Renders the specified HTML into a new image of unknown size that will be determined by max width/height and HTML layout.<br/>
        /// If <paramref name="maxWidth"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxHeight"/> is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// The generated image have transparent background that the html is rendered on.<br/>
        /// GDI+ text rending can be controlled by providing <see cref="TextRenderingHint"/>.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="maxWidth">optional: the max width of the rendered html, if not zero and html cannot be layout within the limit it will be clipped</param>
        /// <param name="maxHeight">optional: the max height of the rendered html, if not zero and html cannot be layout within the limit it will be clipped</param>
        /// <param name="textRenderingHint">optional: (default - SingleBitPerPixelGridFit)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        public static Image RenderToImageGdiPlus(string html, int maxWidth = 0, int maxHeight = 0, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            return RenderToImageGdiPlus(html, Size.Empty, new Size(maxWidth, maxHeight), textRenderingHint, cssData, stylesheetLoad, imageLoad);
        }

        /// <summary>
        /// Renders the specified HTML into a new image of unknown size that will be determined by min/max width/height and HTML layout.<br/>
        /// If <paramref name="maxSize.Width"/> is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize.Height"/> is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// If <paramref name="minSize"/> (Width/Height) is above zero the rendered image will not be smaller than the given min size.<br/>
        /// The generated image have transparent background that the html is rendered on.<br/>
        /// GDI+ text rending can be controlled by providing <see cref="TextRenderingHint"/>.<br/>
        /// See "Rendering to image" remarks section on <see cref="HtmlRender"/>.<br/>
        /// </summary>
        /// <param name="html">HTML source to render</param>
        /// <param name="minSize">optional: the min size of the rendered html (zero - not limit the width/height)</param>
        /// <param name="maxSize">optional: the max size of the rendered html, if not zero and html cannot be layout within the limit it will be clipped (zero - not limit the width/height)</param>
        /// <param name="textRenderingHint">optional: (default - SingleBitPerPixelGridFit)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the generated image of the html</returns>
        public static Image RenderToImageGdiPlus(string html, Size minSize, Size maxSize, TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias, CssData cssData = null,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (string.IsNullOrEmpty(html))
                return new Bitmap(0, 0, PixelFormat.Format32bppArgb);

            using (var container = new SaaHtmlContainer())
            {
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;
                container.UseGdiPlusTextRendering = true;

                if (stylesheetLoad != null)
                    container.StylesheetLoad += stylesheetLoad;
                if (imageLoad != null)
                    container.ImageLoad += imageLoad;
                container.SetHtml(html, cssData);

                var finalSize = MeasureHtmlByRestrictions(container, minSize, maxSize);
                container.MaxSize = finalSize;

                // create the final image to render into by measured size
                var image = new Bitmap(finalSize.Width, finalSize.Height, PixelFormat.Format32bppArgb);

                // render HTML into the image
                using (var g = Graphics.FromImage(image))
                {
                    g.TextRenderingHint = textRenderingHint;
                    container.PerformPaint(g);
                }

                return image;
            }
        }


        #region Private methods

        /// <summary>
        /// Measure the size (width and height) required to draw the given html under given width and height restrictions.<br/>
        /// </summary>
        /// <param name="g">Device to use for measure</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="maxWidth">optional: bound the width of the html to render in (default - 0, unlimited)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="useGdiPlusTextRendering">true - use GDI+ text rendering, false - use GDI text rendering</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the size required for the html</returns>
        private static SizeF Measure(Graphics g, string html, float maxWidth, CssData cssData, bool useGdiPlusTextRendering,
            EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad, EventHandler<HtmlImageLoadEventArgs> imageLoad)
        {
            SizeF actualSize = SizeF.Empty;
            if (!string.IsNullOrEmpty(html))
            {
                using (var container = new SaaHtmlContainer())
                {
                    container.MaxSize = new SizeF(maxWidth, 0);
                    container.AvoidAsyncImagesLoading = true;
                    container.AvoidImagesLateLoading = true;
                    container.UseGdiPlusTextRendering = useGdiPlusTextRendering;

                    if (stylesheetLoad != null)
                        container.StylesheetLoad += stylesheetLoad;
                    if (imageLoad != null)
                        container.ImageLoad += imageLoad;

                    container.SetHtml(html, cssData);
                    container.PerformLayout(g);

                    actualSize = container.ActualSize;
                }
            }
            return actualSize;
        }

        /// <summary>
        /// Measure the size of the html by performing layout under the given restrictions.
        /// </summary>
        /// <param name="htmlContainer">the html to calculate the layout for</param>
        /// <param name="minSize">the minimal size of the rendered html (zero - not limit the width/height)</param>
        /// <param name="maxSize">the maximum size of the rendered html, if not zero and html cannot be layout within the limit it will be clipped (zero - not limit the width/height)</param>
        /// <returns>return: the size of the html to be rendered within the min/max limits</returns>
        private static Size MeasureHtmlByRestrictions(SaaHtmlContainer htmlContainer, Size minSize, Size maxSize)
        {
            // use desktop created graphics to measure the HTML
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            using (var mg = new GraphicsAdapter(g, htmlContainer.UseGdiPlusTextRendering))
            {
                var sizeInt = HtmlRendererUtils.MeasureHtmlByRestrictions(mg, htmlContainer.HtmlContainerInt, Utils.Convert(minSize), Utils.Convert(maxSize));
                if (maxSize.Width < 1 && sizeInt.Width > 4096)
                    sizeInt.Width = 4096;
                return Utils.ConvertRound(sizeInt);
            }
        }

        /// <summary>
        /// Renders the specified HTML source on the specified location and max size restriction.<br/>
        /// If <paramref name="maxSize"/>.Width is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize"/>.Height is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// Clip the graphics so the html will not be rendered outside the max height bound given.<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">the top-left most location to start render the html at</param>
        /// <param name="maxSize">the max size of the rendered html (if height above zero it will be clipped)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="useGdiPlusTextRendering">true - use GDI+ text rendering, false - use GDI text rendering</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        private static SizeF RenderClip(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData, bool useGdiPlusTextRendering, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad, EventHandler<HtmlImageLoadEventArgs> imageLoad)
        {
            Region prevClip = null;
            if (maxSize.Height > 0)
            {
                prevClip = g.Clip;
                g.SetClip(new RectangleF(location, maxSize));
            }

            var actualSize = RenderHtml(g, html, location, maxSize, cssData, useGdiPlusTextRendering, stylesheetLoad, imageLoad);

            if (prevClip != null)
            {
                g.SetClip(prevClip, CombineMode.Replace);
            }

            return actualSize;
        }

        /// <summary>
        /// Renders the specified HTML source on the specified location and max size restriction.<br/>
        /// If <paramref name="maxSize"/>.Width is zero the html will use all the required width, otherwise it will perform line 
        /// wrap as specified in the html<br/>
        /// If <paramref name="maxSize"/>.Height is zero the html will use all the required height, otherwise it will clip at the
        /// given max height not rendering the html below it.<br/>
        /// Returned is the actual width and height of the rendered html.<br/>
        /// </summary>
        /// <param name="g">Device to render with</param>
        /// <param name="html">HTML source to render</param>
        /// <param name="location">the top-left most location to start render the html at</param>
        /// <param name="maxSize">the max size of the rendered html (if height above zero it will be clipped)</param>
        /// <param name="cssData">optional: the style to use for html rendering (default - use W3 default style)</param>
        /// <param name="useGdiPlusTextRendering">true - use GDI+ text rendering, false - use GDI text rendering</param>
        /// <param name="stylesheetLoad">optional: can be used to overwrite stylesheet resolution logic</param>
        /// <param name="imageLoad">optional: can be used to overwrite image resolution logic</param>
        /// <returns>the actual size of the rendered html</returns>
        private static SizeF RenderHtml(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData, bool useGdiPlusTextRendering, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad, EventHandler<HtmlImageLoadEventArgs> imageLoad)
        {
            SizeF actualSize = SizeF.Empty;

            if (!string.IsNullOrEmpty(html))
            {
                using (var container = new SaaHtmlContainer())
                {
                    container.Location = location;
                    container.MaxSize = maxSize;
                    container.AvoidAsyncImagesLoading = true;
                    container.AvoidImagesLateLoading = true;
                    container.UseGdiPlusTextRendering = useGdiPlusTextRendering;

                    if (stylesheetLoad != null)
                        container.StylesheetLoad += stylesheetLoad;
                    if (imageLoad != null)
                        container.ImageLoad += imageLoad;

                    container.SetHtml(html, cssData);
                    container.PerformLayout(g);
                    container.PerformPaint(g);

                    actualSize = container.ActualSize;
                }
            }

            return actualSize;
        }

#if !MONO
        /// <summary>
        /// Copy all the bitmap bits from memory bitmap buffer to the given image.
        /// </summary>
        /// <param name="memoryHdc">the source memory bitmap buffer to copy from</param>
        /// <param name="image">the destination bitmap image to copy to</param>
        private static void CopyBufferToImage(IntPtr memoryHdc, Image image)
        {
            using (var imageGraphics = Graphics.FromImage(image))
            {
                var imgHdc = imageGraphics.GetHdc();
                Win32Utils.BitBlt(imgHdc, 0, 0, image.Width, image.Height, memoryHdc, 0, 0, Win32Utils.BitBltCopy);
                imageGraphics.ReleaseHdc(imgHdc);
            }
        }
#endif

        #endregion
    }
}
