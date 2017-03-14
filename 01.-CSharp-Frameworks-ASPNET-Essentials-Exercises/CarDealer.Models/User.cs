namespace CarDealer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
