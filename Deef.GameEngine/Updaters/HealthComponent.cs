using System;
using System.Drawing;
using Deef.GameEngine.Renderers;
using Console = Colorful.Console;

namespace Deef.GameEngine.Updaters
{
    public class HealthComponent  : IUpdate, IRender
    {
        private readonly OneCharLoopAnimation _pulsingHeart;

        public HealthComponent(World world)
        {
           _pulsingHeart = new OneCharLoopAnimation(new[] {'♥', '♥', '♥', '♥', '♥', '♥', '♥', '♥'},
                new[]
                {
                    Color.DarkRed, Color.IndianRed, Color.MediumVioletRed, Color.DarkMagenta, Color.BlueViolet,
                    Color.MediumSlateBlue, Color.CornflowerBlue, Color.Blue
                }, 150);
        }

        public int Left { get; set; } = 43;
        public int Top { get; set; } = 4;

        public RegenAttribute Health { get; set; }

        public void Update(GameTime gameTime)
        {
            Health?.Update(gameTime);
        }

        public void Render(GameTime gameTime)
        {
            var prevPositionTop = Console.CursorTop;
            var prevPositionLeft = Console.CursorLeft;
            Console.SetCursorPosition(Left, Top);
            //var oldBgColor = Console.BackgroundColor;
            //Console.BackgroundColor = Color.Silver;
            _pulsingHeart.Render(gameTime);
            Console.SetCursorPosition(Left+1, Top);
            if (Math.Abs(Health.OldCurrent - Health.Current) > 0.001)
            {
                var currentHealthString = $" Health: {Health.Current, -3}/{Health.Max, 3}|";
                Console.Write(currentHealthString, Color.White);
            }

            Console.SetCursorPosition(prevPositionTop, prevPositionLeft);

           // Console.BackgroundColor = oldBgColor;
        }
    }
}