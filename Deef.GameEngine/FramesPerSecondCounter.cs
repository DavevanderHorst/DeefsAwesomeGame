using System;

namespace Deef.GameEngine
{
    public class FramesPerSecondCounter : IUpdate, IRender
    {
        private readonly World _world;
        private static readonly TimeSpan OneSecondTimeSpan = new TimeSpan(0, 0, 1);
        private int _framesCounter;
        private TimeSpan _timer = OneSecondTimeSpan;

        public FramesPerSecondCounter(World world)
        {
            _world = world;
        }
        public int FramesPerSecond { get; set; }
        

        public void Update(GameTime gameTime)
        {
            _timer += gameTime.RelativeElapsedTime;
            if (_timer <= OneSecondTimeSpan)
            {
                return;
            }

            FramesPerSecond =  _framesCounter;
            _framesCounter  =  0;
            _timer          -= OneSecondTimeSpan;

            if (_world.Has<FpsCount>())
            {
                var count = _world.Get<FpsCount>();
                count.FramesPerSecond = FramesPerSecond;
            }
            else
            {
                _world.Set(new FpsCount{FramesPerSecond = FramesPerSecond});
            }
        }

        public void Render(GameTime gameTime)
        {
            _framesCounter++;
        }
    }
}