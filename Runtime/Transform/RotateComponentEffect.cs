using DG.Tweening;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    public class RotateComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DORotate(EndValue, Duration);
        }
    }
}
