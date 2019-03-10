namespace Project.Task.Interfaces
{
    interface IRectangle : IChangeable
    {
        /// <summary>
        /// Changes size of object.
        /// </summary>
        /// <param name="height">Height of object.</param>
        /// <param name="width">Width of object.</param>
        void Resize(int height, int width);
    }
}
