namespace UrunSatis.Models
{
    public class Users
    {
        public int Id { get; set; } // Primary Key
        public string FirstName { get; set; } = null!; // First Name
        public string LastName { get; set; } = null!; // Last Name
        public string Email { get; set; } = null!; // Email
        public string Password { get; set; } = null!; // Password
        public bool IsAdmin { get; set; } // Is Admin? (For admin users)
    }
}
