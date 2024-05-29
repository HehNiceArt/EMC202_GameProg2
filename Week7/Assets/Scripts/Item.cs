[System.Serializable]
public struct Item
{
    public string itemName;
    public int itemId;
    public int quanity;
    public Item(string name, int Id, int Quantity)
    {
        itemName = name;
        itemId = Id;
        quanity = Quantity;
    }
}
