using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public static class SeedInventoryTestData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new InventoryManagementContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<InventoryManagementContext>>()))
        {
            // Handle null context
            if (context == null || context.StockItems == null)
            {
                throw new ArgumentNullException("Null InventoryManagementContext");
            }

            // Look for availible stock.
            if (context.StockItems.Any())
            {
                return;
            }

            // Seed test records to DB (Note: similar logic for initializing seed-datawould usually be confined to unit-tests).
            context.StockItems.AddRange(
                new StockItem
                {
                    Description = "Brackets",
                    StockAmount = 6,
                    SafeStockAmount = 50,
                    Price = 3.99M
                },

                new StockItem
                {
                    Description = "Archwires",
                    StockAmount = 10,
                    SafeStockAmount = 10,
                    Price = 6.99M
                },

                new StockItem
                {
                    Description = "Bands & Buccal Tubes",
                    StockAmount = 1,
                    SafeStockAmount = 75,
                    Price = 19.99M
                },

                new StockItem
                {
                    Description = "Impression Materials",
                    StockAmount = 1,
                    SafeStockAmount = 100,
                    Price = 0.99M
                }
            );
            context.SaveChanges();
        }
    }
}