using System;

namespace Deef.GameEngine
{
    public class PlayerMovementSystem : IUpdate
    {
        private readonly World _world;

        public PlayerMovementSystem(World world)
        {
            _world = world;
        }

        public void Update(GameTime gameTime)
        {
            if (_world.Has<PlayerInput>())
            {
                var input = _world.Get<PlayerInput>();

                MovementHelper playerPosition;
                if(_world.Has<MovementHelper>())
                {
                    playerPosition = _world.Get<MovementHelper>();
                }
                else
                {
                    playerPosition = new MovementHelper();
                }
                

                if (input.Current != default)
                {
                    switch (input.Current.Key)
                    {
                        case ConsoleKey.DownArrow:
                            //Update position
                            playerPosition.MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            //Update position
                            playerPosition.MoveUp();
                            break;
                        case ConsoleKey.LeftArrow:
                            //Update position
                            playerPosition.MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            //Update position
                            playerPosition.MoveRight();
                            break;

                        default:
                            return;
                    }
                }
                else
                {
                    playerPosition.Changed = false;
                }
            }
        }
    }
}