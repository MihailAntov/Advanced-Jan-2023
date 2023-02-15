using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string _class)
        {
            Name = name;
            Class = _class;
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Player {Name}: {Class}");
            str.AppendLine($"Rank: {Rank}");
            str.AppendLine($"Description: {Description}");
            return str.ToString().TrimEnd();
        }
    }
}
