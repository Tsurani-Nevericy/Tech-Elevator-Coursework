using System;
using System.Collections.Generic;
using System.Text;

namespace WizardWardrobe.Exceptions
{
    public class ArticleExistsException : Exception
    {
        public ArticleExistsException(Article item)
        {
            DuplicateArticle = item;
        }

        public Article DuplicateArticle { get; }
    }
}
