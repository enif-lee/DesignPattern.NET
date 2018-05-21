using System;

namespace DesignPattern.NET.Visitor.Problem
{
    public class File : Entry
    {
        public string Extension { get; set; }

        public File(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        public override void OutputList(Action<string> output)
        {
            output("/" + Name + "." + Extension);
        }

        public override void OutputListWithSize(Action<string> output)
        {
            throw new NotImplementedException();
        }
    }
}