using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Sprite
{
    [UmphComponentMenu("Sprite Alpha", "DO Tween/Sprite/Sprite Alpha")]
    public class SpriteAlphaComponentEffect : DOTweenComponentEffect<SpriteRenderer, float>
    {
        protected override Tweener GetBaseTween()
        {
            return Target.DOFade(EndValue, Duration);
        }
    }
}
