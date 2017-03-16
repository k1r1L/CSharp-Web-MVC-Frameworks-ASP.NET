namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;
    using ViewModels.Parts;
    using ViewModels.Suppliers;

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

        public AllPartViewModel GetAllPartById(int id)
        {
            Part partEntity = this.DbContext.Parts.Find(id);

            return Mapper.Map<AllPartViewModel>(partEntity);
        }

        public EditPartViewModel GetEditPartById(int id)
        {
            Part partEntity = this.DbContext.Parts.Find(id);
            EditPartViewModel epvm = Mapper.Map<EditPartViewModel>(partEntity);

            return epvm;
        }

        public void DeletePart(int id)
        {
            Part partEntity = this.DbContext.Parts.Find(id);
            this.DbContext.Parts.Remove(partEntity);
            this.DbContext.SaveChanges();
        }

        public void EditPart(EditPartBindingModel bindingModel)
        {
            Part partEntity = this.DbContext.Parts.Find(bindingModel.Id);
            if (partEntity != null)
            {
                partEntity.Price = bindingModel.Price;
                partEntity.Quantity = bindingModel.Quantity;
                this.DbContext.Entry(partEntity).State = EntityState.Modified;
                this.DbContext.SaveChanges();
            }

        }
    }
}
