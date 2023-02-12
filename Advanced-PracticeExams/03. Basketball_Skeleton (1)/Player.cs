using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"-Player: {Name}");
            str.AppendLine($"--Position: {Position}");
            str.AppendLine($"--Rating: {Rating}");
            str.AppendLine($"--Games played: {Games}");

            return str.ToString().TrimEnd();
        }
    }
}
