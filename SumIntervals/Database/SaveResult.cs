namespace Task11Library
{
    public static class SaveResult
    {
        public static void Save(SumInterval sumInterval)
        {
            using (var db = new SumIntervalsContext())
            {
                db.Results.Add(sumInterval);
                db.SaveChanges();
            }
        }
    }
}