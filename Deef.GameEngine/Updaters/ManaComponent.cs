using System;
using System.Drawing;

namespace Deef.GameEngine.Updaters
{
    public class ManaComponent : IUpdate, IRender
    {
        public ManaComponent(World world)
        {
            
        }

        public int Left { get; set; } = 30;
        public int Top { get; set; } = 5;

        public void Update(GameTime gameTime)
        {
            if (Mana != null)
            {
                Mana.Update(gameTime);
            }
        }
        public RegenAttribute Mana { get; set; }
        public void Render(GameTime gameTime)
        {
            
            var manaString = $"✶ Mana  : {Convert.ToInt32(Mana.Current), -3}/{Mana.Max, 3} | {Mana.RegenRatePerSecond.ToString("F1"), 3} /s|";
            manaString.WriteWithCursorRestore(Left, Top, Color.LightSkyBlue);
        }
    }
}