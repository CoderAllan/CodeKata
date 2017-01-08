namespace MultiThreaded.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities;

    [TestClass]
    public class ParseAndValidateCommandLineArgumentsTest
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
        public void ParseAndValidateCommandLineArguments_NoArguments_ExpectUsageShown()
        {
            // Arrange 
            var args = new string[0];

            // Act
            var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

            // Assert
            Assert.IsNull(triangleSideLengths, "No TriangleSideLengths object should have been returned");
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Usage", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the usage text.");
        }

        [TestMethod]
        public void ParseAndValidateCommandLineArguments_NotAllArgumentsPresent_ExpectUsageShown()
        {
            // Arrange 
            var args = new[] {"3", "5"};

            // Act
            var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

            // Assert
            Assert.IsNull(triangleSideLengths, "No TriangleSideLengths object should have been returned");
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Usage", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the usage text.");
        }

        [TestMethod]
        public void ParseAndValidateCommandLineArguments_InvalidArgumentsPresent_ExpectErrorMessage()
        {
            // Arrange 
            var argsDictionary = new Dictionary<string, string[]>
            {
                {"A", new[] { "0", "2", "5" }},
                {"B", new[] { "2", "-10", "5" }},
                {"C", new[] { "5", "2", "-2" }},
            };

            foreach (var triangleSideName in argsDictionary.Keys)
            {
                var args = argsDictionary[triangleSideName];

                // Act
                var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

                // Assert
                Assert.IsNull(triangleSideLengths, "No TriangleSideLengths object should have been returned");
                Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
                Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Length of side " + triangleSideName + " is not valid", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the correct error text.");
            }
        }

        [TestMethod]
        public void ParseAndValidateCommandLineArguments_IllegalArgumentsPresent_ExpectErrorMessage()
        {
            // Arrange 
            var argsDictionary = new Dictionary<string, string[]>
            {
                {"A", new[] { "d", "2", "5" }},
                {"B", new[] { "2", "%", "5" }},
                {"C", new[] { "5", "2", "Æ" }},
            };

            foreach (var triangleSideName in argsDictionary.Keys)
            {
                var args = argsDictionary[triangleSideName];

                // Act
                var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

                // Assert
                Assert.IsNull(triangleSideLengths, "No TriangleSideLengths object should have been returned");
                Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
                Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Argument for length of side " + triangleSideName + " is illegal", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the correct error text.");
            }
        }

        [TestMethod]
        public void ParseAndValidateCommandLineArguments_TwoIllegalArgumentsPresent_ExpectErrorMessage()
        {
            // Arrange 
            var args = new[] { "d", "?", "5" };

            // Act
            var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

            // Assert
            Assert.IsNull(triangleSideLengths, "No TriangleSideLengths object should have been returned");
            Assert.IsTrue(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should have been called.");
            Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Argument for length of side A is illegal", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the correct error text.");
            Assert.IsTrue(_testOutputter.WriteLineTestValue.IndexOf("Argument for length of side B is illegal", StringComparison.OrdinalIgnoreCase) >= 0, "Outputter.WriteLine should have been called with the correct error text.");
        }

        [TestMethod]
        public void ParseAndValidateCommandLineArguments_ValidArguments_ExpectValidTriangleSideLengthsObject()
        {
            // Arrange 
            var args = new[] { "3", "5", "6" };

            // Act
            var triangleSideLengths = _triangleClassifier.ParseAndValidateCommandLineArguments(args);

            // Assert
            Assert.IsNotNull(triangleSideLengths, "A TriangleSideLengths object should have been returned");
            Assert.IsFalse(_testOutputter.WriteLineWasCalled, "Outputter.WriteLine should not have been called.");
            Assert.IsNull(_testOutputter.WriteLineTestValue, "Outputter.WriteLine should not have been called with any text.");
        }
    }
}
