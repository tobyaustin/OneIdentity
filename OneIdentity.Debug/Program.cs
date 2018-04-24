namespace OneIdentity.Debug
{
   // https://jsonplaceholder.typicode.com/users
   // mongoimport --jsonArray /d oneIdentity /c user /file c:\tmp\users.json

   using System;
   using System.Linq;
   using MongoDB.Driver;
   using OneIdentity.Db.Models;

   public class Program
   {
      public static void Main()
      {
         // This is just a quick debug console app to get things up and running and to try out simple stuff...

         Console.WriteLine("Begining debug...");

         var user = new User
         {
            Id = 228463,
            Name = "Toby Austin",
            Username = "toby_austin",
            Email = "someone@somewhere.com",
            Phone = "01234 567890",
            Website = "www.mysite.com",
            Address = new Address
            {
               City = "Cambridge",
               Street = "The Street",
               Suite = "None",
               ZipCode = "AB12 3CD",
               Geo = new Geo
               {
                  Longitude = "0.06072",
                  Latitude = "52.115"
               }
            },
            Company = null
         };

         //var userHelper = new UserHelper<User>("mongodb://localhost:27017", "oneIdentity");
         //#pragma warning disable 4014
         //userHelper.UpdateAsync(user);
         //#pragma warning restore 4014

         var client = new MongoClient("mongodb://localhost:27017");
         var db = client.GetDatabase("oneIdentity");
         var collection = db.GetCollection<User>("user");
         var existingUser = collection.AsQueryable().Single(u => u.Id == 228463);
         user.ObjectId = existingUser.ObjectId;
         var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
         collection.ReplaceOneAsync(filter, user);

         Console.WriteLine("Debug completed.");
      }
   }
}