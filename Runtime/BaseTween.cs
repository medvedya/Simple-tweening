using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleTweening
{
    public enum AssociationMode { AnimationCurve, Liner, ArcSmooth, SineSmooth }
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
                case AssociationMode.ArcSmooth:
                    if (t < 0.5f)
                    {
                        //newPos.y = Mathf.Cos(Mathf.Asin(t * 2f)) / 2f * -1f + 0.5f;
                        //simplify https://www.wolframalpha.com/input/?i=simplefy+y+%3D+Cos%28Asin%28x+*+2%29%29+%2F+2+*+-1+%2B+0.5
                        t = -0.5f * (Mathf.Sqrt(1f - 4f * t * t) - 1f);
                    }
                    else
                    {
                        //newPos.y = Mathf.Cos(Mathf.Asin(1f - ((t - 0.5f) * 2f))) / 2f + 0.5f;
                        //simplify https://www.wolframalpha.com/input/?i=simplefy+y+%3D+Cos%28Asin%281+-+%28%28t+-+0.5%29+*+2%29%29%29+%2F+2+%2B+0.5
                        t = 0.5f * Mathf.Sqrt(-4f * t * t + 8f * t - 3f) + 0.5f;
                    }
                    break;
                case AssociationMode.SineSmooth:
                    t = (Mathf.Sin((t - 0.5f) * Mathf.PI) + 1f) / 2f;
                    break;
                default:
                    break;
            }
            OnSetValue(outputValueStart + t * outputValueLength);
        }
        protected abstract void OnSetValue(float t);
    }
   
}
