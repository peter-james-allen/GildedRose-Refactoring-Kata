using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        DecreaseQuality(item);
                    }
                }
                else
                {
                    IncreaseQuality(item);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQuality(item);
                        }
                    }
                }

                UpdateSellIn(item);

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                DecreaseQuality(item);
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        IncreaseQuality(item);
                    }
                }
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50) item.Quality++;
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros") item.SellIn--;
        }
    }
}
