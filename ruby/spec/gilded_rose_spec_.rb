require 'gilded_rose_original'

describe GildedRose do

  items = [
    Item.new(name="+5 Dexterity Vest", sell_in=10, quality=20),
    Item.new(name="Aged Brie", sell_in=2, quality=0),
    Item.new(name="Elixir of the Mongoose", sell_in=5, quality=7),
    Item.new(name="Sulfuras, Hand of Ragnaros", sell_in=0, quality=80),
    Item.new(name="Sulfuras, Hand of Ragnaros", sell_in=-1, quality=80),
    Item.new(name="Backstage passes to a TAFKAL80ETC concert", sell_in=15, quality=20),
    Item.new(name="Backstage passes to a TAFKAL80ETC concert", sell_in=10, quality=49),
    Item.new(name="Backstage passes to a TAFKAL80ETC concert", sell_in=5, quality=49),
    # This Conjured item does not work properly yet
    Item.new(name="Conjured Mana Cake", sell_in=3, quality=6),
    Item.new(name="Conjured Bagel", sell_in=3, quality=20)
  ]
  let(:subject) { GildedRose.new(items) }

  describe "#update_quality" do
    it "does not change the name" do
      item = [Item.new("foo", 0, 0)]
      GildedRose.new(item).update_quality()
      expect(item[0].name).to eq "foo"
    end

    context "sell in date" do
      it "should decrease normal items sell in date by 1" do
        [0,1,2,5,6,7,8,9].each do |i|
          expect{ subject.update_quality }.to change{ items[i].sell_in }.by -1
        end
      end
      it "should not decrease sulfuras sell in date" do
        [3,4].each do |i|
          expect{ subject.update_quality }.to change{ items[i].sell_in }.by 0
        end
      end
    end
  end

  context "quality" do
    it "should decrease normal items quality by 1" do
      [0,2].each do |i|
        p items[i]
        expect{ subject.update_quality }.to change{ items[i].quality }.by -1
      end
    end
    it "should not decrease sulfuras quality" do
      [3,4].each do |i|
        expect{ subject.update_quality }.to change{ items[i].sell_in }.by 0
      end
    end
  end
end
