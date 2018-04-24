namespace OneIdentity.Business
{
   using System.Collections.Generic;
   using System.Threading.Tasks;

   public interface IHelper<T>
   {
      IEnumerable<T> GetAll();

      T Get(int id);

      Task Add(T item);

      Task Update(T item);

      Task Remove(T item);
   }
}