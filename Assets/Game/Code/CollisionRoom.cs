using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollisionRoom
    {
        private readonly MonoBehaviour _coroutineHolder;
        private readonly SettingsSO _settings;
        private readonly Queue<Figure> _pooledFigures;
        private readonly List<Figure> _activeFigures;

        public CollisionRoom(SettingsSO settings, MonoBehaviour coroutineHolder)
        {
            _settings = settings;
            _coroutineHolder = coroutineHolder;
            _pooledFigures = new Queue<Figure>(_settings.FiguresCount);
            _activeFigures = new List<Figure>(_settings.FiguresCount);
        }

        public void Start()
        {
            _coroutineHolder.StartCoroutine(GetSpawnRoutine());
        }

        private IEnumerator GetSpawnRoutine()
        {
            while (true)
            {
                if (_activeFigures.Count == _settings.FiguresCount)
                {
                    yield return null;
                }
                else
                {
                    var template = _settings.Figures[Random.Range(minInclusive: 0, _settings.Figures.Length)];
                    var figure = Object.Instantiate(template);
                    figure.Initialize(_settings);
                    figure.Launch();
                    yield return new WaitForSeconds(seconds: 1);
                }
            }
        }
    }
}