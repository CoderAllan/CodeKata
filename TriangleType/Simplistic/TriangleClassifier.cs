namespace Simplistic
{
    using System.Text;

    public class TriangleClassifier
    {
        private readonly IOutputter _outputter;

        public TriangleClassifier() : this(new Outputter())
        {
        }
        public TriangleClassifier(IOutputter outputter)
        {
            _outputter = outputter;
        }

        public TriangleSideLengths ParseAndValidateCommandLineArguments(string[] args)
        {
            TriangleSideLengths triangleSideLengths;
            if (args.Length < 3)
            {
                ShowUsage();
                triangleSideLengths = null;
            }
            else
            {
                int lengthOfSideA;
                bool argumentForLengthOfSideAIsOk = int.TryParse(args[0], out lengthOfSideA);
                int lengthOfSideB;
                bool argumentForLengthOfSideBIsOk = int.TryParse(args[1], out lengthOfSideB);
                int lengthOfSideC;
                bool argumentForLengthOfSideCIsOk = int.TryParse(args[2], out lengthOfSideC);
                
                var errorMessage = new StringBuilder();
                bool validationFailed = false;
                if (!argumentForLengthOfSideAIsOk || !argumentForLengthOfSideBIsOk || !argumentForLengthOfSideCIsOk)
                {
                    if (!argumentForLengthOfSideAIsOk)
                    {
                        errorMessage.AppendLine("Argument for length of side A is illegal. Valid arguments are integers greater than 0.");
                    }
                    if (!argumentForLengthOfSideBIsOk)
                    {
                        errorMessage.AppendLine("Argument for length of side B is illegal. Valid arguments are integers greater than 0.");
                    }
                    if (!argumentForLengthOfSideCIsOk)
                    {
                        errorMessage.AppendLine("Argument for length of side C is illegal. Valid arguments are integers greater than 0.");
                    }
                    validationFailed = true;
                }
                if (argumentForLengthOfSideAIsOk && lengthOfSideA <= 0)
                {
                    errorMessage.AppendLine("Length of side A is not valid. Valid lengths are greater than 0.");
                    validationFailed = true;
                }
                if (argumentForLengthOfSideBIsOk && lengthOfSideB <= 0)
                {
                    errorMessage.AppendLine("Length of side B is not valid. Valid lengths are greater than 0.");
                    validationFailed = true;
                }
                if (argumentForLengthOfSideCIsOk && lengthOfSideC <= 0)
                {
                    errorMessage.AppendLine("Length of side C is not valid. Valid lengths are greater than 0.");
                    validationFailed = true;
                }
                if (validationFailed)
                {
                    _outputter.WriteLine(errorMessage.ToString());
                    triangleSideLengths = null;
                }
                else
                {
                    triangleSideLengths = new TriangleSideLengths
                    {
                        LengthOfSideA = lengthOfSideA,
                        LengthOfSideB = lengthOfSideB,
                        LengthOfSideC = lengthOfSideC
                    };
                }
            }

            return triangleSideLengths;
        }

        public void Classify(TriangleSideLengths triangleSideLengths)
        {
            var errorMessage = new StringBuilder();
            bool validationFailed = false;
            if (triangleSideLengths.LengthOfSideA <= 0)
            {
                errorMessage.AppendLine("Length of side A is not valid. Valid lengths are greater than 0.");
                validationFailed = true;
            }
            if (triangleSideLengths.LengthOfSideB <= 0)
            {
                errorMessage.AppendLine("Length of side B is not valid. Valid lengths are greater than 0.");
                validationFailed = true;
            }
            if (triangleSideLengths.LengthOfSideC <= 0)
            {
                errorMessage.AppendLine("Length of side C is not valid. Valid lengths are greater than 0.");
                validationFailed = true;
            }
            if (validationFailed)
            {
                _outputter.WriteLine(errorMessage.ToString());
            }
            else
            {
                if (triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB &&
                    triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC)
                {
                    _outputter.WriteLine("All sides have the same length. That means that the triangle is equilateral.");
                }
                else if (triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB ||
                         triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideC ||
                         triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC)
                {
                    _outputter.WriteLine("Two sides have the same length. That means that the triangle is isosceles.");
                }
                else if (triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideB &&
                         triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideC &&
                         triangleSideLengths.LengthOfSideB != triangleSideLengths.LengthOfSideC)
                {
                    _outputter.WriteLine("No sides have the same length. That means that the triangle is scalene.");
                }
                else
                {
                    _outputter.WriteLine("Congratulations! You found a triangle that are not supposed to exist.");
                }
            }
        }

        private void ShowUsage()
        {
            const string usageText = @"
TriangleClassifier v1.0   Allan Simonsen 2017-01-07

Usage: TriangleClassifier <LengthOfSideA> <LengthOfSideB> <LengthOfSideC>

<LengthOfSideA> An integer greater than 0
<LengthOfSideB> An integer greater than 0
<LengthOfSideC> An integer greater than 0

Example:
TriangleClassifier 3 4 5
";
            _outputter.WriteLine(usageText);
        }
    }
}
