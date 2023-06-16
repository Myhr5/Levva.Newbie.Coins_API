using Levva.Newbie.Coins.Domain.Models;

namespace Levva.Newbie.Coins.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Get(int Id);
        List<Category> GetAll();
        void Update(Category category);
        void Delete(int Id);
    }
}
