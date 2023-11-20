using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public partial class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items) => _items = items;

    public Dictionary<string, Func<Item, UpdatableItem>> UPDATABLEITEMS_TABLE = new() {
            { "Aged Brie", (item) => new AgedBrie(item) },
            { "Backstage passes to a TAFKAL80ETC concert", (item) => new BackstagePass(item) },
            { "Sulfuras, Hand of Ragnaros", (item) => new UpdatableItem(item) },
            { "Default", (item) => new NormalItem(item) }
    };

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var typeItem = UpdateableItemFactory(item);
            typeItem.Update();
        }
    }

    public UpdatableItem UpdateableItemFactory(Item item) =>
        UPDATABLEITEMS_TABLE.FirstOrDefault(updatableItem => updatableItem.Key.Equals(item.Name) || updatableItem.Key.Equals("Default")).Value(item);
}