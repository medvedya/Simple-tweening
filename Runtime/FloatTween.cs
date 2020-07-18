using UnityEngine;
namespace SimpleTweening
{
    public class FloatTween : BaseTween
    {
        [System.Serializable]
        public class UnityEvent_float : UnityEngine.Events.UnityEvent<float>
        {
        }
        [SerializeField]
        protected UnityEvent_float onSetValueEvent;
#pragma warning disable
        [SerializeField]
        BaseTween[] otherTweensToSetValue;
#pragma warning restore
        [SerializeField]
        float startValue = 0, endValue = 1;

        protected override void OnSetValue(float t)
        {
            onSetValueEvent.Invoke(Mathf.Lerp(startValue, endValue, t));
            if (otherTweensToSetValue != null)
            {
                foreach (var item in otherTweensToSetValue)
                {
                    if (item != null)
                    {
                        item.SetValue(t);
                    }
                }
            }
        }
    }
}
