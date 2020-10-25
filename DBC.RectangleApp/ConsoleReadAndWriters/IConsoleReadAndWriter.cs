namespace DBC.RectangleApp.ConsoleReadAndWriters
{
    public interface IConsoleReadAndWriter
    {
        /// <summary>
        /// Write the string in console
        /// </summary>
        /// <param name="str">The string to be written in console</param>
        void Write(string str);

        /// <summary>
        /// Read a line from console
        /// </summary>
        /// <returns>The user input</returns>
        string Read();
    }
}
