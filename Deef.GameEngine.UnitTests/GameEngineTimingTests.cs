using System;
using Deef.GameEngine.Updaters;
using FluentAssertions;
using NUnit.Framework;

namespace Deef.GameEngine.UnitTests
{
    public class GameEngineTimingTests
    {
        private GameEngine _gameEngine;

        [SetUp]
        public void Setup()
        {
            _gameEngine = new GameEngine();
        }

        [Test]
        public void ElapsedGameTimeShouldProgressAfterTick()
        {
            _gameEngine.GameTime.Elapsed.Should().Be(default(TimeSpan));
            _gameEngine.Start();

            _gameEngine.Tick();
            var afterOneTick = _gameEngine.GameTime.Elapsed;
            afterOneTick.Should().BeGreaterThan(TimeSpan.FromTicks(0));

            _gameEngine.Tick();
            _gameEngine.GameTime.Elapsed.Should().BeGreaterThan(afterOneTick);
        }

        [Test]
        public void UpdateSystemShouldGetGameTime()
        {

            //Arrange
            var regenAttrHealth = new RegenAttribute { Name = "Health", Current = 100, Max = 200, RegenRatePerSecond = 0.5};
            var component = new HealthComponent(new World()) {Health = regenAttrHealth};

            GameTime gameTime = new GameTime();

            component.Update(gameTime);
            //Precondition
            component.Health.Current.Should().Be(100);
            
            //Act
            gameTime.Elapsed += TimeSpan.FromSeconds(2);
            component.Update(gameTime);

            //Assert
            component.Health.Current.Should().Be(101);
        }

        //TODO: TEST MAX

        [Test]
        public void ManaComponentShouldRegenerate()
        {
            //Arrange
            var regenAttrMana = new RegenAttribute { Name = "Mana", Current = 100, Max = 200, RegenRatePerSecond = 10};

            var component = new ManaComponent(new World()) {Mana = regenAttrMana};
            

            GameTime gameTime = new GameTime();

            component.Update(gameTime);
            //Precondition
            component.Mana.Current.Should().Be(100);
            
            //Act
            gameTime.Elapsed += TimeSpan.FromSeconds(2);
            component.Update(gameTime);

            //Assert
            component.Mana.Current.Should().Be(120);
        }

        //GameLoop maken, Tick doet -> Update / Render
        // 1 inputtje kunnen verwerken
        // 1 dingetje renderen
    }
}