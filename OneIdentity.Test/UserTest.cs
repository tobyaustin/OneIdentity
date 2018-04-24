namespace OneIdentity.Test
{
   using MongoDB.Driver;
   using Moq;
   using NUnit.Framework;
   using OneIdentity.Business;
   using OneIdentity.Db.Models;

   // Very simple example tests. Not complete.

   [TestFixture]
   public class UserTest
   {
      [Test]
      public async void TestUserCanBeCreated()
      {
         var user = GetTestUser();
         var mock = new Mock<IMongoClient>();
         var userHelper = new UserHelper<User>(mock.Object, "user");
         await userHelper.Add(user);
      }

      // TODO: Other CRUD tests.

      public void TestVerifyUserReturnsTrueWhenValid()
      {
         var user = GetTestUser();
         Assert.That(UserHelper<User>.UserIsValid(user), Is.EqualTo(true));
      }

      public void TestVerifyUserReturnsFalseWhenIdIsIncorrect()
      {
         var user = GetTestUser();
         user.Id = -1;
         Assert.That(UserHelper<User>.UserIsValid(user), Is.EqualTo(false)); // TODO: Currently fails.
      }

      // TODO: Other business logic tests.

      private static User GetTestUser()
      {
         return new User
         {
            Id = 99,
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
      }
   }
}