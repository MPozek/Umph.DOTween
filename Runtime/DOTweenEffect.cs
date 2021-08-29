using DG.Tweening;
using System;
using Umph.Core;

namespace Umph.DOTween
{
    /// <summary>
    /// A wrapper class for dotween effects
    /// </summary>
    public class DOTweenEffect : IEffect
    {
        private Tween _tween;
        private readonly Func<Tween> _tweenConstructor;

        public DOTweenEffect(float duration, System.Func<Tween> tweenConstructor)
        {
            Duration = duration;
            _tweenConstructor = tweenConstructor;
        }

        ~DOTweenEffect()
        {
            if (_tween != null)
                _tween.Kill();
        }

        public float Duration { get; private set; }
        
        public bool RequiresUpdates => false;

        public bool IsCompleted => _tween != null && (!_tween.active || _tween.IsComplete());
        public bool IsPlaying => _tween != null && _tween.IsPlaying();

        public void Play()
        {
            if (_tween == null || !_tween.active || _tween.IsComplete())
            {
                if (_tween != null)
                {
                    _tween.Kill();
                    _tween = null;
                }

                _tween = _tweenConstructor.Invoke();
                _tween.SetRecyclable(true);
                _tween.SetAutoKill(false);
            }

            _tween.Play();
        }

        public void Pause()
        {
            if (IsPlaying)
            {
                _tween.Pause();
            }
        }

        public void Reset()
        {
            if (_tween != null)
            {
                _tween.Rewind();
                _tween.Kill();
                _tween = null;
            }
        }

        public void Skip()
        {
            if (_tween == null || !_tween.active)
            {
                Play();
            }

            _tween.Complete();
            _tween.Kill();
            _tween = null;
        }

        public void Update(float deltaTime)
        {
        }
    }
}
