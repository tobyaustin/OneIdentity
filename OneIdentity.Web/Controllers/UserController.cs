namespace OneIdentity.Api.Controllers
{
   using System.Collections.Generic;
   using Microsoft.AspNetCore.Mvc;
   using OneIdentity.Business;
   using OneIdentity.Db.Models;

   [Produces("application/json")]
   [Route("api/User")]
   public class UserController : Controller
   {
      private readonly IHelper<User> helper;

      public UserController(IHelper<User> helper)
      {
         this.helper = helper;
      }

      // GET: api/User
      [HttpGet]
      public IEnumerable<User> Get()
      {
         return this.helper.GetAll();
      }

      // GET: api/User/5
      [HttpGet("{id}", Name = "Get")]
      public User Get(int id)
      {
         return this.helper.Get(id);
      }

      // POST: api/User
      [HttpPost]
      public void Post([FromBody] User value)
      {
         this.helper.AddAsync(value);
      }

      // PUT: api/User/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] User value)
      {
         value.Id = id;
         this.helper.UpdateAsync(value);
      }

      // DELETE: api/ApiWithActions/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         var user = this.helper.Get(id);
         this.helper.RemoveAsync(user);
      }
   }
}