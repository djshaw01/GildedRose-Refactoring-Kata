namespace csharpcore
{
    public class BetterItemBuilder
    {
        public BetterItem build(Item item)
        {
            if (item.Name.StartsWith("Conjured"))
            {
                return new ConjuredItem() {Name = item.Name, Quality = item.Quality, SellIn = item.SellIn};
            }
            if (item.Name.StartsWith("Backstage Passes"))
            {
                return new BackStagePass() {Name = item.Name, Quality = item.Quality, SellIn = item.SellIn};
            }
            if (item.Name.StartsWith("Sulfuras"))
            {
                return new LegendaryItem() {Name = item.Name, SellIn = item.SellIn};
            }
            if ("Aged Brie".Equals(item.Name))
            {
                return new AgedBrie() {Name = item.Name, Quality = item.Quality, SellIn = item.SellIn};
            }


            return new BetterItem() {Name = item.Name, Quality = item.Quality, SellIn = item.SellIn};
        }
    }
}