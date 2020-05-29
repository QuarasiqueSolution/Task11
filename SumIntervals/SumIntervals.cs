//Write a function called sumIntervals/sum_intervals() that accepts an array of intervals, and returns the sum of all the interval lengths.Overlapping intervals should only be counted once.
//Intervals

//Intervals are represented by a pair of integers in the form of an array.The first value of the interval will always be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.
//Overlapping Intervals

//List containing overlapping intervals:

//[
//   [1,4],
//   [7, 10],
//   [3, 5]
//]

//The sum of the lengths of these intervals is 7. Since[1, 4] and[3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.

using NUnit.Framework;
using System.Linq;
using Interval = System.ValueTuple<int, int>;

namespace Task11Library
{
    public class SumIntervals
    {
        public static int GetSumInterval((int, int)[] intervals)
        {
            var listOfIntervals = intervals.OrderBy(x => x.Item1).ToList();
            if (listOfIntervals.Count == 0)
            {
                return 0;
            }

            var intervalToAdd = listOfIntervals[0];
            int sum = 0;
            for (int i = 1; i < listOfIntervals.Count; i++)
            {
                if (intervalToAdd.Item2 < listOfIntervals[i].Item1)
                {
                    sum += intervalToAdd.Item2 - intervalToAdd.Item1;
                    intervalToAdd = listOfIntervals[i];
                }
                else if (intervalToAdd.Item2 >= listOfIntervals[i].Item1 && intervalToAdd.Item2 < listOfIntervals[i].Item2)
                {
                    intervalToAdd.Item2 = listOfIntervals[i].Item2;
                }
            }

            sum += intervalToAdd.Item2 - intervalToAdd.Item1;

            return sum;
        }

        [Test]
        public void ShouldHandleEmptyIntervals()
        {
            Assert.AreEqual(0, GetSumInterval(new Interval[] { }));
            Assert.AreEqual(0, GetSumInterval(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [Test]
        public void ShouldAddDisjoinedIntervals()
        {
            Assert.AreEqual(9, GetSumInterval(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            Assert.AreEqual(11, GetSumInterval(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            Assert.AreEqual(7, GetSumInterval(new Interval[] { (-1, 4), (-5, -3) }));
            Assert.AreEqual(78, GetSumInterval(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [Test]
        public void ShouldAddAdjacentIntervals()
        {
            Assert.AreEqual(54, GetSumInterval(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            Assert.AreEqual(23, GetSumInterval(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [Test]
        public void ShouldAddOverlappingIntervals()
        {
            Assert.AreEqual(7, GetSumInterval(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            Assert.AreEqual(6, GetSumInterval(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            Assert.AreEqual(19, GetSumInterval(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [Test]
        public void ShouldHandleMixedIntervals()
        {
            Assert.AreEqual(13, GetSumInterval(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            Assert.AreEqual(1234, GetSumInterval(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            Assert.AreEqual(158, GetSumInterval(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}