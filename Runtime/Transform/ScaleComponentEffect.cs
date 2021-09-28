using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Transform
{
    [System.Serializable]
    [UmphComponentMenu("Scale", "DO Tween/Transform/Scale")]
    public class ScaleComponentEffect : DOTweenComponentEffect<UnityEngine.Transform, Vector3>
    {
        protected override Tweener GetBaseTween()
        {
            return Target.DOScale(EndValue, Duration);
        }
    }
}
