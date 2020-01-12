using System.Collections.Generic;
//using Colorful;
//using System.Drawing;
//using Deef.GameEngine.Updaters;

//namespace Deef.GameEngine.Renderers
//{
//    public class MonsterRenderSystem : IRender
//    {
//        private readonly World _world;

//        public MonsterRenderSystem(World world)
//        {
//            _world = world;
//        }
//        public void Render(GameTime gameTime)
//        {
//            if (_world.Has<List<Monster>>())
//            {
//                var monsters = _world.Get<List<Monster>>();
//                //if changed
//                foreach (var monster in monsters)
//                {
//                    if (monster.Mover.Changed)
//                    {
//                        var prevTop = monster.Mover.OldTop;
//                        var prevLeft = monster.Mover.OldLeft;

//                        //Clear write previous, or leave trail
//                        " ".WriteWithCursorRestore(prevLeft, prevTop, Console.BackgroundColor);
//                        "M".WriteWithCursorRestore(monster.Mover.Left, monster.Mover.Top, Color.GreenYellow);
//                        _world.MapIsChanged = true;
//                    }
//                }
//            }
//        }
//    }
//}
