namespace OneIdentity.Db
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Linq.Expressions;
   using MongoDB.Driver;

   public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity
   {
      protected readonly IMongoCollection<T> Collection;

      //public ReadOnlyRepository(string connectionString, string collectionName)
      //{
      //   var client = new MongoClient(connectionString);
      //   var db = client.GetDatabase(collectionName);
      //   this.Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
      //}

      public ReadOnlyRepository(IMongoClient client, string collectionName)
      {
         var db = client.GetDatabase(collectionName);
         this.Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
      }

      public IEnumerable<T> GetAll()
      {
         return this.Collection.AsQueryable();
      }

      public T Get(int id)
      {
         return this.Collection.AsQueryable().Single(t => t.Id == id);
      }

      public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
      {
         return this.Collection.AsQueryable().Where(predicate);
      }
   }
}