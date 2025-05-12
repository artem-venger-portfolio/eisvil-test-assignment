using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class SettingsSO : ScriptableObject
    {
        private const string TYPE_NAME = nameof(SettingsSO);
    }
}