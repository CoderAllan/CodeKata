namespace Simplistic.Tests
{
    public class TestOutputter : IOutputter
    {
        public bool WriteLineWasCalled { get; private set; }
        
        public string WriteLineTestValue { get; private set; }
        
        public void WriteLine(string text)
        {
            WriteLineWasCalled = true;
            WriteLineTestValue = text;
        }
    }
}
