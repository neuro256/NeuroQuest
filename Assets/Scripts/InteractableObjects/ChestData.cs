using NeuroQuest.Infrastructure;
using NeuroQuest.UI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public enum ChestState
    {
        Closed = 0,
        Opened = 1
    }

    [CreateAssetMenu(menuName = "NeuroQuest/Inventory/ChestData", fileName = "NewChestData")]
    public class ChestData : ScriptableObject
    {
        [SerializeField]
        private List<ItemData> _items;
        [SerializeField]
        private string _openedSpritePath;
        [SerializeField]
        private string _closedSpritePath;
        [SerializeField]
        private QuestionData _questionData;

        public List<ItemData> Items => _items ??= new List<ItemData>();
        public QuestionData QuestionData => _questionData;

        public async Task<Sprite> LoadSpriteAsync(ChestState state)
        {
            string path = state switch
            {
                ChestState.Closed => _closedSpritePath,
                ChestState.Opened => _openedSpritePath,
                _ => _closedSpritePath
            };

            return await AddressablesLoader.LoadAsync<Sprite>(path);
        }
    }
}

