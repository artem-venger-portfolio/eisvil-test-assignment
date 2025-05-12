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
            CurrentCountChangedEventHandler();
        }

        private void UpdateProgress()
        {
            var progress = (float)_task.CurrentCount / _task.TargetCount;
            var fillRectTransform = (RectTransform)_fill.transform;
            fillRectTransform.anchorMax = new Vector2(progress, y: 1);
            if (_task.IsDone)
            {
                _fill.color = Color.softYellow;
            }
        }

        private void UpdateName()
        {
            _nameField.text = $"{_task.DisplayName} ({_task.CurrentCount}/{_task.TargetCount})";
        }

        private void CurrentCountChangedEventHandler()
        {
            UpdateProgress();
            UpdateName();
        }
    }
}