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

        public string DisplayName => "Play seconds";

        public event Action CurrentCountChanged;
        public event Action Done;

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
            }

            Done?.Invoke();
        }

        private void IncrementCurrentCount()
        {
            CurrentCount++;
            CurrentCountChanged?.Invoke();
        }
    }
}