using NeuroQuest.Inventory;
using NeuroQuest.UI.Presentation;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Chest : MonoBehaviour, IInteractable
    {
        private const string correctAnswerText = "Правильно! Ты получаешь ключ";
        private const string wrongAnswerText = "Неверный ответ!";
        private const float notificationWindowDuration = 2f;

        [SerializeField] private ChestData _chestData;

        private bool _isOpened;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            LoadSprite(ChestState.Closed);

            var interactiveZone = GetComponentInChildren<InteractiveZone>();
            if (interactiveZone != null)
            {
                interactiveZone.Init(this);
            }
        }

        public void Interact()
        {
            if (_isOpened)
                return;

            OpenChest();
        }

        private void OpenChest()
        {
            var windowManager = FindFirstObjectByType<WindowManager>();
            var question = _chestData.QuestionData;

            if(question == null)
            {
                Debug.LogError("question data is null");
                return;
            }

            windowManager.ShowGame(question,
                onSuccess: () =>
                {
                    _isOpened = true;

                    var playerInventory = FindFirstObjectByType<PlayerInventory>();

                    foreach (var itemData in _chestData.Items)
                    {
                        var item = itemData.CreateItem();
                        playerInventory.Add(item);
                        Debug.Log($"Игрок получил {itemData.Type} ({item})");
                    }

                    LoadSprite(ChestState.Opened);

                    windowManager.ShowNotification(correctAnswerText);
                },
                onFail: () =>
                {
                    windowManager.ShowNotification(wrongAnswerText, notificationWindowDuration);
                });
        }

        private async void LoadSprite(ChestState state)
        {
            var sprite = await _chestData.LoadSpriteAsync(state);
            if (sprite != null)
                _spriteRenderer.sprite = sprite;
        }
    }
}