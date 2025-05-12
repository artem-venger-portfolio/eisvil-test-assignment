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

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _direction = Random.insideUnitCircle;
        }

        public FigureType Type => _type;

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = _direction * _speed;
        }
    }
}