using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class SceneReferences
    {
        [SerializeField]
        private Camera _camera;

        public Camera Camera => _camera;
    }
}