namespace ObjectOriented
{
    using Model;

    public class ScaleneTriangle : ITriangle
    {
        public bool DoMatch(TriangleSideLengths triangleSideLengths)
        {
            return triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideB &&
                   triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideC &&
                   triangleSideLengths.LengthOfSideB != triangleSideLengths.LengthOfSideC;
        }

        public string Description
        {
            get { return "No sides have the same length. That means that the triangle is scalene."; }
        }
    }
}
