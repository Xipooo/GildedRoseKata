namespace GildedRoseKata;

public class Sulfurace : IItemUpdate
{
    private Item item;
    public Sulfurace(Item item)
    {
        this.item = item;
    }
    public void Update() { return; }
}