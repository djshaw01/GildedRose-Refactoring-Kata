using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<BetterItem> Items;
        public GildedRose(IList<BetterItem> Items)
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
