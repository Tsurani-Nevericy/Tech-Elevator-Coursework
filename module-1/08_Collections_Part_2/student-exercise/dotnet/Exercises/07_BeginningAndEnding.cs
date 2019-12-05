using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of non-empty strings, return a Dictionary<string, string> where for every different string in the array,
         * there is a key of its first character with the value of its last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["man", "moon", "main"]) → {"m": "n"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            Dictionary<string, string> ssDict = new Dictionary<string, string>();
            foreach (string s in words)
            {
                string sF = s.Substring(0, 1);
                string sL = s.Substring(s.Length - 1, 1);
                if (!ssDict.ContainsKey(sF))
                {
                    ssDict.Add(sF, sL);
                }
                ssDict[sF] = sL;
            }
            return ssDict;
        }
    }
}
