
function EquilateralTriangle(){
    this.Description = "All sides have the same length. That means that the triangle is equilateral.";
    this.DoMatch = function (triangleSideLengths){
        return triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB &&
               triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC;
    }
}