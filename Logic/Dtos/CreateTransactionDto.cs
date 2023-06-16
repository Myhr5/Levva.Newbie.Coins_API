using Levva.Newbie.Coins.Domain.Enums;

namespace LevvaCoins.Logic.Dtos
{
    public class CreateTransactionDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }
        public int CategoryId { get; set; }
    }
}