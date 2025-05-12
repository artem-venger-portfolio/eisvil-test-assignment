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
            SetProgress(_task.Progress);
            SetName(_task);
            _task.CurrentCountChanged += CurrentCountChangedEventHandler;
        }

        private void SetProgress(float progress)
        {
            var fillRectTransform = (RectTransform)_fill.transform;
            fillRectTransform.anchorMax = new Vector2(progress, y: 1);
            if (_task.IsDone)
            {
                _fill.color = Color.softYellow;
            }
        }

        private void SetName(ITask task)
        {
            _nameField.text = $"{task.DisplayName} ({task.CurrentCount}/{task.TargetCount})";
        }

        private void CurrentCountChangedEventHandler()
        {
            SetProgress(_task.Progress);
            SetName(_task);
        }
    }
}