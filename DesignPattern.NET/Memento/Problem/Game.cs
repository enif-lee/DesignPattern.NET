using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.NET.Memento.Problem
{
    public class Game
    {
        private readonly IList<StateSnapshot> _snapshots = new List<StateSnapshot>();

        public void Play()
        {
            var adventurer = new Adventurer();

            while (true)
            {
                if (adventurer.Position.IsSavePoint)
                    _snapshots.Add(new StateSnapshot
                    {
                        CurrentMap = adventurer.CurrentMap,
                        Hp = adventurer.Hp,
                        Mp = adventurer.Mp,
                        Items = new List<Item>(adventurer.Items),
                        Position = adventurer.Position
                    });

                // Try adventure

                if (adventurer.Hp <= 0)
                {
                    var lastSnapshot = _snapshots.Last();
                    adventurer.Hp = lastSnapshot.Hp;
                    adventurer.Mp = lastSnapshot.Mp;
                    adventurer.Items = lastSnapshot.Items;
                    adventurer.Position = lastSnapshot.Position;
                    adventurer.CurrentMap = lastSnapshot.CurrentMap;
                }
            }
        }
    }
}