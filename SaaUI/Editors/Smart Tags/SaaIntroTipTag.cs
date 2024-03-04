using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace SaaUI
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class SaaIntroTipTag : ComponentDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new SaaIntroTipControlActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    internal class SaaIntroTipControlActionList : DesignerActionList
    {
        private SaaIntroTip control;

        private DesignerActionUIService designerActionUISvc = null;

        //The constructor associates the control with the smart tag list.
        public SaaIntroTipControlActionList(IComponent component)
            : base(component)
        {
            this.control = component as SaaIntroTip;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService))
        as DesignerActionUIService;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            items.Add(new DesignerActionHeaderItem("Designer"));
            items.Add(new DesignerActionHeaderItem("Colors"));

            items.Add(new DesignerActionPropertyItem("BackColor", "Back Color", "Colors", "Gets or Sets the background color."));
            items.Add(new DesignerActionPropertyItem("TextColor", "Text Color", "Colors", "Gets or Sets the text color."));
            items.Add(new DesignerActionPropertyItem("ArrowColor", "Arrow Color", "Colors", "Gets or Sets the arrow color."));
            items.Add(new DesignerActionPropertyItem("BorderColor", "Border Color", "Colors", "Gets or Sets the border color around the target region."));
            items.Add(new DesignerActionPropertyItem("RegionColor", "Region Color", "Colors", "Gets or Sets the background color of the target region."));

            items.Add(new DesignerActionMethodItem(this, "Designer", "-- Edit with Designer --", "Designer", "Opens with designer", true));

            //items.Add(new DesignerActionPropertyItem("TextColor",
            //                     "text Color", "Colors",
            //                     "Selects the text color."));
            //items.Add(new DesignerActionPropertyItem("ArrowColor",
            //                     "Arrow Color", "Colors",
            //                     "Selects arrow color"));
            return items;
        }
        public void Designer()
        {
            SaaIntroTipDesigner des = new SaaIntroTipDesigner(this.control);
            des.ShowDialog();
        }
        public Color BackColor
        {
            get
            {
                return this.control.BackColor;
            }
            set
            {

                this.control.BackColor = value;
            }
        }
        public Color TextColor
        {
            get
            {
                return this.control.TextColor;
            }
            set
            {

                this.control.TextColor = value;
            }
        }
        public Color ArrowColor
        {
            get
            {
                return this.control.ArrowColor;
            }
            set
            {

                this.control.ArrowColor = value;
            }
        }
        public Color BorderColor
        {
            get
            {
                return this.control.BorderColor;
            }
            set
            {

                this.control.BorderColor = value;
            }
        }
        public Color RegionColor
        {
            get
            {
                return this.control.TargetBackColor;
            }
            set
            {

                this.control.TargetBackColor = value;
            }
        }

    }
}
