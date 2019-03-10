using System;
using System.Collections.Generic;
using Project.Common.Core.Interfaces;
using Project.Task.Interfaces;

namespace Project.Task.Classes
{
    class Rectangle : IRectangle
    {
        private const string Name = "Rectangle";
        private Point leftBottom;
        private readonly IInformation writer;

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        public Rectangle(IInformation view)
        {
            this.writer = view;
            this.leftBottom.X = this.writer.WindowWidth / 2;
            this.leftBottom.Y = this.writer.WindowHeight / 2;
        }

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program also it sets lengths of sides.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        /// <param name="width">Length of top and bottom sides of rectangle.</param>
        /// <param name="height">Length of left and right sides of rectangle.</param>
        public Rectangle(IInformation view, int width, int height) : this(view)
        {
            this.Height = height;
            this.Width = width;

            if (width > this.writer.WindowWidth / 2 || height > this.writer.WindowHeight / 2)
            {
                this.Height = 5;
                this.Width = 3;

                this.IncorrectSize += UIPart.OupputMessage;

                if (this.IncorrectSize != null)
                {
                    var message = "Width or height of rectangle is bigger than window size!\n" +
                        "Height is assigned to 5\nWidth is assigned to 3";

                    this.IncorrectSize(this, message);
                }
            }
        }

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program also it sets lengths of sides and coordinates of left-bottom point of
        /// rectangle.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        /// <param name="width">Length of top and bottom sides of rectangle.</param>
        /// <param name="height">Length of left and right sides of rectangle.</param>
        /// <param name="leftBottom">Left-bottom point of rectangle.</param>
        public Rectangle(IInformation view, int width, int height, Point leftBottom) : this(view)
        {
            this.leftBottom.X = this.writer.WindowWidth / 2 + leftBottom.X;
            this.leftBottom.Y = this.writer.WindowHeight / 2 - leftBottom.Y;
            this.Height = height;
            this.Width = width;

            if (this.Width + this.leftBottom.X - this.writer.WindowWidth / 2 >= this.writer.WindowWidth / 2 ||
                this.leftBottom.X <= CoordinateSystem.EndOfUserUI || this.leftBottom.Y < this.Height ||
                this.leftBottom.Y >= this.writer.WindowHeight)
            {
                this.Height = 5;
                this.Width = 3;
                this.leftBottom.X = this.writer.WindowWidth / 2;
                this.leftBottom.Y = this.writer.WindowHeight / 2;

                this.IncorrectSize += UIPart.OupputMessage;

                if (this.IncorrectSize != null)
                {
                    var message = "Rectangle has invalid coordinates and can't fits into dispaly!\n" +
                        "Height is assigned to 5\nWidth is assigned to 3\nCoordinates assigned to (0, 0)";

                    this.IncorrectSize(this, message);
                }
            }
        }

        public event EventHandler<string> IncorrectSize;

        public int Height { get; set; }

        public int Width { get; set; }

        /// <summary>
        /// Overrided method to print stats of current object.
        /// </summary>
        /// <returns>String with stats of object.</returns>
        public override string ToString()
        {
            var result = Name;
            result += $"\nX position is {this.leftBottom.X - this.writer.WindowWidth / 2}\n" +
                $"Y position is {this.writer.WindowHeight / 2 - this.leftBottom.Y}";
            result += $"\nWidth is {this.Width}\nHeight is {this.Height}";

            return result;
        }

        /// <summary>
        /// Method moves rectangle in appropriate direction.
        /// </summary>
        /// <param name="changeX">Value that will change X coordinate of left-bottom point.</param>
        /// <param name="changeY">Value that will change Y coordinate of left-bottom point.</param>
        public void Move(int changeX, int changeY)
        {
            this.leftBottom.X += changeX;
            this.leftBottom.Y += changeY;

            if (this.CheckPosition())
            {
                this.leftBottom.X -= changeX;
                this.leftBottom.Y -= changeY;
            }
        }

        /// <summary>
        /// Method changes size of rectangle.
        /// </summary>
        /// <param name="height">New value of height in rectangle.</param>
        /// <param name="width">New value of width in rectangle.</param>
        public void Resize(int height, int width)
        {
            this.Height += height;
            this.Width += width;

            if (this.CheckPosition())
            {
                this.Height -= height;
                this.Width -= width;
            }
        }

        /// <summary>
        /// This method prints rectangle on the screen.
        /// </summary>
        /// <param name="symbol">Character from which the figure will be formed.</param>
        public void Draw(char symbol = '*')
        {
            this.SetDefaultSide();

            for (var j = this.leftBottom.X; j <= this.leftBottom.X + this.Width; j++)
            {
                for (var i = this.leftBottom.Y - this.Height; i <= this.leftBottom.Y; i++)
                {
                    if (j == this.writer.WindowWidth / 2 
                        || i == this.writer.WindowHeight / 2)
                    {
                        continue;
                    }

                    if (j == this.leftBottom.X || j == this.leftBottom.X + this.Width || i == this.leftBottom.Y - this.Height
                        || i == this.leftBottom.Y)
                    {
                        this.DrawSymbol(j, i, symbol);
                    }
                }
            }
        }

