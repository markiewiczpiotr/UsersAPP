using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastStart.Entities;

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
                    eMail = "markiewiczpiotr85@gmail.com",
                    nrFBO = 480900107375,
                    nrTel = "+48600100001",
                    Rola = "Admin"
                },
                new Users()
                {
                    Imie = "Aneta",
                    Nazwisko = "Markiewicz",
                    eMail = "anetaszmagla@gmail.com",
                    nrFBO = 480900093437,
                    nrTel = "+48600100002",
                    Rola = "Manager"
                },
                new Users()
                {
                    Imie = "Anna",
                    Nazwisko = "Golebicka",
                    eMail = "a.golebicka@gmail.com",
                    nrFBO = 480900093433,
                    nrTel = "+48600100003",
                    Rola = "User"
                }
            };
            return users;
        }
    }
}