namespace CarDealer.ViewModels.Sales
{
    using System.Collections.Generic;

    public class AddSaleViewModel
    {
        public AddSaleViewModel()
        {
            this.Discounts = new double[]
            {
                5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90
            };
        }
        public IEnumerable<AddSaleCustomerViewModel> Customers { get; set; }

        public IEnumerable<AddSaleCarViewModel> Cars { get; set; }

        public IEnumerable<double> Discounts { get; set; }
    }
}
