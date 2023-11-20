using GildedRoseKata;

namespace GildedRose_Tests;

public class GildedRose_AcceptanceTests
{

    [Fact]
    // At the end of each day, our system lowers Quality by one for every item
    public void UpdateQuality_Should_ReduceSellInByOne()
    {
        // Given the item has a sellInDays of 5
        var fooItem = createItem("Foo", 2, 5);
        var SUT = createGildedRose(fooItem);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the sellInDays is 4
        Assert.Equal(4, fooItem.SellIn);
    }

    [Fact]
    // At the end of each day, our system lowers SellIn for every item
    public void UpdateQuality_Should_ReduceQualityByOne()
    {
        // Given the item has a quality of 5
        var fooItem = createItem("Foo", 5, 4);
        var SUT = createGildedRose(fooItem );

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality is 4
        Assert.Equal(4, fooItem.Quality);
    }

    [Fact]
    // Once the sell-by date has passed, Quality degrades twice as fast
    public void UpdateQuality_Should_ReduceQualityByTwo_When_SellinIsNegative()
    {
        //GIVEN the sell-by date has passed
        var outDatedItem = createItem("Foo", 2, -1);
        var SUT = createGildedRose(outDatedItem);

        //WHEN the Quality Update occurs
        SUT.UpdateQuality();

        //THEN the quality degrades twice as fast
        Assert.Equal(0, outDatedItem.Quality);
    }

    [Fact]
    // The Quality of an item is never negative
    public void UpdateQuality_Should_ReturnZeroQuality_When_QualityIsAlreadyZero()
    {
        // Given the quality of an item is 0
        var zeroQualityItem = createItem("Foo", 0, 1);
        var SUT = createGildedRose(zeroQualityItem);

        // When the Quality Update occurs
        SUT.UpdateQuality();

        // Then the quality of the item is still 0
        Assert.Equal(0, zeroQualityItem.Quality);
    }

    [Fact]
    // "Aged Brie" actually increases in Quality the older it gets
    public void UpdateQuality_Should_IncreaseQualityByOne_When_ItemIsAgedBrie()
    {
        // Given the item name is "Aged Brie" and it's quality is 1
        var agedBrie = createItem("Aged Brie", 1, 5);
        var SUT = createGildedRose(agedBrie);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the aged brie should be 2
        Assert.Equal(2, agedBrie.Quality);
    }

    [Fact]
    // The Quality of an item is never more than 50
    public void UpdateQuality_Should_Return50Quality_When_AgedBrieQualityIsAlready50()
    {
        // Given the item is aged brie with a quality of 50
        var agedBrie = createItem("Aged Brie", 50, 50);
        var SUT = createGildedRose(agedBrie);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the aged brie should still be 50
        Assert.Equal(50, agedBrie.Quality);
    }


    [Fact]
    // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    public void UpdateQuality_Should_Return10Quality_When_QualityIsAlready10()
    {
        // Given the item is named "Sulfuras, Hand of Ragnaros" and has a quality of 10
        var sulfrasItem = createItem("Sulfuras, Hand of Ragnaros", 10, 10);
        var SUT = createGildedRose(sulfrasItem);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the Sulfras is still 10
        Assert.Equal(10, sulfrasItem.Quality);
    }

    [Theory]
    [InlineData(5, 10)]
    [InlineData(8, 6)]
    // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
    // Quality increases by 2 when there are 10 days or less
    // and by 3 when there are 5 days or less but Quality drops to 0 after the concert
    public void UpdateQuality_Should_IncreaseQualityByTwo_When_ItemIsBackstagePasses_And_SellInBetween10and6(int quality, int sellIn)
    {
        // Given the item is Backstage Passes and the Sell In value is between 10 and 6
        var backstagePasses = createItem("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);
        var SUT = createGildedRose(backstagePasses);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the Backstage Passes increases by two
        Assert.Equal(quality + 2, backstagePasses.Quality);
    }

    [Theory]
    [InlineData(5, 5)]
    [InlineData(8, 1)]
    // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
    // Quality increases by 2 when there are 10 days or less
    // and by 3 when there are 5 days or less but Quality drops to 0 after the concert
    public void UpdateQuality_Should_IncreaseQualityByThree_When_ItemIsBackstagePasses_And_SellInBetween5and1(int quality, int sellIn)
    {
        // Given the item is Backstage Passes and the Sell In value is between 10 and 6
        var backstagePasses = createItem("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);
        var SUT = createGildedRose(backstagePasses);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the Backstage Passes increases by three
        Assert.Equal(quality + 3, backstagePasses.Quality);
    }

    [Theory]
    [InlineData(5, 0)]
    [InlineData(8, -3)]
    // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
    // Quality increases by 2 when there are 10 days or less
    // and by 3 when there are 5 days or less but Quality drops to 0 after the concert
    public void UpdateQuality_Should_ChangeQualityToZero_When_ItemIsBackstagePasses_And_SellInLessThanOrEqualToZero(int quality, int sellIn)
    {
        // Given the item is Backstage Passes and the Sell In value is between 10 and 6
        var backstagePasses = createItem("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);
        var SUT = createGildedRose(backstagePasses);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the Backstage Passes is zero
        Assert.Equal(0, backstagePasses.Quality);
    }

    [Fact]
    // "Conjured" items degrade in Quality twice as fast as normal items
    public void UpdateQuality_Should_Return2Quality_When_ItemIsConjuredAndQualityIs4()
    {
        // Given the item is "Conjured" and it's quality is 4
        var conjured = createItem("Conjured", 4, 5);
        var SUT = createGildedRose(conjured);

        // When the quality update occurs
        SUT.UpdateQuality();

        // Then the quality of the "Conjured" item is 2
        Assert.Equal(2, conjured.Quality);
    }

    private Item createItem(string name, int quality, int sellIn) => new Item { Name = name, Quality = quality, SellIn = sellIn };
    private GildedRose createGildedRose(Item item) => new GildedRose(new List<Item> { item });
}