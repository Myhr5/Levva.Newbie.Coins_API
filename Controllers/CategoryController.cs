using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbie.Coins.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto category)
        {
            var createdCategory = _service.Create(category);
            return Created("", createdCategory);
        }

        [HttpGet]
        public ActionResult<CategoryDto> Get(int Id)
        {
            return _service.Get(Id);
        }

        
        [HttpGet("list")]
        public ActionResult<List<CategoryDto>> GetAll(int Id)
        {
            return _service.GetAll();
        }


        [HttpPut]
        public IActionResult Update(CategoryDto category)
        {
            _service.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return Ok();
        }
    }
}
