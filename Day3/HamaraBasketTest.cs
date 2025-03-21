using NUnit.Framework;
using System.Collections.Generic;

namespace hamaraBasket.Tests
{
    [TestFixture]
    public class HamaraBasketTest
    {
        private DomainFactory myDomainFactory;

        [SetUp]
        public void Setup()
        {
            this.myDomainFactory = new DomainFactory();
        }

        [Test]
        public void GenericItemSellShouldReduceBy1()
        {
            IList<Item> Items = PrepareSingleItemList("LifeBuoy Soap", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void GenericItemQualityShouldReduceBy1()
        {
            IList<Item> Items = PrepareSingleItemList("LifeBuoy Soap", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(9));
        }

        [Test]
        public void GenericItemQualityShouldReduceBy2AfterSellByDate()
        {
            IList<Item> Items = PrepareSingleItemList("LifeBuoy Soap", 0, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(8));
        }

        [Test]
        public void GenericItemQualityShouldNotBeNegative()
        {
            IList<Item> Items = PrepareSingleItemList("LifeBuoy Soap", 10, 0);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void IndianWineQualityShouldIncreaseBy1()
        {
            IList<Item> Items = PrepareSingleItemList("Indian Wine", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void QualityOfAnItemShouldNotExceed50()
        {
            IList<Item> Items = PrepareSingleItemList("Indian Wine", 10, 50);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(50));
        }

        [Test]
        public void IndianWineSellInShouldDecreaseBy1()
        {
            IList<Item> Items = PrepareSingleItemList("Indian Wine", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void ForestHoneyQualityShouldNotChange()
        {
            IList<Item> Items = PrepareSingleItemList("Forest Honey", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(10));
        }

        [Test]
        public void ForestHoneySellInShouldNotChange()
        {
            IList<Item> Items = PrepareSingleItemList("Forest Honey", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(10));
        }

        [Test]
        public void MovieTicketsQualityShouldIncreaseBy1()
        {
            IList<Item> Items = PrepareSingleItemList("Movie Tickets", 15, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void MovieTicketsSellinShouldDecreaseBy1()
        {
            IList<Item> Items = PrepareSingleItemList("Movie Tickets", 15, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(14));
        }

        [Test]
        public void MovieTicketsQualityShouldIncreaseBy2When10DaysOrLess()
        {
            IList<Item> Items = PrepareSingleItemList("Movie Tickets", 10, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(12));
        }

        [Test]
        public void MovieTicketsQualityShouldIncreaseBy3When5DaysOrLess()
        {
            IList<Item> Items = PrepareSingleItemList("Movie Tickets", 5, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void MovieTicketsQualityShouldDropTo0AfterShow()
        {
            IList<Item> Items = PrepareSingleItemList("Movie Tickets", 0, 10);
            InitAndUpdateRules(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void IndianWineQualityIncreasesTwiceAsSellInIsPassed()
        {
            string name = "Indian Wine";
            int sellIn = 0;
            int quality = 10;
            IList<Item> Items = PrepareSingleItemList(name, sellIn, quality);

            InitAndUpdateRules(Items);

            Assert.That(quality + 2, Is.EqualTo(Items[0].Quality));
        }

        private void InitAndUpdateRules(IList<Item> Items)
        {
            this.myDomainFactory.InitAndUpdateRules(Items);
        }

        private IList<Item> PrepareSingleItemList(string aName, int aSellin, int aQuality)
        {
            return this.myDomainFactory.PrepareSingleItemList(aName, aSellin, aQuality);
        }
    }
}
