using System;
using System.Collections.Generic;

namespace hamaraBasket.Tests
{
    public class DomainFactory
    {
        public void InitAndUpdateRules(IList<Item> Items)
        {
            HamaraBasket aHamaraBasket = new HamaraBasket(Items);
            aHamaraBasket.UpdateQuality();
        }

        public IList<Item> PrepareSingleItemList(string aName, int aSellin, int aQuality)
        {
            Item item;
            switch (aName)
            {
                case "Indian Wine":
                    item = new IndianWine(aSellin, aQuality);
                    break;
                case "Movie Tickets":
                    item = new MovieTickets(aSellin, aQuality);
                    break;
                case "Forest Honey":
                    item = new ForestHoney(aSellin, aQuality);
                    break;
                default:
                    item = new RegularItem(aName, aSellin, aQuality);
                    break;
            }
            return new List<Item> { item };
        }
    }
}
