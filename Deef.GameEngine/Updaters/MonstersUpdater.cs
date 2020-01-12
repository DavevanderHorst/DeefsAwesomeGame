using System;
using System.Collections.Generic;
using System.Text;

namespace Deef.GameEngine.Updaters
{
    public class MonstersUpdater : IUpdate
    {
        private readonly World _world;
        public MonstersUpdater(World world)
        {
            _world = world;
        }
        public void Update(GameTime gameTime)
        {
            List<Monster> monsters;
            if(_world.Has<List<Monster>>())
            {
                monsters = _world.Get<List<Monster>>();
            }
            else
            {
                monsters = new List<Monster>();
            }

            foreach (var monster in monsters)
            {
                var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(monster.MonsterMovementSystem._previousMoveUpdateGameTime);
                if (elapsedTimeSincePrevious >= monster.MonsterMovementSystem.MoveInterval)
                {
                    monster.MonsterMovementSystem._previousMoveUpdateGameTime = gameTime.Elapsed;
                    Random rdm = new Random();
                    monster.MonsterMovementSystem._timeBeforeNextMove = rdm.Next(20, 90)/10;
                    int moveToRandomDirection = rdm.Next(0, 4);
                    switch (moveToRandomDirection)
                    {
                        case 0 :
                            monster.Mover.MoveDown();
                            break;
                        case 1 :
                            monster.Mover.MoveUp();
                            break;
                        case 2 :
                            monster.Mover.MoveLeft();
                            break;
                        case 3 :
                            monster.Mover.MoveRight();
                            break;
                    }
                }
                else
                {
                    monster.Mover.Changed = false;
                }
            }
        }
    }
}
