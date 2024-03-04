using System.Drawing;
using System.Drawing.Drawing2D;

namespace SaaUI
{

    internal class RoundedRectangleF
    {


        Point location;
        float radius;
        GraphicsPath grPath;
        GraphicsPath _BorderPath;
        float x, y;
        float width, height;

        RectangleF upperLeft;
        RectangleF upperRight;
        RectangleF lowerLeft;
        RectangleF lowerRight;


        public RoundedRectangleF(float width, float height, float radius, RoundCorners Corner = RoundCorners.All, float x = 0, float y = 0)
        {

            location = new Point(0, 0);
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            grPath = new GraphicsPath();
            if (radius <= 0)
            {
                grPath.AddRectangle(new RectangleF(x, y, width, height));

                return;
            }
            switch (Corner)
            {
                case RoundCorners.All:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.TopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);

                        grPath.AddArc(upperLeftRect, 180, 90);
                        break;
                    }
                case RoundCorners.TopRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);

                        break;
                    }
                case RoundCorners.Top:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Bottom:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Left:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Right:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.AllExceptTopRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptTopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptBottomRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptBottomLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.TopRightBottonLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomRightTopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.None:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        grPath.AddArc(upperLeftRect, 180, 90);
                        grPath.AddArc(upperRightRect, 270, 90);
                        grPath.AddArc(lowerRightRect, 0, 90);
                        grPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
            }


            MakeBoder(width, height, radius, Corner, x, y);

            grPath.CloseAllFigures();

        }

        private void MakeBoder(float width, float height, float radius, RoundCorners Corner = RoundCorners.All, float x = 0, float y = 0)
        {

            var location = new Point(0, 0);
            _BorderPath = new GraphicsPath();

            RectangleF upperLeft;
            RectangleF upperRight;
            RectangleF lowerLeft;
            RectangleF lowerRight;

            if (radius <= 0)
            {
                _BorderPath.AddRectangle(new RectangleF(x, y, width, height));

                return;
            }
            switch (Corner)
            {
                case RoundCorners.All:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius + 2, 2 * radius + 2);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;
                        var rx = radius * 1;
                        var ry = radius * 1;
                        var h = height - 2;
                        var w = width - 2;
                        _BorderPath.AddArc(x, y, rx + rx, ry + ry, 180, 90);
                        _BorderPath.AddLine(x + rx, y, x + w - rx, y);
                        _BorderPath.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
                        _BorderPath.AddLine(x + w, y + ry, x + w, y + h - ry);
                        _BorderPath.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 91);
                        _BorderPath.AddLine(x + rx, y + h, x + w - rx, y + h);
                        _BorderPath.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 91);

                        //_BorderPath.AddArc(upperLeftRect, 180, 90);
                        //_BorderPath.AddArc(upperRightRect, 270, 90);
                        //_BorderPath.AddArc(lowerRightRect, 0, 90);
                        //_BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.TopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        break;
                    }
                case RoundCorners.TopRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);

                        break;
                    }
                case RoundCorners.Top:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Bottom:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Left:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.Right:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
                case RoundCorners.AllExceptTopRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptTopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptBottomRight:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.AllExceptBottomLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.TopRightBottonLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.BottomRightTopLeft:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);


                        break;
                    }
                case RoundCorners.None:
                    {
                        RectangleF upperLeftRect = new RectangleF(x, y, 2 * 1, 2 * 1);
                        RectangleF upperRightRect = new RectangleF(width - 2 * 1 - 1, x, 2 * 1, 2 * 1);
                        RectangleF lowerLeftRect = new RectangleF(x, height - 2 * 1 - 1, 2 * 1, 2 * 1);
                        RectangleF lowerRightRect = new RectangleF(width - 2 * 1 - 1, height - 2 * 1 - 1, 2 * 1, 2 * 1);

                        upperLeft = upperLeftRect;
                        upperRight = upperRightRect;
                        lowerLeft = lowerRightRect;
                        lowerRight = lowerLeftRect;

                        _BorderPath.AddArc(upperLeftRect, 180, 90);
                        _BorderPath.AddArc(upperRightRect, 270, 90);
                        _BorderPath.AddArc(lowerRightRect, 0, 90);
                        _BorderPath.AddArc(lowerLeftRect, 90, 90);
                        break;
                    }
            }




            _BorderPath.CloseAllFigures();

        }

        public RoundedRectangleF()
        {
        }
        public GraphicsPath Path
        {
            get
            {
                return grPath;
            }
        }
        public GraphicsPath BorderPath
        {
            get
            {
                return _BorderPath;
            }
        }
        public RectangleF Rect
        {
            get
            {
                return new RectangleF(x, y, width, height);
            }
        }
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public RectangleF UpperRight
        {
            get
            {
                return upperRight;
            }
        }
        public RectangleF UpperLeft
        {
            get
            {
                return upperLeft;
            }
        }
        public RectangleF LowerLeft
        {
            get
            {
                return lowerLeft;
            }
        }
        public RectangleF LowerRight
        {
            get
            {
                return lowerRight;
            }
        }


    }
}
