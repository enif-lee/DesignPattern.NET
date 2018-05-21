using System.Collections.Generic;

namespace DesignPattern.NET.Visitor.Solution
{
    public class Directory : Entry
    {
        private readonly List<Entry> _entries = new List<Entry>();
        public IEnumerable<Entry> Entries => _entries;

        public Entry Add(Entry entry)
        {
            _entries.Add(entry);
            return entry;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}