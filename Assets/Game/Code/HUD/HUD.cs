using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private TaskView _taskTemplate;

        [SerializeField]
        private RectTransform _taskContainer;

        private IList<ITask> _tasks;

        public void Initialize(IList<ITask> tasks)
        {
            _tasks = tasks;
            foreach (var currentTask in _tasks)
            {
                var taskView = Instantiate(_taskTemplate, _taskContainer);
                taskView.Initialize(currentTask);
            }
        }
    }
}