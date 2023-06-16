using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;
using LevvaCoins.Logic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbie.Coins.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;
        private readonly ICategoryService _categoryService;
        public TransactionController(ITransactionService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionDto transaction)
        {
            var userId = User.Identity!.Name;
            var category = _categoryService.Get(transaction.CategoryId);
            var createdTransaction = _service.Create(Convert.ToInt32(userId), transaction);

            createdTransaction.Category = category;

            return Created("Transaction created", createdTransaction);
        }

        [HttpGet("{SearchInput}")]
        public ActionResult<List<TransactionDto>> Get(string SearchInput)
        {
            return _service.Search(SearchInput);
        }

        [HttpGet("list")]
        public ActionResult<List<TransactionDto>> GetAll([FromQuery] string? search)
        {
            if (search == null) return _service.GetAll();

            return _service.GetAll();
        }

        [HttpPut]
        public IActionResult Update(TransactionDto transaction)
        {
            _service.Update(transaction);
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
