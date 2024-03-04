using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace SaaUI
{
    internal class SaAccordionBehavior : Behavior
    {
        Control control;
        public SaAccordionBehavior(Control cont)
        {
            this.control = cont;
        }
        public override bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc)
        {
            ((SaaAccordion)control).Expand = !((SaaAccordion)control).Expand;
            return base.OnMouseDown(g, button, mouseLoc);
        }
    }

    internal class SaFormBehavior : Behavior
    {
        Control control;
        public SaFormBehavior(Control cont)
        {
            this.control = cont;
        }
        public override bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc)
        {
            // ((SaaAccordion)control).Expand = !((SaaAccordion)control).Expand;
            return base.OnMouseDown(g, button, mouseLoc);
        }

        public override void OnDragEnter(Glyph g, DragEventArgs e)
        {

            base.OnDragEnter(g, e);
        }
    }

}
