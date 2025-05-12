using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class HUD : MonoBehaviour
    {
        private IList<ITask> _tasks;

        public void Initialize(IList<ITask> tasks)
        {
            _tasks = tasks;
        }
    }
}