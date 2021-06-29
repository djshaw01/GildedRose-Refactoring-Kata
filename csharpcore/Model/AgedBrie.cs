namespace csharpcore
{
    
    /// <summary>
    /// -	"Aged Brie" actually increases in Quality the older it gets
    /// </summary>
    public class AgedBrie:BetterItem
    {
        private string _name = "Aged Brie";
        public new string Name
        {
            get => _name;
            set => _name = (value == _name) ? value : _name;
        }
        public override void Update()
        {
            SellIn -= 1;
            Quality += 1;
        }
    }
}