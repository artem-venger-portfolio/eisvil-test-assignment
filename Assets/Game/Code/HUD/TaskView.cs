using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField]
        private Image _fill;

        [SerializeField]
        private TMP_Text _nameField;

        private ITask _task;

        public void Initialize(ITask task)
        {
            _task = task;
            _task.CurrentCountChanged += CurrentCountChangedEventHandler;
            _task.Done += DoneEventHandler;
            CurrentCountChangedEventHandler();
        }

        private void CurrentCountChangedEventHandler()
        {
            UpdateProgress();
            UpdateName();
        }

        private void UpdateProgress()
        {
            var currentCount = _task.CurrentCount;
            var taskTargetCount = _task.TargetCount;
            var progress = (float)currentCount / taskTargetCount;

            var fillRectTransform = (RectTransform)_fill.transform;
            fillRectTransform.anchorMax = new Vector2(progress, y: 1);
        }

        private void UpdateName()
        {
            _nameField.text = $"{_task.DisplayName} ({_task.CurrentCount}/{_task.TargetCount})";
        }

        private void DoneEventHandler()
        {
            _fill.color = Color.softYellow;
        }
    }
}