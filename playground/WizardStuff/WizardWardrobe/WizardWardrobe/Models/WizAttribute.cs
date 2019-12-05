using System;
using System.Collections.Generic;
using System.Text;

namespace WizardWardrobe.Models
{
    public class WizAttribute
    {
        public string Name { get; }
        public string Data { get; }
        public WizAttribute(string data)
        {
            var item = data.Substring(1, data.Length - 2).Split(":");
            Name = item[0];
            Data = item[1];
        }
    }
}
