namespace GildedRoseKata;
public class NormalItem : IItemUpdate
{
    private Item item;


    public NormalItem(Item item)
    {
        this.item = item;
    }

    public void Update()
    {
        if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
        if (item.Quality > 0) item.Quality = item.Quality - 1;
        item.SellIn = item.SellIn - 1;
    }
}