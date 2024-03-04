using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace SaaUI
{
    internal class SaaAccordionGlyph : Glyph
    {
        private BehaviorService behaviorService;
        private Control control;

        public SaaAccordionGlyph(BehaviorService behaviorService, Control control, Control actionControl) : base(new SaAccordionBehavior(actionControl))
        {
            this.behaviorService = behaviorService;
            this.control = control;
        }
        public override Rectangle Bounds
        {
            get
            {
                Point edge = behaviorService.ControlToAdornerWindow(control);
                Size size = control.Size;
                Point center = new Point(edge.X,
                edge.Y);

                Rectangle bounds = new Rectangle(
                    center.X + 10,
                    center.Y + 10,
                    size.Width - 20,
                    size.Height - 20);
                return bounds;
            }

        }

        public override Cursor GetHitTest(Point p)
        {
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }

        public override void Paint(PaintEventArgs pe)
        {

        }
    }

    //Forms
    internal class SaaFormsGlyph : Glyph
    {
        private BehaviorService behaviorService;
        private Control control;

        public SaaFormsGlyph(BehaviorService behaviorService, Control control) : base(new SaFormBehavior(control))
        {
            this.behaviorService = behaviorService;
            this.control = control;
        }
        public override Rectangle Bounds
        {
            get
            {
                Point edge = behaviorService.ControlToAdornerWindow(control);
                Size size = control.Size;

                Rectangle bounds = new Rectangle(
                    0,
                    0,
                    size.Width,
                    50);
                return bounds;
            }

        }

        public override Cursor GetHitTest(Point p)
        {
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }

        public override void Paint(PaintEventArgs pe)
        {

        }
    }

   
}
