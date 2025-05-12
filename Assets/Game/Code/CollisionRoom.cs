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
            var requiredFiguresCount = _settings.FiguresCount;
            _pooledFigures = new Queue<Figure>(requiredFiguresCount);
            _activeFigures = new List<Figure>(requiredFiguresCount);
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
                if (IsRequiredNumberOfFiguresPresent())
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

        private bool IsRequiredNumberOfFiguresPresent()
        {
            return _activeFigures.Count == _settings.FiguresCount;
        }

        private void SpawnFigure()
        {
            if (IsPoolEmpty())
            {
                CreateFigureInPool();
            }

            ActivateFigureFromPool();
        }

        private bool IsPoolEmpty()
        {
            return _pooledFigures.Count == 0;
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

        private void ActivateFigureFromPool()
        {
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
            FigureDestroyed?.Invoke(figure.Type);
        }
    }
}