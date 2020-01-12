using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Deef.GameEngine.Updaters;

namespace Deef.GameEngine.Renderers
{
    public class PlayerMessageRenderSystem : IRender
    {
        private readonly World _world;

        public PlayerMessageRenderSystem(World world)
        {
            _world = world;
        }
        public void Render(GameTime gameTime)
        {
            if (_world.HasMessage)
            {
                if (_world.Has<Queue<string>>())
                {
                    var messageQueue = _world.Get<Queue<string>>();
                    int top = 15 + _world.WrongDirectionCount;
                    string toPrint = messageQueue.Dequeue();
                    toPrint.WriteWithCursorRestore(1,top,Color.IndianRed);

                }

                _world.HasMessage = false;
            }
            
        }
    }
}
