using DG.Tweening;
using Umph.Core;
using UnityEngine;

namespace Umph.DOTween.Renderer
{
    [UmphComponentMenu("Material Vec4", "DO Tween/Renderer/Material Vec4")]
    public class MaterialVector4ComponentEffect : DOTweenComponentEffect<UnityEngine.Renderer, Vector4>
    {
        public bool UseSharedMaterial;
        public string PropertyName;

        protected override Tween GetBaseTween()
        {
            if (UseSharedMaterial)
            {
                return Target.sharedMaterial.DOVector(EndValue, PropertyName, Duration);
            }
            else
            {
                return Target.material.DOVector(EndValue, PropertyName, Duration);
            }
        }
    }
}
