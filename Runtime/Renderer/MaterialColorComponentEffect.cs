using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Renderer
{
    [UmphComponentMenu("Material Color", "DO Tween/Renderer/Material Color")]
    public class MaterialColorComponentEffect : DOTweenComponentEffect<UnityEngine.Renderer, Color>
    {
        public bool UseSharedMaterial;
        public string PropertyName;

        protected override Tween GetBaseTween()
        {
            if (UseSharedMaterial)
            {
                return Target.sharedMaterial.DOColor(EndValue, PropertyName, Duration);
            }
            else
            {
                return Target.material.DOColor(EndValue, PropertyName, Duration);
            }
        }
    }
}
