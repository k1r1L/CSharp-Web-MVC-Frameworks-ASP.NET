namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public User()
        {
            this.Logs = new HashSet<Log>();
        }

        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

    }
}
