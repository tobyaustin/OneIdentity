namespace OneIdentity.Business
{
   using System.Collections.Generic;
   using System.Threading.Tasks;

   public interface IHelper<T>
   {
      IEnumerable<T> GetAll();

      T Get(int id);

      Task AddAsync(T item);

      Task UpdateAsync(T item);

      Task RemoveAsync(T item);
   }
}