using CRUDApi.Entities;

namespace CRUDApi.Services
{
    public interface IUserService 
    {
        void add(User user);
         
        void update(User user);
        User ValidteUser(string email, string password);
    }
}
