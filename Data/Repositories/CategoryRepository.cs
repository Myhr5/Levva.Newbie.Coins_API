using Levva.Newbie.Coins.Data.Interfaces;
using Levva.Newbie.Coins.Domain.Models;

namespace Levva.Newbie.Coins.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public Category Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(int Id)
        {
            var category = _context.Category.Find(Id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

        public Category Get(int Id)
        {
            return _context.Category.Find(Id);
        }

        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
    }
}
