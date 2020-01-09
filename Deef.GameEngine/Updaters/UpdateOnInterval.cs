using System;

namespace Deef.GameEngine.Updaters
{
    public class UpdateOnInterval : IUpdate
    {
        private readonly TimeSpan _interval;
        private readonly IUpdate _updaterToCall;

        private TimeSpan _previousInterval;

        public UpdateOnInterval(TimeSpan interval, IUpdate updaterToCall)
        {
            _interval = interval;
            _updaterToCall = updaterToCall;
        }

        public void Update(GameTime gameTime)
        {
            var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(_previousInterval);
            if (elapsedTimeSincePrevious >= _interval)
            {
                //Every Interval
                _updaterToCall.Update(gameTime);
            }

            _previousInterval = gameTime.Elapsed;
        }
    }
}