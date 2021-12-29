using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class BaseDAO<T> where T : class
    {
        protected DerContext db;

        public BaseDAO(DerContext derContext)
        {
            db = derContext;
        }

        public void AddOrUpdate(T item)
        {
            db.Set<T>().AddOrUpdate(item);
            
            db.SaveChanges();
        }


        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
    }
}