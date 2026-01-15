using System;

namespace DeluxeHotelMVC.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        // Şifre düz metin tutulmaz!
        // Hash olarak saklanır.
        public string PasswordHash { get; set; }

        // SQL datetime sorununu çözmek için default değer
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

