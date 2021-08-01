using Umph.Core;
using UnityEngine;
using DG.Tweening;

namespace Umph.DOTween
{

    public abstract class DOTweenComponentEffect<T_Target, T_Value> : UmphComponentEffect where T_Target : Component
    {
#if UNITY_EDITOR
        public override void EDITOR_Initialize(GameObject ownerObject) 
        {
            Target = ownerObject.GetComponentInChildren<T_Target>();
        }
#endif

        [Header("Properties")]
        public int Loops = 1;
        public LoopType LoopType = LoopType.Incremental;

        public bool IsRelative = false;

        [Header("Ease")]
        public DOTweenEase Ease = DOTweenEase.Linear;

        [ShowIf("Ease", DOTweenEase.InElastic, DOTweenEase.OutElastic, DOTweenEase.InOutElastic, DOTweenEase.InBack, DOTweenEase.InOutBack, DOTweenEase.OutBack)]
        public float Amplitude = 1.70158f;

        [ShowIf("Ease", DOTweenEase.Flash)]
        public float FlashCount = 1f;

        [ShowIf("Ease", DOTweenEase.InElastic, DOTweenEase.OutElastic, DOTweenEase.InOutElastic)]
        public float Period = 0f;

        [ShowIf("Ease", DOTweenEase.CustomCurve)]
        public AnimationCurve Curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Values")]
        public T_Target Target;
        public float Duration = 1f;
        public T_Value EndValue;

        public Tween ConstructTween()
        {
            var tween = GetBaseTween();

            tween.SetLoops(Loops, LoopType);
            tween.SetRelative(IsRelative);

            if (Ease == DOTweenEase.Flash)
            {
                tween.SetEase(Ease.ToDOEase(), FlashCount);
            }
            else if (Ease == DOTweenEase.InElastic || Ease == DOTweenEase.OutElastic || Ease == DOTweenEase.InOutElastic)
            {
                tween.SetEase(Ease.ToDOEase(), Amplitude, Period);
            }
            else if (Ease == DOTweenEase.InBack || Ease == DOTweenEase.OutBack || Ease == DOTweenEase.InOutBack)
            {
                tween.SetEase(Ease.ToDOEase(), Amplitude);
            }
            else if (Ease == DOTweenEase.CustomCurve)
            {
                tween.SetEase(Curve);
            }
            else
            {
                tween.SetEase(Ease.ToDOEase());
            }

            return tween;
        }

        public override IEffect ConstructEffect()
        {
            return new DOTweenEffect(ConstructTween());
        }

        protected abstract Tween GetBaseTween();
    }
}
