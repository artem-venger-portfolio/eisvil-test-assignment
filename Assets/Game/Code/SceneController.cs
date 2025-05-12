using System.Collections;
using UnityEngine;

namespace Game
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private SettingsSO _settings;

        [SerializeField]
        private SceneReferences _sceneReferences;

        private IEnumerator Start()
        {
            var gameCamera = _sceneReferences.Camera;
            var edges = _sceneReferences.Edges;
            edges.Initialize(gameCamera);

            for (var i = 0; i < _settings.FiguresCount; i++)
            {
                var template = _settings.Figures[Random.Range(minInclusive: 0, _settings.Figures.Length)];
                var figure = Instantiate(template);
                figure.Initialize(_settings);
                figure.Launch();
                yield return new WaitForSeconds(seconds: 1);
            }
        }
    }
}