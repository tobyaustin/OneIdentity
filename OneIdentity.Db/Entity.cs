namespace OneIdentity.Db
{
   using MongoDB.Bson;
   using MongoDB.Bson.Serialization.Attributes;

   public class Entity
   {
      [BsonElement("id")]
      public int Id { get; set; }

      [BsonId]
      private ObjectId ObjectId { get; set; } // TODO: Required?
   }
}