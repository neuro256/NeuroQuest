using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class ChaseMovement : MiniEnemyMovement
    {
        private readonly Transform _target;
        private readonly float _speed;
        
        public ChaseMovement(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
        }

        public override void Tick(MiniEnemy enemy, float deltaTime)
        {
            if (_target == null) return;

            Vector2 direction = (_target.position - enemy.transform.position).normalized;
            enemy.transform.position += (Vector3)(_speed * deltaTime * direction);
        }
    }
}

