using DG.Tweening;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    public class LocalMoveComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOLocalMove(EndValue, Duration);
        }
    }
}
