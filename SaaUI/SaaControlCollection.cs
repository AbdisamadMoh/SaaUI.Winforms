using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaControlCollection : Control.ControlCollection
    {
        bool _Isinner = false;
        public SaaControlCollection(Control owner, bool isInner) : base(owner)
        {
            _Isinner = isInner;
        }
        public override void Add(System.Windows.Forms.Control value)
        {
            //foreach (Control ctrl in this)
            //    if (ctrl is Panel) // Panel should be replaced by your panel class type
            //    {
            //        ctrl.Controls.Add(value);
            //        return;
            //    }
            //if (_Isinner)
            //{
            //    this.Add(value);
            //    return;
            //}

            base.Add(value);
        }
        public override void AddRange(Control[] controls)
        {
            base.AddRange(controls);
        }

        public override void Remove(System.Windows.Forms.Control value)
        {
            base.Remove(value);
        }

    }
}
