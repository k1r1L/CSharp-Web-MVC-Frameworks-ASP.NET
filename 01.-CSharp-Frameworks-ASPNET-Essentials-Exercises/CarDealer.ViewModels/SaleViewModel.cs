namespace CarDealer.ViewModels
{
    public class SaleViewModel
    {
        public CarViewModel Car { get; set; }

        public CustomerViewModel Customer { get; set; }

        public double? PriceWithDiscount { get; set; }

        public double? PriceWithoutDiscount { get; set; }

        public int DiscountPercentage { get; set; }
    }
}