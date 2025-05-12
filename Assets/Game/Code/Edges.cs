using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(EdgeCollider2D))]
    public class Edges : MonoBehaviour
    {
        private EdgeCollider2D _edgeCollider;

        public void Initialize(Camera gameCamera)
        {
            _edgeCollider = GetComponent<EdgeCollider2D>();
            var bottomLeft = gameCamera.ViewportToWorldPoint(Vector2.zero);
            var topLeft = gameCamera.ViewportToWorldPoint(Vector2.up);
            var topRight = gameCamera.ViewportToWorldPoint(Vector2.one);
            var bottomRight = gameCamera.ViewportToWorldPoint(Vector2.right);
            var edgePoints = new List<Vector2>
            {
                bottomLeft,
                topLeft,
                topRight,
                bottomRight,
                bottomLeft,
            };
            _edgeCollider.SetPoints(edgePoints);
        }
    }
}