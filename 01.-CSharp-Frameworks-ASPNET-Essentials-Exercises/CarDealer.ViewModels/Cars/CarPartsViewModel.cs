namespace CarDealer.ViewModels.Cars
{
    using System.Collections.Generic;
    using Parts;

    public class CarPartsViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }

        public List<PartViewModel> Parts { get; set; }
    }
}