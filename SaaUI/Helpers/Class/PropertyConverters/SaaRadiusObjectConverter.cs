using System;
using System.ComponentModel;
using System.Globalization;

namespace SaaUI.Properties
{
    internal class SaaRadiusObjectConverter : ExpandableObjectConverter
    {
        // This override prevents the PropertyGrid from 
        // displaying the full type name in the value cell.
        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var v = ((Radius)value);
                string val = v.BottomLeft + "; " + v.BottomRight + "; " + v.TopRight + "; " + v.TopLeft;
                return val;
            }

            return base.ConvertTo(
                context,
                culture,
                value,
                destinationType);
        }
    }
}
