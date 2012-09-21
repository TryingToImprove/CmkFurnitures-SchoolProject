using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;

namespace CmkFurnitures.Services.Dependencies
{
    public class ArticleServiceDependencies
    {
        public IArticleRepository ArticleRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        public IAdminRepository AdminRepository { get; set; }
    }
}
