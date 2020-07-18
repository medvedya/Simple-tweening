using UnityEngine;
namespace SimpleTweening.Animators
{
    public class TargetTweenAnimator : BaseTweenAnimator
    {
        [SerializeField]
        float speed = 1, currentValue = 0, targetValue = 0;
        public float TargerValue
        {
            set
            {
                targetValue = value;
            }
            get
            {
                return targetValue;
            }
        }
        public override void UpdateAnimator(float dt)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, dt * speed);
            this.SetValue(currentValue);
        }
    }
}
