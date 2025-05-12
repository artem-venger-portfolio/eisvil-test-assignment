using UnityEngine;

namespace Game
{
    public class Figure : MonoBehaviour
    {
        [SerializeField]
        private FigureType _type;

        public FigureType Type => _type;
    }
}