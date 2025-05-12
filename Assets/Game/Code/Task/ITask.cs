using System;

namespace Game
{
    public interface ITask
    {
        public string DisplayName { get; }
        public float Progress { get; }
        public bool IsDone { get; }
        public event Action<float> ProgressChanged;
    }
}