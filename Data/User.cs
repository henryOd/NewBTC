namespace NewBTC.Data
{
    public class User
    {
        public int UserId { get; set; }

        public string? UserUserName { get; set; }

        public string? UserLastName { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserEmail { get; set; }

        public string? PasswordHash { get; set; }
        public string? BitcoinAddress { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



    }
}
