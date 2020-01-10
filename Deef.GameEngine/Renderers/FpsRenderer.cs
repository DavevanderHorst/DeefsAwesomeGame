using System.Drawing;
using Console = Colorful.Console;

namespace Deef.GameEngine.Renderers
{
    internal class FpsRenderer : IRender
    {
        private readonly World _world;
        private readonly OneCharLoopAnimation _defaultSpinnerAnimation;

        public FpsRenderer(World world)
        {
            _world = world;
            _defaultSpinnerAnimation = new OneCharLoopAnimation(
                new[] {'/', '-', '\\', '|'},
                new Color[] {Color.Crimson, Color.Gold , Color.DarkGreen, Color.Cyan}, 100);
        }

        public void Render(GameTime gameTime)
        {
            if (_world.Has<FpsCount>())
            {
                var prevPositionTop = Console.CursorTop;
                var prevPositionLeft = Console.CursorLeft;

                Console.SetCursorPosition(108, 0);
                _defaultSpinnerAnimation.Render(gameTime);

                Console.SetCursorPosition(109, 0);
                Console.Write($"[FPS: {_world.Get<FpsCount>().FramesPerSecond, 4}]", Color.BlueViolet);
                Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
            }
        }
    }
}