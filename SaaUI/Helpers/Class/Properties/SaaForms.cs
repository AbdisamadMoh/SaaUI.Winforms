using System;
using System.ComponentModel;
using System.Drawing;

namespace SaaUI.Properties
{
    [TypeConverter(typeof(SaaRadiusObjectConverter))]
    public class SaaWidnows10HeaderProperties
    {
        public SaaWidnows10HeaderProperties()
        {

        }

        public delegate void OnChange();
        public event OnChange Change;


        int _TopRight = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public int TopRight
        {
            get
            {
                return _TopRight;
            }
            set
            {
                if (value > -1)
                {
                    _TopRight = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }



    }

    public class HeaderClose
    {
        public HeaderClose()
        {
            Radius.Change += Radius_Change;
        }

        private void Radius_Change()
        {
            Change?.Invoke();
        }

        public delegate void OnChange();
        public event OnChange Change;


        Radius _Radius = new Radius();
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                Change?.Invoke();

            }
        }

        Color _BackColor = Color.Transparent;
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
                Change?.Invoke();
            }
        }

        Color _HoverBackColor = Color.Transparent;
        public Color HoverBackColor
        {
            get
            {
                return _HoverBackColor;
            }
            set
            {
                _HoverBackColor = value;
                Change?.Invoke();
            }
        }

        Color _ClickBackColor = Color.Transparent;
        public Color ClickBackColor
        {
            get
            {
                return _ClickBackColor;
            }
            set
            {
                _ClickBackColor = value;
                Change?.Invoke();
            }
        }

        Image _Image = Resources.X_16;
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                Change?.Invoke();
            }
        }

        Image _HoverImage = Resources.X_16;
        public Image HoverImage
        {
            get
            {
                return _HoverImage;
            }
            set
            {
                _HoverImage = value;
                Change?.Invoke();
            }
        }

        Image _ClickImage = Resources.X_16;
        public Image ClickImage
        {
            get
            {
                return _ClickImage;
            }
            set
            {
                _ClickImage = value;
                Change?.Invoke();
            }
        }

        bool _Visible = true;
        public bool Visible
        {
            get
            {
                return _Visible;
            }
            set
            {
                _Visible = value;
                Change?.Invoke();
            }
        }


    }
}
