using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    [CreateAssetMenu(menuName = "NeuroQuest/MiniGame/EnemyType", fileName = "NewMiniEnemyType")]
    public class MiniEnemyType : ScriptableObject
    {
        [SerializeField] private MiniEnemy _prefab;
        [SerializeField] private MiniEnemyMovementType _movementType;

        public MiniEnemy Prefab => _prefab;
        public MiniEnemyMovementType MovementType => _movementType;
    }

    public enum MiniEnemyMovementType
    {
        Linear,
        Chase
    }
}
