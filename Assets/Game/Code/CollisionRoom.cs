using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

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

        public event Action<FigureType> FigureDestroyed;

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
                    SpawnFigure();
                    yield return new WaitForSeconds(_settings.SpawnInterval);
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void SpawnFigure()
        {
            if (_pooledFigures.Count == 0)
            {
                CreateFigureInPool();
            }

            var figure = _pooledFigures.Dequeue();
            _activeFigures.Add(figure);
            figure.CollidedWithOtherFigure += CollidedWithOtherFigureEventHandler;
            figure.Show();
            figure.Launch();
        }

        private void CollidedWithOtherFigureEventHandler(Figure figure)
        {
            figure.CollidedWithOtherFigure -= CollidedWithOtherFigureEventHandler;
            figure.Stop();
            figure.Hide();
            _activeFigures.Remove(figure);
            _pooledFigures.Enqueue(figure);
        }

        private void CreateFigureInPool()
        {
            var figures = _settings.Figures;
            var template = figures[Random.Range(minInclusive: 0, figures.Length)];
            var figure = Object.Instantiate(template);
            figure.Initialize(_settings);
            figure.Hide();
            _pooledFigures.Enqueue(figure);
        }
    }
}