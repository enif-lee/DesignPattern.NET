using System.Collections.Generic;

namespace DesignPattern.NET.Memento.Solution.Adventure
{
    class Adventurer
    {
        // Auto generated fields
        public int Hp { get;  set; }
        private int Mp { get; set; }
        public Position Position { get; private set; }
        private Map CurrentMap { get; set; }
        private IEnumerable<Item> Items { get; set; }

        public StateSnapshot CreateSnapshot()
        {
            return new StateSnapshot
            {
                CurrentMap = CurrentMap,
                Hp = Hp,
                Mp = Mp,
                Items = new List<Item>(Items),
                Position = Position
            };
        }

        public void RestoreSnapshot(StateSnapshot snapshot)
        {
            Hp = snapshot.Hp;
            Mp = snapshot.Mp;
            Items = snapshot.Items;
            Position = snapshot.Position;
            CurrentMap = snapshot.CurrentMap;
        }
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
        internal int Hp { get; set; }
        internal int Mp { get; set; }
        public Position Position { get; set; }
        public Map CurrentMap { get; set; }
        internal IEnumerable<Item> Items { get; set; }
    }
}