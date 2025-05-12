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

        private void Start()
        {
            var collisionRoom = CreateAndStartCollisionRoom();
            CreateTasks(collisionRoom);
        }

        private CollisionRoom CreateAndStartCollisionRoom()
        {
            InitializeEdges();

            var collisionRoom = new CollisionRoom(_settings, this);
            collisionRoom.Start();

            return collisionRoom;
        }

        private void InitializeEdges()
        {
            var gameCamera = _sceneReferences.Camera;
            var edges = _sceneReferences.Edges;
            edges.Initialize(gameCamera);
        }

        private void CreateTasks(CollisionRoom collisionRoom)
        {
            var tasks = new List<ITask>
            {
                new DestroyAnyTask(collisionRoom, targetCount: 10),
                new DestroyTask(collisionRoom, FigureType.Circle, targetCount: 10),
                new WaitingTask(this, seconds: 120),
            };
            foreach (var currentTask in tasks)
            {
                currentTask.StartTracking();
            }
            _sceneReferences.HUD.Initialize(tasks);
        }
    }
}