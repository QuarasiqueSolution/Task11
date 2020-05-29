using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task11Library;

namespace SumIntervals_Web_Application.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            List<SumInterval> sumIntervals = GetLastResults.GetRows();
            SelectList results = new SelectList(sumIntervals, "Id", "Result");
            ViewBag.Results = results;
            return View();
        }

        [HttpPost]
        public ViewResult SumIntervalsForm(string InputTextbox)
        {
            int[] intervalsArray = InputTextbox.Split(' ').Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
            if (intervalsArray.Length <= 1)
            {
                ViewBag.IntervalsLabel = "Array is empty or not filled!";
                ViewBag.SumIntervalsLabel = "";
                ViewBag.DbLabel = "";
                return View("~/Views/Main/Result.cshtml");
            }
            if (intervalsArray.Length % 2 != 0)
            {
                ViewBag.WarningLabel = "Warning: Last interval contains only one number. Erasing last interval...";
                intervalsArray = intervalsArray.Take(intervalsArray.Length - 1).ToArray();
            }
            int intervalsLength = intervalsArray.Length / 2;
            ValueTuple<int, int>[] intervals = new ValueTuple<int, int>[intervalsLength];
            for (int i = 0; i < intervalsLength; i++)
            {
                intervals[i].Item1 = intervalsArray[i + i];
                intervals[i].Item2 = intervalsArray[i + i + 1];
            }
            string inputedIntervals = "Intervals: \n";
            foreach (var e in intervals)
            {
                inputedIntervals += "[" + e.Item1 + ", " + e.Item2 + "]";
            }
            int result = SumIntervals.GetSumInterval(intervals);
            SaveResult.Save(new SumInterval { Result = result });

            ViewBag.IntervalsLabel = inputedIntervals;
            ViewBag.SumIntervalsLabel = "Sum of these intervals: " + result.ToString();
            ViewBag.DbLabel = "Result was inserted into database.";
            return View("~/Views/Main/Result.cshtml");
        }
    }
}