using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Data
{
    public class DbInitializer
    {
        private readonly IDbContextFactory<StockDbContext> _factory;
        public DbInitializer(IDbContextFactory<StockDbContext> factory) => _factory = factory;

        public async Task EnsureCreatedAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            await db.Database.EnsureCreatedAsync();

            // --- Optional: seed a little data on empty DB ---
            if (!await db.Aisles.AnyAsync())
            {
                var a1 = new Models.Aisle { AisleId = 1, RackId = 1001, FloorLevel = 1 };
                var lvl = new Models.AisleLevel { LevelId = 1, AisleId = 1 };
                var p = new Models.Product { ProductId = 1000000000001, AisleId = 1, AisleLevelId = 1, StockInTotal = 50, StockOnRack = 10 };

                db.Aisles.Add(a1);
                db.AisleLevels.Add(lvl);
                db.Products.Add(p);
                await db.SaveChangesAsync();
            }
        }
    }
}
