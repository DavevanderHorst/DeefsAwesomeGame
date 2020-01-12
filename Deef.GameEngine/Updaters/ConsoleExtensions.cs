using System;
using System.Drawing;
using Console = Colorful.Console;

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
        public static void RemoveExtraText(int howManyLines)
        {
            Console.SetCursorPosition(0,16);
            for (int i = 0; i < howManyLines; i++)
            {
                Console.WriteLine(new String(' ', Console.BufferWidth));
            }
        }
    }
}