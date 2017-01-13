
function IsoscelesTriangle(){
    this.Description = "Two sides have the same length. That means that the triangle is isosceles.";
    this.DoMatch = function (triangleSideLengths){
        return triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideB ||
               triangleSideLengths.LengthOfSideA == triangleSideLengths.LengthOfSideC ||
               triangleSideLengths.LengthOfSideB == triangleSideLengths.LengthOfSideC;
    }
}