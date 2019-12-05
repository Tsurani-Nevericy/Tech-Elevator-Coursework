using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WizardWardrobe.Exceptions;
using WizardWardrobe.Models;

namespace WizardWardrobe
{
    public class Wardrobe
    {
        private const string HAT = "Hat";
        private const string ROBE = "Robe";
        private const string WAND = "Wand";

        private List<WizardCostume> _costumes = new List<WizardCostume>();

        private void LoadWardrobe(string filePath)
        {
            var costumeLines = File.ReadAllLines(filePath);
            foreach(var costumeLine in costumeLines)
            {
                var costume = CreateCostume(costumeLine);
                _costumes.Add(costume);
            }
        }

        private WizardCostume CreateCostume(string costumeData)
        {
            WizardCostume costume = new WizardCostume();

            var items = costumeData.Split("$");
            costume.Name = items[0];

            var articleLines = items[1].Split(";");
            foreach (var articleLine in articleLines)
            {
                var article = CreateArticle(articleLine);
                costume.AddArticle(article);
            }

            return costume;
        }

        private Article CreateArticle(string articleData)
        {
            Article article = null;

            var properties = articleData.Split(",");
            foreach (var property in properties)
            {
                var item = GetAttribute(property);

                if (item.Name == Article.TYPE)
                {
                    if (item.Data == HAT)
                    {
                        article = CreateHat(properties);
                    }
                    else if(item.Data == ROBE)
                    {
                        article = CreateRobe(properties);
                    }
                    else if (item.Data == WAND)
                    {
                        article = CreateWand(properties);
                    }
                    else
                    {
                        throw new UnknownArticleException();
                    }
                }
            }

            return article;
        }

        private Hat CreateHat(string[] properties)
        {
            Hat hat = new Hat();

            PopulateArticleData(hat, properties);

            foreach (var property in properties)
            {
                var item = GetAttribute(property);
                if (item.Name == Hat.IS_POINTY)
                {
                    hat.IsPointy = item.Data.ToLower() == "true" ? true : false;
                }
                else if (item.Name != Article.TYPE &&
                         item.Name != Article.NAME &&
                         item.Name != Article.DESCRIPTION &&
                         item.Name != Article.COLOR)
                {
                    throw new UnknownPropertyException();
                }
            }

            return hat;
        }

        private Robe CreateRobe(string[] properties)
        {
            Robe robe = new Robe();

            PopulateArticleData(robe, properties);

            foreach (var property in properties)
            {
                var item = GetAttribute(property);
                if (item.Name == Robe.SUPPORTS_INVISIBILITY)
                {
                    robe.SupportInvisibility = item.Data.ToLower() == "true" ? true : false;
                }
                else if (item.Name != Article.TYPE &&
                         item.Name != Article.NAME &&
                         item.Name != Article.DESCRIPTION &&
                         item.Name != Article.COLOR)
                {
                    throw new UnknownPropertyException();
                }
            }

            return robe;
        }

        private Wand CreateWand(string[] properties)
        {
            Wand wand = new Wand();

            PopulateArticleData(wand, properties);

            foreach (var property in properties)
            {
                var item = GetAttribute(property);
                if (item.Name == Wand.MATERIAL_TYPE)
                {
                    wand.MaterialType = GetMaterialType(item.Data);
                }
                else if (item.Name != Article.TYPE &&
                         item.Name != Article.NAME &&
                         item.Name != Article.DESCRIPTION &&
                         item.Name != Article.COLOR)
                {
                    throw new UnknownPropertyException();
                }
            }

            return wand;
        }

        private Wand.eMaterialType GetMaterialType(string wandMaterial)
        {
            Wand.eMaterialType result = Wand.eMaterialType.Wood;

            if(wandMaterial == Wand.GLASS_TYPE)
            {
                result = Wand.eMaterialType.Glass;
            }
            else if (wandMaterial == Wand.METAL_TYPE)
            {
                result = Wand.eMaterialType.Metal;
            }

            return result;
        }

        private void PopulateArticleData(Article article, string[] properties)
        {
            foreach (var property in properties)
            {
                var item = GetAttribute(property);
                if (item.Name == "Name")
                {
                    article.Name = item.Data;
                }
                else if (item.Name == "Description")
                {
                    article.Description = item.Data;
                }
                else if (item.Name == "Color")
                {
                    article.Color = item.Data;
                }
            }
        }

        private WizAttribute GetAttribute(string property)
        {
            return new WizAttribute(property);
        }

        public Wardrobe(string filePath)
        {
            LoadWardrobe(filePath);
        }

        public List<WizardCostume> Costumes
        {
            get
            {
                return _costumes;
            }
        }
    }
}
