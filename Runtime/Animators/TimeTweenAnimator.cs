using UnityEngine;
namespace SimpleTweening.Animators
{
    public class TimeTweenAnimator : BaseTweenAnimator
    {
        enum FloatWrapMode {Clamp,Loop, PingPong }
        [SerializeField]
        FloatWrapMode wrapMode = FloatWrapMode.Loop;
        [SerializeField]
        public float time;
        [SerializeField]
        private float duration = 1;

        public override void UpdateAnimator(float dt)
        {
            time += dt;
            float useTime = 0;
            switch (wrapMode)
            {
                case FloatWrapMode.Clamp:
                    useTime = Mathf.Clamp(time, 0f, duration);
                    break;
                case FloatWrapMode.Loop:
                    useTime = Mathf.Repeat(time, duration);
                    break;
                case FloatWrapMode.PingPong:
                    useTime = Mathf.PingPong(time, duration);
                    break;
                default:
                    break;
            }
            SetValue(useTime / duration);
        }
    }
}
