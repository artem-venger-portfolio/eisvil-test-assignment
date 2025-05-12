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

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.linearVelocity = Random.insideUnitCircle * _speed;
        }

        public FigureType Type => _type;
    }
}