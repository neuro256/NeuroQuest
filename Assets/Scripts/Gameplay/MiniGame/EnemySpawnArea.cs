using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    [ExecuteAlways]
    public class EnemySpawnArea : MonoBehaviour
    {
        [SerializeField] private Transform _topLeft;
        [SerializeField] private Transform _bottomRight;

        public Vector2 GetRandomPoint()
        {
            return new Vector2(
                Random.Range(_topLeft.position.x, _bottomRight.position.x),
                Random.Range(_bottomRight.position.y, _topLeft.position.y)
            );
        }

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
        }
#endif
    }
}

