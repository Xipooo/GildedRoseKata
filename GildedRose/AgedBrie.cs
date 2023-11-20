namespace GildedRoseKata;

public class AgedBrie : UpdatableItem
{
    public AgedBrie(Item item) : base(item) {}

    public override void Update()
    {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 0) item.Quality = item.Quality + 1;
    }
}