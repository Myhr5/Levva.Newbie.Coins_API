using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using LevvaCoins.Logic.Dtos;

namespace Levva.Newbie.Coins.Logic.Interfaces
{
    public interface ITransactionService
    {
        TransactionDto Create(int id, CreateTransactionDto transacion);
        TransactionDto Get(int Id);
        List<TransactionDto> GetAll();
        void Update(TransactionDto transaction);
        void Delete(int Id);

        List<TransactionDto> SearchDescription(string search);
    }
}
