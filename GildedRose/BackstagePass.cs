namespace GildedRoseKata;
public class BackstagePass : IItemUpdate
{
    private Item item;


    public BackstagePass(Item item)
    {
        this.item = item;
    }
    public void Update()
    {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
        if (item.SellIn < 1) item.Quality = item.Quality - item.Quality;
    }
}