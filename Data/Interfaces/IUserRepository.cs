using Levva.Newbie.Coins.Domain.Models;

namespace Levva.Newbie.Coins.Data.Interfaces
{
    public interface IUserRepository
    {
        User Get(int Id);
        User GetByEmailAndPassword(string email, string password);
        List<User> GetAll();
        void Delete(int Id);        
        void Create(User user);
        void Update(User user);
    }
}
