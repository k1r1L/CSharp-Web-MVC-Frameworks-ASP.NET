namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;

    public class PartsService : Service
    {
        public IEnumerable<SupplierViewModel> GetAllSuppliers()
        {
            return this.DbContext.Suppliers.Select(supplier => new SupplierViewModel()
            {
                Id = supplier.Id,
                Name = supplier.Name
            });
        }

        public void AddPart(AddPartBindingModel bindingModel)
        {
            int supplierId = int.Parse(bindingModel.Supplier.Substring(0, bindingModel.Supplier.IndexOf('.')));
            Part partEntity = new Part()
            {
                Name = bindingModel.Name,
                Price = bindingModel.Price,
                Quantity = bindingModel.Quantity ?? 1,
                Supplier = this.DbContext.Suppliers.Find(supplierId)
            };
            this.DbContext.Parts.Add(partEntity);
            this.DbContext.SaveChanges();
        }

        public IEnumerable<AllPartViewModel> GetAllParts()
        {
            return this.DbContext.Parts.Select(p => new AllPartViewModel()
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public AllPartViewModel GetPartById(int id)
        {
            Part partEntity = this.DbContext.Parts.Find(id);

            return Mapper.Map<AllPartViewModel>(partEntity);
        }

        public void DeletePart(int id)
        {
            Part partEntity = this.DbContext.Parts.Find(id);
            this.DbContext.Parts.Remove(partEntity);
            this.DbContext.SaveChanges();
        }
    }
}
