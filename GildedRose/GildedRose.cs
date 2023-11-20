using System.Collections.Generic;

namespace GildedRoseKata;

public partial class GildedRose
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
            IItemUpdate typeItem = item.Name switch
            {
                "Aged Brie" => new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item),
                "Sulfuras, Hand of Ragnaros" => new Sulfurace(item),
                _ => new NormalItem(item)
            };
            typeItem.Update();
        }
    }
}