using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace SaaUI
{
    [ToolboxItem(true)]
  public  class SaaHtml : SaaHtmlPanel
    {
        /// <summary>
        /// Gets or Sets text of this control including html.
        /// </summary>
        [Editor(typeof(Using.SaaSaaHtmlEditor), typeof(UITypeEditor))]
        [Description("Gets or Sets text of this control including html.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }
    }
}
