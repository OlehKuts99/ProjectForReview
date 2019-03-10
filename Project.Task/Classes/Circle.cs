using System;
using Project.Common.Core.Interfaces;
using Project.Task.Interfaces;

namespace Project.Task.Classes
{
    class Circle : ICircle
    {
        private const string Name = "Circle";
        private readonly IInformation writer;
        private Point center;

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        public Circle(IInformation view)
        {
            this.writer = view;
            this.center.X = this.writer.WindowWidth / 2;
            this.center.Y = this.writer.WindowHeight / 2;
        }

        /// <summary>
        /// Constructor sets the origin of the coordinates to the middle of the window and object which responses for
        /// input/output information in program also it sets value for radius of circle.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        /// <param name="radius">Radius of circle.</param>
        public Circle(IInformation view, int radius) : this(view)
        { 
            this.Radius = radius;
        }

        public event EventHandler<string> IncorrectRadius;

        public int Radius { get; set; }

        /// <summary>
        /// Overrided method to print stats of current object.
        /// </summary>
        /// <returns>String with stats of object.</returns>
        public override string ToString()
        {
            var result = Name;
            result += $"\nCenter position is ({this.center.X - this.writer.WindowWidth / 2}," +
                $" {this.writer.WindowHeight / 2 - this.center.Y})\nRadius is {this.Radius}";

            return result;
        }

        /// <summary>
        /// This method prints circle on the screen.
        /// </summary>
        /// <param name="symbol">Character from which the figure will be formed.</param>
        public void Draw(char symbol = '*')
        {
            int x = this.Radius * (-1);
            while (x <= this.Radius)
            {
                var y = (int)Math.Floor(Math.Sqrt(this.Radius * this.Radius - x * x));

                if (x + this.center.X == this.writer.WindowWidth / 2 || y + this.center.Y == this.writer.WindowHeight / 2)
                {
                    y = -y;
                }
                else
                {
                    this.DrawSymbol(x + this.center.X, y + this.center.Y, symbol);
                    y = -y;
                }

                if (x + this.center.X == this.writer.WindowWidth / 2 || y + this.center.Y == this.writer.WindowHeight / 2)
                {
                    x += 1;
                }
                else
                {
                    this.DrawSymbol(x + this.center.X, y + this.center.Y, symbol);
                    x += 1;
                }
            }
        }

        /// <summary>
        /// Moves circle in certain direction.
        /// </summary>
        /// <param name="x">Value that will change X coordinate of center point.</param>
        /// <param name="y">Value that will change Y coordinate of center point.</param>
        public void Move(int x, int y)
        {
            this.center.X += x;
            this.center.Y += y;

            if (this.CheckPosition())
            {
                this.center.X -= x;
                this.center.Y -= y;
            }
        }

        /// <summary>
        /// Changes size of circle.
        /// </summary>
        /// <param name="changeRadius">Value that will change radius of circle.</param>
        public void Resize(int changeRadius)
        {
            this.Radius += changeRadius;

            if (this.CheckPosition())
            {
                this.Radius -= changeRadius;
            }
        }

        /// <summary>
        /// Method returns new, the smallest circle which can contains two other circles inside. 
        /// </summary>
        /// <param name="firstObject">First circle.</param>
        /// <param name="secondObject">Second circle.</param>
        /// <returns>New circle.</returns>
        public IChangeable BuildTheSmallest(IChangeable firstObject, IChangeable secondObject)
        {
            var circle = new Circle(this.writer)
            {
                Radius = ((Circle)firstObject).Radius + ((Circle)secondObject).Radius
            };

            return circle;
        }

        /// <summary>
        /// Checks if circle is in allowed zone (within the screen).
        /// </summary>
        /// <returns>True if circle moves outside the screen.</returns>
        private bool CheckPosition()
        {
            if (this.center.Y < this.Radius || this.center.Y + this.Radius > this.writer.WindowHeight - 1 ||
                this.center.X + this.Radius > this.writer.WindowWidth - 1 || 
                this.center.X - this.Radius < CoordinateSystem.EndOfUserUI)
            {
                return true;
            }

            if (this.Radius < 0)
            {
                this.IncorrectRadius += UIPart.OupputMessage;

                try
                {
                    this.IncorrectRadius(this, "Radius can't be < 0 !\n");
                    this.IncorrectRadius -= UIPart.OupputMessage;
                }
                catch (NullReferenceException)
                {
                    this.Radius = 1;
                    throw new NullReferenceException("IncorrectRadius event is null!\n");
                }

                this.Radius = 1;
            }

            return false;
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
