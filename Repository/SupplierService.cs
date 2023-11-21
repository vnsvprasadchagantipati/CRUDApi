using CRUDApi.Entities;
using CRUDApi.Services;
using CRUDApi.Database;

namespace CRUDApi.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly MyContext _context;
        public SupplierService()
        {

            _context = new MyContext();
        }

        public void AddSupplier(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Supplier> getSuppliers()
        {
            try
            {
                return _context.Suppliers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveSupplier(string suplNo)
        {
            try
            {
                Supplier supplier = _context.Suppliers.Find(suplNo);
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void updateSupplier(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
