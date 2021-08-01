using DG.Tweening;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    public class MoveComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOMove(EndValue, Duration);
        }
    }
}
