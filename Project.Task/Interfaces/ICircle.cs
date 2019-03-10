namespace Project.Task.Interfaces
{
    interface ICircle : IChangeable
    {
        /// <summary>
        /// Changes size of circle.
        /// </summary>
        /// <param name="changeRadius">Radius of circle.</param>
        void Resize(int changeRadius);
    }
}
