using CampingMaasvallei.Models;
using CampingMaasvallei.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampingMaasvallei.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IDbContextFactory<CampingMaasvalleiContext> _dbContext;

        public UserController(IDbContextFactory<CampingMaasvalleiContext> dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> GetUsers()
        {
            using (var context = _dbContext.CreateDbContext())
            {
                return context.Set<User>().ToList();
            }
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                return context.Set<User>().Where(x => x.id == id).Single();
            }
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// 
        [HttpPost]
        public void CreateUser(string email)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                User u = new User
                {
                    email = email,
                };
                context.Set<User>().Add(u);
                context.SaveChanges();

            }
        }

        /// <summary>
        /// Delete a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        [HttpDelete]
        public void DeleteUser(int id)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                try
                {
                    var user = context.Set<User>().Where(x => x.id == id).Single();
                    context.Set<User>().Remove(user);
                    context.SaveChanges();

                }
                catch (InvalidOperationException e)
                {
                    throw new Exception("No User found with id: " + id, e);
                }
            }
        }

        /// <summary>
        /// Edit user prop fields
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public void EditUser(User user)
        {
            using (var context = _dbContext.CreateDbContext())
            {
                var singleUser = context.Set<User>().Where(x => x.id == user.id).Single();
                if (singleUser != null)
                {
                    singleUser.email = user.email;
                    context.SaveChanges();
                }
            }
        }
    }
}
