using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace SaaUI.UI.SaaForms
{
    internal partial class TestForm : Form
    {
        internal Panel p = new Panel();
        public TestForm()
        {
            p.BackColor = Color.Red;
            p.Height = this.Height / 2;
            p.Dock = DockStyle.Bottom;
            base.Controls.Add(p);
            InitializeComponent();

        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new Controls(this);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private new Control.ControlCollection Controls
        {
            get { return base.Controls; }
        }
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class SaaFormParentControlDesigner : ParentControlDesigner
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
            var contentsPanel = ((TestForm)this.Control);//.panel1;
            this.EnableDesignMode(contentsPanel, "panel1");

            _adoner = new Adorner();
            this.BehaviorService.Adorners.Add(_adoner);
            _adoner.Glyphs.Add(new SaaFormsGlyph(BehaviorService, this.Control));
        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {

            de.Effect = DragDropEffects.None;
        }
        // override se
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
        protected IComponent[] CreateToolCore1(ToolboxItem tool, int x, int y, int widt, int height, bool hasLocation, bool hasSize)
        {
            return null;
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

    internal class Controls : Control.ControlCollection
    {
        private TestForm _owner;
        public Controls(TestForm owner) : base(owner)
        {
            _owner = owner;
        }
        public override void Add(Control value)
        {
            if (value.GetType() == typeof(fp))
            {
                base.Add(value);
            }
            else
            {
                _owner.Controls.Add(value);
            }
        }

        public override void Remove(Control value)
        {
            if (value.GetType() == typeof(fp))
            {
                base.Remove(value);
            }
            else
            {
                _owner.Controls.Remove(value);
            }
        }
    }

    internal class fp : Panel
    {

    }
}
