namespace Project.Common.Core.Interfaces
{
    public interface IRunnable
    {
        /// <summary>
        /// This is general task method, here is described logic of types behavior.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        void Run(IInformation view);
    }
}
