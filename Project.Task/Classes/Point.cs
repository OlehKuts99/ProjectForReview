namespace Project.Task.Classes
{
    struct Point
    {
        /// <summary>
        /// Assigns X and Y coordiantes.
        /// </summary>
        /// <param name="x">Value to be assigned to X.</param>
        /// <param name="y">Value to be assigned to Y.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
