function isInt(value) {
    return !isNaN(value) && 
            parseInt(Number(value)) == value && 
            !isNaN(parseInt(value, 10));
}
function isString(value){
    return (typeof value === 'string' || value instanceof String);
}
function TriangleSideLengths(lengthOfSideA, lengthOfSideB, lengthOfSideC){
    this.LengthOfSideA = lengthOfSideA;
    this.LengthOfSideB = lengthOfSideB;
    this.LengthOfSideC = lengthOfSideC;
}
function ParseAndValidateCommandLineArguments(lengthOfSideA, lengthOfSideB, lengthOfSideC){
    var argumentForLengthOfSideAIsOk = isInt(lengthOfSideA);
    var argumentForLengthOfSideBIsOk = isInt(lengthOfSideB);
    var argumentForLengthOfSideCIsOk = isInt(lengthOfSideC);
    var validationFailed = false;
    var errorMessage = [];
    if (!argumentForLengthOfSideAIsOk || !argumentForLengthOfSideBIsOk || !argumentForLengthOfSideCIsOk)
    {
        if (!argumentForLengthOfSideAIsOk)
        {
            errorMessage.push("Argument for length of side A is illegal. Valid arguments are integers greater than 0.\n");
        }
        if (!argumentForLengthOfSideBIsOk)
        {
            errorMessage.push("Argument for length of side B is illegal. Valid arguments are integers greater than 0.");
        }
        if (!argumentForLengthOfSideCIsOk)
        {
            errorMessage.push("Argument for length of side C is illegal. Valid arguments are integers greater than 0.\n");
        }
        validationFailed = true;
    }
    if (argumentForLengthOfSideAIsOk && lengthOfSideA <= 0)
    {
        errorMessage.push("Length of side A is not valid. Valid lengths are greater than 0.\n");
        validationFailed = true;
    }
    if (argumentForLengthOfSideBIsOk && lengthOfSideB <= 0)
    {
        errorMessage.push("Length of side B is not valid. Valid lengths are greater than 0.\n");
        validationFailed = true;
    }
    if (argumentForLengthOfSideCIsOk && lengthOfSideC <= 0)
    {
        errorMessage.push("Length of side C is not valid. Valid lengths are greater than 0.\n");
        validationFailed = true;
    }
    if (validationFailed)
    {
        return errorMessage;
    }
    else
    {
        var triangleSideLengths = new TriangleSideLengths(lengthOfSideA,lengthOfSideB,lengthOfSideC);
        return triangleSideLengths;
    }
}
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
