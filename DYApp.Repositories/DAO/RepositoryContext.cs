﻿using DYApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LinqKit;
using System.Data.Entity;

namespace DYApp.Repositories.DAO
{
    public class RepositoryContext:IRepositoryContext
    {
        private DYContext context;
        public RepositoryContext(DYContext context)
        {
            this.context = context;
        }

        public void DoAdd<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot
        {
            this.context.Set<TAggregateRoot>().Add(entity);
        }

        public void DoClear<TAggregateRoot>() where TAggregateRoot : AggregateRoot
        {
            IQueryable<TAggregateRoot> aggList = this.context.Set<TAggregateRoot>();
            foreach (TAggregateRoot agg in aggList)
            {
                this.context.Set<TAggregateRoot>().Remove(agg);
            }
            this.DoCommit();
        }

        public int DoCommit()
        {
            return this.context.SaveChanges();
        }

        public TAggregateRoot DoCreate<TAggregateRoot>() where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().Create();
        }

        public bool DoExists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().Any(condition);
        }

        public TAggregateRoot DoFindByID<TAggregateRoot>(Guid id) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().Find(id);
        }

        public IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().AsExpandable().Where(condition);
        }

        public IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(int pageIndex, int pageSize) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().OrderBy(p => p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition, int pageIndex, int pageSize) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().AsExpandable().Where(condition).OrderBy(p => p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IList<TAggregateRoot> DoGetAll<TAggregateRoot>() where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().ToList();
        }

        public int DoGetCount<TAggregateRoot>() where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().Count();
        }

        public int DoGetCount<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot
        {
            return this.context.Set<TAggregateRoot>().Count(condition);
        }

        public void DoRemove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot
        {
            this.context.Set<TAggregateRoot>().Remove(entity);
        }

        public void DoUpdate<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot
        {
            this.context.Set<TAggregateRoot>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
