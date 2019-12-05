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
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            string result = "";
            Dictionary<string, string> ssDict = new Dictionary<string, string>();
            animalName = animalName.ToLower();
            ssDict["rhino"] = "Crash";
            ssDict["giraffe"] = "Tower";
            ssDict["elephant"] = "Herd";
            ssDict["lion"] = "Pride";
            ssDict["crow"] = "Murder";
            ssDict["pigeon"] = "Kit";
            ssDict["flamingo"] = "Pat";
            ssDict["deer"] = "Herd";
            ssDict["dog"] = "Pack";
            ssDict["crocodile"] = "Float";
            if (animalName == null || !ssDict.ContainsKey(animalName) || animalName == "")
            {
                result = "unknown";
            }
            else
            {
                result = ssDict[animalName];
            }
            return result;
        }
    }
}
