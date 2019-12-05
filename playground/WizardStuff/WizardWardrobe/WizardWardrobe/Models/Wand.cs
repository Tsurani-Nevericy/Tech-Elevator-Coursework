using System;
using System.Collections.Generic;
using System.Text;

namespace WizardWardrobe
{
    public class Wand : Article
    {
        public const string WOOD_TYPE = "Wood";
        public const string GLASS_TYPE = "Glass";
        public const string METAL_TYPE = "Metal";
        public const string MATERIAL_TYPE = "MaterialType";

        public enum eMaterialType
        {
            Wood = 0,
            Metal = 1,
            Glass = 2
        }

        public eMaterialType MaterialType { get; set; } = eMaterialType.Wood;        
    }
}
