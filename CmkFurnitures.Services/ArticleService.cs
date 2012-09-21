using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Services.Dependencies;
using CmkFurnitures.Domain;
using CuttingEdge.Conditions;

namespace CmkFurnitures.Services
{
    public class ArticleService : IArticleService
    {
        private ArticleServiceDependencies Dependencies;

        public ArticleService(ArticleServiceDependencies dependencies)
        {
            this.Dependencies = dependencies;
        }

        public IEnumerable<Article> GetAll()
        {
            return this.Dependencies.ArticleRepository.GetAll();
        }

        public Article Create(string title, string text, DateTime creationTime, int adminId)
        {
            Condition.Requires(title).IsNotNullOrWhiteSpace();
            Condition.Requires(text).IsNotNullOrWhiteSpace();
            Condition.Requires(adminId).IsGreaterThan(0);
            Condition.Requires(creationTime).IsGreaterThan(DateTime.UtcNow.AddYears(-100));

            return this.Dependencies.ArticleRepository.Add(new Article
            {
                Title = title,
                Text = text,
                CreationDate = creationTime,
                AuthorId = adminId
            });
        }

        public Article GetById(int id)
        {
            return this.Dependencies.ArticleRepository.GetById(id);
        }

        public Article Update(int id, string title, string text)
        {
            Condition.Requires(title).IsNotNullOrWhiteSpace();
            Condition.Requires(text).IsNotNullOrWhiteSpace();

            Article article = GetById(id);
            article.Title = title;
            article.Text = text;

            this.Dependencies.ArticleRepository.Update(article);

            return article;
        }

        public void Delete(int id)
        {
            Condition.Requires(id).IsGreaterThan(0);

            Dependencies.ArticleRepository.Delete(GetById(id));
        }

        public IEnumerable<Article> GetNewest(int limit)
        {
            Condition.Requires(limit).IsGreaterThan(0);

            return Dependencies.ArticleRepository.GetNewest(limit);
        }
    }
}
