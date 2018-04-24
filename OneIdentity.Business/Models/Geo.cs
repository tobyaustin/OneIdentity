namespace OneIdentity.Db.Models
{
   using MongoDB.Bson.Serialization.Attributes;

   [BsonIgnoreExtraElements]
   public class Geo
   {
      [BsonElement("lat")] 
      public string Latitude { get; set; }

      [BsonElement("lng")] 
      public string Longitude { get; set; }
   }
}
