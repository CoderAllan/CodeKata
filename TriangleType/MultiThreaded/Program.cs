namespace MultiThreaded
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var triangleClassifier = new TriangleClassifier();
            var triangleSideLengths = triangleClassifier.ParseAndValidateCommandLineArguments(args);
            if (triangleSideLengths != null)
            {
                triangleClassifier.Classify(triangleSideLengths);
            }
        }
    }
}
