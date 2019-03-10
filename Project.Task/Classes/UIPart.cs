using Project.Common.Core.Interfaces;
using Project.Task.Interfaces;

namespace Project.Task.Classes
{
    static class UIPart
    {
        public static int Counter { get; set; } = 0;

        public static IInformation Writer { get; set; }

        /// <summary>
        /// Event handler prints message on the screen.
        /// </summary>
        /// <param name="sender">Object that initiated event.</param>
        /// <param name="e">Message that will be printed.</param>
        public static void OupputMessage(object sender, string e)
        {
            Writer.SetCursorPosition(0, Counter);
            PrintString(e);
        }

        /// <summary>
        /// Prints stats about object.
        /// </summary>
        /// <param name="obj">Object of IChangeable interface.</param>
        public static void PrintStats(IChangeable obj)
        { 
            PrintString("Regime is : " + ObjectController.Regime + '\n');
            PrintString(obj.ToString());
        }

        /// <summary>
        /// Draws line between user UI part and system of coordinates.
        /// </summary>
        public static void DrawLine()
        {
            for (var height = 0; height < Writer.WindowHeight; height++)
            {
                Writer.SetCursorPosition(CoordinateSystem.EndOfUserUI - 1, height);
                Writer.Write("|");
            }

            Writer.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Prints string in certain area.
        /// </summary>
        /// <param name="str">String that will be printed.</param>
        public static void PrintString(string str)
        {
            var width = 0;

            for (var i = 0; i < str.Length; i++)
            {
                Writer.Write(str[i].ToString());

                if (str[i] == '\n')
                {
                    width = 0;
                    Counter++;
                }

                width++;

                if (width == CoordinateSystem.EndOfUserUI - 1)
                {
                    width = 0;
                    Writer.SetCursorPosition(width, ++Counter);
                }
            }

            Counter++;
        }
    }
}
