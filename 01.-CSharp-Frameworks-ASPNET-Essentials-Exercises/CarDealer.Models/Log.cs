namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Attributes;

    public class Log
    {
        public int Id { get; set; }

        [Operation, Required]
        public string Operation { get; set; }

        [Required]
        public string ModifiedTable { get; set; }

        [Required]
        public DateTime TimeLogged { get; set; }

        public virtual User Owner { get; set; }
    }
}
