using System.Collections.Generic;
using System.Linq;
using DesignPattern.NET.Memento.Solution.Adventure;

namespace DesignPattern.NET.Memento.Solution
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
                    _snapshots.Add(adventurer.CreateSnapshot());

                // Try adventure

                if (adventurer.Hp <= 0)
                {
                    adventurer.RestoreSnapshot(_snapshots.Last());
                }
            }
        }
    }
}