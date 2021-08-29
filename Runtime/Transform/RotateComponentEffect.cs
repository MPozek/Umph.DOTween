using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [UmphComponentMenu("Rotate", "DO Tween/Transform/Rotate")]
    public class RotateComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DORotate(EndValue, Duration);
        }
    }
}
