
function ScaleneTriangle(){
    this.Description = "No sides have the same length. That means that the triangle is scalene.";
    this.DoMatch = function (triangleSideLengths){
        return triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideB &&
               triangleSideLengths.LengthOfSideA != triangleSideLengths.LengthOfSideC &&
               triangleSideLengths.LengthOfSideB != triangleSideLengths.LengthOfSideC;
    }
}