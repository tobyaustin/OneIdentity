using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OneIdentity.Test")]
namespace OneIdentity.Business
{
   using System;
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using MongoDB.Driver;
   using OneIdentity.Db;
   using OneIdentity.Db.Models;

   public class UserHelper<T> : IHelper<T> where T : User
   {
      private const string InvalidUser = "Invalid User";
      private const string UserCannotBeDeleted = "User cannot be Deleted";

      private readonly Repository<User> repository;

      //public UserHelper(IRepository<T> repository)
      //{
      //   this.repository = repository;
      //}

      public UserHelper(string connectionString, string collectionName)
      {         
         this.repository = new Repository<User>(new MongoClient(connectionString), collectionName);
      }

      public UserHelper(IMongoClient mongoClient, string collectionName)
      {
         this.repository = new Repository<User>(mongoClient, collectionName);
      }

      public IEnumerable<T> GetAll()
      {
         return (IEnumerable<T>)this.repository.GetAll();
      }

      public T Get(int id)
      {
         return (T)this.repository.Get(id);
      }

      public async Task Add(T user)
      {
         if (!UserIsValid(user))
            throw new Exception(InvalidUser);

         // TODO: Set Id based as next available.

         await this.repository.Add(user);
      }

      public async Task Update(T item)
      {
         if(!UserIsValid(item))
            throw new Exception(InvalidUser);

         await this.repository.Update(item);
      }

      public async Task Remove(T user)
      {
         if(!UserCanBeDeleted(user))
            throw new Exception(UserCannotBeDeleted);

         await this.repository.Remove(user);
      }

      internal static bool UserIsValid(User user)
      {
         // Do validation.

         return true;
      }

      internal static bool UserCanBeDeleted(User user)
      {
         // Do validation.

         return true;
      }
   }
}