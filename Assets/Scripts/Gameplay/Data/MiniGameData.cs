using NeuroQuest.Gameplay.MiniGame;
using NeuroQuest.Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/Games/MiniGameData", fileName = "NewMiniGameData")]
    public class MiniGameData : BaseGameData
    {
        public override GameType GameType => GameType.MiniGame;

        [SerializeField] private string _winMessage;
        [SerializeField] private string _gameOverMessage;
        [SerializeField] private List<MiniGameLevelData> _levels;

        public string WinMessage => _winMessage;
        public string GameOverMessage => _gameOverMessage;
        public IReadOnlyList<MiniGameLevelData> Levels => _levels;
    }
}

