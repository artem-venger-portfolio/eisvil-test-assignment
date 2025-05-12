using TMPro;
using UnityEngine;

namespace Game
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _fill;

        [SerializeField]
        private TMP_Text _nameField;

        private ITask _task;
        
        public void Initialize(ITask task)
        {
            _task = task;
            SetProgress(_task.Progress);
            SetName(_task.DisplayName);
            _task.ProgressChanged += ProgressChangedEventHandler;
        }

        private void ProgressChangedEventHandler(float progress)
        {
            SetProgress(progress);
            SetName(_task.DisplayName);
        }

        private void SetProgress(float progress)
        {
            _fill.anchorMax = new Vector2(progress, 1);
        }

        private void SetName(string taskName)
        {
            _nameField.text = taskName;
        }
    }
}