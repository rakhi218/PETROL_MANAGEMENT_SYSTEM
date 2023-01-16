using Microsoft.EntityFrameworkCore;

namespace Pump_Data.DataContext
{
    public class PumpDBContext : DbContext
    {
        public PumpDBContext(DbContextOptions<PumpDBContext> options) : base(options) { }

        public DbSet<PumpDBContext> Pump_Data { get; set; }
    }
}
