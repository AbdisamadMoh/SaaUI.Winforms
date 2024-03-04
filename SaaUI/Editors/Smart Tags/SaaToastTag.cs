using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace SaaUI
{
    internal class SaaToastTag : ComponentDesigner
    {
        private DesignerActionListCollection lists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (lists == null)
                {

                    lists = new DesignerActionListCollection();
                    lists.Add(new UserControlActioonList(this.Component));
                }
                return lists;
            }
        }
    }

    internal class UserControlActioonList : DesignerActionList
    {
        private SaaToast _toast;
        private DesignerActionUIService designerActionSvc = null;

        public UserControlActioonList(IComponent component)
            : base(component)
        {
            this._toast = (SaaToast)component;

            this.designerActionSvc =
              (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        private PropertyDescriptor GetPropertyByName(string propName)
        {
            PropertyDescriptor prop = default(PropertyDescriptor);
            prop = TypeDescriptor.GetProperties(_toast)[propName];
            if (prop == null)
            {
                throw new ArgumentException("Invalid Property", propName);
            }
            else
            {
                return prop;
            }
        }

        public override System.ComponentModel.Design.DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection item = new DesignerActionItemCollection();
            item.Add(new DesignerActionHeaderItem("Saa"));
            item.Add(new DesignerActionMethodItem(this, "OpenDesigner", "-- Edit With Designer --", "Saa", "Edit with Toast designer", true));

            return item;
        }
        private void OpenDesigner()
        {
            SaaToastDesigner std = new SaaToastDesigner();
            std.SaaToast = this._toast;
            std.ShowDialog();
        }
    }
}
