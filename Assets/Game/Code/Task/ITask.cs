using System;

namespace Game
{
    public interface ITask
    {
        public string DisplayName { get; }
        public int CurrentCount { get; }
        public int TargetCount { get; }
        public event Action CurrentCountChanged;
        public event Action Done;
        void StartTracking();
    }
}