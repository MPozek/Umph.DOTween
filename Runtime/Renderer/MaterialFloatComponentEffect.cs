using DG.Tweening;
using Umph.Core;

namespace Umph.DOTween.Renderer
{

    [UmphComponentMenu("Material Float", "DO Tween/Renderer/Material Float")]
    public class MaterialFloatComponentEffect : DOTweenComponentEffect<UnityEngine.Renderer, float>
    {
        public bool UseSharedMaterial;
        public string PropertyName;

        protected override Tweener GetBaseTween()
        {
            if (UseSharedMaterial)
            {
                return Target.sharedMaterial.DOFloat(EndValue, PropertyName, Duration);
            }
            else
            {
                return Target.material.DOFloat(EndValue, PropertyName, Duration);
            }
        }
    }
}
