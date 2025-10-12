using UnityEngine;
using UnityEngine.UI;

namespace NeuroQuest.UI.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        public void SetSprite(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        public void Clear()
        {
            _icon.sprite = null;
        }
    }
}

