using SaaUI.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SaaUI
{
    internal class BorderPath : IDisposable
    {
        GraphicsPath _Path;
        GraphicsPath _BorderPath;
        Image _Image;
        float x, y, width, height;
        Radius radius;
        RadiusF radiusF;
        public BorderPath(float X, float Y, int Width, int Height, Radius Radius)
        {
            _Path = new GraphicsPath();
            x = X; y = Y; width = Width; height = Height; radius = Radius;

            int topLeft = Radius.TopLeft > 0 ? Radius.TopLeft : 1;
            int topRight = Radius.TopRight > 0 ? Radius.TopRight : 1;
            int bottomLeft = Radius.BottomLeft > 0 ? Radius.BottomLeft : 1;
            int bottomRight = Radius.BottomRight > 0 ? Radius.BottomRight : 1;

            _Path.AddArc(X + Width - (topRight * 2), Y, topRight * 2, topRight * 2, 270, 90);
            _Path.AddArc(X + Width - (bottomRight * 2), Y + Height - (bottomRight * 2), bottomRight * 2, bottomRight * 2, 0, 90);
            _Path.AddArc(X, Y + Height - (bottomLeft * 2), bottomLeft * 2, bottomLeft * 2, 90, 90);
            _Path.AddArc(X, Y, topLeft * 2, topLeft * 2, 180, 90);
            _Path.CloseAllFigures();
            MakeBorder();
        }
        public BorderPath(float X, float Y, float Width, float Height, Radius Radius)
        {
            _Path = new GraphicsPath();
            x = X; y = Y; width = Width; height = Height; radius = Radius;

            int topLeft = Radius.TopLeft > 0 ? Radius.TopLeft : 1;
            int topRight = Radius.TopRight > 0 ? Radius.TopRight : 1;
            int bottomLeft = Radius.BottomLeft > 0 ? Radius.BottomLeft : 1;
            int bottomRight = Radius.BottomRight > 0 ? Radius.BottomRight : 1;

            _Path.AddArc(X + Width - (topRight * 2), Y, topRight * 2, topRight * 2, 270, 90);
            _Path.AddArc(X + Width - (bottomRight * 2), Y + Height - (bottomRight * 2), bottomRight * 2, bottomRight * 2, 0, 90);
            _Path.AddArc(X, Y + Height - (bottomLeft * 2), bottomLeft * 2, bottomLeft * 2, 90, 90);
            _Path.AddArc(X, Y, topLeft * 2, topLeft * 2, 180, 90);
            _Path.CloseAllFigures();
            MakeBorder();
        }
        public BorderPath(float X, float Y, float Width, float Height, RadiusF Radius)
        {
            _Path = new GraphicsPath();
            x = X; y = Y; width = Width; height = Height; radiusF = Radius;

            float topLeft = Radius.TopLeft > 0 ? Radius.TopLeft : 1;
            float topRight = Radius.TopRight > 0 ? Radius.TopRight : 1;
            float bottomLeft = Radius.BottomLeft > 0 ? Radius.BottomLeft : 1;
            float bottomRight = Radius.BottomRight > 0 ? Radius.BottomRight : 1;

            _Path.AddArc(X + Width - (topRight * 2), Y, topRight * 2, topRight * 2, 270, 90);
            _Path.AddArc(X + Width - (bottomRight * 2), Y + Height - (bottomRight * 2), bottomRight * 2, bottomRight * 2, 0, 90);
            _Path.AddArc(X, Y + Height - (bottomLeft * 2), bottomLeft * 2, bottomLeft * 2, 90, 90);
            _Path.AddArc(X, Y, topLeft * 2, topLeft * 2, 180, 90);
            _Path.CloseAllFigures();
            MakeBorder();
        }
        public BorderPath(Image _image, Radius Radius, Color BackgroundColor)
        {
            if (_image == null || Radius == null || BackgroundColor == null) return;
          //  CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(_image.Width, _image.Height);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                var width = RoundedImage.Width;
                var height = RoundedImage.Height;
                g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Brush brush = new TextureBrush(_image);
               _Path = new GraphicsPath();
                float topLeft = Radius.TopLeft > 0 ? Radius.TopLeft : 1;
                float topRight = Radius.TopRight > 0 ? Radius.TopRight : 1;
                float bottomLeft = Radius.BottomLeft > 0 ? Radius.BottomLeft : 1;
                float bottomRight = Radius.BottomRight > 0 ? Radius.BottomRight : 1;

                _Path.AddArc(0, 0, topRight * 2, topRight * 2, 270, 90);
                _Path.AddArc(width - (bottomRight * 2), height- (bottomRight * 2), bottomRight * 2, bottomRight * 2, 0, 90);
                _Path.AddArc(0, height - (bottomLeft * 2), bottomLeft * 2, bottomLeft * 2, 90, 90);
                _Path.AddArc(0, 0, topLeft * 2, topLeft * 2, 180, 90);
                g.FillPath(brush, _Path);
            }
            _Image = _image;
        }
        private void MakeBorder()
        {
            _BorderPath = new GraphicsPath();
            float X = x + .5f, Y = y + .5f, Width = width, Height = height;
            Radius Radius = radius;

            int topLeft = Radius.TopLeft > 0 ? Radius.TopLeft : 1;
            int topRight = Radius.TopRight > 0 ? Radius.TopRight : 1;
            int bottomLeft = Radius.BottomLeft > 0 ? Radius.BottomLeft : 1;
            int bottomRight = Radius.BottomRight > 0 ? Radius.BottomRight : 1;

            _BorderPath.AddArc(X + Width - (topRight * 2), Y, topRight * 2, topRight * 2, 270, 90);
            _BorderPath.AddArc(X + Width - (bottomRight * 2), Y + Height - (bottomRight * 2), bottomRight * 2, bottomRight * 2, 0, 90);
            _BorderPath.AddArc(X, Y + Height - (bottomLeft * 2), bottomLeft * 2, bottomLeft * 2, 90, 90);
            _BorderPath.AddArc(X, Y, topLeft * 2, topLeft * 2, 180, 90);
            _BorderPath.CloseAllFigures();
        }



        public GraphicsPath Path
        {
            get
            {
                return _Path;
            }
        }
        public GraphicsPath PathBorder
        {
            get
            {
                return _BorderPath;
            }
        }
        public Image Image
        {
            get
            {
                return _Image;
            }
        }
        public RectangleF RectangleF
        {
            get
            {
                return new RectangleF(x, y, width, height);
            }
        }


        ~BorderPath()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Path.Dispose();
                _BorderPath.Dispose();
                if (_Image != null)
                {
                    _Image.Dispose();
                }
            }
        }
    }
}
