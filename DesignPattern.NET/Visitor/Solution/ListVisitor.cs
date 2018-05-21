using System;

namespace DesignPattern.NET.Visitor.Solution
{
    public class ListVisitor : IVisitor
    {
        public ListVisitor(Action<string> output)
        {
            Output = output;
        }

        private Action<string> Output { get; set; }
        private string CurrentDir { get; set; }

        public void Visit(File file)
        {
            Output(GetPath(file));
        }

        public void Visit(Directory file)
        {
            var temp = CurrentDir;
            var currentDir = GetPath(file);
            Output(currentDir);
            CurrentDir = currentDir;

            foreach (var entry in file.Entries)
            {
                entry.Accept(this);
            }

            CurrentDir = temp;
        }

        private string GetPath(Entry file)
        {
            return CurrentDir + "/" + file.Name;
        }
    }
}