namespace OneIdentity.Db
{
   using System.Threading.Tasks;
   using MongoDB.Driver;

   public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : Entity
   {
      public Repository(IMongoClient mongoClient, string collectionName) : base(mongoClient, collectionName) { }

      public async Task Add(T entity)
      {
         await this.Collection.InsertOneAsync(entity);
      }

      public async Task Remove(T entity)
      {
         await this.Collection.DeleteOneAsync(GetFilter(entity));
      }

      public async Task Update(T entity)
      {
         await this.Collection.ReplaceOneAsync(GetFilter(entity), entity);
      }

      private static FilterDefinition<T> GetFilter(T entity)
      {
         return Builders<T>.Filter.Eq(e => e.Id, entity.Id);
      }
   }
}