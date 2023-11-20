namespace GildedRoseKata;

public class AgedBrie : IItemUpdate
{
    private Item item;

    public AgedBrie(Item item)
    {
        this.item = item;
    }

    public void Update()
    {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 0) item.Quality = item.Quality + 1;
    }
}