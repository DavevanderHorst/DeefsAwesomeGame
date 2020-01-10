using System;
using System.Collections.Generic;
using System.Text;

namespace Deef.GameEngine
{
    public class MonsterMovementSystem : IUpdate
    {
        private readonly World _world;
        private int _timeBeforeNextMove = 5;
        private TimeSpan RegenInterval => TimeSpan.FromSeconds(_timeBeforeNextMove);
        private TimeSpan _previousRegenUpdateGameTime;
        public MonsterMovementSystem(World world)
        {
            _world = world;
        }

        public void Update(GameTime gameTime)
        {
            MonsterPosition monsterPosition;
            if(_world.Has<MonsterPosition>())
            {
                monsterPosition = _world.Get<MonsterPosition>();
            }
            else
            {
                monsterPosition = new MonsterPosition();
            }

            var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(_previousRegenUpdateGameTime);
            if (elapsedTimeSincePrevious >= RegenInterval)
            {
                _previousRegenUpdateGameTime = gameTime.Elapsed;
                Random rdm = new Random(Environment.TickCount);
                _timeBeforeNextMove = rdm.Next(2, 9);
                int moveToRandomDirection = rdm.Next(0, 4);
                switch (moveToRandomDirection)
                {
                    case 0 :
                        monsterPosition.MoveDown();
                        break;
                    case 1 :
                        monsterPosition.MoveUp();
                        break;
                    case 2 :
                        monsterPosition.MoveLeft();
                        break;
                    case 3 :
                        monsterPosition.MoveRight();
                        break;
                }
            }
            else
            {
                monsterPosition.Changed = false;
            }
        }
    }
}
