using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI.Engines.CSS.Attributes
{
    internal interface ISharedAttributes
    {
        Padding Padding { get; set; }
        Padding Margin { get; set; }
        Color BackgroundColor { get; set; }
        Color ForeColor { get; set; }


    }
}
