using InventoryManagement.Data;

namespace InventoryManagement.Repositories
{
    public class SalesRepository
    {
        private readonly InventoryManagementContext _db;

        public SalesRepository(InventoryManagementContext db)
        {
            _db = db;
        }

        public bool SellStockItems(int productId, int quantity)
        {
            // StockItem
            var stockItem = _db.StockItems.FirstOrDefault(si => si.ProductId == productId);
            if (stockItem == null)
            {
                return false;
            }
            if (stockItem.StockAmount < quantity)
            {
                return false;
            }
            stockItem.StockAmount = stockItem.StockAmount - quantity;
            _db.Update(stockItem);
            _db.SaveChanges();
            return true;
        }
    }
}
