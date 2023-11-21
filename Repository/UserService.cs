using AutoMapper;
using CRUDApi.Services;
using CRUDApi.Entities;
using CRUDApi.Database;

namespace CRUDApi.Repository
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;
        public UserService() 
        
        {
         _context = new MyContext();
        }
        public void add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            } 
        }

        public void update(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User ValidteUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.UserEmail == email && u.Password == password);
        }
    }
}
