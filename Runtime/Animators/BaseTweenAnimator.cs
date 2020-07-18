using UnityEngine;
namespace SimpleTweening.Animators
{
    public abstract class BaseTweenAnimator : FloatTween
    {
        private void Update()
        {
            UpdateAnimator(Time.deltaTime);
        }

        public abstract void UpdateAnimator(float dt);
    }
}
