using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            bool result;
            if (numberOfPiecesToRemove > PiecesOfFruitLeft)
            {
                result = false;
            }
            else
            {
                PiecesOfFruitLeft -= numberOfPiecesToRemove;
                result = true;

            }
            return result;
        }
    }
}
