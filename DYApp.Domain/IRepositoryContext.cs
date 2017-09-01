using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain
{
    public interface IRepositoryContext
    {
        void DoAdd<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
        void DoUpdate<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
        void DoRemove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
        IList<TAggregateRoot> DoGetAll<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
        int DoCommit();
        int DoGetCount<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
        IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot;
        TAggregateRoot DoCreate<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
        int DoGetCount<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot;
        IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(int pageIndex, int pageSize) where TAggregateRoot : AggregateRoot;
        IQueryable<TAggregateRoot> DoGet<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition, int pageIndex, int pageSize) where TAggregateRoot : AggregateRoot;
        TAggregateRoot DoFindByID<TAggregateRoot>(Guid id) where TAggregateRoot : AggregateRoot;
        bool DoExists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> condition) where TAggregateRoot : AggregateRoot;
        void DoClear<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
    }
}
