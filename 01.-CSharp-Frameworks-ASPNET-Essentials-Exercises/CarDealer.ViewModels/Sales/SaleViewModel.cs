﻿namespace CarDealer.ViewModels.Sales
{
    using Cars;
    using Customers;

    public class SaleViewModel
    {
        public CarViewModel Car { get; set; }

        public CustomerViewModel Customer { get; set; }

        public double? PriceWithDiscount { get; set; }

        public double? PriceWithoutDiscount { get; set; }

        public int DiscountPercentage { get; set; }
    }
}