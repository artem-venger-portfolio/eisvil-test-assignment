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

        private const string TYPE_NAME = nameof(SettingsSO);

        public Figure[] Figures => _figures;
    }
}