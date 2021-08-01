using DG.Tweening;
using Umph.Core;

namespace Umph.DOTween
{
    /// <summary>
    /// A wrapper class for dotween effects
    /// </summary>
    public class DOTweenEffect : IEffect
    {
        private readonly DG.Tweening.Tween _tween;

        public DOTweenEffect(DG.Tweening.Tween tween)
        {
            tween.Pause();
            tween.SetAutoKill(false);
            _tween = tween;
        }

        public float Duration => _tween.Duration();
        
        public bool RequiresUpdates => false;

        public bool IsCompleted => _tween.IsComplete();

        public void Play()
        {
            _tween.Rewind();
            _tween.Play();
        }

        public void Reset()
        {
            _tween.Rewind();
        }

        public void Skip()
        {
            _tween.Complete(true);
        }

        public void Update(float deltaTime)
        {
        }
    }
}
