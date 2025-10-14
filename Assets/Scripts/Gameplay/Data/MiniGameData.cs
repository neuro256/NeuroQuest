using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/Games/MiniGameData", fileName = "NewMiniGameData")]
    public class MiniGameData : BaseGameData
    {
        public override GameType GameType => GameType.MiniGame;

        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}

