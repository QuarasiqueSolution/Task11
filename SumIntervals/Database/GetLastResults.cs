using System.Collections.Generic;
using System.Linq;

namespace Task11Library
{
    public static class GetLastResults
    {
        public static List<SumInterval> GetRows()
        {
            IQueryable<SumInterval> sumIntervals;
            using (var db = new SumIntervalsContext())
            {
                sumIntervals = db.Results.OrderByDescending(x => x.Id).Take(5);
                return sumIntervals.ToList();
            }
        }
    }
}