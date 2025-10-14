using System.Collections;
using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class MiniEnemy : MonoBehaviour
    {
        [SerializeField] private float _lifetime = 2f;

        private EnemySpawner _spawner;
        private MiniEnemyMovement _movement;
        private Coroutine _lifeRoutine;

        private void OnEnable()
        {
            _lifeRoutine = StartCoroutine(LifetimeCoroutine());
        }

        private void OnDisable()
        {
            if (_lifeRoutine != null)
                StopCoroutine(_lifeRoutine);
        }

        public void Init(MiniEnemyMovement movement, EnemySpawner spawner)
        {
            _spawner = spawner;
            _movement = movement;
        }

        private void Update()
        {
            _movement?.Tick(this, Time.deltaTime);
        }

        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(_lifetime);
            _spawner.ReleaseEnemy(this);
        }
    }
}

