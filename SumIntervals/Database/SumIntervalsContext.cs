using System.Data.Entity;

namespace Task11Library
{
    public class SumIntervalsContext: DbContext
    {
        public DbSet<SumInterval> Results { get; set; }

        public SumIntervalsContext() : base("Test854203")
        {
            Database.SetInitializer(new SumIntervalDbInitializer());
        }
    }
}
