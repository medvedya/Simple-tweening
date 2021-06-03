using UnityEngine;
namespace SimpleTweening
{
    public class Vector3Tween : BaseTween
    {
        [System.Serializable]
        public class UnityEvent_Vector3 : UnityEngine.Events.UnityEvent<Vector3>
        {
        }
#pragma warning disable
        [SerializeField]
        UnityEvent_Vector3 onSetValueEvent;
        [SerializeField]
        bool setToLocalPosition, setToLocalScale;
        [SerializeField]
        Vector3 startValue, endValue;
#pragma warning restore

        protected override void OnSetValue(float t)
        {
            var value = Vector3.LerpUnclamped(startValue, endValue, t);
            onSetValueEvent.Invoke(value);
            if (setToLocalPosition)
            {
                this.transform.localPosition = value;
            }
            if (setToLocalScale)
            {
                this.transform.localScale = value;
            }
        }
        [ContextMenu("Record start local position")]
        private void RecordStartPosition()
        {
            startValue = transform.localPosition;
        }
        [ContextMenu("Record end local position")]
        private void RecordEndPosition()
        {
            endValue = transform.localPosition;
        }
        [ContextMenu("Move to start local position")]
        private void MoveToStartPosition()
        {
            this.transform.localPosition = startValue;
        }
        [ContextMenu("Move to end local position")]
        private void MoveToEndPosition()
        {
            this.transform.localPosition = endValue;

        }

    }
}
