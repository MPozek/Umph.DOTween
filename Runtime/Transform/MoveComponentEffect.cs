using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [UmphComponentMenu("Move", "DO Tween/Transform/Move")]
    public class MoveComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOMove(EndValue, Duration);
        }
    }
}
