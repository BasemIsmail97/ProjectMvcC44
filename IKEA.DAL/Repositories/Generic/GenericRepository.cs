using IKEA.DAL.Data.Contexts;
using IKEA.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity>(ApplicationDbcontext dbcontext):  IGenericRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return dbcontext.Set<TEntity>().ToList();
            }
            return dbcontext.Set<TEntity>().AsNoTracking().ToList();
        }
        public TEntity? GetById(int id)
        {
           
            return dbcontext.Set<TEntity>().Find(id);
        }
        public int Add(TEntity Entity)
        {
            dbcontext.Set<TEntity>().Add(Entity);
            return dbcontext.SaveChanges();
        }
        public int Update(TEntity Entity)
        {
            dbcontext.Set<TEntity>().Update(Entity);
            return dbcontext.SaveChanges();
        }
        public int Delete(TEntity Entity)
        {
            dbcontext.Set<TEntity>().Remove(Entity);
            return dbcontext.SaveChanges();

        }

    }
}
