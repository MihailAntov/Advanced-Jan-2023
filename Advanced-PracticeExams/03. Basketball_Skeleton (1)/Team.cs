using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count { get { return players.Count; } }

        public string AddPlayer(Player player)
        {
            if(OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if(player.Name == null || player.Position == null)
            {
                return "Invalid player's information.";
            }

            if(player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player playerToBeremoved = players
                .FirstOrDefault(n => n.Name == name);
            if(playerToBeremoved != null)
            {
                OpenPositions++;
            }
            return players.Remove(playerToBeremoved);
        }

        public int RemovePlayerByPosition(string position)
        {
            int removed = players.RemoveAll(n => n.Position == position);
            OpenPositions += removed;
            return  removed;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToBeRetired = players.FirstOrDefault(n => n.Name == name);
            if(playerToBeRetired != null)
            {
                OpenPositions++;
                playerToBeRetired.Retired = true;
            }
            
            return playerToBeRetired;
        }

        public List<Player> AwardPlayers (int games)
        {
            return players.Where(n => n.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach(Player player in players.Where(n=>n.Retired == false))
            {
                str.AppendLine(player.ToString());
            }
            return str.ToString().TrimEnd();

        }
    }
}
