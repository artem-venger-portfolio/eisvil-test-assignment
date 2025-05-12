using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class WaitingTask : ITask
    {
        private readonly MonoBehaviour _coroutineHolder;

        public WaitingTask(MonoBehaviour coroutineHolder, int seconds)
        {
            _coroutineHolder = coroutineHolder;
            TargetCount = seconds;
        }

        public int CurrentCount { get; private set; }

        public int TargetCount { get; }

        public float Progress { get; private set; }

        public bool IsDone => CurrentCount == TargetCount;

        public string DisplayName => "Play seconds";

        public event Action<float> ProgressChanged;
        public event Action CurrentCountChanged;

        public void StartTracking()
        {
            _coroutineHolder.StartCoroutine(GetWaitRoutine());
        }

        private IEnumerator GetWaitRoutine()
        {
            while (CurrentCount < TargetCount)
            {
                yield return new WaitForSeconds(seconds: 1);
                IncrementCurrentCount();
                Progress = (float)CurrentCount / TargetCount;
                ProgressChanged?.Invoke(Progress);
            }
        }

        private void IncrementCurrentCount()
        {
            CurrentCount++;
            CurrentCountChanged?.Invoke();
        }
    }
}