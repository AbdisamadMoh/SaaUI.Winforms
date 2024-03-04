using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaaUI
{
    public abstract class SaaNotifier
    {
        public event EventHandler<EventArgs> Notifier;
        public SaaNotifier()
        {
        }

        public void Notify()
        {
            Notifier?.Invoke(this, null);
        }
    }
}
