﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HHH.DataModel.Repository
{
    public interface IGenericRepository<T> where T : class
    {
       
        IEnumerable<T> Get();
        T GetByID(object id);
        void Insert(T entity);
        void Delete(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        IEnumerable<T> GetMany(Func<T, bool> where);
        IQueryable<T> GetManyQueryable(Func<T, bool> where);
        T Get(Func<T, Boolean> where);
        void Delete(Func<T, Boolean> where);
        IEnumerable<T> GetAll();
        IQueryable<T> GetWithInclude(System.Linq.Expressions.Expression<Func<T,bool>> predicate, params string[] include);
        bool Exists(object primaryKey);
        T GetSingle(Func<T, bool> predicate);
        T GetFirst(Func<T, bool> predicate);

    }
}
