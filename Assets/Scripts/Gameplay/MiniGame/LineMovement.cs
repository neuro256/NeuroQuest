using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class LineMovement : MiniEnemyMovement
    {
        private readonly Vector2 _direction;
        private readonly float _speed;

        public LineMovement(Vector2 direction, float speed)
        {
            _direction = direction.normalized;
            _speed = speed;
        }

        public override void Tick(MiniEnemy enemy, float deltaTime)
        {
            enemy.transform.position += (Vector3)(_speed * deltaTime * _direction);
        }
    }
}