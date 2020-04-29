using System;
using System.Collections.Generic;

namespace project
{
    public class VoteCounter
    {
        public static string FindWinner(List<string> votes)
        {
            var VoteDictionary = PrepareVotes(votes);

            //Loop through dictionary
            int maxValue = 0;
            string Winner = "";

            foreach (KeyValuePair<string, int> entry in VoteDictionary)
            {
                if(entry.Value > maxValue)
                {
                    maxValue = entry.Value;
                    Winner = entry.Key;
                }

            }
            return Winner;
        }

        public static Dictionary<string, int> PrepareVotes(List<string> votes)
        {
            var VoteDictionary = new Dictionary<string, int>();
            //Add votes to a dictionary 
            foreach (var vote in votes)
            {
                if(VoteDictionary.ContainsKey(vote))
                {
                    VoteDictionary[vote] = VoteDictionary[vote] +1;
                }
                else
                {
                    VoteDictionary.Add(vote, 1);
                }
                
            }

            return VoteDictionary;
        }
    }
}
