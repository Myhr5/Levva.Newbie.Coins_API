namespace Levva.Newbie.Coins.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
