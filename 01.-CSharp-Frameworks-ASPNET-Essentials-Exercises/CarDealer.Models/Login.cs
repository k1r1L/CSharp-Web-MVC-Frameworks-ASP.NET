namespace CarDealer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
