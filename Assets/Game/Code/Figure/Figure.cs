using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Figure : MonoBehaviour
    {
        [SerializeField]
        private FigureType _type;

        [SerializeField]
        private float _speed;

        private Vector2 _lastVelocity;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SetVelocity(Random.insideUnitCircle * _speed);
        }

        public FigureType Type => _type;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var normal = -collision.contacts[0].normal;
            SetVelocity(Vector2.Reflect(_lastVelocity, normal));
        }

        private void SetVelocity(Vector2 value)
        {
            _lastVelocity = value;
            _rigidbody.linearVelocity = _lastVelocity;
        }
    }
}