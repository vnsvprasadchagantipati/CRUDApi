using CRUDApi.Entities;

namespace CRUDApi.Services
{
    public interface ISupplierService
    {
        void AddSupplier(Supplier supplier);
        void RemoveSupplier(string suplNo);
        void updateSupplier(Supplier supplier);
       List <Supplier> getSuppliers();
    }
}
