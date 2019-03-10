using System;
using Project.Common.Core.Interfaces;

namespace Project.Common.Core.Classes
{
    public class ConsoleView : IInformation
    {
        /// <summary>
        /// Returns Console.WindowWidth property.
        /// </summary>
        public int WindowWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        /// <summary>
        /// Returns Console.WindowHeight property.
        /// </summary>
        public int WindowHeight
        {
            get
            {
                return Console.WindowHeight;
            }
        }

        /// <summary>
        /// Prints in console some string without transition on new line.
        /// </summary>
        /// <param name="str">String to be printed.</param>
        public void Write(string str)
        {
            Console.Write(str);
        }

        /// <summary>
        /// Prints in console some string with transition on new line.
        /// </summary>
        /// <param name="str">String to be printed.</param>
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Reads string which inputs user.
        /// </summary>
        /// <returns>String which inputed user.</returns>
        public string Read()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Sets cursore in console.
        /// </summary>
        /// <param name="left">Retreat from left edge of console.</param>
        /// <param name="top">Retreat from top edge in console.</param>
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Deletes all symbols in console.
        /// </summary>
        /// <param name="EndOfUserUI">Width of user UI window.</param>
        public void Clear(int EndOfUserUI)
        {
            for (var y = 0; y < Console.WindowHeight / 2; y++)
            {
                for (var x = 0; x < EndOfUserUI - 1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }
        }

        /// <summary>
        /// Obtains symbol and returns it code.
        /// </summary>
        /// <param name="intercept">Sets whether to display inputed char or not.</param>
        /// <returns>Code of key.</returns>
        public int ReadKey(bool intercept)
        {
            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo();

            consoleKeyInfo = Console.ReadKey(intercept);
            return Convert.ToInt32(consoleKeyInfo.Key);
        }
    }
}
