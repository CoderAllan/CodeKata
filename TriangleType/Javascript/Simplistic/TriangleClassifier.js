function ClassifyTriangle(a, b, c){
    var triangleSideLengths = ParseAndValidateCommandLineArguments(a, b, c);
    if(triangleSideLengths instanceof Array){
        return triangleSideLengths;
    }else{
        var triangleType = [];
        if (triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB &&
            triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC)
        {
            triangleType = ["All sides have the same length. That means that the triangle is equilateral."];
        }
        else if (triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB ||
                triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideC ||
                triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC)
        {
            triangleType = ["Two sides have the same length. That means that the triangle is isosceles."];
        }
        else if (triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideB &&
                triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideC &&
                triangleSideLengths.LengthOfSideB != triangleSideLengths.LengthOfSideC)
        {
            triangleType = ["No sides have the same length. That means that the triangle is scalene."];
        }
        else
        {
            triangleType = ["Congratulations! You found a triangle that are is supposed to exist."];
        }
        return triangleType;
    }
}
