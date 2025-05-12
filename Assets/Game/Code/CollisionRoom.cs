using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollisionRoom
    {
        private readonly GameObject _coroutineHolder;
        private readonly SettingsSO _settings;
        private readonly Queue<Figure> _pooledFigures;
        private readonly List<Figure> _activeFigures;

        public CollisionRoom(SettingsSO settings, GameObject coroutineHolder)
        {
            _settings = settings;
            _coroutineHolder = coroutineHolder;
            _pooledFigures = new Queue<Figure>(_settings.FiguresCount);
            _activeFigures = new List<Figure>(_settings.FiguresCount);
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}