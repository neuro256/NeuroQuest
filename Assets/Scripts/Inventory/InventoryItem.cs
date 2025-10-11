namespace NeuroQuest.Inventory
{
    public abstract class InventoryItem : IInventoryItem
    {
        public abstract ItemType Type { get; }

        public virtual bool Equals(InventoryItem other)
        {
            if(other == null) return false;
            return Type == other.Type;
        }

        public override bool Equals(object obj) => Equals(obj as InventoryItem);
        public override int GetHashCode() => Type.GetHashCode();
    }
}

