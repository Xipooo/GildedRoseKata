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
            else if (item.Name == "Sulfuras, Hand of Ragnaros") SulfurasUpdate(item);
            else NormalUpdate(item);
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

    public void AgedBrieUpdate(Item item)
    {
        new AgedBrie(item).Update();
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
    public void BackstagePassesUpdate(Item item)
    {
        new BackstagePass(item).Update();
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

    public void SulfurasUpdate(Item item)
    {
        new Sulfurace(item).Update();
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

    public void NormalUpdate(Item item)
    {
        new NormalItem(item).Update();
    }
}