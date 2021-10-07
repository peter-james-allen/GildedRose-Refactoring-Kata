using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        private readonly ReadOnlyCollection<string> ITEMS_TO_NOT_UPDATE = new ReadOnlyCollection<string>(new[] { "Sulfuras, Hand of Ragnaros" });

        private readonly IList<Item> Items;
        private Item CurrentItem;
        private int IncrementValue;

        public GildedRose(IList<Item> items)
        {
            Items = items;
            CurrentItem = new Item();
            IncrementValue = 1;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                CurrentItem = item;

                if (DoNotUpdate()) continue;

                UpdateCurrentItemSellIn();

                UpdateCurrentItemQuality();
            }
        }

        private bool DoNotUpdate()
        {
            return ITEMS_TO_NOT_UPDATE.Contains(CurrentItem.Name);
        }

        private void UpdateCurrentItemSellIn()
        {
            CurrentItem.SellIn--;
            UpdateIncrementIfExpired();
        }

        private void UpdateIncrementIfExpired()
        {
            IncrementValue = CurrentItem.SellIn < 0 ? 2 : 1;
        }

        private void UpdateCurrentItemQuality()
        {
            switch (CurrentItem.Name)
            {
                case "Aged Brie":
                    IncreaseQuality();
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    IncrementValue = CurrentItem.SellIn < 5 ? 3 : CurrentItem.SellIn < 10 ? 2 : 1;
                    IncreaseQuality();
                    if (CurrentItem.SellIn < 0) CurrentItem.Quality = 0;
                    break;

                default:
                    DecreaseQuality();
                    break;
            }

            SetCurrentItemQualityLimit();
        }
        private void IncreaseQuality()
        {
            CurrentItem.Quality += IncrementValue;
        }

        private void DecreaseQuality()
        {
            CurrentItem.Quality -= IncrementValue;
        }

        private void SetCurrentItemQualityLimit()
        {
            CurrentItem.Quality = Math.Clamp(CurrentItem.Quality, MIN_QUALITY, MAX_QUALITY);
        }
    }
}
