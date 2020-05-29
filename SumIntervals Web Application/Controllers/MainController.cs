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
        public string SumIntervalsForm(string InputTextbox)
        {
            string finalResultString = "";
            int[] intervalsArray = InputTextbox.Split(' ').Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
            if (intervalsArray.Length <= 1)
            {
                return "Array is empty or not filled!";
            }
            if (intervalsArray.Length % 2 != 0)
            {
                finalResultString += "Warning: Last interval contains only one number. Erasing last interval...\n";
                intervalsArray = intervalsArray.Take(intervalsArray.Length - 1).ToArray();
            }
            int intervalsLength = intervalsArray.Length / 2;
            ValueTuple<int, int>[] intervals = new ValueTuple<int, int>[intervalsLength];
            for (int i = 0; i < intervalsLength; i++)
            {
                intervals[i].Item1 = intervalsArray[i + i];
                intervals[i].Item2 = intervalsArray[i + i + 1];
            }
            finalResultString += "Intervals: \n";
            foreach (var e in intervals)
            {
                finalResultString += "[" + e.Item1 + ", " + e.Item2 + "]\n";
            }
            int result = SumIntervals.GetSumInterval(intervals);
            finalResultString += "Sum of these intervals: " + result + "\n";
            SaveResult.Save(new SumInterval { Result = result });
            finalResultString += "Result was inserted into database.";
            return finalResultString;
        }
    }
}