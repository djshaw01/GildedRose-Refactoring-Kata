using Xunit;
using AutoFixture;
using System.Collections.Generic;
using FluentAssertions;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact] 
        public void betteritem_builder_returns_correct_implementation_based_on_item_name()
        {
            var itemBuilder = _fixture.Build<BetterItemBuilder>()
                .Create();
            var item = itemBuilder.build(new Item() {Name = "Foobar", SellIn = 10, Quality = 10});
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(10);
            item.Should().BeOfType<BetterItem>();
            item = itemBuilder.build(new Item() {Name = "Conjured Mana Cake", SellIn = 10, Quality = 10});
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(10);
            item.Should().BeOfType<ConjuredItem>();
            item = itemBuilder.build(new Item() {Name = "Sulfuras", SellIn = 10, Quality = 10});
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(80);
            item.Should().BeOfType<LegendaryItem>();
            
            item = itemBuilder.build(new Item() {Name = "Aged Brie", SellIn = 10, Quality = 10});
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(10);
            item.Should().BeOfType<AgedBrie>();
            item = itemBuilder.build(new Item() {Name = "Backstage Passes to Metallica", SellIn = 10, Quality = 10});
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(10);
            item.Should().BeOfType<BackStagePass>();

            
        }


        [Fact] 
        public void basic_betteritem_quality_never_greater_than_50()
        {
            var item = _fixture.Build<BetterItem>()
                .With(i => i.Name, "FooBar")
                .With(i => i.Quality, 68)
                .With(i => i.SellIn, 10)
                .Create();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(50);
        }

        [Fact] 
        public void basic_betteritem_quality_never_less_than_0()
        {
            var item = _fixture.Build<BetterItem>()
                .With(i => i.Name, "FooBar")
                .With(i => i.Quality, 0)
                .With(i => i.SellIn, 10)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(9);
            quality.Should().Be(0);
        }

        [Fact] 
        public void basic_betteritem_update_reduces_sell_in_and_quality_after_update()
        {
            var item = _fixture.Build<BetterItem>()
                .With(i => i.Name, "FooBar")
                .With(i => i.Quality, 50)
                .With(i => i.SellIn, 10)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(9);
            quality.Should().Be(49);
        }
        
        [Fact] 
        public void basic_betteritem_update_reduces_sell_in_by_one_and_quality_by_two_after_update_if_sellin_less_than_zero()
        {
            var item = _fixture.Build<BetterItem>()
                .With(i => i.Name, "FooBar")
                .With(i => i.Quality, 10)
                .With(i => i.SellIn, 1)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(0);
            quality.Should().Be(9);
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(-1);
            quality.Should().Be(7);
        }
        
        [Fact] 
        public void agedbrie_increases_in_quality_the_older_it_gets()
        {
            var item = _fixture.Build<AgedBrie>()
                .With(i => i.Name, "Aged Brie")
                .With(i => i.Quality, 10)
                .With(i => i.SellIn, 1)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(0);
            quality.Should().Be(11);
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(-1);
            quality.Should().Be(12);
        }
        
        /// <summary>
        ///  "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        /// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        /// Quality drops to 0 after the concert
        /// </summary>
        [Fact] 
        public void backstage_pass_increases_in_quality_faster_the_older_it_gets_but_quality_to_zero_after_concert_passes()
        {
            var item = _fixture.Build<BackStagePass>()
                .With(i => i.Name, "Backstage passes to a TAFKAL80ETC concert")
                .With(i => i.Quality, 10)
                .With(i => i.SellIn, 12)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(11);
            quality.Should().Be(11);
            
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(10);
            quality.Should().Be(13); // quality increased twice as fast if there are ten days or less

            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(9);
            quality.Should().Be(15); // quality increased twice as fast if there are ten days or less


            item.SellIn = 5;
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(4);
            quality.Should().Be(18); // quality increased 3 times as fast if there are ten days or less

            item.SellIn = 0;
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(-1);
            quality.Should().Be(0); // quality drops to 0 after concert

        }
        [Fact] 
        public void sulfuras_never_needs_to_be_sold_and_quality_never_changes()
        {
            var item = _fixture.Build<LegendaryItem>()
                .With(i => i.Name, "Sulfuras")
                .With(i => i.Quality, 80)
                .With(i => i.SellIn, 50)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(50);
            quality.Should().Be(80);
        }

        [Fact] 
        public void conjured_items_quality_degrades_twice_as_fast_as_normal()
        {
            var item = _fixture.Build<ConjuredItem>()
                .With(i => i.Name, "Conjured Mana Cake")
                .With(i => i.Quality, 10)
                .With(i => i.SellIn, 8)
                .Create();
            item.Update();
            var sellin = item.SellIn;
            var quality = item.Quality;
            sellin.Should().Be(7);
            quality.Should().Be(8);

            item.SellIn = 0;
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(-1);
            quality.Should().Be(6);

            item.Quality = 0;
            item.Update();
            sellin = item.SellIn;
            quality = item.Quality;
            sellin.Should().Be(-2);
            quality.Should().Be(0);

        }
        
    }
}