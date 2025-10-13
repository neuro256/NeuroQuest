using NeuroQuest.Infrastructure;
using System;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/ChestActions/StartGame", fileName = "NewStartGameAction")]
    public class StartGameActionData : ChestActionData
    {
        [SerializeField] private BaseGameData _gameData;

        public override void Execute(Action onComplete = null)
        {
            var gameController = FindFirstObjectByType<GameController>();
            gameController.StartGame(_gameData, onSuccess: () => onComplete?.Invoke());
        }
    }
}

