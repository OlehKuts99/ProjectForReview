namespace Project.Task.Interfaces
{
    interface IDrawable
    {
        /// <summary>
        /// Responses for drawing of objects.
        /// </summary>
        /// <param name="symbol">Character from which the figure will be formed.</param>
        void Draw(char symbol = '*');
    }
}
