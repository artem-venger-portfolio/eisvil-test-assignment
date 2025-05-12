using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Figure : MonoBehaviour
    {
        [SerializeField]
        private FigureType _type;

        private Vector2 _lastVelocity;
        private Rigidbody2D _rigidbody;
        private SettingsSO _settings;

        public FigureType Type => _type;

        public event Action<Figure> CollidedWithOtherFigure;

        public void Initialize(SettingsSO settings)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _settings = settings;
        }

        public void Show()
        {
            SetActive(isActive: true);
        }

        public void Launch()
        {
            SetVelocity(Random.insideUnitCircle.normalized * _settings.FigureSpeed);
        }

        public void Stop()
        {
            SetVelocity(Vector2.zero);
        }

        public void Hide()
        {
            SetActive(isActive: false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var otherObject = collision.gameObject;
            if (otherObject.TryGetComponent<Figure>(out _))
            {
                Destroy(gameObject);
                CollidedWithOtherFigure?.Invoke(this);
            }
            else if (otherObject.TryGetComponent<Edges>(out _))
            {
                var normal = -collision.contacts[0].normal;
                SetVelocity(Vector2.Reflect(_lastVelocity, normal));
            }
        }

        private void SetVelocity(Vector2 value)
        {
            _lastVelocity = value;
            _rigidbody.linearVelocity = _lastVelocity;
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}