namespace CarDealer.BindingModels
{
    using System.Collections.Generic;

    public class AddCarBindingModel
    {
        public string Model { get; set; }

        public string Make { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<int> Parts { get; set; }
    }
}
