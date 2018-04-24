namespace OneIdentity.Db
{
   using System;
   using System.Collections.Generic;
   using System.Linq.Expressions;

   public interface IReadOnlyRepository<T> where T : class
   {
      IEnumerable<T> GetAll();

      T Get(int id);

      IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
   }
}