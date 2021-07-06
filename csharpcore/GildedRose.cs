using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<ItemDecorator> Items;
        public GildedRose(IList<ItemDecorator> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.Update();
            }
        }
    }
}
