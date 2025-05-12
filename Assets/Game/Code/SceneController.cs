using UnityEngine;

namespace Game
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private SettingsSO _settings;

        [SerializeField]
        private SceneReferences _sceneReferences;

        private CollisionRoom _collisionRoom;

        private void Start()
        {
            var gameCamera = _sceneReferences.Camera;
            var edges = _sceneReferences.Edges;
            edges.Initialize(gameCamera);

            _collisionRoom = new CollisionRoom(_settings, this);
            _collisionRoom.Start();
        }
    }
}