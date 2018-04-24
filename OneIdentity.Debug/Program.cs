namespace OneIdentity.Debug
{
   // https://jsonplaceholder.typicode.com/users
   // mongoimport --jsonArray /d oneIdentity /c user /file c:\tmp\users.json

   using System;
   using MongoDB.Driver;

   public class Program
   {
      public static void Main()
      {
         // This is just a quick debug console app to get things up and running and to try out simple stuff...

         Console.WriteLine("Begining debug...");

         var client = new MongoClient("mongodb://localhost:27017");
         client.GetDatabase("oneIdentity");
         
         Console.WriteLine("Debug completed.");
      }
   }
}