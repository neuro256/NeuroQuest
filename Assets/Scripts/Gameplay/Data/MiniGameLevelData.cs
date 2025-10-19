using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    [CreateAssetMenu(menuName = "NeuroQuest/MiniGame/Level", fileName = "NewMiniGameLevel")]
    public class MiniGameLevelData : ScriptableObject
    {
        [SerializeField] private float _duration = 10f;
        [SerializeField] private float _pauseBetweenLevels = 2f;
        [SerializeField] private float _spawnInterval = 0.4f;
        [SerializeField] private float _enemySpeed = 3f;
        [SerializeField] private Vector2 _enemyMoveDirection = Vector2.down;
        [SerializeField] private List<EnemySpawnArea> _spawnAreas;
        [SerializeField] private List<MiniEnemyType> _enemyTypes;

        public float Duration => _duration;
        public float PauseBetweenLevels => _pauseBetweenLevels;
        public float SpawnInterval => _spawnInterval;
        public float EnemySpeed => _enemySpeed;
        public Vector2 EnemyMoveDirection => _enemyMoveDirection;
        public IReadOnlyList<EnemySpawnArea> SpawnAreas => _spawnAreas;
        public IReadOnlyList<MiniEnemyType> EnemyTypes => _enemyTypes;
    }
}

