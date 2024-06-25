using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Repositrories
{
    public class OrderRepository
    {
        private readonly InventoryManagementContext _db;

        public OrderRepository(InventoryManagementContext db)
        {
            _db = db;
        }

        public bool GenerateOrder(int productId)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                // Order
                var order = _db.Orders.First();
                order ??= new Order();
                _db.Orders.Add(order);
                _db.SaveChanges();

                var stockItems = _db.StockItems.ToList();
                foreach (var stockItem in stockItems)
                {
                    // OrderDetail
                    var orderDetail = _db.OrderDetails.FirstOrDefault(od => od.ProductId == stockItem.ProductId);
                    var orderQuantity = GetOrderQuantity(stockItem);
                    if (orderDetail != null)
                    {
                        if (orderDetail.Quantity == orderQuantity)
                        {
                            return false;
                        }
                        orderDetail.Quantity = orderQuantity;
                        _db.Update(stockItem);
                    }
                    else
                    {
                        orderDetail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = productId,
                            Quantity = orderQuantity
                        };
                        _db.OrderDetails.Add(orderDetail);
                    }

                    _db.SaveChanges();
                }
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int GetOrderQuantity(StockItem stockItem)
        {   var maxOrderQuantity = (int)Math.Floor((decimal)100.00 / stockItem.Price);
            return stockItem.SafeStockAmount - stockItem.StockAmount < maxOrderQuantity 
                ? stockItem.SafeStockAmount - stockItem.StockAmount 
                : maxOrderQuantity;
        }
    }
}