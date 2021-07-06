namespace csharpcore
{
    /// <summary>
    /// - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    /// - "Sulfuras" is legendary item and as such its Quality is 80 and it never alters.
    /// </summary>
    public class LegendaryItem:ItemDecorator
    {

        public static int _quality = 80;

        public LegendaryItem()
        {
            _internal.Quality = _quality;
        }
        public override int Quality
        {
            get => _internal.Quality;
            set => _internal.Quality = value==80?value:80;
        }

        public override void Update()
        {
        }
    }
}