using System;
using System.Diagnostics;

namespace Deef.GameEngine
{
    public class GameEngine
    {
        private readonly IUpdate[] _updateSystems;
        private readonly IRender[] _renderSystems;
        private readonly Stopwatch _gameStopWatch = new Stopwatch();
        private bool _shouldRun = true;

        public GameEngine()
        {
        }

        public GameEngine(IUpdate[] updateSystems, IRender[] renderSystems): this() // what does this 'this' do ???
        {
            _updateSystems = updateSystems;
            _renderSystems = renderSystems;
        }

        public GameTime GameTime { get; } = new GameTime();

        public void Start()
        {
            _gameStopWatch.Start();
           
            while (_shouldRun)
            {
                Tick();
            }
        }

        private TimeSpan _previousElapsedTime;

        public void Tick()
        {
            var gameTimeElapsed = _gameStopWatch.Elapsed;
            GameTime.RelativeElapsedTime = gameTimeElapsed.Subtract(_previousElapsedTime);

            GameTime.Elapsed = gameTimeElapsed;
            _previousElapsedTime = gameTimeElapsed;

            DoUpdate(GameTime);
            DoRender(GameTime);
        }


        private void DoUpdate(GameTime gameTime)
        {
            foreach (var updateSystem in _updateSystems)
            {
                updateSystem.Update(gameTime);
            }
        }

        private void DoRender(GameTime gameTime)
        {
            foreach (var renderSystem in _renderSystems)
            {
                renderSystem.Render(gameTime);
            }
        }
    }
}