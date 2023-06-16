using AutoMapper;
using Levva.Newbie.Coins.Data.Interfaces;
using Levva.Newbie.Coins.Domain.Models;
using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Levva.Newbie.Coins.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(IUserRepository repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        public void Create(UserDto user)
        {
            var _user = _mapper.Map<User>(user);
            _repository.Create(_user);

        }

        public List<UserDto> GetAll()
        {
            var users = _mapper.Map<List<UserDto>>(_repository.GetAll());
            return users;
        }

        public UserDto Get(int Id)
        {
            var _user = _mapper.Map<UserDto>(_repository.Get(Id));
            return _user;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }


        public void Update(UserDto user)
        {
            var _user = _mapper.Map<User>(user);
            _repository.Update(_user);
        }

        public LoginAuthDto Login(LoginDto login)
        {
            var user = _repository.GetByEmailAndPassword(login.Email, login.Password);
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var auth = new LoginAuthDto { Id = user.Id, Email = user.Email, Name = user.Name };

            auth.Token = "Bearer " + tokenHandler.WriteToken(token);
            //login.Name = usuario.Name;
            //login.Email = usuario.Email;
            //login.Password = null;
            //login.Id = usuario.Id;
            return auth;
        }
    }

}
