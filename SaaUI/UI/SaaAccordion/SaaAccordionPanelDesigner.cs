using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SaaUI
{
    internal class SaaAccordionPanelDesigner : ParentControlDesigner
    {
        public SaaAccordionPanelDesigner()
        {
            this.DrawGrid = false;
        }
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules sel = base.SelectionRules;
                sel &= ~SelectionRules.AllSizeable;
                return SelectionRules.None;
            }
        }
        protected override void PostFilterAttributes(IDictionary attributes)
        {
            base.PostFilterAttributes(attributes);
            attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
        }

        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            var propertiesToRemove = new string[]
            {
                "Dock","Anchor", "Size", "Location","Width","Height","MinimumSize", "MaximumSize","AutoSize",
                "AutoSizeMode", "Visible", "Enabled"
            };
            foreach (var s in propertiesToRemove)
            {
                if (properties.Contains(s))
                {
                    properties[s] = TypeDescriptor.CreateProperty(this.Component.GetType(),
                        (PropertyDescriptor)properties[s], new BrowsableAttribute(false));
                }
            }
        }
    }
}
