namespace FastStart.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long NrFBO { get; set; }
        public string NrTel { get; set; }
        public string Rola { get; set; }

    }
}
