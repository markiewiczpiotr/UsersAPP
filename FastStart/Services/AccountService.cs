/*
using FastStart.Entities;
using FastStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDTO dto);
    }
    public class AccountService : IAccountService
    {
        private readonly UsersDbContext _context;
        public AccountService(UsersDbContext context)
        {
            _context = context;
        }
        public void RegisterUser(RegisterUserDTO dto)
        {
            var newRegistered = new Users()
            {
                eMail = dto.eMail,
                DataUrodzin = dto.DataUrodzin,
                Rola = dto.Rola
            };
            _context.Users.Add(newRegistered);
            _context.SaveChanges();
        }
    }
}
*/