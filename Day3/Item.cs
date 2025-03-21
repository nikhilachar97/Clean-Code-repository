namespace hamaraBasket
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public virtual void UpdateQuality()
        {
        }

        protected void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }
        protected void DecreaseSellIn()
        {
            SellIn--;
        }

        protected void IncreaseQuality(int amount = 1)
        {
            Quality = Math.Min(50, Quality + amount);
        }

      
        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
