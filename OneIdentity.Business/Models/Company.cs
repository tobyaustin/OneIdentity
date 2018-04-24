namespace OneIdentity.Db.Models
{
   using MongoDB.Bson.Serialization.Attributes;

   public class Company
   {
      [BsonElement("name")] 
      public string Name { get; set; }

      [BsonElement("catchPhrase")]       
      public string CatchPhrase { get; set; }

      [BsonElement("bs")] 
      public string Bs { get; set; }
   }
}
