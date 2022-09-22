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
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Users> GetUsers()
        {
            var users = new List<Users>()
            {
                new Users()
                {
                    Imie = "Anna",
                    Nazwisko = "Manna",
                    Email = "a.manna@email.com",
                    NrFBO = 480901001113,
                    NrTel = "+48600100003",
                    Rola = "User"
                },
                new Users()
                {
                    Imie = "Ada",
                    Nazwisko = "Mada",
                    Email = "a.mada@email.com",
                    NrFBO = 480901001112,
                    NrTel = "+48600100002",
                    Rola = "Manager"
                },
                new Users()
                {
                    
                    Imie = "Adam",
                    Nazwisko = "Madam",
                    Email = "a.madam@email.com",
                    NrFBO = 480901001111,
                    NrTel = "+48600100001",
                    Rola = "Admin"
                }
            };
            return users;
        }
    }
}