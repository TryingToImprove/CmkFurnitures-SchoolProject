using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class AuthorRepository :  BaseRepository, IAuthorRepository
    {
        public AuthorRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