        /// <summary>
        /// Method returns new, the smallest rectangle which can contains two other rectangles inside. 
        /// </summary>
        /// <param name="rectangleFirts">First rectangle.</param>
        /// <param name="rectangleSecond">Second rectangle.</param>
        /// <returns>New rectangle.</returns>
        public IChangeable BuildTheSmallest(IChangeable rectangleFirts, IChangeable rectangleSecond)
        {
            Rectangle temp = new Rectangle(this.writer)
            {
                Height = ((Rectangle)rectangleFirts).Height + ((Rectangle)rectangleSecond).Height,
                Width = ((Rectangle)rectangleFirts).Width > ((Rectangle)rectangleSecond).Width ? 
                ((Rectangle)rectangleFirts).Width : ((Rectangle)rectangleSecond).Width
            };

            return temp;
        }

        /// <summary>
        /// This method returns rectangle which will be created as a result of intersection two other rectangles.
        /// </summary>
        /// <param name="rectangleFirst">First rectangle.</param>
        /// <param name="rectangleSecond">Secind rectangle.</param>
        /// <returns>New rectangle.</returns>
        public Rectangle RectangleIntersection(Rectangle rectangleFirst, Rectangle rectangleSecond)
        { 
            Rectangle temp = new Rectangle(this.writer);
            int index = 0;

            int[][] firstRectangleCoordinates = new int[2][]
            {
                new int[rectangleFirst.leftBottom.X + rectangleFirst.Width - rectangleFirst.leftBottom.X + 1],
                new int[rectangleFirst.Height + 1]
            };

            int[][] secondRectangleCoordinates = new int[2][]
            {
                new int[rectangleSecond.leftBottom.X + rectangleSecond.Width - rectangleSecond.leftBottom.X + 1],
                new int[rectangleSecond.Height + 1]
            };

            for (var i = rectangleFirst.leftBottom.X; i <= rectangleFirst.leftBottom.X + rectangleFirst.Width; i++)
            {
                firstRectangleCoordinates[0][index] = i;
                index++;
            }

            index = 0;
            for (var i = rectangleFirst.leftBottom.Y - rectangleFirst.Height; i <= rectangleFirst.leftBottom.Y; i++)
            {
                firstRectangleCoordinates[1][index] = i;
                index++;
            }

            index = 0;
            for (var i = rectangleSecond.leftBottom.X; i <= rectangleSecond.leftBottom.X + rectangleSecond.Width; i++)
            {
                secondRectangleCoordinates[0][index] = i;
                index++;
            }

            index = 0;
            for (var i = rectangleSecond.leftBottom.Y - rectangleSecond.Height; i <= rectangleSecond.leftBottom.Y; i++)
            {
                secondRectangleCoordinates[1][index] = i;
                index++;
            }

            List<int> xCoordinates = this.GeneralPart(firstRectangleCoordinates[0], secondRectangleCoordinates[0]);
            List<int> yCoordinates = this.GeneralPart(firstRectangleCoordinates[1], secondRectangleCoordinates[1]);

            temp.Width = xCoordinates[xCoordinates.Count - 1] - xCoordinates[0];
            temp.Height = yCoordinates[yCoordinates.Count - 1] - yCoordinates[0];

            return temp;
        }

        /// <summary>
        /// Returns common part of two arrays.
        /// </summary>
        /// <param name="firstArray">First array.</param>
        /// <param name="secondArray">Second array.</param>
        /// <returns>Common part of two arrays.</returns>
        private List<int> GeneralPart(int[] firstArray, int[] secondArray)
        {
            List<int> coordinates = new List<int>();

            for (var i = 0; i < firstArray.Length; i++)
            {
                for (var j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        coordinates.Add(firstArray[i]);
                    }
                }
            }

            return coordinates;
        }

        /// <summary>
        /// Checks if rectangle is in allowed zone (within the screen).
        /// </summary>
        /// <returns>True if rectangle moves outside the screen.</returns>
        private bool CheckPosition()
        {
            if (this.Width + this.leftBottom.X - this.writer.WindowWidth / 2 >= this.writer.WindowWidth / 2 ||
                    this.leftBottom.X <= CoordinateSystem.EndOfUserUI - 1 || this.leftBottom.Y < this.Height ||
                    this.leftBottom.Y >= this.writer.WindowHeight)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Assignes default values to sides of rectangle.
        /// </summary>
        private void SetDefaultSide()
        {
            if (this.Height == 0 || this.Width == 0)
            {
                this.IncorrectSize += UIPart.OupputMessage;

                try
                {
                    var message = "Some of sides is 0!\nAssigned default values!\n";
                    this.IncorrectSize(this, message);
                    this.IncorrectSize -= UIPart.OupputMessage;
                }
                catch (NullReferenceException)
                {
                    this.Height = 5;
                    this.Width = 3;
                    throw new NullReferenceException("IncorrectSize event is null!\n");
                }
             
                this.Height = 5;
                this.Width = 3;
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
