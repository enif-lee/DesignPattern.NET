using System;

namespace DesignPattern.NET.Visitor.Context
{
    public abstract class Entry
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Entry Add(Entry entry)
        {
            throw new Exception("FileTreatmentException");
        }

        public abstract void OutputList(Action<string> output);
    }
}