using System.Data.Entity;

namespace Task11Library
{
    public class SumIntervalsContext : DbContext
    {
        public DbSet<SumInterval> Results { get; set; }

        public SumIntervalsContext() : base("SumOfInterval")
        {
            Database.SetInitializer(new SumIntervalDbInitializer());
        }
    }
}