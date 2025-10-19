using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private MiniPlayerController _miniPlayer;

        private MiniGameLevelData _currentLevel;

        private readonly List<MiniEnemy> _pool = new();
        private float _timer;
        private bool _isSpawning;

        public void Init(MiniGameLevelData level)
        {
            _currentLevel = level;

            _pool.Clear();

            foreach (var enemyType in level.EnemyTypes)
            {
                for(int i= 0; i < 5; i++)
                {
                    var enemy = Instantiate(enemyType.Prefab, transform);
                    enemy.gameObject.SetActive(false);
                    _pool.Add(enemy);
                }
            }
        }

        public void StartSpawning() => _isSpawning = true;
        public void StopSpawning()
        {
            _isSpawning = false;

            foreach (var enemy in _pool)
            {
                enemy.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (!_isSpawning || _currentLevel == null)
                return;

            _timer += Time.deltaTime;
            if (_timer >= _currentLevel.SpawnInterval)
            {
                _timer = 0;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var level = _currentLevel;
            var type = level.EnemyTypes[Random.Range(0, level.EnemyTypes.Count)];
            var spawnArea = level.SpawnAreas[Random.Range(0, level.SpawnAreas.Count)];

            var enemy = GetFreeEnemy(type);
            enemy.transform.position = spawnArea.GetRandomPoint();

            var movement = CreateMovement(type.MovementType, level.EnemySpeed, level.EnemyMoveDirection);
            enemy.Init(movement, this);
            enemy.gameObject.SetActive(true);
        }

        private MiniEnemy GetFreeEnemy(MiniEnemyType type)
        {
            foreach (var e in _pool)
                if (!e.gameObject.activeSelf && e.name.Contains(type.name))
                    return e;

            var enemy = Instantiate(type.Prefab, transform);
            enemy.gameObject.SetActive(false);
            _pool.Add(enemy);
            return enemy;
        }

        private MiniEnemyMovement CreateMovement(MiniEnemyMovementType type, float speed, Vector2 direction)
        {
            return type switch
            {
                MiniEnemyMovementType.Linear => new LinearMovement(direction, speed),
                MiniEnemyMovementType.Chase => new ChaseMovement(_miniPlayer.transform, speed),
                _ => new LinearMovement(direction, speed)
            };
        }

        public void ReleaseEnemy(MiniEnemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}

