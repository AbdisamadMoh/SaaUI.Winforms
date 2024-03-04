using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaaUI.Helpers.Class;

namespace SaaUI
{
    public class SaaTable:Control
    {
        public SaaTable()
        {
            Size = new System.Drawing.Size(412, 276);
            new Colors().color(this);
        }
    }
}
