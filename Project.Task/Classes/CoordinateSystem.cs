using Project.Common.Core.Interfaces;
using Project.Task.Interfaces;

namespace Project.Task.Classes
{
    class CoordinateSystem : IDrawable
    {
        private readonly int startX;
        private readonly int startY;
        private readonly IInformation writer;

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        public CoordinateSystem(IInformation view)
        {
            this.writer = view;
            this.startX = this.writer.WindowWidth / 2;
            this.startY = this.writer.WindowHeight / 2;
        }

        public static int EndOfUserUI { get; } = 30;

        /// <summary>
        /// Prints system of coordinates on the screen.
        /// </summary>
        /// <param name="symbol">Character from which the figure will be formed.</param>
        public void Draw(char symbol = '*')
        {
            this.writer.SetCursorPosition(0, 0);

            for (var heigth = 0; heigth < this.writer.WindowHeight; heigth++)
            {
                this.DrawSymbol(this.startX, heigth, symbol);
            }

            for (var width = EndOfUserUI; width < this.writer.WindowWidth; width++)
            {
                this.DrawSymbol(width, this.startY, symbol);
            }
        }

        /// <summary>
        /// Methods draws some symbol in appropriate position.
        /// </summary>
        /// <param name="xCoordinate">X-coordinate of point to draw.</param>
        /// <param name="yCoordinate">Y-coordinate of point to draw.</param>
        /// <param name="symbol">Symbol that will be printed.</param>
        private void DrawSymbol(int xCoordinate, int yCoordinate, char symbol)
        {
            this.writer.SetCursorPosition(xCoordinate, yCoordinate);
            this.writer.Write(symbol.ToString());
        }
    }
}
