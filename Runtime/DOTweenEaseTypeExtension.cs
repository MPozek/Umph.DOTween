using DG.Tweening;

namespace Umph.DOTween
{
    public static class DOTweenEaseTypeExtension
    {
        public static Ease ToDOEase(this DOTweenEase ease)
        {
            return (Ease)ease;
        }
    }
}
