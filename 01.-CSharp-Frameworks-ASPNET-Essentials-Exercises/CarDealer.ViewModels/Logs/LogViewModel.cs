namespace CarDealer.ViewModels.Logs
{
    using System;

    public class LogViewModel
    {
        public int Id { get; set; }

        public string Operation { get; set; }

        public string ModifiedTable { get; set; }

        public DateTime TimeLogged { get; set; }

        public string Owner { get; set; }
    }
}
