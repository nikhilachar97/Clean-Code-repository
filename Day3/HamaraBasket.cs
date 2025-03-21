using System.Collections.Generic;

namespace hamaraBasket
{
    public class RegularItem : Item
    {
        public RegularItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseSellIn();
            if (SellIn < 0)
            {
                DecreaseQuality();
            }
        }
    }

    public class IndianWine : Item
    {
        public IndianWine(int sellIn, int quality) : base("Indian Wine", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            DecreaseSellIn();
            if (SellIn < 0)
            {
                IncreaseQuality();
            }
        }
    }

    public class MovieTickets : Item
    {
        public MovieTickets(int sellIn, int quality) : base("Movie Tickets", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (SellIn > 10)
            {
                IncreaseQuality(1);
            }
            else if (SellIn > 5)
            {
                IncreaseQuality(2);
            }
            else if (SellIn > 0)
            {
                IncreaseQuality(3);
            }
            else
                Quality = 0; 

            DecreaseSellIn();
        }
    }

    public class ForestHoney : Item
    {
        public ForestHoney(int sellIn, int quality) : base("Forest Honey", sellIn, quality)
        {
        }
    }

    public class HamaraBasket
    {
        private IList<Item> Items;

        public HamaraBasket(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
            }
        }
    }
}
