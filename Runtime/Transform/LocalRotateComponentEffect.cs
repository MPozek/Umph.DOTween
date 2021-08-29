using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [UmphComponentMenu("Local Rotate", "DO Tween/Transform/Local Rotate")]
    public class LocalRotateComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOLocalRotate(EndValue, Duration);
        }
    }
}
