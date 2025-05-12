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

        public FigureType Type => _type;

        public void Initialize(float speed)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SetVelocity(Random.insideUnitCircle * speed);
        }

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