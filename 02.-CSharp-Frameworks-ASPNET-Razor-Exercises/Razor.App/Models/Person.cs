namespace Razor.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public string Name { get; set; }

        [UIHint("Age")]
        public int Age { get; set; }

        [UIHint("Email")]
        public string Email { get; set; }

        [UIHint("IsSubscribed")]
        public bool IsSubscribed { get; set; }
    }
}