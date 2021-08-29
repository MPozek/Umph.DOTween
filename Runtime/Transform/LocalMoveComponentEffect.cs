using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [UmphComponentMenu("Local Move", "DO Tween/Transform/Local Move")]
    public class LocalMoveComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tween GetBaseTween()
        {
            return Target.DOLocalMove(EndValue, Duration);
        }
    }
}
