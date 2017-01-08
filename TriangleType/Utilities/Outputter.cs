namespace Utilities
{
    using System;

    public class Outputter : IOutputter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
