function ClassifyTriangle(a, b, c){
    var triangleSideLengths = ParseAndValidateCommandLineArguments(a, b, c);
    if(triangleSideLengths instanceof Array){
        return triangleSideLengths;
    }else{
        var classifiedTriangleType = [];
        var triangleTypes = [new EquilateralTriangle(), new IsoscelesTriangle(), new ScaleneTriangle()];

        var matchFound = false;
        for (var i = 0; i < triangleTypes.length; i++)
        {
            if (triangleTypes[i].DoMatch(triangleSideLengths))
            {
                matchFound = true;
                classifiedTriangleType = [triangleTypes[i].Description];
                break;
            }
        }
        if (!matchFound)
        {
            classifiedTriangleType = ["Congratulations! You found a triangle that is not supposed to exist."];
        }
        return classifiedTriangleType;
    }
}
