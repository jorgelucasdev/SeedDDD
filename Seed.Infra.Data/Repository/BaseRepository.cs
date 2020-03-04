using Seed.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seed.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext context = new MySqlContext();
        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Remove(int id)
        {

            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

      

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }
        public IList<T> SelectAll(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

    }
}
