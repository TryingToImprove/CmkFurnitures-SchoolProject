using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        IEnumerable<Article> GetAll();

        Article Add(Article article);

        void Update(Article article);

        Article GetById(int id);

        void Delete(Article article);

        IEnumerable<Article> GetNewest(int limit);
    }
}
