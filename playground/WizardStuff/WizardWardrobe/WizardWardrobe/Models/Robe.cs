using System;
using System.Collections.Generic;
using System.Text;

namespace WizardWardrobe
{
    public class Robe : Article
    {
        public const string SUPPORTS_INVISIBILITY = "SupportsInvisibility";

        public bool SupportInvisibility { get; set; } = false;
    }
}
