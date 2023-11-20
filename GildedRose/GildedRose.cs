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

            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros") item.Quality = item.Quality - 1;
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50) item.Quality = item.Quality + 1;
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50 && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 11) item.Quality = item.Quality + 1;
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50 && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 6) item.Quality = item.Quality + 1;
            if (item.Name != "Sulfuras, Hand of Ragnaros") item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0 && item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros") item.Quality = item.Quality - 1;
            if (item.SellIn < 0 && item.Name != "Aged Brie" && item.Name == "Backstage passes to a TAFKAL80ETC concert") item.Quality = item.Quality - item.Quality;
            if (item.SellIn < 0 && item.Name == "Aged Brie" && item.Quality < 50) item.Quality = item.Quality + 1;
        }
    }
}