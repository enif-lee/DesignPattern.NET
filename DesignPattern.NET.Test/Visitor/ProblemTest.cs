using DesignPattern.NET.Visitor.Context;
using Xunit;
using Xunit.Abstractions;

namespace DesignPattern.NET.Test.Visitor
{
    public class ProblemTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public ProblemTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void ContextTest()
        {
            var rootDir = new Directory {Name = "root"};

            rootDir.Add(new File("name", "hello"));
            rootDir.Add(new File("name", "world"));
            rootDir.Add(new File("name", "design"));

            var testDir = new Directory {Name = "test"};
            rootDir.Add(testDir);
            testDir.Add(new File("name", "pattern"));

            rootDir.OutputList(_outputHelper.WriteLine);
        }
    }
}