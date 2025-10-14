using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/Games/MiniGameData", fileName = "NewMiniGameData")]
    public class MiniGameData : BaseGameData
    {
        public override GameType GameType => GameType.MiniGame;

        [SerializeField] private float _duration;
        [SerializeField] private string _winMessage;
        [SerializeField] private string _gameOverMessage;

        public float Duration => _duration;
        public string WinMessage => _winMessage;
        public string GameOverMessage => _gameOverMessage;
    }
}

