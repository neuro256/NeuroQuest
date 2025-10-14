using NeuroQuest.Gameplay;
using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class MiniGameLauncher : MonoBehaviour, IInteractable
    {
        [SerializeField] private BaseGameData _gameData;

        private bool _isLaunched;

        private void Awake()
        {
            var interactiveZone = GetComponentInChildren<InteractiveZone>();
            if (interactiveZone != null)
            {
                interactiveZone.Init(this);
            }
        }

        public void Interact()
        {
            if (_isLaunched)
                return;

            var gameController = FindFirstObjectByType<GameController>();
            gameController.StartGame(_gameData, 
                onSuccess: () => _isLaunched = false,
                onFail: () => _isLaunched = false);
        }
    }
}
