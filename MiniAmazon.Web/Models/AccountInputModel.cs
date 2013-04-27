namespace MiniAmazon.Web.Models
{
    public class AccountInputModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string Genre { get; set; }
    }
}