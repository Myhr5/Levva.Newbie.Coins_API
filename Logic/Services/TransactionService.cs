using AutoMapper;
using Levva.Newbie.Coins.Data.Interfaces;
using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;
using LevvaCoins.Logic.Dtos;

namespace Levva.Newbie.Coins.Logic.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public TransactionDto Create(int user, CreateTransactionDto transaction)
        {
            var _transaction = _mapper.Map<Transaction>(transaction);
            _transaction.UserId = user;
            _transaction.CreatedAt =DateTime.Now;

            return _mapper.Map<TransactionDto>(_repository.Create(_transaction));
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public TransactionDto Get(int Id)
        {
            var transaction = _mapper.Map<TransactionDto>(_repository.Get(Id));
            return transaction;
        }

        public List<TransactionDto> GetAll()
        {
            var transactions = _mapper.Map<List<TransactionDto>>(_repository.GetAll());
            return transactions;
        }

        public void Update(TransactionDto transaction)
        {
            var _transaction = _mapper.Map<Transaction>(transaction);
            _repository.Update(_transaction);
        }

        public List<TransactionDto> Search(string search)
        {
            var transactions = _repository.GetAll();
            var searchedTransaction = transactions.Where(transaction =>
            {
                var listByDescription = transaction.Description.Contains(search);
                var listByCategoryDescription = transaction.Category.Description.Contains(search); 
                
                return listByCategoryDescription && listByCategoryDescription;
            }).ToList();
            var mappedList = _mapper.Map<List<TransactionDto>>(searchedTransaction);
            return mappedList;
        }
    }
}
