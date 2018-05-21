using System;
using System.Collections.Generic;

namespace DesignPattern.NET.Visitor.Context
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

        public override void OutputList(Action<string> output)
        {
            var path = "/" + Name;
            output(path);

            foreach (var entry in Entries)
            {
                entry.OutputList(name => output(path + name));
            }
        }
    }
}