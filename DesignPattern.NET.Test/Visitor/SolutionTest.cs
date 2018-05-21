using DesignPattern.NET.Visitor.Solution;
using Xunit;
using Xunit.Abstractions;

namespace DesignPattern.NET.Test.Visitor
{
    public class SolutionTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public SolutionTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Visitor()
        {
            var rootDir = new Directory {Name = "root"};

            rootDir.Add(new File {Name = "file.name", Size = 3000});
            rootDir.Add(new File {Name = "file.hello", Size = 3000});
            rootDir.Add(new File {Name = "file.test", Size = 3000});

            var testDir = new Directory {Name = "test"};
            rootDir.Add(testDir);
            testDir.Add(new File {Name = "this_is_target_place"});

            var visitor = new ListVisitor(_outputHelper.WriteLine);

            rootDir.Accept(visitor);
        }
    }
}