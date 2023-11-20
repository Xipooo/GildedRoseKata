using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "Aged Brie") AgedBrieUpdate(item);
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert") BackstagePassesUpdate(item);
            else if (item.Name == "Sulfuras, Hand of Ragnaros") SulfrasUpdate(item);
            else NormalUpdate(item);
        }
    }

    public void AgedBrieUpdate(Item item) {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 0) item.Quality = item.Quality + 1;
    }

    public void BackstagePassesUpdate(Item item) {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
        if (item.SellIn < 1) item.Quality = item.Quality - item.Quality;
    }

    public void SulfrasUpdate(Item item) {
        return;
    }

    public void NormalUpdate(Item item) {
        if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
        if (item.Quality > 0) item.Quality = item.Quality - 1;
        item.SellIn = item.SellIn - 1;
    }
}