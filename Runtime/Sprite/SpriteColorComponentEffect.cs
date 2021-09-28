using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Sprite
{
    [UmphComponentMenu("Sprite Color", "DO Tween/Sprite/Sprite Color")]
    public class SpriteColorComponentEffect : DOTweenComponentEffect<SpriteRenderer, Color>
    {
        protected override Tweener GetBaseTween()
        {
            return Target.DOColor(EndValue, Duration);
        }
    }
}
