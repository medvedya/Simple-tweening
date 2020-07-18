using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleTweening
{
    public enum AssociationMode { AnimationCurve, Liner }
    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField]
        AssociationMode outputAssociation = AssociationMode.Liner;
#pragma warning disable
        [SerializeField]
        AnimationCurve outputAnimationCurve;
#pragma warning restore
        [SerializeField]
        float inputValueStart = 0, inputValueLength = 1, outputValueStart = 0, outputValueLength = 1;  
        public void SetValue(float t)
        {
            t = Mathf.Clamp01((t - inputValueStart) / inputValueLength);
            switch (outputAssociation)
            {
                case AssociationMode.AnimationCurve:
                    t = outputAnimationCurve.Evaluate(t);
                    break;
                case AssociationMode.Liner:
                    break;
                default:
                    break;
            }
            OnSetValue(outputValueStart + t * outputValueLength);
        }
        protected abstract void OnSetValue(float t);
    }
   
}
