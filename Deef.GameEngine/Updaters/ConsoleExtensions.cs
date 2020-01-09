using System.Drawing;
using Colorful;

namespace Deef.GameEngine.Updaters
{
    public static class ConsoleExtensions
    {
        public static void WriteWithCursorRestore(this string value, int left, int top, Color color = default)
        {
            var prevPositionTop = Console.CursorTop;
            var prevPositionLeft = Console.CursorLeft;


            Console.SetCursorPosition(left, top);
          
            if (color == default)
            {
                Console.Write(value);
            }
            else
            {
                Console.Write(value, color);
            }

            Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
        }
    }
}