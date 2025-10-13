using NeuroQuest.Gameplay;
using NeuroQuest.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Chest : MonoBehaviour, IInteractable
    {
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
            var actionData = _chestData.ActionData;

            ExecuteActionsSequentially(_chestData.ActionData);
        }

        private void ExecuteActionsSequentially(List<ChestActionData> actions, int index = 0)
        {
            if (actions == null || index >= actions.Count) return;

            actions[index].Execute(() =>
            {
                ExecuteActionsSequentially(actions, index + 1);
                
                if (actions[index].IsMainAction)
                {
                    _isOpened = true;

                    CollectItems(_chestData.Items);

                    LoadSprite(ChestState.Opened);
                }
            });
        }

        private void CollectItems(List<ItemData> itemsData)
        {
            if (itemsData == null || itemsData.Count == 0)
                return;

            var playerInventory = FindFirstObjectByType<PlayerInventory>();

            foreach (var itemData in itemsData)
            {
                var item = itemData.CreateItem();
                playerInventory.Add(item);
                Debug.Log($"Игрок получил {itemData.Type} ({item})");
            }
        }

        private async void LoadSprite(ChestState state)
        {
            var sprite = await _chestData.LoadSpriteAsync(state);
            if (sprite != null)
                _spriteRenderer.sprite = sprite;
        }
    }
}