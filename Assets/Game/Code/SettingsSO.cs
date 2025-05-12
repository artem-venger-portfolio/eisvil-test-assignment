using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = "Game/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class SettingsSO : ScriptableObject
    {
        [SerializeField]
        private Figure[] _figures;

        [SerializeField]
        private float _figureSpeed;

        [SerializeField]
        private int _figuresCount;

        private const string TYPE_NAME = nameof(SettingsSO);

        public Figure[] Figures => _figures;

        public float FigureSpeed => _figureSpeed;

        public int FiguresCount => _figuresCount;
    }
}