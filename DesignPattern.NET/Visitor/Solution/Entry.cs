using System;

namespace DesignPattern.NET.Visitor.Solution
{
    public abstract class Entry : IElement
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Entry Add(Entry entry)
        {
            throw new Exception("FileTreatmentException");
        }

        public abstract void Accept(IVisitor visitor);
    }
}