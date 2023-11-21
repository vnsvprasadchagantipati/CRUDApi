using CRUDApi.Services;
using CRUDApi.Entities;
using CRUDApi.Database;

namespace CRUDApi.Repository
{
    public class ItemService : IItemService
    {
        private readonly MyContext _context;
        public ItemService()
        {

            _context = new MyContext();

        }
        public void Add(Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Item getItemByCode(string itemCode)
        {
            try
            {
               Item item = _context.Items.Find(itemCode);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Item getItemBYName(string itemName)
        {
            try
            {
                Item item = _context.Items.SingleOrDefault(i => i.ItemDesc == itemName);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Item> getItems()
        {
            try
            {
                return _context.Items.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(string itemCode)
        {
            try
            {
                Item item = _context.Items.Find(itemCode);
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Item item)
        {
            try
            {

                _context.Items.Update(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
