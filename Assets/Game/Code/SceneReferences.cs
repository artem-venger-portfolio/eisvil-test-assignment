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

        [SerializeField]
        private HUD _hud;

        public Camera Camera => _camera;

        public Edges Edges => _edges;

        public HUD HUD => _hud;
    }
}