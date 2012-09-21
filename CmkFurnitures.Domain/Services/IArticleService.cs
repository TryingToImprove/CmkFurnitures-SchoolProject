using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();

        Article Create(string title, string text, DateTime creationTime, int adminId);

        Article GetById(int id);

        Article Update(int id, string title, string text);

        void Delete(int id);

        IEnumerable<Article> GetNewest(int limit);
    }
}
