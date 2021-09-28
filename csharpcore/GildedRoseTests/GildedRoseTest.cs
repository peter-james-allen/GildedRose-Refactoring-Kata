using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_ReducesSellInAndQualityByOne()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "testItem", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void QualityCanNeverBeNegative()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "testItem", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(7, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void WhenSellbyDateIsPassed_QualityDegradesTwiceAsFast()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "testItem", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 1 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void WhenSellbyDateIsPassed_AgedBrieIncreasesInQualityTwiceAsFast()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverAboveFifty()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(-3, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);

        }

        [Fact]
        public void SulfurasQualityAnSellInNeverChange()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 12 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(3, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);

        }

        [Fact]
        public void WhenSellInIsGreaterThanTen_BackstagePassesIncreasesInQualityByOne()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 3 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(11, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void WhenSellInIsBetweenTenAndFive_BackstagePassesIncreasesInQualityByTwo()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(8, Items[0].SellIn);
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void WhenSellInIsBetweenFiveAndZero_BackstagePassesIncreasesInQualityByThree()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 2 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(3, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void WhenSellInIsNegative_BackstagePassesQualityIsZero()
        {
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 24 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }
    }
}
