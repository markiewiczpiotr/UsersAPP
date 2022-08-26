using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastStart.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastStart.Migrations
{
    public class UsersSeeder
    {
        private readonly UsersDbContext _dbContext;

        public UsersSeeder(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Roles> GetRoles()
        {
            var roles = new List<Roles>()
            {
                new Roles()
                {
                    Nazwa = "Admin"
                },
                new Roles()
                {
                    Nazwa = "Manager"
                },new Roles()
                {
                    Nazwa = "User"
                },
            };
            return roles;
        }
        private IEnumerable<Users> GetUsers()
        {
            var users = new List<Users>()
            {
                new Users()
                {
                    Imie = "Piotr",
                    Nazwisko = "Markiewicz",
                    Email = "markiewiczpiotr85@gmail.com",
                    NrFBO = 480900107375,
                    NrTel = "+48600100001",
                    Rola = "Admin"
                },
                new Users()
                {
                    Imie = "Aneta",
                    Nazwisko = "Markiewicz",
                    Email = "anetaszmagla@gmail.com",
                    NrFBO = 480900093437,
                    NrTel = "+48600100002",
                    Rola = "Manager"
                },
                new Users()
                {
                    Imie = "Anna",
                    Nazwisko = "Golebicka",
                    Email = "a.golebicka@gmail.com",
                    NrFBO = 480900093433,
                    NrTel = "+48600100003",
                    Rola = "User"
                }
            };
            return users;
        }
    }
}