using CRUDApi.Entities;

namespace CRUDApi.Services
{
    public interface IItemService
    {
        void Add(Item item);
        void Remove(string itemCode);
      List<Item> getItems();
        Item getItemByCode(string itemCode);
        Item getItemBYName(string itemName);

        void Update(Item item);
    }
}
