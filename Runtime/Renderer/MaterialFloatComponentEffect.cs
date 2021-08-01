using DG.Tweening;

namespace Umph.DOTween.Renderer
{
    public class MaterialFloatComponentEffect : DOTweenComponentEffect<UnityEngine.Renderer, float>
    {
        public bool UseSharedMaterial;
        public string PropertyName;

        protected override Tween GetBaseTween()
        {
            return Target.material.DOFloat(EndValue, PropertyName, Duration);
        }
    }
}
