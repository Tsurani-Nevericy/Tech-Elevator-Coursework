using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public class FarmAnimal : ISingable, ISellable
    {       
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        public decimal Price { get; }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        public FarmAnimal(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// The noise made when the farm animal makes a sound.
        /// </summary>
        /// <returns></returns>
        public virtual string MakeSoundOnce()
        {
            return "";
        }

        /// <summary>
        /// The noise made when the farm animal makes its sound twice.
        /// </summary>
        /// <returns></returns>
        public virtual string MakeSoundTwice()
        {
            return "";
        }

        public virtual string ToString()
        {
            return Name;
        }

        public string Sell()
        {
            return "You sold the " + Name + "!";
        }

    }
}
