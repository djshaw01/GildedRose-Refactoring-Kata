namespace csharpcore
{
    /// <summary>
    /// -	"Conjured" items degrade in Quality twice as fast as normal items
    /// </summary>
    public class ConjuredItem:BetterItem
    {
        public override void Update()
        {
            base.Update();
            if(SellIn >= 0) /// Item degrades twice as fast if sell in is < 0, so only do this if sellin is >= 0
                Quality -= 1;
        }
    }
}