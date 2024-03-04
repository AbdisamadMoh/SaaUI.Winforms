using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace SaaUI
{
    internal class SaaControlDesignerAccordion:ControlDesigner
    {
        private Adorner _adoner;
        protected override void Dispose(bool disposing)
        {
            if (disposing && _adoner != null)
            {
                BehaviorService b = BehaviorService;
                if (b != null)
                {
                    b.Adorners.Remove(_adoner);
                }
            }
            base.Dispose(disposing);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _adoner = new Adorner();
            this.BehaviorService.Adorners.Add(_adoner);
            _adoner.Glyphs.Add(new SaaAccordionGlyph(BehaviorService, Control, null));
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var c = (SaaAccordionHead)sender;
            c.Call();
        }

        protected override bool GetHitTest(Point point)
        {
           
            return base.GetHitTest(point);
        }
        public virtual void OnHit(Point p)
        {

        }
    }
}
