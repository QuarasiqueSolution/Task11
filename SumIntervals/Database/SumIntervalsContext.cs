using System.Data.Entity;

namespace Task11
{
    public class SumIntervalsContext: DbContext
    {
        public DbSet<SumInterval> Results { get; set; }

        public SumIntervalsContext() : base()
        {
            Database.SetInitializer(new SumIntervalDbInitializer());
        }
    }
}
