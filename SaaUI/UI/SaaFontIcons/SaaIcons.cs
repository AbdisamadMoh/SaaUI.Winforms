using SaaUI.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace SaaUI.UI.SaaFontIcons
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    [ToolboxBitmap(typeof(SaaIcons), "icons.SaaIntroTip.bmp")]
    [ProvideProperty("Icon", typeof(Control))]
    [ProvideProperty("Target", typeof(Control))]
    internal class SaaIcons : Component, IExtenderProvider
    {

        Dictionary<Control, string> _targetFont = new Dictionary<Control, string>();
        Dictionary<Control, string> _targetNames = new Dictionary<Control, string>();
        public SaaIcons()
        {

        }
        public bool CanExtend(object extendee)
        {
            return ((extendee != null) && extendee is Control && !(extendee is Form));
        }

        public void SetIcon(Control contr, string fontName)
        {
            if (!this.CanExtend(contr)) return;
            addToLIst(contr, fontName, "_");
            renderIcon(contr);
        }
        public string GetIcon(Control contr)
        {
            return _targetFont.ContainsKey(contr) ? _targetFont[contr] : "";
        }
        public string GetTarget(Control contr)
        {
            return _targetNames.ContainsKey(contr) ? _targetNames[contr] : "";
        }
        public void SetTarget(Control contr, string TargetImageProperty)
        {
            if (!this.CanExtend(contr)) return;
            addToLIst(contr, "_", TargetImageProperty);
            renderIcon(contr);
        }
        private void renderIcon(Control c)
        {
            if (_targetNames.ContainsKey(c) && _targetFont.ContainsKey(c))
            {
                var name = _targetNames[c];
                var font = _targetFont[c];
                if (name != "" && font != "")
                {
                    c.SetProperty(name, Resources.icons8_Multiply_32);
                }
                else if (font == "none" && name != null)
                {

                    c.SetProperty(name, null);
                }
            }
        }
        private void addToLIst(Control contr, string fontName = "_", string name = "_")
        {
            if (_targetNames.ContainsKey(contr))
            {
                _targetNames[contr] = name != "_" ? name : _targetNames[contr];
            }
            else
            {
                _targetNames.Add(contr, name != "_" ? name : "");
            }

            if (_targetFont.ContainsKey(contr))
            {
                _targetFont[contr] = fontName != "_" ? fontName : _targetFont[contr];
            }
            else
            {
                _targetFont.Add(contr, fontName != "_" ? fontName : "");
            }
        }
    }
}
