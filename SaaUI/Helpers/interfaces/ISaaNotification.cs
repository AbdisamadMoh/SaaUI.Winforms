using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaaUI
{
    internal interface ISaaNotifier
    {
        // event EventHandler<EventArgs> Notify;
        void Notify(SaaNotifier from = null);
    }
}
