using DG.Tweening;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    public class LocalRotateComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOLocalRotate(EndValue, Duration);
        }
    }
}
