using SaaUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// User guide introduction tip. Helps you introduce users to your application.
    /// </summary>
    [Description("User guide introduction tip. Helps you introduce users to your application.")]
    [ToolboxBitmap(typeof(SaaChatPanel), "icons.SaaIntroTip.bmp")]
    [ProvideProperty("Tip", typeof(Control))]
    [ProvideProperty("SortIndex", typeof(Control))]
    [DefaultEvent("TargetClicked")]
    [Designer(typeof(SaaIntroTipTag))]
    public partial class SaaIntroTip : Component, IExtenderProvider
    {
        SaaIntroTipControl _intro = new SaaIntroTipControl();

        /// <summary>
        /// Fires when user starts clicking the target control.
        /// </summary>
        [Description("Fires when user starts clicking the target control."), Category("Saa")]
        public event EventHandler<IntroTipClickEventArgs> TargetClicking;
        /// <summary>
        /// Fires when user starts clicking anywhere on the introtip including the target control.
        /// </summary>
        [Description("Fires when user starts clicking anywhere on the introtip including the target control."), Category("Saa")]
        public event EventHandler<IntroTipClickEventArgs> Clicking;

        /// <summary>
        /// Fires when user clicks the target control.
        /// </summary>
        [Description("Fires when user clicks the target control."), Category("Saa")]
        public event EventHandler<IntroTipClickEventArgs> TargetClicked;
        /// <summary>
        /// Fires when user clicks anywhere on the introtip including the target control.
        /// </summary>
        [Description("Fires when user clicks anywhere on the introtip including the target control."), Category("Saa")]
        public event EventHandler<IntroTipClickEventArgs> Clicked;

        /// <summary>
        /// Fires when the mouse pointer is over the target control.
        /// </summary>
        [Description("Fires when the mouse pointer is over the target control."), Category("Saa")]
        public event EventHandler<IntroTipHoverEventArgs> TargetHover;
        /// <summary>
        /// Fires when the mouse pointer is over anywhere on the introtip including the target control.
        /// </summary>
        [Description("Fires when the mouse pointer is over anywhere on the introtip including the target control."), Category("Saa")]
        public event EventHandler<IntroTipHoverEventArgs> Hover;

        /// <summary>
        /// Fires when the mouse pointer leaves the target control.
        /// </summary>
        [Description("Fires when the mouse pointer leaves the target control."), Category("Saa")]
        public event EventHandler<IntroTipHoverEventArgs> TargetLeaveHover;
        /// <summary>
        /// Fires when the mouse pointer leaves the introtip.
        /// </summary>
        [Description("Fires when the mouse pointer leaves the introtip."), Category("Saa")]
        public event EventHandler<IntroTipHoverEventArgs> LeaveHover;
        public SaaIntroTip()
        {
            InitializeComponent();
            _intro.MouseEnter += _intro_MouseEnter;
            _intro.MouseLeave += _intro_MouseLeave;
            _intro.MouseDown += _intro_MouseDown;
            _intro.MouseUp += _intro_MouseUp;
            _intro.MouseMove += _intro_MouseEnter;
        }

        private void _intro_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isTriggable(e.Button)) return;
            if (_intro == null || _intro.ParentForm == null) return;
            IntroTipClickEventArgs tipEvent = new IntroTipClickEventArgs()
            {
                MouseButtons = e.Button,
                MouseLocation = e.Location,
                Location = _intro.Control.Location,
                TargetControl = _intro.Control,
                SortIndex = GetSortIndex(_intro.Control),
                Tip = GetTip(_intro.Control),
                RelativeLocationToForm = _intro.Control.LocationRelativeToForm()
            };
            if (IsTarget(tipEvent.MouseLocation))
            {
                tipEvent.IsTarget = true;
                this.TargetClicked?.Invoke(this, tipEvent);
            }
            this.Clicked?.Invoke(this, tipEvent);
            if (_isShowAll)
            {
                if (this.NextTrigger == IntroTipTrigger.BothClick)
                {
                    ShowNext();

                }
                else if (this.NextTrigger == IntroTipTrigger.TargetClick)
                {
                    if (tipEvent.IsTarget)
                    {
                        ShowNext();
                    }
                }
                else if (this.NextTrigger == IntroTipTrigger.NonTargetClick)
                {
                    if (!tipEvent.IsTarget)
                    {
                        ShowNext();
                    }
                }
            }
        }

        private void _intro_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isTriggable(e.Button)) return;
            if (_intro == null || _intro.ParentForm == null) return;
            IntroTipClickEventArgs tipEvent = new IntroTipClickEventArgs()
            {
                MouseButtons = e.Button,
                MouseLocation = e.Location,
                Location = _intro.Control.Location,
                TargetControl = _intro.Control,
                SortIndex = GetSortIndex(_intro.Control),
                Tip = GetTip(_intro.Control),
                RelativeLocationToForm = _intro.Control.LocationRelativeToForm()
            };

            if (IsTarget(tipEvent.MouseLocation))
            {
                tipEvent.IsTarget = true;
                this.TargetClicking?.Invoke(this, tipEvent);
            }
            this.Clicking?.Invoke(this, tipEvent);
        }

        private void _intro_MouseLeave(object sender, EventArgs e)
        {
            if (_intro == null || _intro.ParentForm == null) return;
            IntroTipHoverEventArgs tipEvent = new IntroTipHoverEventArgs()
            {
                MouseLocation = _intro.MouseLocation(),
                Location = _intro.Control.Location,
                TargetControl = _intro.Control,
                SortIndex = GetSortIndex(_intro.Control),
                Tip = GetTip(_intro.Control),
                RelativeLocationToForm = _intro.Control.LocationRelativeToForm()
            };

            if (IsTarget(tipEvent.MouseLocation))
            {
                tipEvent.IsTarget = true;
                this.TargetLeaveHover?.Invoke(this, tipEvent);
            }

            this.LeaveHover?.Invoke(this, tipEvent);
        }

        private void _intro_MouseEnter(object sender, EventArgs e)
        {
            if (_intro == null || _intro.ParentForm == null) return;
            IntroTipHoverEventArgs tipEvent = new IntroTipHoverEventArgs()
            {
                MouseLocation = _intro.MouseLocation(),
                Location = _intro.Control.Location,
                TargetControl = _intro.Control,
                SortIndex = GetSortIndex(_intro.Control),
                Tip = GetTip(_intro.Control),
                RelativeLocationToForm = _intro.Control.LocationRelativeToForm()
            };

            if (IsTarget(tipEvent.MouseLocation))
            {
                tipEvent.IsTarget = true;
                this.TargetHover?.Invoke(this, tipEvent);
                _intro.Cursor = this.TargetCursor;
            }
            else
            {
                _intro.Cursor = this.Cursor;
            }
            this.Hover?.Invoke(this, tipEvent);
        }

        private bool isTriggable(MouseButtons e)
        {
            bool ret = false;
            if (this.MouseClicks == SaaMouseClicks.AnyClick)
            {
                ret = true;
            }
            else if (this.MouseClicks == SaaMouseClicks.LeftClick)
            {
                if (e == MouseButtons.Left)
                {
                    ret = true;
                }
            }
            else if (this.MouseClicks == SaaMouseClicks.RightClick)
            {
                if (e == MouseButtons.Right)
                {
                    ret = true;
                }
            }
            else if (this.MouseClicks == SaaMouseClicks.NoClick)
            {
                ret = false;
            }

            return ret;
        }
        Dictionary<Control, introTipHolder> _controls = new Dictionary<Control, introTipHolder>();
        public bool CanExtend(object extendee)
        {
            return !(extendee == null || extendee.GetType() == typeof(Form) || extendee is SaaIntroTipControl);
        }

        /// <summary>
        /// Gets the tip text of a control
        /// </summary>
        /// <param name="control">target control</param>
        /// <returns>returns tip text</returns>
        [Description("Gets or Sets tip text associated with this control. Leave empty if you don't want tip for this control")]
        [Category("SaaIntroTip")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string GetTip(Control control)
        {
            string _s = "";
            if (_controls.ContainsKey(control))
            {
                _s = _controls[control].Tip;
            }
            return _s;
        }


        /// <summary>
        /// Sets introtip to control. The <paramref name="SortIndex"/> will be 0.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tip"></param>
        [Description("Gets or Sets tip text associated with this control. Leave empty if you don't want tip for this control")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("SaaIntroTip")]
        public void SetTip(Control control, string tip)
        {
            if (control.GetType() == typeof(Form) || control is SaaIntroTipControl) return;
            if (control == null) return;
            if (!_controls.ContainsKey(control))
            {
                introTipHolder intr = new introTipHolder()
                {
                    Tip = tip,
                    Control = control
                };
                _controls.Add(control, intr);
            }
            else
            {
                _controls[control].Tip = tip;
            }
        }

        /// <summary>
        /// Sets introtip to control with The <paramref name="SortIndex"/> specified.
        /// </summary>
        /// <param name="control">Target control</param>
        /// <param name="tip">Tip text</param>
        /// <param name="SortIndex">Position of the control in the introtip</param>
        public void SetTip(Control control, string tip, int SortIndex)
        {
            if (control.GetType() == typeof(Form) || control is SaaIntroTipControl) return;
            if (control == null) return;
            if (!_controls.ContainsKey(control))
            {
                introTipHolder intr = new introTipHolder()
                {
                    Tip = tip,
                    Control = control,
                    SortIndex = SortIndex
                };
                _controls.Add(control, intr);
            }
            else
            {
                _controls[control].Tip = tip;
                _controls[control].SortIndex = SortIndex;
            }
        }

        /// <summary>
        /// Sets control to the specified SortIndex in the introtip.
        /// </summary>
        /// <param name="control">t=Target control</param>
        /// <param name="sortIndex">Position of the control in the introtip.</param>
        [Description("Sets or Sets SortIndex of the control in the introtip. It is the position of the control in the introtip.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("SaaIntroTip")]
        public void SetSortIndex(Control control, int sortIndex)
        {
            if (control == null) return;
            if (_controls.ContainsKey(control))
            {
                _controls[control].SortIndex = sortIndex;
            }
            else
            {
                SetTip(control, "", sortIndex);
            }

        }

        /// <summary>
        /// Gets the SortIndex of the specified control in the introtip.
        /// </summary>
        /// <param name="control">Target Control</param>
        /// <returns>returns the SortIndex.</returns>
        [Description("Sets or Sets SortIndex of the control in the introtip. It is the position of the control in the introtip.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("SaaIntroTip")]
        public int GetSortIndex(Control control)
        {
            if (_controls.ContainsKey(control)) return _controls[control].SortIndex; else return 0;
        }

        /// <summary>
        /// Indicates whether the specified point is the location of the target control.
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <param name="includeOffset">If the target offset will also be recognized as the target point.</param>
        /// <returns>true if the specified point is the target, otherwise false</returns>
        public bool IsTarget(Point point, bool includeOffset = false)
        {
            return _intro.IsTarget(point, includeOffset);
        }
        /// <summary>
        /// Indicates whether the specified point is the location of the target control.
        /// </summary>
        /// <param name="x">point X</param>
        /// <param name="y">Point Y</param>
        /// <param name="includeOffset">If the target offset will also be recognized as the target point.</param>
        /// <returns>true if the specified point is the target, otherwise false</returns>
        public bool IsTarget(int x, int y, bool includeOffset = false)
        {
            return _intro.IsTarget(x, y, includeOffset);
        }

        /// <summary>
        /// Shows the introtip on the specified control.
        /// </summary>
        /// <param name="target">Target control</param>
        /// <param name="tip">Text to display.</param>
        public void Show(Control target, string tip)
        {
            if (target == null) return;
            Delete();
            Display(target, tip);
        }
        IEnumerable<KeyValuePair<Control, introTipHolder>> _sorted;
        int _currentIndex = 0;
        bool _isShowAll = false;

        /// <summary>
        /// Starts displaying introtip for all controls that has tip text set. It will start from the lowest SortIndex.
        /// </summary>
        public void ShowAll()
        {
            _sorted = _controls.OrderByDescending(x => x.Value.SortIndex).Reverse();
            _isShowAll = true;
            _currentIndex = 0;
            ShowNext();
        }

        /// <summary>
        /// Starts displaying introtip for all controls that has tip text set, starting from the specified SortIndex and going up. If the SortIndex doesn't exist, nothing will be displayed.
        /// </summary>
        /// <param name="fromSortIndex">SortIndex to start from. If the SortIndex doesn't exist, nothing will be displayed.</param>
        public void ShowAll(int fromSortIndex)
        {
            _sorted = _controls.OrderByDescending(x => x.Value.SortIndex).Reverse();
            var ind = getIndex(fromSortIndex);
            if (ind != null)
            {

                _isShowAll = true;
                _currentIndex = ind.Value;
                ShowNext();
            }
        }

        /// <summary>
        /// Jumps to the next control if there is introtip going on or was going on but dismissed with <see cref="Hide()"/>.
        /// </summary>
        public void ShowNext()
        {
            Delete();
            if (_sorted != null && _sorted.Count() > 0 && _sorted.Count() > _currentIndex && _currentIndex > -1)
            {

                var _targ = _sorted.ElementAt(_currentIndex);
                var _control = _targ.Key;
                if (_control != null && !string.IsNullOrEmpty(_targ.Value.Tip) && _control.TopLevelControl != null)
                {

                    Display(_control, _targ.Value.Tip);
                    _currentIndex++;
                }
                else
                {
                    _currentIndex++;
                    ShowNext();
                }
            }
            else
            {
                Hide(true);
            }
        }
        private int? getIndex(int sortindex)
        {
            int? r = null;
            for (int i = 0; i < _sorted.Count(); i++)
            {
                var k = _sorted.ElementAt(i).Key;
                var ind = _sorted.ElementAt(i).Value.SortIndex;
                if (k != null && ind == sortindex)
                {
                    r = i;
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// Dismisses and suspends the introtip. You can continue with <see cref="ShowNext()"/>.
        /// </summary>
        public void Hide()
        {
            Delete();
        }

        /// <summary>
        /// Dismisses and resets the introtip.
        /// </summary>
        /// <param name="reset">Whether to reset the introtip. if true, then <see cref="ShowNext()"/> will not work.</param>
        public void Hide(bool reset)
        {
            Delete();
            if (reset)
            {
                _currentIndex = 0;
                _sorted = null;
                _isShowAll = false;
                _intro.Control = null;
            }
        }
        Control _currControl = null;

        /// <summary>
        /// Gets the current control the introtip is showing the user.
        /// </summary>
        [Browsable(false)]
        public Control CurrentControl
        {
            get
            {
                return _intro.Control;
            }
        }
        private void Display(Control target, string text)
        {
            if (target.GetType() == typeof(Form) || target is SaaIntroTipControl) return;
            if (target == null) return;
            var F = target.FindForm();
            if (F == null) return;

            _intro.Control = target;
            _intro.Value = text;
            _intro.Size = F.Size;
            _intro.Location = new Point(0, 0);
            if (!F.Controls.Contains(_intro))
            {
                F.Controls.Add(_intro);
            }
        }
        private void Delete()
        {
            var f = _intro.FindForm();
            if (f == null) return;
            if (f.Controls.Contains(_intro))
            {
                f.Controls.Remove(_intro);
            }
        }

        /// <summary>
        /// Indicates whether there is suspended introtip that was going on and can be resumed using <see cref="ShowNext()"/>. 
        /// </summary>
        [Browsable(false)]
        public bool CanResume { get { return _isShowAll; } }

        /// <summary>
        /// Gets or Sets if ShowNext() is triggered when target or/and the introtip is clicked.
        /// </summary>
        [Description("Gets or Sets if ShowNext() is triggered when target or/and the introtip is clicked."), Category("Saa")]
        public IntroTipTrigger NextTrigger { get; set; } = IntroTipTrigger.BothClick;
        /// <summary>
        /// Gets or Sets which mouse clicks does the introtip accept.
        /// </summary>
        [Description("Gets or Sets which mouse clicks does the introtip accept."), Category("Saa")]
        public SaaMouseClicks MouseClicks { get; set; } = SaaMouseClicks.LeftClick;
        /// <summary>
        /// Gets or Sets cursor of the target region.
        /// </summary>
        [Description("Gets or Sets cursor of the target region."), Category("Saa")]
        public Cursor TargetCursor { get; set; } = Cursors.Hand;
        /// <summary>
        /// Gets or Sets cursor of the introtip.
        /// </summary>
        [Description("Gets or Sets cursor of the introtip"), Category("Saa")]
        public Cursor Cursor { get; set; } = Cursors.Default;
        /// <summary>
        /// Gets or Sets text offset of the introtip.
        /// </summary>
        [Description("Gets or Sets text offset of the introtip."), Category("Saa")]
        public Point TextOffset
        {
            get
            {
                return _intro.TextOffset;
            }
            set
            {
                _intro.TextOffset = value;
            }
        }

        /// <summary>
        /// Gets or Sets the width or the thickness of the arrow.
        /// </summary>
        [Description("Gets or Sets the width or the thickness of the arrow."), Category("Saa")]
        public float ArrowThickness
        {
            get
            {
                return _intro.ArrowThickness;
            }
            set
            {
                _intro.ArrowThickness = value;
            }
        }

        /// <summary>
        /// Gets or Sets arrow color.
        /// </summary>
        [Description("Gets or Sets arrow color."), Category("Saa")]
        public Color ArrowColor
        {
            get
            {
                return _intro.ArrowColor;
            }
            set
            {
                _intro.ArrowColor = value;
            }
        }
        /// <summary>
        /// Gets or Sets the height of the arrow.
        /// </summary>
        [Description("Gets or Sets the height of the arrow."), Category("Saa")]
        public int ArrowHeight
        {
            get
            {
                return _intro.ArrowHeight;
            }
            set
            {
                _intro.ArrowHeight = value;
            }
        }

        /// <summary>
        /// Gets or Sets how much the arrow should bend.
        /// </summary>
        [Description("Gets or Sets how much the arrow should bend."), Category("Saa")]
        public int ArrowBend
        {
            get
            {
                return _intro.ArrowBend;
            }
            set
            {
                _intro.ArrowBend = value;
            }
        }

        /// <summary>
        /// Gets or Sets arrow offset.
        /// </summary>
        [Description("Gets or Sets arrow offset."), Category("Saa")]
        public Point ArrowOffset
        {
            get
            {
                return _intro.ArrowOffset;
            }
            set
            {
                _intro.ArrowOffset = value;
            }
        }

        /// <summary>
        /// Gets or Sets arrow head style.
        /// </summary>
        [Description("Gets or Sets arrow head style."), Category("Saa")]
        public LineCap ArrowHeadStyle
        {
            get
            {
                return _intro.ArrowHeadStyle;
            }
            set
            {
                _intro.ArrowHeadStyle = value;
            }
        }

        /// <summary>
        /// Gets or Sets arrow tail style.
        /// </summary>
        [Description("Gets or Sets arrow tail style."), Category("Saa")]
        public LineCap ArrowTailStyle
        {
            get
            {
                return _intro.ArrowTailStyle;
            }
            set
            {
                _intro.ArrowTailStyle = value;
            }
        }

        /// <summary>
        /// Gets or Sets arrow line style.
        /// </summary>
        [Description("Gets or Sets arrow line style."), Category("Saa")]
        public DashStyle ArrowLineStyle
        {
            get
            {
                return _intro.ArrowLineStyle;
            }
            set
            {
                _intro.ArrowLineStyle = value;
            }
        }

        /// <summary>
        /// Gets or Sets background color of the target region.
        /// </summary>
        [Description("Gets or Sets background color of the target region."), Category("Saa")]
        public Color TargetBackColor
        {
            get
            {
                return _intro.RegionColor;
            }
            set
            {
                _intro.RegionColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets extra height or width to be added to the target region.
        /// </summary>
        [Description("Gets or Sets extra height or width to be added to the target region."), Category("Saa")]
        public Padding TargetOffSet
        {
            get
            {
                return _intro.RegionOffSet;
            }
            set
            {

                _intro.RegionOffSet = value;

            }
        }

        /// <summary>
        /// Gets or Sets position of the arrow and text on the introtip.
        /// </summary>
        [Description("Gets or Sets position of the arrow and text on the introtip."), Category("Saa")]
        public SaaIntroTipPosition Position
        {
            get
            {
                return _intro.Position;
            }
            set
            {
                _intro.Position = value;
            }
        }

        /// <summary>
        /// Gets or Sets transparency of the introtip.
        /// </summary>
        [Description("Gets or Sets transparency of the introtip."), Category("Saa")]
        public int Transparency
        {
            get { return _intro.Transparency; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _intro.Transparency = value;
                }
                else
                {
                    throw new Exception("Value must be betweem 0 and 100");
                }
            }
        }


        /// <summary>
        /// Gets or Sets the radius of the target region.
        /// </summary>
        [Description("Gets or Sets the radius of the target region."), Category("Saa")]
        public Radius Radius
        {
            get
            {
                return _intro.Radius;
            }
            set
            {
                _intro.Radius = value;
            }
        }

        /// <summary>
        /// Gets or Sets target region border thickness. '0' means no border.
        /// </summary>
        [Description("Gets or Sets target region border thickness. '0' means no border."), Category("Saa")]
        public int Border
        {
            get
            {
                return _intro.Border;
            }
            set
            {
                _intro.Border = value;
            }
        }

        /// <summary>
        /// Gets or Sets target region border color.
        /// </summary>
        [Description("Gets or Sets target region border color."), Category("Saa")]
        public Color BorderColor
        {
            get
            {
                return _intro.BorderColor;
            }
            set
            {
                _intro.BorderColor = value;
            }
        }
        /// <summary>
        /// Gets or Sets target region border style.
        /// </summary>
        [Description("Gets or Sets target region border style."), Category("Saa")]
        public DashStyle BorderStyle
        {
            get
            {
                return _intro.BorderStyle;
            }
            set
            {
                _intro.BorderStyle = value;
            }
        }

        /// <summary>
        /// Gets or Sets background color of the introtip.
        /// </summary>
        [Description("Gets or Sets background color of the introtip."), Category("Saa")]
        public Color BackColor
        {
            get
            {
                return _intro.BackColor;
            }
            set
            {
                _intro.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets introtip font.
        /// </summary>
        [Description("Gets or Sets introtip font."), Category("Saa")]
        public Font Font
        {
            get
            {
                return _intro.Font;
            }
            set
            {
                _intro.Font = value;
            }
        }

        /// <summary>
        /// Gets or Sets color of the text.
        /// </summary>
        [Description("Gets or Sets color of the text."), Category("Saa")]
        public Color TextColor
        {
            get
            {
                return _intro.ForeColor;
            }
            set
            {
                _intro.ForeColor = value;
            }
        }

    }
    internal class introTipHolder
    {
        public Control Control { get; set; }
        public string Tip { get; set; }
        public int SortIndex { get; set; } = 0;
    }
    public class IntroTipClickEventArgs : EventArgs
    {
        /// <summary>
        /// Target control that is associated with the current introtip firing this event.
        /// </summary>
        public object TargetControl { get; set; }
        /// <summary>
        /// Tip text of the target control that is associated with the current introtip firing this event.
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// SortIndex of the target control that is associated with the current introtip firing this event.
        /// </summary>
        public int SortIndex { get; set; }
        /// <summary>
        /// Mouse button that is clicked
        /// </summary>
        public MouseButtons MouseButtons { get; set; }
        /// <summary>
        /// Location of the target control relative to the main form.
        /// </summary>
        public Point RelativeLocationToForm { get; set; }
        /// <summary>
        /// Location of the target control relative to its parent container.
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Location of the mouse pointer on the target control.
        /// </summary>
        public Point MouseLocation { get; set; }
        /// <summary>
        /// Indicates whether the location clicked is the location of the target control.
        /// </summary>
        public bool IsTarget { get; set; } = false;
    }
    public class IntroTipHoverEventArgs : EventArgs
    {
        /// <summary>
        /// Location of the mouse pointer on the target control.
        /// </summary>
        public Point MouseLocation { get; set; }
        /// <summary>
        /// Target control that is associated with the current introtip firing this event.
        /// </summary>
        public object TargetControl { get; set; }
        /// <summary>
        /// Tip text of the target control that is associated with the current introtip firing this event.
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// SortIndex of the target control that is associated with the current introtip firing this event.
        /// </summary>
        public int SortIndex { get; set; }
        /// <summary>
        /// Location of the target control relative to the main form.
        /// </summary>
        public Point RelativeLocationToForm { get; set; }
        /// <summary>
        /// Location of the target control relative to its parent container.
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Indicates whether the location clicked is the location of the target control.
        /// </summary>
        public bool IsTarget { get; set; } = false;
    }
}
