using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class SaaPropertyNotifierAttribute : Attribute
    {
        ISaaNotifier Parent;
        SaaNotifier Child;
        Dictionary<SaaNotifier, Type> _dic = new Dictionary<SaaNotifier, Type>();
        public SaaPropertyNotifierAttribute()
        {
            Debug.WriteLine("debugged...");
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(SaaPropertyNotifierAttribute),true));
            foreach(var type in types)
            {
                var properties = type.GetProperties().Where(t => t.PropertyType.IsAssignableFrom(typeof(SaaNotifier)));
            var c = properties.ElementAt(0).GetType();
            }
        }
        private void Child_Notifier(object sender, EventArgs e)
        {
            if (Parent != null) Parent.Notify(Child);
        }
    }
}
