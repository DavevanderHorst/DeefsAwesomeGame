using Colorful;
using System.Drawing;
using Deef.GameEngine.Updaters;

namespace Deef.GameEngine.Renderers
{
    public class MonsterRenderSystem : IRender
    {
        private readonly World _world;

        public MonsterRenderSystem(World world)
        {
            _world = world;
        }
        public void Render(GameTime gameTime)
        {
            if (_world.Has<MonsterPosition>())
            {
                var monsterPosition = _world.Get<MonsterPosition>();
                //if changed
                if (monsterPosition.Changed)
                {
                    var prevTop = monsterPosition.OldTop;
                    var prevLeft = monsterPosition.OldLeft;

                    //Clear write previous, or leave trail
                    " ".WriteWithCursorRestore(prevLeft, prevTop, Console.BackgroundColor);
                    "M".WriteWithCursorRestore(monsterPosition.Left, monsterPosition.Top, Color.GreenYellow);
                }
            }
        }
    }
}
