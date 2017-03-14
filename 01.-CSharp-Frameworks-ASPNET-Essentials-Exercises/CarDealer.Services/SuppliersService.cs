namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class SuppliersService : Service
    {
        public IEnumerable<SupplierViewModel> GetAllSuppliers(string type)
        {
            IEnumerable<SupplierViewModel> suppliers = null;
            if (type != null)
            {
                if (type == "importers")
                {
                    suppliers = this.DbContext.Suppliers
                        .Where(s => s.IsImporter)
                        .Select(s => new SupplierViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            NumberOfParts = s.Parts.Count
                        })
                        .ToList();
                }

                if (type == "local")
                {
                    suppliers = this.DbContext.Suppliers
                        .Where(s => !s.IsImporter)
                        .Select(s => new SupplierViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            NumberOfParts = s.Parts.Count
                        })
                        .ToList();
                }

                return suppliers;
            }

            return this.DbContext.Suppliers
                        .Select(s => new SupplierViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            NumberOfParts = s.Parts.Count
                        })
                        .ToList();
        }
    }
}
