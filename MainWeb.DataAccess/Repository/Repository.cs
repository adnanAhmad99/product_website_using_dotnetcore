﻿using Microsoft.EntityFrameworkCore;
using MainApp.DataAccess.Data;
using MainApp.DataAccess.Repository.IRepostiory;
using System.Linq.Expressions;

namespace MainApp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext db)
        {
                _db = db;
                this.dbset = _db.Set<T>();
            _db.Product.Include(u => u.Category).Include(u => u.CategoryDataId);
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, bool includeDataPara = false)
        {
            IQueryable<T> query = dbset.Where(filter);
            if (includeDataPara)
            {
                query = query.Include("Category");

            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(bool includeDataPara=false)
        {
            IQueryable<T> query = dbset;
            if (includeDataPara)
            {
            query=query.Include("Category");

            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
    }
}
