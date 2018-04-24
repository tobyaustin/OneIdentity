namespace OneIdentity.Db
{
   using System.Threading.Tasks;

   public interface IRepository<T> : IReadOnlyRepository<T> where T : class
   {
      Task Add(T entity);

      Task Update(T entity);

      Task Remove(T entity);
   }
}