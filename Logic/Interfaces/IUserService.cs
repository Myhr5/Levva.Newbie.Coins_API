using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;

namespace Levva.Newbie.Coins.Logic.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto userDto);
        UserDto Get(int Id);
        List<UserDto> GetAll();
        void Update(UserDto userDto);
        void Delete(int Id);
        LoginAuthDto Login(LoginDto loginDto);
    }
}
