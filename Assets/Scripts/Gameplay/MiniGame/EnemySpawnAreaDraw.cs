using UnityEditor;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    [ExecuteAlways]
    public class EnemySpawnAreaDraw : MonoBehaviour
    {
        [SerializeField] private Transform _topLeft;
        [SerializeField] private Transform _bottomRight;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_topLeft == null || _bottomRight == null)
                return;

            Gizmos.color = Color.green;
            var p1 = _topLeft.position;
            var p2 = _bottomRight.position;
            var center = (p1 + p2) / 2;
            var size = new Vector3(Mathf.Abs(p1.x - p2.x), Mathf.Abs(p1.y - p2.y), 0);
            Gizmos.DrawWireCube(center, size);

            Handles.Label(_topLeft.position + Vector3.up * 0.5f,
            $"({_topLeft.position.x:F1}, {_topLeft.position.y:F1}, {_topLeft.position.z:F1})");

            Handles.Label(_bottomRight.position + Vector3.up * 0.5f,
            $"({_bottomRight.position.x:F1}, {_bottomRight.position.y:F1}, {_bottomRight.position.z:F1})");
        }
#endif
    }
}
