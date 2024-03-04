using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaDataGridButtonCell: DataGridViewButtonCell
    {
        public SaaDataGridButtonCell() : base()
        {

        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        }
        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewButtonCell);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return "Button";
            }
        }

    }
}
