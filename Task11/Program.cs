using NUnit.Framework;
using System.Linq;
using Interval = System.ValueTuple<int, int>;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        internal static int sumIntervals((int, int)[] intervals)
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
            Assert.AreEqual(0, sumIntervals(new Interval[] { }));
            Assert.AreEqual(0, sumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [Test]
        public void ShouldAddDisjoinedIntervals()
        {
            Assert.AreEqual(9, sumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            Assert.AreEqual(11, sumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            Assert.AreEqual(7, sumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
            Assert.AreEqual(78, sumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [Test]
        public void ShouldAddAdjacentIntervals()
        {
            Assert.AreEqual(54, sumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            Assert.AreEqual(23, sumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [Test]
        public void ShouldAddOverlappingIntervals()
        {
            Assert.AreEqual(7, sumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            Assert.AreEqual(6, sumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            Assert.AreEqual(19, sumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [Test]
        public void ShouldHandleMixedIntervals()
        {
            Assert.AreEqual(13, sumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            Assert.AreEqual(1234, sumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            Assert.AreEqual(158, sumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }
    }
}
