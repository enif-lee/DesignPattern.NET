using System.Collections.Generic;

namespace DesignPattern.NET.Memento.Problem
{
    class Adventurer
    {
        // Auto generated fields
        public int Hp { get; set; }
        public int Mp { get; set; }
        public Position Position { get; set; }
        public Map CurrentMap { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

    class Position
    {
        public bool IsSavePoint => true;
    }

    class Map
    {
    }

    class Item
    {
    }

    struct StateSnapshot
    {
        public int Hp { get; set; }
        public int Mp { get; set; }
        public Position Position { get; set; }
        public Map CurrentMap { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}