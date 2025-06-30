using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    [RequireComponent (typeof (SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _framerate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;

        private SpriteRenderer _renderer;
        private float secondsPerFrame;
        private float nextFrameTime;
        private int currentSpriteIndex;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            secondsPerFrame = 1f / _framerate;
            nextFrameTime = Time.time + secondsPerFrame;
            currentSpriteIndex = 0;
        }

        private void Update()
        {
            if (nextFrameTime > Time.time) return;

            if (currentSpriteIndex >= _sprites.Length)
            {
                if (_loop)
                    currentSpriteIndex = 0;
                else
                {
                    enabled = false;
                    _onComplete?.Invoke();
                    return;
                }
            }

            _renderer.sprite = _sprites[currentSpriteIndex];
            nextFrameTime += secondsPerFrame;
            currentSpriteIndex++;
        }
    }
}
