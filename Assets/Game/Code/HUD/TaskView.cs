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
            var fillRectTransform = (RectTransform)_fill.transform;
            fillRectTransform.anchorMax = new Vector2(progress, y: 1);
            if (Mathf.Approximately(progress, b: 1))
            {
                _fill.color = Color.softYellow;
            }
        }

        private void SetName(string taskName)
        {
            _nameField.text = taskName;
        }
    }
}