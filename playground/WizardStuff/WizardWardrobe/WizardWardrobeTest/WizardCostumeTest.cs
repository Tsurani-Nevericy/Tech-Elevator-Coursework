using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardWardrobe;

namespace WizardWardrobeTest
{
    [TestClass]
    public class WizardCostumeTest
    {
        [TestMethod]
        public void AddArticleTest()
        {
            var costume = CreateCostume();

            Assert.AreEqual(costume.Robe.Color, "blue");
            Assert.AreEqual(costume.Robe.Name, "robey");
            Assert.AreEqual(costume.Robe.Description, "description");
            Assert.AreEqual(costume.Robe.SupportInvisibility, true);

            Assert.AreEqual(costume.Hat.Color, "blue");
            Assert.AreEqual(costume.Hat.Name, "hatty");
            Assert.AreEqual(costume.Hat.Description, "description");
            Assert.AreEqual(costume.Hat.IsPointy, true);

            Assert.AreEqual(costume.Wands[0].Color, "blue");
            Assert.AreEqual(costume.Wands[0].Name, "wanda");
            Assert.AreEqual(costume.Wands[0].Description, "description");
            Assert.AreEqual(costume.Wands[0].MaterialType, Wand.eMaterialType.Glass);
        }

        private WizardCostume CreateCostume()
        {
            var costume = new WizardCostume();
            costume.AddArticle(CreateHat("blue", "description", "hatty", true));
            costume.AddArticle(CreateRobe("blue", "description", "robey", true));
            costume.AddArticle(CreateWand("blue", "description", "wanda", Wand.eMaterialType.Glass));
            return costume;
        }

        private Robe CreateRobe(string color, string desc, string name, bool supportsInvisibility)
        {
            var robe = new Robe();
            robe.Color = color;
            robe.Description = desc;
            robe.Name = name;
            robe.SupportInvisibility = supportsInvisibility;
            return robe;
        }

        private Hat CreateHat(string color, string desc, string name, bool isPointy)
        {
            var hat = new Hat();
            hat.Color = color;
            hat.Description = desc;
            hat.Name = name;
            hat.IsPointy = isPointy;
            return hat;
        }

        private Wand CreateWand(string color, string desc, string name, Wand.eMaterialType type)
        {
            var wand = new Wand();
            wand.Color = color;
            wand.Description = desc;
            wand.Name = name;
            wand.MaterialType = type;
            return wand;
        }
    }
}
