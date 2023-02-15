using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if(Count == Capacity)
            {
                return;
            }

            roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(n => n.Name == name));
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(n => n.Name == name);
            if(player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(n => n.Name == name);
            if(player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
            
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] playersToKick = roster.Where(n => n.Class == _class).ToArray();
            roster.RemoveAll(n => n.Class == _class);
            return playersToKick;
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Players in the guild: {Name}");
            foreach(Player player in roster)
            {
                str.AppendLine(player.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
