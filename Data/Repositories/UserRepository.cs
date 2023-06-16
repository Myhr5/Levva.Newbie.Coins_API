using Levva.Newbie.Coins.Data.Interfaces;
using Levva.Newbie.Coins.Domain.Models;

namespace Levva.Newbie.Coins.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var user = _context.User.Find(Id);
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User Get(int Id)
        {
            return _context.User.Find(Id);
        }

        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.User.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
