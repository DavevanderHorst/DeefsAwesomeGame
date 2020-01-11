using System;
using System.Collections.Generic;
using System.Text;

namespace Deef.GameEngine
{
    public class Monster
    {
        public MonsterMovementSystem MonsterMovementSystem;
        public MovementHelper Mover;
        public Monster(World world, int startPositionLeft, int startPositionTop)
        {
            Random rdm = new Random();
            MonsterMovementSystem = new MonsterMovementSystem(world, rdm.Next(2,9));
            Mover = new MovementHelper();
            Mover.MoveTo(startPositionLeft,startPositionTop);
        }
    }
}
