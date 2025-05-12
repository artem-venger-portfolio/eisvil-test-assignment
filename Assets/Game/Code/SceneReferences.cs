using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class SceneReferences
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Edges _edges;

        public Camera Camera => _camera;

        public Edges Edges => _edges;
    }
}