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
            _task.ProgressChanged += SetProgress;
            _nameField.text = _task.DisplayName;
        }

        private void SetProgress(float progress)
        {
            _fill.anchorMax = new Vector2(progress, 1);
        }
    }
}