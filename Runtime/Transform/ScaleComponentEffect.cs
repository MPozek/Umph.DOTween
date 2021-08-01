using DG.Tweening;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [System.Serializable]
    public class ScaleComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOScale(EndValue, Duration);
        }
    }
}
