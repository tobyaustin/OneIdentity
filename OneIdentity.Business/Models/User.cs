namespace OneIdentity.Db.Models
{
   using MongoDB.Bson.Serialization.Attributes;

   public class User : Entity
   {
      [BsonElement("name")] 
      public string Name { get; set; }

      [BsonElement("username")] 
      public string Username { get; set; }

      [BsonElement("email")] 
      public string Email { get; set; }

      [BsonElement("address")]
      public Address Address { get; set; }

      [BsonElement("phone")] 
      public string Phone { get; set; }

      [BsonElement("website")] 
      public string Website { get; set; }

      [BsonElement("company")]
      public Company Company { get; set; }
   }
}
