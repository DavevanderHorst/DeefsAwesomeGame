using System;
using System.Collections.Generic;
using System.Text;

namespace Deef.GameEngine
{
    public class MonsterMovementSystem
    {
        public readonly World _world;
        public int _timeBeforeNextMove;
        public TimeSpan MoveInterval => TimeSpan.FromSeconds(_timeBeforeNextMove);
        public TimeSpan _previousMoveUpdateGameTime;
        public MonsterMovementSystem(World world, int timeBeforeNextMove)
        {
            _world = world;
            _timeBeforeNextMove = timeBeforeNextMove;
        }
    }
}
