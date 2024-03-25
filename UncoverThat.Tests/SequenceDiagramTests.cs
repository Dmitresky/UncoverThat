using Microsoft.CodeAnalysis.CSharp;
using System;
using UncoverThat.Engine;

namespace UncoverThat.Tests
{
    public class SequenceDiagramTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test_GenerateSequenceDiagram(string path)
        {
            var actual = DiagramGenerator.GenerateSequenceDiagram($"{path}/Source.cs");

            var expected = File.ReadAllText($"{path}/SequenceDiagram_Mermaid.txt");

            Assert.That(actual, Is.EqualTo(expected));
        }

        public static IEnumerable<string> TestCases()
        {
            var directories = Directory.GetDirectories("Cases");

            foreach (var directory in directories)
            {
                yield return directory;
            }
        }
    }
}