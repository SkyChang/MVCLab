﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Data.Entity;
using MVCLab.Domain.CRM;

namespace MVCLab.Infrastructure.Data.CRM
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal MVCLabContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MVCLabContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        
        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            //表示所有集合
            IQueryable<TEntity> query = dbSet;

            //Where條件塞選
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Include
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            //OrderBy
            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        /// <summary>
        /// 從資料庫取得ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            
            return dbSet.Find(id);
        }
        
        /// <summary>
        /// 於資料庫新增一筆Entity資料異動
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// 透過id去增加一筆刪除資料庫資料之異動
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// 透過Entity去增加一筆刪除資料庫資料之異動
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            //假如Entity處於Detached狀態，就先Attach起來，這樣才能順利移除
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// 使用Entity增加一筆更新資料庫資料之異動
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public void Test()
        {

        }
    }
}
