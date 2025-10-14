using UnityEngine;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class DropMovement : MiniEnemyMovement
    {
        private readonly float _speed;

        public DropMovement(float speed)
        {
            _speed = speed;
        }

        public override void Tick(MiniEnemy enemy, float deltaTime)
        {
            Vector2 pos = enemy.transform.position;
            pos.y -= _speed * deltaTime;
            enemy.transform.position = pos;
        }
    }
}