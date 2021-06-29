namespace csharpcore
{
    /// <summary>
    /// - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    /// - "Sulfuras" is legendary item and as such its Quality is 80 and it never alters.
    /// </summary>
    public class LegendaryItem:BetterItem
    {

        public int _quality = 80;
        public override int Quality
        {
            get => _quality;
            set => _quality = value==80?value:80;
        }

        public override void Update()
        {
        }
    }
}