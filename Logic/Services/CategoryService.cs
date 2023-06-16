using AutoMapper;
using Levva.Newbie.Coins.Data.Interfaces;
using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;

namespace Levva.Newbie.Coins.Logic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CategoryDto Create(CreateCategoryDto category)
        {
            var _category = _mapper.Map<Category>(category);
            return _mapper.Map<CategoryDto>(_repository.Create(_category));
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public CategoryDto Get(int Id)
        {
            var category = _mapper.Map<CategoryDto>(_repository.Get(Id));
            return category;
        }

        public List<CategoryDto> GetAll()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_repository.GetAll());
            return categories;
        }

        public void Update(CategoryDto category)
        {
            var _category = _mapper.Map<Category>(category);
            _repository.Update(_category);
        }
    }
}
