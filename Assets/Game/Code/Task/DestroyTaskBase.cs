using System;

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

        public int CurrentCount { get; private set; }

        public int TargetCount { get; }

        public abstract string DisplayName { get; }

        public event Action CurrentCountChanged;

        public event Action Done;

        public void StartTracking()
        {
            _collisionRoom.FigureDestroyed += FigureDestroyedEventHandler;
        }

        protected abstract bool CanIncrementCounter(FigureType figure);

        private void FigureDestroyedEventHandler(FigureType figure)
        {
            if (CanIncrementCounter(figure) == false)
            {
                return;
            }

            IncrementCurrentCount();

            var isDone = CurrentCount == TargetCount;
            if (isDone)
            {
                _collisionRoom.FigureDestroyed -= FigureDestroyedEventHandler;
                Done?.Invoke();
            }
        }

        private void IncrementCurrentCount()
        {
            CurrentCount++;
            CurrentCountChanged?.Invoke();
        }
    }
}