using UnityEngine;
namespace SimpleTweening
{
    public class ColorTween : BaseTween
    {
        [System.Serializable]
        public class UnityEvent_Color : UnityEngine.Events.UnityEvent<Color> { }
        [SerializeField]
        protected UnityEvent_Color onSetValueEvent;
#pragma warning disable
        [SerializeField]
        Gradient gradient;
#pragma warning restore

        protected override void OnSetValue(float t)
        {
            onSetValueEvent.Invoke(gradient.Evaluate(t));
        }
    }
}
