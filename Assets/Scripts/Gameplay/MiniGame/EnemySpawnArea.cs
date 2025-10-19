using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    [CreateAssetMenu(menuName = "NeuroQuest/MiniGame/SpawnArea", fileName = "NewSpawnArea")]
    public class EnemySpawnArea : ScriptableObject
    {
        [SerializeField] private Vector2 _topLeft;
        [SerializeField] private Vector2 _bottomRight;

        public Vector2 GetRandomPoint()
        {
            return new Vector2(
                Random.Range(_topLeft.x, _bottomRight.x),
                Random.Range(_bottomRight.y, _topLeft.y)
            );
        }
    }
}

