using System;
using System.Data.Entity;

namespace Task11
{
    public class SumIntervalDbInitializer: CreateDatabaseIfNotExists<SumIntervalsContext>
    {
        protected override void Seed(SumIntervalsContext context)
        {
            context.Results.Add(new SumInterval { Result = 1 });
            context.Results.Add(new SumInterval { Result = 2 });
            context.Results.Add(new SumInterval { Result = 3 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
