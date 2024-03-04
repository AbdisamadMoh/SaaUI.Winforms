using System;
using System.ComponentModel;
using System.Globalization;

namespace SaaUI.Properties
{
    internal class SaaToggleStylesObjectConverter : ExpandableObjectConverter
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
                // var v = ((iOS)value);
                string val = "Style";
                if (value.GetType() == typeof(iOS))
                {
                    val = "iOS Style";
                }
                else if (value.GetType() == typeof(SaaToggleColors))
                {
                    val = "Colors";
                }
                else if (value.GetType() == typeof(Flat))
                {
                    val = "Flat Style";
                }
                else if (value.GetType() == typeof(Skewed))
                {
                    val = "Skewed Style";
                }
                else if (value.GetType() == typeof(ToggleSkewedCoordinates))
                {
                    val = "Shape Coordinates";
                }
                return val;
            }

            return base.ConvertTo(
                context,
                culture,
                value,
                destinationType);
        }
    }

    internal class SaaObjectConverter : ExpandableObjectConverter
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
                string val = "Object";
                //if (value.GetType() == typeof(ComboBoxColors))
                //{
                //    val = "Colors";
                //}
                //else if (value.GetType() == typeof(object))
                //{
                //    val = "Object";
                //}
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
