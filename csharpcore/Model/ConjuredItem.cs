namespace csharpcore
{
    /// <summary>
    /// -	"Conjured" items degrade in Quality twice as fast as normal items
    /// </summary>
    public class ConjuredItem:ItemDecorator
    {
        public override void Update()
        {
            base.Update();
            if (SellIn >= 0) /// Item degrades twice as fast if sell in is < 0, so only do this if sellin is >= 0
                Quality -= 1;
            else
                Quality -= 2; /// do does quality degrade 4 times as fast after the item has expired???
        }
    }
}