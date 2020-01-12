using System;
using System.Drawing;

namespace Deef.GameEngine.Updaters
{
    public class ManaComponent : IUpdate, IRender
    {
        public ManaComponent(World world)
        {
            
        }

        public int Left { get; set; } = 43;
        public int Top { get; set; } = 5;

        public void Update(GameTime gameTime)
        {
            Mana?.Update(gameTime);
        }
        public RegenAttribute Mana { get; set; }
        public void Render(GameTime gameTime)
        {
            if (Math.Abs(Mana.OldCurrent - Mana.Current) > 0.001)
            {
                var manaString = $"✶ Mana  : {Convert.ToInt32(Mana.Current), -3}/{Mana.Max, 3}|";
                manaString.WriteWithCursorRestore(Left, Top, Color.LightSkyBlue);
                Mana.OldCurrent = Mana.Current;
            }
        }
    }
}