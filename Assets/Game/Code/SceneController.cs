using System.Collections.Generic;
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

            var tasks = new List<ITask>
            {
                new DestroyAnyTask(_collisionRoom, targetCount: 30),
                new DestroyTask(_collisionRoom, FigureType.Circle, targetCount: 15),
                new WaitingTask(this, seconds: 120),
            };
            _sceneReferences.HUD.Initialize(tasks);
        }
    }
}