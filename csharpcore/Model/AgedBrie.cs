namespace csharpcore
{
    
    /// <summary>
    /// -	"Aged Brie" actually increases in Quality the older it gets
    /// </summary>
    public class AgedBrie:ItemDecorator
    {
        private static string _name = "Aged Brie";

        public AgedBrie()
        {
            _internal.Name = _name;
        }
        public override string Name
        {
            get => _internal.Name;
            set => _internal.Name = (value.Equals(_name)) ? value : _name;
        }

        public override void Update()
        {
            SellIn -= 1;
            Quality += 1;
        }
    }
}