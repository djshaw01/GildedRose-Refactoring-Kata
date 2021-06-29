namespace csharpcore
{
    public class BackStagePass:AgedBrie
    {
        /// <summary>
        /// -	"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        /// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        /// Quality drops to 0 after the concert
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (SellIn <= 10)
                Quality += 1;
            if (SellIn < 5)
                Quality += 1;
            if (SellIn < 0)
                Quality = 0;
        }
    }
}