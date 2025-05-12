using System;
using UnityEngine;

namespace Game
{
    public class DestroyAnyTask : ITask
    {
        private readonly CollisionRoom _collisionRoom;
        private readonly int _targetCount;
        private int _destroyedFiguresCount;

        public DestroyAnyTask(CollisionRoom collisionRoom, int targetCount)
        {
            _collisionRoom = collisionRoom;
            _targetCount = targetCount;
            _collisionRoom.FigureDestroyed += FigureDestroyedEventHandler;
        }

        public float Progress { get; private set; }

        public string DisplayName => "Any object destroyed";

        public event Action<float> ProgressChanged;

        private void FigureDestroyedEventHandler(FigureType figure)
        {
            _destroyedFiguresCount++;
            Progress = (float)_destroyedFiguresCount / _targetCount;
            if (Mathf.Approximately(Progress, b: 1))
            {
                _collisionRoom.FigureDestroyed -= FigureDestroyedEventHandler;
            }
            ProgressChanged?.Invoke(Progress);
        }
    }
}