
namespace ObjectOriented.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using Utilities;

    [TestClass]
    public class ClassifierTest
    {
        private TriangleClassifier _triangleClassifier;
        private TestOutputter _testOutputter;

        [TestInitialize]
        public void Initialize()
        {
            _testOutputter = new TestOutputter();
            _triangleClassifier = new TriangleClassifier(_testOutputter);
        }

        [TestMethod]
        public void Classifier_Equilateral_ExpectCorrectAnswer()
        {
            // Arrange
            var triangleSideLengths = new TriangleSideLengths
            {
                LengthOfSideA = 12,
                LengthOfSideB = 12,
                LengthOfSideC = 12
            };

            // Act
            _triangleClassifier.Classify(triangleSideLengths);

            // Assert
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.AreEqual("All sides have the same length. That means that the triangle is equilateral.", _testOutputter.WriteLineTestValue, "Outputter.WriteLine should have been called with the correct text.");
        }

        [TestMethod]
        public void Classifier_Isosceles_ExpectCorrectAnswer()
        {
            // Arrange
            var triangleSideLengths = new TriangleSideLengths
            {
                LengthOfSideA = 5,
                LengthOfSideB = 64,
                LengthOfSideC = 5
            };

            // Act
            _triangleClassifier.Classify(triangleSideLengths);

            // Assert
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.AreEqual("Two sides have the same length. That means that the triangle is isosceles.", _testOutputter.WriteLineTestValue, "Outputter.WriteLine should have been called with the correct text.");
        }

        [TestMethod]
        public void Classifier_Scalene_ExpectCorrectAnswer()
        {
            // Arrange
            var triangleSideLengths = new TriangleSideLengths
            {
                LengthOfSideA = 3,
                LengthOfSideB = 4,
                LengthOfSideC = 5
            };

            // Act
            _triangleClassifier.Classify(triangleSideLengths);

            // Assert
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.AreEqual("No sides have the same length. That means that the triangle is scalene.", _testOutputter.WriteLineTestValue, "Outputter.WriteLine should have been called with the correct text.");
        }

        [TestMethod]
        public void Classifier_IllegalValues_ExpectCorrectAnswer()
        {
            // Arrange
            var triangleSideLengthsDictionary = new Dictionary<string, TriangleSideLengths>
            {
                {"A", new TriangleSideLengths { LengthOfSideA = -3, LengthOfSideB = 4, LengthOfSideC = 5 }},
                {"B", new TriangleSideLengths { LengthOfSideA = 13, LengthOfSideB = -24, LengthOfSideC = 35 }},
                {"C", new TriangleSideLengths { LengthOfSideA = 23, LengthOfSideB = 34, LengthOfSideC = -45 }},
            };

            foreach (string triangleSideName in triangleSideLengthsDictionary.Keys)
            {
                var triangleSideLengths = triangleSideLengthsDictionary[triangleSideName];

                // Act
                _triangleClassifier.Classify(triangleSideLengths);

                // Assert
                Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
                Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Length of side " + triangleSideName + " is not valid. Valid lengths are greater than 0.", System.StringComparison.Ordinal) >= 0, "Outputter.WriteLine should have been called with the correct text.");
            }
        }
    }
}
