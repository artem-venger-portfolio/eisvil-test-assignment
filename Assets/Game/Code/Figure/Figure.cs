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
            MoveToDefaultPosition();
            SetRandomVelocity();
        }

        public void Stop()
        {
            SetVelocity(Vector2.zero);
        }

        public void Hide()
        {
            SetActive(isActive: false);
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void MoveToDefaultPosition()
        {
            transform.position = Vector3.zero;
        }

        private void SetRandomVelocity()
        {
            var randomDirection = Random.insideUnitCircle.normalized;
            var velocity = randomDirection * _settings.FigureSpeed;
            SetVelocity(velocity);
        }

        private void SetVelocity(Vector2 value)
        {
            _lastVelocity = value;
            _rigidbody.linearVelocity = _lastVelocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsFigure(collision))
            {
                HandleFigureCollision();
            }
            else if (IsEdge(collision))
            {
                HandleEdgeCollision(collision);
            }
        }

        private bool IsFigure(Collision2D collision)
        {
            return HasComponent<Figure>(collision);
        }

        private bool HasComponent<T>(Collision2D collision) where T: Component
        {
            return collision.gameObject.TryGetComponent<T>(out _);
        }

        private void HandleFigureCollision()
        {
            CollidedWithOtherFigure?.Invoke(this);
        }

        private bool IsEdge(Collision2D collision)
        {
            return HasComponent<Edges>(collision);
        }

        private void HandleEdgeCollision(Collision2D collision)
        {
            var normal = -collision.contacts[0].normal;
            SetVelocity(Vector2.Reflect(_lastVelocity, normal));
        }
    }
}