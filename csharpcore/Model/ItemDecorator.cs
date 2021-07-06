namespace csharpcore
{
    /// <summary>
    /// New Class to sit over the Item Class due to the following:
    /// "do not alter the Item class or Items property as those belong to the
    /// goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
    /// ownership"
    /// </summary>
    public class ItemDecorator
    {

        protected Item _internal = new Item();

        public virtual string Name
        {
            get { return _internal.Name; }
            set { _internal.Name = value; }
        }

        public int SellIn
        {
            get { return _internal.SellIn; }
            set { _internal.SellIn = value; }
        }
        
        /// <summary>
        /// -	The Quality of an item is never negative
        /// -	The Quality of an item is never more than 50
        /// </summary>
        public virtual int Quality
        {
            get { return _internal.Quality; }
            set
            {
                int _quality;
                _quality = value > 50 ? 50 : (value < 0)?0:value;
                _internal.Quality = _quality;
            }
            
        }

        /// <summary>
        /// -	At the end of each day our system lowers both values for every item
        /// -	Once the sell by date has passed, Quality degrades twice as fast
        /// -	The Quality of an item is never negative
        /// </summary>
        public virtual void Update()
        {
            SellIn -= 1;
            Quality -= 1;
            if (SellIn < 0)
                Quality -= 1;
        }
    }
}