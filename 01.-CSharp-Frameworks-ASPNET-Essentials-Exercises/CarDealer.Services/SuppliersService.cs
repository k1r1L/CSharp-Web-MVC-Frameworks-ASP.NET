namespace CarDealer.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;
    using ViewModels.Suppliers;

    public class SuppliersService : Service
    {
        public IEnumerable<SupplierViewModel> GetAllSuppliersByType(string type)
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

        public IEnumerable<NewSupplierViewModel> GetNewSuppliersVm()
        {
            IEnumerable<Supplier> suppliersInDb = this.DbContext.Suppliers;
            IEnumerable<NewSupplierViewModel> allSuppliers =
                Mapper.Map<IEnumerable<Supplier>, IEnumerable<NewSupplierViewModel>>(suppliersInDb);

            return allSuppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            this.DbContext.Suppliers.Add(supplier);
            this.DbContext.SaveChanges();
        }

        public void EditSupplier(EditSupplierBindingModel esbm)
        {
            Supplier supplierEntity = this.DbContext.Suppliers.Find(esbm.Id);
            supplierEntity.Name = esbm.Name;
            this.DbContext.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            Supplier supplierEntity = this.DbContext.Suppliers.Find(id);
            List<Part> parts = supplierEntity.Parts.ToList();
            foreach (Part part in parts)
            {
                this.DbContext.Entry(part).State = EntityState.Deleted;
            }

            this.DbContext.Entry(supplierEntity).State = EntityState.Deleted;
            this.DbContext.SaveChanges();
        }

        public EditSupplierViewModel GetEditSupplierViewModel(int id)
        {
            Supplier supplierEntity = this.DbContext.Suppliers.Find(id);
            EditSupplierViewModel vm = Mapper.Map<EditSupplierViewModel>(supplierEntity);

            return vm;
        }

        public DeleteSupplierViewModel GetDeleteSupplierViewModel(int id)
        {
            Supplier supplierEntity = this.DbContext.Suppliers.Find(id);
            DeleteSupplierViewModel vm = Mapper.Map<DeleteSupplierViewModel>(supplierEntity);

            return vm;
        }
    }
}
