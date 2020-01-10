using System.Drawing;
using Colorful;
using Deef.GameEngine.Updaters;

namespace Deef.GameEngine
{
    public class PlayerRenderSystem : IRender
    {
        private readonly World _world;

        public PlayerRenderSystem(World world)
        {
            _world = world;
        }

        public void Render(GameTime gameTime)
        {
            //Get PlayerPosition from World;
            if (_world.Has<PlayerPosition>())
            {
                var playerPosition = _world.Get<PlayerPosition>();
                //if changed
                if (playerPosition.Changed)
                {
                    var prevTop = playerPosition.OldTop;
                    var prevLeft = playerPosition.OldLeft;

                    //Clear write previous, or leave trail
                    " ".WriteWithCursorRestore(prevLeft, prevTop, Console.BackgroundColor);
                    "X".WriteWithCursorRestore(playerPosition.Left, playerPosition.Top, Color.GreenYellow);
                }
            }
        }
    }
}