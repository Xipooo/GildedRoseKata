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


    public interface IItemUpdate {
        void Update();
    }
    
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

    public class BackstagePass : IItemUpdate {
        private Item item;


        public BackstagePass(Item item)
        {
            this.item = item;
        }
        public void Update() {
            if (item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
            if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
            if (item.SellIn < 1) item.Quality = item.Quality - item.Quality;
        }
    }

    public class Sulfurace : IItemUpdate
    {
        private Item item;
        public Sulfurace(Item item)
        {
            this.item = item;
        }
        public void Update() { return; }
    }

    public class NormalItem : IItemUpdate {
        private Item item;


        public NormalItem(Item item)
        {
            this.item = item;
        }

        public void Update() {
            if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
            if (item.Quality > 0) item.Quality = item.Quality - 1;
            item.SellIn = item.SellIn - 1;
        }
    }
}