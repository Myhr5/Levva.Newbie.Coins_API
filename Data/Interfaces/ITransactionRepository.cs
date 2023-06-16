using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;

namespace Levva.Newbie.Coins.Data.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        Transaction Get(int Id);
        List<Transaction> GetAll();
        void Update(Transaction transaction);
        void Delete(int Id);

        ICollection<Transaction> SearchByDescription(string search);
    }
}
