using System;
using UnityEngine;

namespace Game
{
    public abstract class DestroyTaskBase : ITask
    {
        private readonly CollisionRoom _collisionRoom;

        protected DestroyTaskBase(CollisionRoom collisionRoom, int targetCount)
        {
            _collisionRoom = collisionRoom;
            TargetCount = targetCount;
        }

        public float Progress { get; private set; }

        public bool IsDone => DestroyedFiguresCount == TargetCount;

        public abstract string DisplayName { get; }

        public event Action<float> ProgressChanged;

        public void StartTracking()
        {
            _collisionRoom.FigureDestroyed += FigureDestroyedEventHandler;
        }

        protected int TargetCount { get; }

        protected int DestroyedFiguresCount { get; private set; }

        protected abstract bool CanIncrementCounter(FigureType figure);

        private void FigureDestroyedEventHandler(FigureType figure)
        {
            if (CanIncrementCounter(figure) == false)
            {
                return;
            }

            DestroyedFiguresCount++;
            Progress = (float)DestroyedFiguresCount / TargetCount;
            if (Mathf.Approximately(Progress, b: 1))
            {
                _collisionRoom.FigureDestroyed -= FigureDestroyedEventHandler;
            }
            ProgressChanged?.Invoke(Progress);
        }
    }
}