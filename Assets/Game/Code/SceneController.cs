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

            foreach (var currentTemplate in _settings.Figures)
            {
                var figure = Instantiate(currentTemplate);
                figure.Initialize(_settings.FigureSpeed);
                yield return new WaitForSeconds(1);
            }
        }
    }
}