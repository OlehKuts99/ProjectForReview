namespace Project.Task.Interfaces
{
    interface IChangeable : IDrawable
    {
        /// <summary>
        /// Moves object in certain direction.
        /// </summary>
        /// <param name="x">Value that will change X coordinate of certain object.</param>
        /// <param name="y">Value that will change Y coordinate of certain object.</param>
        void Move(int x, int y);

        /// <summary>
        /// Build the most possible small object which can contain two other objects.
        /// </summary>
        /// <param name="firstObject">First object.</param>
        /// <param name="secondObject">Second object.</param>
        /// <returns>New IChangeable object.</returns>
        IChangeable BuildTheSmallest(IChangeable firstObject, IChangeable secondObject);
    }
}
