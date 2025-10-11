namespace NeuroQuest.Inventory
{
    public enum ItemType
    {
        None,
        Key
    }

    public interface IInventoryItem
    {
        ItemType Type { get; }
    }
}

