using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaDataGridViewButtonColumn:DataGridViewColumn
    {
        string defaultValue = "button";
        public SaaDataGridViewButtonColumn():base(new SaaDataGridButtonCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(SaaDataGridButtonCell)))
                {
                    throw new InvalidCastException("Must be a SaaDataGridButtonCell");
                }
                base.CellTemplate = value;
            }
        }


    }
}
