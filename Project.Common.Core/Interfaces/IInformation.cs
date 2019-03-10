namespace Project.Common.Core.Interfaces
{
    public interface IInformation
    {
        /// <summary>
        /// Width of screen in certain enviroument.
        /// </summary>
        int WindowWidth { get; }

        /// <summary>
        /// Height of screen in certain enviroument.
        /// </summary>
        int WindowHeight { get; }

        /// <summary>
        /// Sets cursor in certain output screen.
        /// </summary>
        /// <param name="left">Retreat from left edge of screen.</param>
        /// <param name="top">Retreat from top edge of screen.</param>
        void SetCursorPosition(int left, int top);

        /// <summary>
        /// Prints in output screen some string without transition on new line.
        /// </summary>
        /// <param name="str">String to be printed.</param>
        void Write(string str);

        /// <summary>
        /// Prints in output screen some string with transition on new line.
        /// </summary>
        /// <param name="str">String to be printed.</param>
        void WriteLine(string str);

        /// <summary>
        /// Reads string which inputs user.
        /// </summary>
        /// <returns>String which inputed user.</returns>
        string Read();

        /// <summary>
        /// Deletes all symbols in console.
        /// </summary>
        /// <param name="EndOfUserUI">Width of user UI window.</param>
        void Clear(int EndOfUserUI);

        /// <summary>
        /// Obtains symbol and returns it code.
        /// </summary>
        /// <param name="intercept">Sets whether to display inputed char or not.</param>
        /// <returns>Code of key.</returns>
        int ReadKey(bool intercept);
    }
}
