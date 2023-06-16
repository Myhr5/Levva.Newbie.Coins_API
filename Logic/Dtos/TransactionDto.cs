using Levva.Newbie.Coins.Domain.Enums;

namespace Levva.Newbie.Coins.Logic.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Type { get; set; }
        public virtual CategoryDto? Category { get; set; }
    }
}
