using System;
using System.Collections.Generic;
using System.Text;

namespace WizardWardrobe
{
    public class Hat : Article
    {
        public const string IS_POINTY = "IsPointy";

        public bool IsPointy { get; set; } = true;
    }
}
