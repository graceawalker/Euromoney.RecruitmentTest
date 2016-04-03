using System;

namespace ContentConsole.Wrapper
{
    public interface IConsoleWrapper
    {
        void WriteLine(string input);
        string ReadLine();
        char ReadKey();
        void Clear();
    }

    public class ConsoleWrapper:IConsoleWrapper
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public char ReadKey()
        {
           return Console.ReadKey().KeyChar;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
