using System;

namespace NeuroQuest.Inventory
{
    public enum KeyType
    {
        Red, 
        Green,
        Blue,
        Yellow,
        White
    }

    public class KeyItem : InventoryItem
    {
        public override ItemType Type => ItemType.Key;
        public KeyType KeyType { get; private set; }


        public KeyItem(KeyType type)
        {
            KeyType = type;
        }

        public bool Equals(KeyItem other)
        {
            return KeyType == other.KeyType && Type == other.Type;
        }

        public override bool Equals(InventoryItem other)
        {
            if(other is KeyItem key)
                return Equals(key);

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, KeyType);
        }
    }
}
