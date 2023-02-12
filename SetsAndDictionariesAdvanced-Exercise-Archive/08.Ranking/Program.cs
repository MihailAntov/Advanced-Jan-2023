using System;
using System.Linq;
using System.Collections.Generic;
namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string input;
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = input.Split(":");
                contests.Add(inputArgs[0], inputArgs[1]);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArgs = input.Split("=>");
                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (!contests.ContainsKey(contest)
                    || contests[contest] != password)
                {
                    continue;
                }

                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }
                if (!submissions[username].ContainsKey(contest))
                {
                    submissions[username].Add(contest, 0);
                }

                if (points > submissions[username][contest])
                {
                    submissions[username][contest] = points;
                }
            }

            submissions = submissions.OrderByDescending(n => n.Value.Select(m => m.Value).Sum())
                .ToDictionary(n => n.Key, n => n.Value);

            KeyValuePair<string, Dictionary<string, int>> first = submissions.First();


            Console.WriteLine($"Best candidate is {first.Key} with total {first.Value.Select(n => n.Value).Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (KeyValuePair<string, Dictionary<string, int>> user in submissions.OrderBy(n => n.Key))
            {
                Console.WriteLine(user.Key);
                foreach (KeyValuePair<string, int> contest in user.Value.OrderByDescending(n => n.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
