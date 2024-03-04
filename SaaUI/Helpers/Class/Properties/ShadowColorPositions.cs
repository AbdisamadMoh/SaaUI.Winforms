using System.ComponentModel;

namespace SaaUI.Properties
{
    /*--------------------------Separator---------------------------*/


    [TypeConverter(typeof(SaaShadowColorConverter))]
    public class ShadowColorPositions
    {
        public ShadowColorPositions()
        {

        }
        public ShadowColorPositions(float outerColor, float middleColor, float innerColor)
        {
            OuterColor = outerColor;
            MiddleColor = middleColor;
            InnerColor = innerColor;
        }
        public delegate void OnChange();
        public event OnChange Change;
        float _OuterColor = 0f;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(0f)]
        public float OuterColor
        {
            get
            {
                return _OuterColor;
            }
            set
            {
                if (value <= 1 || value >= 0)
                {
                    _OuterColor = value;
                    Change?.Invoke();
                }
            }
        }

        float _MiddleColor = .1f;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(.1f)]
        public float MiddleColor
        {
            get
            {
                return _MiddleColor;
            }
            set
            {
                if (value <= 1 || value >= 0)
                {
                    _MiddleColor = value;
                    Change?.Invoke();
                }
            }
        }

        float _InnerColor = 1f;
        [Browsable(true), NotifyParentProperty(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(1f)]
        public float InnerColor
        {
            get
            {
                return _InnerColor;
            }
            set
            {
                if (value <= 1 || value >= 0)
                {
                    _InnerColor = value;
                    Change?.Invoke();
                }
            }
        }
    }
}
