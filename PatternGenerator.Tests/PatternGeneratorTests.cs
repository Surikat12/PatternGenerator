using System.IO;
using NUnit.Framework;

namespace PatternGeneratorApp.Tests
{
    [TestFixture]
    public class PatternGeneratorTests
    {
        private PatternGenerator _patternGenerator;

        private static string ReadFromFile(string fileName)
        {
            using var sr = new StreamReader(fileName);
            return sr.ReadToEnd();
        }

        [SetUp]
        public void Setup()
        {
            var compositePath = Path.Combine("Templates", "CompositePattern.txt");
            var visitorPath = Path.Combine("Templates", "VisitorPattern.txt");
            _patternGenerator = new PatternGenerator(compositePath, visitorPath);
        }

        [Test]
        public void CompositeTest1()
        {
            var result = _patternGenerator.GenerateComposite("A", "B", "C");
            var expectedResultPath = Path.Combine("PatternExamples", "CompositePattern1.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CompositeTest2()
        {
            var result = _patternGenerator.GenerateComposite("Component", "Leaf", "Composite");
            var expectedResultPath = Path.Combine("PatternExamples", "CompositePattern2.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CompositeTest3()
        {
            var result = _patternGenerator.GenerateComposite("Comp1", "Leaf1", "Comp2");
            var expectedResultPath = Path.Combine("PatternExamples", "CompositePattern3.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void VisitorTest1()
        {
            var result = _patternGenerator.GenerateVisitor("A", "B", "C", "D");
            var expectedResultPath = Path.Combine("PatternExamples", "VisitorPattern1.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void VisitorTest2()
        {
            var result = _patternGenerator.GenerateVisitor("IComponent", "IVisitor", "ConcreteVisitor", "Visitor");
            var expectedResultPath = Path.Combine("PatternExamples", "VisitorPattern2.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void VisitorTest3()
        {
            var result = _patternGenerator.GenerateVisitor("IC1", "IV1", "C2", "V2");
            var expectedResultPath = Path.Combine("PatternExamples", "VisitorPattern3.txt");
            var expectedResult = ReadFromFile(expectedResultPath);

            Assert.AreEqual(expectedResult, result);
        }
    }
}