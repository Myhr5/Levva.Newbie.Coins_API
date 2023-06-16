using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;

namespace Levva.Newbie.Coins.Logic.Interfaces
{
    public interface ICategoryService
    {
        CategoryDto Create(CreateCategoryDto category);
        CategoryDto Get(int Id);
        List<CategoryDto> GetAll();
        void Update(CategoryDto category);
        void Delete(int Id);
    }
}
