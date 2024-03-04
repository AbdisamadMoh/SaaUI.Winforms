using System;
using System.ComponentModel;

namespace SaaUI.Properties
{

    [TypeConverter(typeof(SaaRadiusObjectConverter))]
    public class Radius
    {
        public Radius()
        {

        }
        public Radius(int topLeft, int topRight, int bottomLeft, int bottomRight)
        {
            if (topLeft > -1) TopLeft = topLeft;
            if (topRight > -1) TopRight = topRight;
            if (bottomLeft > -1) BottomLeft = bottomLeft;
            if (bottomRight > -1) BottomRight = bottomRight;
        }
        public delegate void OnChange();
        public event OnChange Change;
        int _TopLeft = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0), RefreshProperties(RefreshProperties.Repaint)]
        public int TopLeft
        {
            get
            {
                return _TopLeft;
            }
            set
            {
                if (value > -1)
                {
                    _TopLeft = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }

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



        int _BottomRight = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public int BottomRight
        {
            get
            {
                return _BottomRight;
            }
            set
            {
                if (value > -1)
                {
                    _BottomRight = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }

        int _BottomLeft = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public int BottomLeft
        {
            get
            {
                return _BottomLeft;
            }
            set
            {
                if (value > -1)
                {
                    _BottomLeft = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }
    }
    [TypeConverter(typeof(SaaRadiusObjectConverter))]
    public class RadiusF
    {
        public RadiusF()
        {

        }
        public RadiusF(float topLeft, float topRight, float bottomLeft, float bottomRight)
        {
            if (topLeft > -1) TopLeft = topLeft;
            if (topRight > -1) TopRight = topRight;
            if (bottomLeft > -1) BottomLeft = bottomLeft;
            if (bottomRight > -1) BottomRight = bottomRight;
        }
        public delegate void OnChange();
        public event OnChange Change;
        float _TopLeft = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0), RefreshProperties(RefreshProperties.Repaint)]
        public float TopLeft
        {
            get
            {
                return _TopLeft;
            }
            set
            {
                if (value > -1)
                {
                    _TopLeft = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }

        float _TopRight = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public float TopRight
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



        float _BottomRight = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public float BottomRight
        {
            get
            {
                return _BottomRight;
            }
            set
            {
                if (value > -1)
                {
                    _BottomRight = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }

        float _BottomLeft = 0;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0)]
        public float BottomLeft
        {
            get
            {
                return _BottomLeft;
            }
            set
            {
                if (value > -1)
                {
                    _BottomLeft = value;
                    Change?.Invoke();
                }
                else
                {
                    throw new Exception("Value must be greater than -1");
                }
            }
        }
    }
}
