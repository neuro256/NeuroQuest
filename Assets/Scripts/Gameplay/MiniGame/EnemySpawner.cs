using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn Area")]
        [SerializeField] private EnemySpawnArea _spawnArea;

        [Header("Enemy")]
        [SerializeField] private MiniEnemy _enemyPrefab;
        [SerializeField] private int _initialPoolSize = 10;
        [SerializeField] private float _spawnInterval = 1.2f;
        [SerializeField] private float _enemySpeed = 2.5f;

        private readonly List<MiniEnemy> _pool = new();
        private float _timer;
        private bool _isSpawning;

        public void Init()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                var enemy = Instantiate(_enemyPrefab, transform);
                enemy.gameObject.SetActive(false);
                _pool.Add(enemy);
            }
        }

        public void StartSpawning() => _isSpawning = true;
        public void StopSpawning()
        {
            foreach (var enemy in _pool)
            {
                enemy.gameObject.SetActive(false);
            }

            _isSpawning = false;
        }

        private void Update()
        {
            if (!_isSpawning || _spawnArea == null)
                return;

            _timer += Time.deltaTime;
            if (_timer >= _spawnInterval)
            {
                _timer = 0;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = GetFreeEnemy();
            var spawnPos = _spawnArea.GetRandomPoint();
            enemy.transform.position = spawnPos;

            var movement = new DropMovement(_enemySpeed);
            enemy.Init(movement, this);
            enemy.gameObject.SetActive(true);
        }

        private MiniEnemy GetFreeEnemy()
        {
            foreach (var e in _pool)
                if (!e.gameObject.activeSelf)
                    return e;

            var newEnemy = Instantiate(_enemyPrefab, transform);
            newEnemy.gameObject.SetActive(false);
            _pool.Add(newEnemy);
            return newEnemy;
        }

        public void ReleaseEnemy(MiniEnemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}

