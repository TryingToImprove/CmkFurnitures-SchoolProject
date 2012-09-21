using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public IEnumerable<Article> GetAll()
        {
            return Entities.Articles;
        }

        public Article Add(Article article)
        {
            Entities.Articles.AddObject(article);
            SaveChanges();

            return article;
        }

        public void Update(Article article)
        {
            SaveChanges();
        }


        public Article GetById(int id)
        {
            return Entities.Articles.FirstOrDefault(x => x.ArticleId == id);
        }


        public void Delete(Article article)
        {
            Entities.Articles.DeleteObject(article);
            SaveChanges();
        }


        public IEnumerable<Article> GetNewest(int limit)
        {
            return Entities.Articles.OrderByDescending(x => x.CreationDate).Take(3);
        }
    }
}
