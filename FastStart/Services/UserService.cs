using AutoMapper;
using FastStart.Entities;
using FastStart.Exceptions;
using FastStart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastStart.Services
{
    public interface IUserService
    {
        int Create(CreateUsersDTO dto);
        IEnumerable<UsersDTO> GetAll(string searchPhrase);
        UsersDTO GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateUsersDTO dto);
        string GenerateJwt(LoginDTO dto);
    }

    public class UserService : IUserService
    {
        private readonly UsersDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(UsersDbContext dbContext, IMapper mapper, ILogger<UserService> logger, 
            IPasswordHasher<Users> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public IEnumerable<UsersDTO> GetAll(string searchPhrase)
        {
            var users = _dbContext
                .Users
                .Where(u => searchPhrase == null || u.Rola.ToLower().Contains(searchPhrase.ToLower()))
                .ToList();

            var usersDTOs = _mapper.Map<List<UsersDTO>>(users);
            return usersDTOs;
        }
        public UsersDTO GetById(int id)
        {
            var users = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (users is null)
                throw new NotFoundExceptions("User not found");

            var result = _mapper.Map<UsersDTO>(users);
            return result;
        }
        public int Create(CreateUsersDTO dto)
        {
            _logger.LogWarning($"Someone added a new user");

            var users = _mapper.Map<Users>(dto);

            var hashedPassword = _passwordHasher.HashPassword(users, dto.Password);

            users.Password = hashedPassword;
            _dbContext.Users.Add(users);
            _dbContext.SaveChanges();

            if (users is null)
                throw new NotFoundExceptions("User not found");

            return users.Id;
        }
        public void Update(int id, UpdateUsersDTO dto)
        {
            _logger.LogWarning($"User with id: {id} UPDATE action invoked");

            var users = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (users is null)
                throw new NotFoundExceptions("User not found");

            users.Nazwisko = dto.Nazwisko;
            users.Email = dto.Email;
            users.NrTel = dto.NrTel;
            users.Rola = dto.Rola;

            var hashedPassword = _passwordHasher.HashPassword(users, dto.Password);

            users.Password = hashedPassword;

            _dbContext.SaveChanges();

        }
        public void Delete(int id)
        {
            _logger.LogWarning($"User with id: {id} DELETE action invoked");

            var users = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (users is null)
                throw new NotFoundExceptions("User not found");

            _dbContext.Users.Remove(users);
            _dbContext.SaveChanges();

        }

        public string GenerateJwt(LoginDTO dto)
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Imie} {user.Nazwisko}"),
                new Claim(ClaimTypes.Role, user.Rola),
                new Claim("DataUrodzenia", $"{user.DataUrodzenia}"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
