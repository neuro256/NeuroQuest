using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    public class MiniGameData : BaseGameData
    {
        public override GameType GameType => GameType.MiniGame;

        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}

