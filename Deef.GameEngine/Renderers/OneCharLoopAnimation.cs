using System;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace Deef.GameEngine.Renderers
{
    public class OneCharLoopAnimation : IRender
    {
        private readonly char[] _frames;
        private readonly Color[] _colors;
        private readonly int _numberOfMsPerFrame;

        public OneCharLoopAnimation(char[] frames, Color[] colors, int numberOfMsPerFrame)
        {
            if (frames.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.", nameof(frames));
            }

            if (colors.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.", nameof(colors));
            }

            if (colors.Length != frames.Length)
            {
                throw new InvalidDataException("Number of colors must be the same as the number of frames.");
            }

            if (numberOfMsPerFrame <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfMsPerFrame));
            }

            _frames = frames;
            _colors = colors;
            _numberOfMsPerFrame = numberOfMsPerFrame;
        }
        private TimeSpan FrameInterval => TimeSpan.FromMilliseconds(_numberOfMsPerFrame);

        public int OldFrameIndex { get; private set; }

        private TimeSpan _previousRegenUpdateGameTime;
        private int _frameIndex = 0;

        public void Render(GameTime gameTime)
        {
            var elapsedTimeSincePrevious = gameTime.Elapsed.Subtract(_previousRegenUpdateGameTime);
            if (elapsedTimeSincePrevious >= FrameInterval)
            {
                //Every frame
                _frameIndex = (++_frameIndex % _frames.Length);
                _previousRegenUpdateGameTime = gameTime.Elapsed;
            }

            if (_frameIndex != OldFrameIndex)
            {
                Console.Write(_frames[_frameIndex], _colors[_frameIndex]);
                OldFrameIndex = _frameIndex;
            }
        }
    }
}