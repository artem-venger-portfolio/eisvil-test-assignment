using System;
using UnityEngine;

namespace Game
{
    public class DestroyTask : ITask
    {
        private readonly CollisionRoom _collisionRoom;
        private readonly FigureType _targetFigure;
        private readonly int _targetCount;
        private int _destroyedFiguresCount;

        public DestroyTask(CollisionRoom collisionRoom, FigureType targetFigure, int targetCount)
        {
            _collisionRoom = collisionRoom;
            _targetFigure = targetFigure;
            _targetCount = targetCount;
            _collisionRoom.FigureDestroyed += FigureDestroyedEventHandler;
        }

        public float Progress { get; private set; }

        public string DisplayName => $"{_targetCount.ToString()} destroyed ({_destroyedFiguresCount}/{_targetCount})";

        public event Action<float> ProgressChanged;

        private void FigureDestroyedEventHandler(FigureType figure)
        {
            if (_targetFigure != figure)
            {
                return;
            }

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