using Umph.Core;
using UnityEngine;
using DG.Tweening;
using System;

namespace Umph.DOTween
{
    public abstract class DOTweenComponentEffect<T_Target, T_Value> : UmphComponentEffect where T_Target : Component
    {
        [System.Serializable]
        public class LoopSettings
        {
            public int LoopCount = 1;
            public LoopType LoopType = LoopType.Incremental;

            internal void ApplyTo(Tween tween)
            {
                tween.SetLoops(LoopCount, LoopType);
            }
        }

        [System.Serializable]
        public class EasingSettings
        {
            public DOTweenEase Ease = DOTweenEase.Linear;

            [ShowIf("Ease", DOTweenEase.InElastic, DOTweenEase.OutElastic, DOTweenEase.InOutElastic, DOTweenEase.InBack, DOTweenEase.InOutBack, DOTweenEase.OutBack)]
            public float Amplitude = 1.70158f;

            [ShowIf("Ease", DOTweenEase.Flash)]
            public float FlashCount = 1f;

            [ShowIf("Ease", DOTweenEase.InElastic, DOTweenEase.OutElastic, DOTweenEase.InOutElastic)]
            public float Period = 0f;

            [ShowIf("Ease", DOTweenEase.CustomCurve)]
            public AnimationCurve Curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

            internal void ApplyTo(Tween tween)
            {
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
            }
        }

#if UNITY_EDITOR
        public override void EDITOR_Initialize(GameObject ownerObject, string name) 
        {
            base.EDITOR_Initialize(ownerObject, name);
            Target = ownerObject.GetComponentInChildren<T_Target>();
        }
#endif

        public EasingSettings Easing = new EasingSettings();
        public LoopSettings Looping = new LoopSettings();

        [Header("Values")]
        public T_Target Target;
        public float Duration = 1f;
        public bool IsRelative = false;
        public bool IsFromTween;
        public T_Value EndValue;

        public Tween ConstructTween()
        {
            var tween = GetBaseTween();

            if (IsFromTween)
            {
                tween.From(false, IsRelative);
            }
            else
            {
                tween.SetRelative(IsRelative);
            }

            Looping.ApplyTo(tween);

            Easing.ApplyTo(tween);

            return tween;
        }

        public override IEffect ConstructEffect()
        {
            return new DOTweenEffect(Duration, ConstructTween);
        }

        protected abstract Tweener GetBaseTween();
    }
}
