namespace MultiThreaded
{
    using Model;

    public class EquilateralTriangle : ITriangle
    {
        public bool DoMatch(TriangleSideLengths triangleSideLengths)
        {
            return triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB &&
                   triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC;
        }

        public string Description
        {
            get { return "All sides have the same length. That means that the triangle is equilateral."; }
        }
    }
}
