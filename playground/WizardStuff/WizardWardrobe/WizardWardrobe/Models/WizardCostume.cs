using System;
using System.Collections.Generic;
using WizardWardrobe.Exceptions;

namespace WizardWardrobe
{
    public class WizardCostume
    {
        private List<Article> _articles = new List<Article>();

        public string Name { get; set; }

        public Robe Robe
        {
            get
            {
                Robe result = null;
                foreach(var article in _articles)
                {
                    if(article is Robe)
                    {
                        //result = article as Robe; // Will return null if the cast fails
                        result = (Robe)article; // Will throw an exception if the cast fails
                    }
                }
                return result;
            }
        }

        public Hat Hat
        {
            get
            {
                Hat result = null;
                foreach (var article in _articles)
                {
                    if (article is Hat)
                    {
                        result = (Hat)article;
                    }
                }
                return result;
            }
        }

        public List<Wand> Wands
        {
            get
            {
                List<Wand> result = new List<Wand>();
                foreach (var article in _articles)
                {
                    if (article is Wand)
                    {
                        result.Add((Wand)article);
                    }
                }
                return result;
            }
        }

        public void AddArticle(Article article)
        {
            if((article is Robe && Robe != null) ||
               (article is Hat && Hat != null))
            {
                throw new ArticleExistsException(article);
            }

            if (article is Robe ||
                article is Hat || 
                article is Wand)
            {
                _articles.Add(article);
            }
            else
            {
                throw new UnknownArticleException();
            }
        }
    }
}
