using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class WaitingTask : ITask
    {
        private readonly int _targetSeconds;
        private int _secondsLeft;

        public WaitingTask(MonoBehaviour coroutineHolder, int seconds)
        {
            _targetSeconds = seconds;
            coroutineHolder.StartCoroutine(GetWaitRoutine());
        }

        public float Progress { get; private set; }

        public string DisplayName => $"Play time ({_secondsLeft}/{_targetSeconds})";

        public event Action<float> ProgressChanged;

        private IEnumerator GetWaitRoutine()
        {
            while (_secondsLeft < _targetSeconds)
            {
                yield return new WaitForSeconds(seconds: 1);
                _secondsLeft++;
                Progress = (float)_secondsLeft / _targetSeconds;
                ProgressChanged?.Invoke(Progress);
            }
        }
    }
}