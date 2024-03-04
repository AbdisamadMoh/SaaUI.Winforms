using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace SaaUI
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class SaaAccordionParentControlDesigner : ParentControlDesigner
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
            var contentsPanel = ((SaaAccordion)this.Control).ContentPanel;
            this.EnableDesignMode(contentsPanel, "ContentPanel");

            _adoner = new Adorner();
            this.BehaviorService.Adorners.Add(_adoner);
            _adoner.Glyphs.Add(new SaaAccordionGlyph(BehaviorService, ((SaaAccordion)this.Control).Head, this.Control));
        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {

            de.Effect = DragDropEffects.None;
        }
        bool _hover = false;
        protected override void OnMouseEnter()
        {
            _hover = true;
            base.OnMouseEnter();
        }
        protected override void OnMouseLeave()
        {
            _hover = false;
            base.OnMouseLeave();

        }
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            if (_hover)
            {
                //var c = ((SaaAccordionItem)this.Control).Head;
                //var points = ((SaaAccordionItem)this.Control).Head.Bounds;
                //Rectangle bounds = new Rectangle(
                //   points.X + 10,
                //   points.Y + 10,
                //   c.Width - 20,
                //   c.Height - 20);
                //var pen = new Pen(ControlPaint.Dark(Color.White, 25));
                //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                //pe.Graphics.DrawRectangle(pen, bounds);
                //pen.Dispose();
            }
            base.OnPaintAdornments(pe);
        }
        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int widt, int height, bool hasLocation, bool hasSize)
        {
            IDesignerHost host;
            Control control;
            control = this.Control;
            host = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ParentControlDesigner childDesigner;

                childDesigner = (ParentControlDesigner)host.GetDesigner(control);

                // add controls onto the TabListPage control instead of the TabList
                ParentControlDesigner.InvokeCreateTool(childDesigner, tool);
            }
            return null;
        }
    }
}
