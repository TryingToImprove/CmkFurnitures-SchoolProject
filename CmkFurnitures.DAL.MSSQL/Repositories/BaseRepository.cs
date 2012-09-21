using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public abstract class BaseRepository
    {
        protected CmkFurnituresDbEntities Entities;

        public BaseRepository(CmkFurnituresDbEntities entities)
        {
            this.Entities = entities;
        }

        protected void SaveChanges()
        {
            Entities.SaveChanges();
        }
    }
}
