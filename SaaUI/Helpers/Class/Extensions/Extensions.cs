using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// This class contains extensions that you may find helpful. 
    /// </summary>
    public static class SaaExtensions
    {
        /// <summary>
        /// Provides the <see cref="Size"/> of the specified text when drawn with the specified font.
        /// </summary>
        /// <param name="text">Text to measure</param>
        /// <param name="font">Font of the text</param>
        /// <returns>Returns in pixels, Size the text requires</returns>
        public static Size GetSize(this string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
        }
        /// <summary>
        /// Gets the total Size (including Offsets) of all toasts that are open and visible on the screen. 
        /// </summary>
        /// <param name="toast"></param>
        /// <returns></returns>
        public static Size GetSize(this SaaToast toast)
        {
            return new Size(FormList.GetWidth(), FormList.GetHeight());
        }

        /// <summary>
        /// Gets the total Size (including Offsets) of all toasts that are open and visible on the screen in the specified position.
        /// </summary>
        /// <param name="toast"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Size GetSize(this SaaToast toast, ToastPosition position)
        {

            return new Size(FormList.GetWidth(position), FormList.GetHeight(position));
        }
        /// <summary>
        /// Converts <see cref="Color"/> to Hexadecimal
        /// </summary>
        /// <param name="color">Color to convert</param>
        /// <returns>returns color in hexadecimal like #FFFF00</returns>
        public static string ToHEX(this Color color) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";

        /// <summary>
        /// Converts <see cref="Color"/> to RGB
        /// </summary>
        /// <param name="color">Color to convert</param>
        /// <returns>returns color in RGB like RGB(255,255,0)</returns>
        public static string ToRGB(this Color color) => $"RGB({color.R}, {color.G}, {color.B})";

        internal static string GenerateID(this string str)
        {
            return (Guid.NewGuid().ToString().Replace("_", "").Replace("-", "") + DateTime.Now.Ticks + Guid.NewGuid().ToString().Replace("_", "").Replace("-", ""));

        }

        /// <summary>
        /// Generates globally unique ids. The possibility of generating same Id for lifetime is 0%.
        /// </summary>
        public static string NewID
        {
            get
            {
                return (Guid.NewGuid().ToString().Replace("_", "").Replace("-", "") + DateTime.Now.Ticks + Guid.NewGuid().ToString().Replace("_", "").Replace("-", ""));
            }
        }

        /// <summary>
        /// Makes a color transparent in the given percentage.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static Color GetTransparency(this Color color, int percentage)
        {
            int transpancePercentage = (int)((((float)percentage / 100f) * 255f));
            transpancePercentage = transpancePercentage > 0 ? transpancePercentage : 1;
            var c = color != Color.Transparent ? Color.FromArgb(transpancePercentage, color) : color;

            return c;
        }

        /// <summary>
        /// Gets the location of a control relative to where it appears on the form. No matter if the control is inside other containers or nested containers.
        /// <para></para>
        /// <see cref="Exception"/><br></br>
        /// <list type="bullet"><see cref="NullReferenceException"/></list>
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <returns>Location of the control relative to where it appears on the form.</returns>
        public static Point LocationRelativeToForm(this Control control)
        {


            Form form = control.FindForm();
            if (form == null) return new Point(0, 0);
            Control parent = control.Parent;
            Point offset = control.Location;
            while (parent != null && !(parent is Form))
            {
                offset.X += parent.Location.X;
                offset.Y += parent.Location.Y;
                parent = parent.Parent;
            }
            return offset;
        }

        /// <summary>
        /// Gets mouse location relative to the parent form. It returns <see cref="Point.Empty"/> if the mouse is outside the form.
        /// <para></para>
        /// <see cref="Exception"/><br></br>
        /// <list type="bullet">
        /// <see cref="ArgumentNullException"/>
        /// </list>
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Point MouseLocation(this Control control)
        {
            if (control == null) throw new Exception("Control can not be null");
            Point p = Point.Empty;
            var pr = control.FindForm();
            if (pr == null) return p;
            if (control is Form) { p = new Point(); p = control.PointToClient(Cursor.Position); }
            else
            {
                p = new Point();

                var cr = control.LocationRelativeToForm();
                p = pr.PointToClient(Cursor.Position);
            }
            return p;
        }

        /// <summary>
        /// Gets mouse location of a control relative to itself. This is the position of the mouse pointer within the control. If the mouse pointer is outside the control then it returns -1 (both X and Y).
        /// <para></para>
        /// <see cref="Exception"/><br></br>
        /// <list type="bullet">
        /// <see cref="ArgumentNullException"/>
        /// </list>
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Point InnerMouseLocation(this Control control)
        {
            if (control == null) throw new Exception("Control can not be null");
            Point p = control.MouseLocation();
            var pr = control.FindForm();
            if (pr == null) return p;
            Point cp = control.LocationRelativeToForm();
            p.X = p.X - cp.X;
            p.Y = p.Y - cp.Y;
            if (p.X < 0 || p.X > control.Width || p.Y < 0 || p.Y > control.Height)
            {
                p.X = -1;
                p.Y = -1;
            }
            return p;
        }
        /// <summary>
        /// SetDoubleBuffering(Control) enables or disables doubleBuffering for a control. Flag (true/false) tells whether to enable or disable.
        /// <para></para>
        /// <see cref="Exception"/><br></br>
        /// <list type="bullet">
        /// <see cref="ArgumentNullException"/>
        /// </list>
        /// </summary>
        /// <param name="control"></param>
        /// <param name="flag"></param>

        public static void SetDoubleBuffering(this Control control, bool flag)
        {
            if (control == null) throw new Exception("Control can not be null");
            control.SetProperty("DoubleBuffering", flag);

        }
        /// <summary>
        /// Checks whether string array has the specified item in its collection.
        /// </summary>
        /// <param name="strArray">source</param>
        /// <param name="item">item to check</param>
        /// <param name="caseSensitive">(optional) whether it is case sensitive</param>
        /// <returns>returns true if the item exists in the collection.</returns>
        public static bool Contains(this string[] strArray, string item, bool caseSensitive = false)
        {
            if (strArray == null) return false;
            bool _ret = false;
            foreach (var s in strArray)
            {
                if (s.Length > 0)
                {
                    var st1 = caseSensitive ? s : s.ToLower();
                    var st2 = caseSensitive ? item : item.ToLower();
                    if (st1 == st2) { _ret = true; break; }
                }
            }

            return _ret;
        }

        /// <summary>
        /// Copy properties of this control to another control.
        /// </summary>
        /// <param name="fromControl">source control</param>
        /// <param name="toControl">destination control</param>
        /// <param name="propertiesNoToCopy">(optional) properties to skip. put 'null' to skip nothing.</param>
        private static void CopyPropertiesExceptTo(this Control fromControl, Control toControl, string[] propertiesNoToCopy = null)
        {
            if (fromControl == null) throw new Exception("Source control is null");
            if (toControl == null) throw new Exception("destination control is null");
            if (fromControl.GetType() != toControl.GetType()) throw new Exception("Both controls should be same type.");
            if (propertiesNoToCopy == null) { propertiesNoToCopy = new string[] { }; }
            foreach (var fprop in fromControl.GetType().GetProperties())
            {
                foreach (var tprop in toControl.GetType().GetProperties())
                {
                    if (fprop.Name == tprop.Name && fprop.PropertyType == tprop.PropertyType && !propertiesNoToCopy.Contains(fprop.Name))
                    {
                        if (!fprop.CanWrite) return;
                        tprop.SetValue(toControl, fprop.GetValue(fromControl, null), null);
                    }
                }
            }

        }

        /// <summary>
        /// Copies properties from the specified control to this control.
        /// </summary>
        /// <param name="toControl">destination control</param>
        /// <param name="fromControl">source control</param>
        /// <param name="propertiesNotToCopy">(optional) properties to skip. Put 'null' to skip nothing.</param>
        public static void CopyPropertiesFromExcept(this Control toControl, Control fromControl, string[] propertiesNotToCopy = null)
        {
            CopyPropertiesExceptTo(fromControl, toControl, propertiesNotToCopy);
        }

        /// <summary>
        /// Copies specified properties from this control to the specified control.
        /// </summary>
        /// <param name="fromControl">source control</param>
        /// <param name="toControl">destination control</param>
        /// <param name="propertiesToCopy">properties to copy</param>
        private static void CopyPropertiesTo(this Control fromControl, Control toControl, string[] propertiesToCopy = null)
        {
            if (fromControl == null) throw new Exception("Source control is null");
            if (toControl == null) throw new Exception("destination control is null");
            if (fromControl.GetType() != toControl.GetType()) throw new Exception("Both controls should be same type.");
            //if (propertiesToCopy == null) throw new Exception("Properties to copy can not be null.");
            foreach (var fprop in fromControl.GetType().GetProperties())
            {
                foreach (var tprop in toControl.GetType().GetProperties())
                {
                    if (fprop.Name == tprop.Name && fprop.PropertyType == tprop.PropertyType && (propertiesToCopy.Contains(fprop.Name) || propertiesToCopy == null))
                    {
                        if (!fprop.CanWrite) return;
                        tprop.SetValue(toControl, fprop.GetValue(fromControl, null), null);
                    }
                }
            }

        }

        /// <summary>
        /// Copies specified properties from the specified control to this control.
        /// </summary>
        /// <param name="toControl">destination control</param>
        /// <param name="fromControl">source control</param>
        /// <param name="propertiesToCopy">properties to copy</param>
        public static void CopyPropertiesFrom(this Control toControl, Control fromControl, string[] propertiesToCopy)
        {

            CopyPropertiesTo(fromControl, toControl, propertiesToCopy);
        }

        /// <summary>
        /// Sets property to an object.
        /// </summary>
        /// <param name="obj">target object</param>
        /// <param name="propertyName">target property name</param>
        /// <param name="value">target property value</param>
        public static void SetProperty(this object obj, string propertyName, object value)
        {
            if (obj == null) throw new Exception("target control is null");
            if (string.IsNullOrEmpty(propertyName)) throw new Exception("property name can not be empty");
            foreach (var fprop in obj.GetType().GetProperties())
            {
                if (fprop.Name == propertyName)
                {

                    if (!fprop.CanWrite) return;
                    fprop.SetValue(obj, value, null);

                }
            }
        }

        /// <summary>
        /// Gets property value of an object.
        /// </summary>
        /// <param name="obj">target object</param>
        /// <param name="propertyName">target property</param>
        /// <returns>Value of the property as an object.</returns>
        public static object GetProperty(this object obj, string propertyName)
        {
            object o = null;
            if (obj == null) throw new Exception("target object is null");
            if (string.IsNullOrEmpty(propertyName)) throw new Exception("property name can not be empty");
            foreach (var fprop in obj.GetType().GetProperties(reflectionFlags()))
            {
                if (fprop.Name == propertyName)
                {
                    if (!fprop.CanRead) return null;
                    fprop.GetValue(obj, null);
                }
            }
            return o;
        }

        /// <summary>
        /// Converts string array to List.
        /// </summary>
        /// <param name="strArray">string array to convert</param>
        /// <returns></returns>
        public static List<string> ToList(this string[] strArray)
        {
            List<string> _s = new List<string>();
            foreach(var i in strArray)
            {
                _s.Add(i);
            }
            return _s;
        }

       static string[] _numSuffixes = { "th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th" };

        /// <summary>
        /// Converts integers like 1, 2, and 3 to ordinal strings like 1st, 2nd, and 3rd.
        /// </summary>
        /// <param name="n">Number to convert</param>
        public static string NumberToOrdinal(this int n)
        {
            // Make exception for teens
            int i = (n % 100);
            int j = (i > 10 && i < 20) ? 0 : (n % 10);
            return String.Format("{0}{1}", n, _numSuffixes[j]);
        }

        private static BindingFlags reflectionFlags()
        {
            return (BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
        }

        internal static int GetFurthestPoint(decimal dividend, decimal divisor, decimal add)
        {
            decimal incr = dividend % divisor == 0 ? 0 : add;
            return (int)(Math.Truncate((dividend / divisor)) + incr);
        }
    }
}

