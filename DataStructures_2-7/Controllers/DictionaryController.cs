using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_2_7.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<string, int> oDictionary = new Dictionary<string, int>();
        
        
        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        // Add one item to Dictionary
        public ActionResult AddOne()
        {
            oDictionary.Add(("New Entry #" +(oDictionary.Count+1)),(oDictionary.Count+1));
            return View("Index");
        }

        // Add huge list to Dictionary
        public ActionResult AddHugeList()
        {
            oDictionary.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                oDictionary.Add(("New Entry #" + i), i);
            }
            return View("Index");
        }

        // Displays the Dictionary
        public ActionResult DisplayDictionary()
        {
            foreach (KeyValuePair<string,int> item in oDictionary)
            {
                ViewBag.Dictionary += "<li class=\"list-group-item\">New Entry #" + item.Value.ToString() + "</li>";
            }

            return View("Index");
        }

        // Deletes item from Dictionary
        public ActionResult DeleteFromDictionary()
        {
            oDictionary.Remove("New Entry #"+oDictionary.Count);
            return View("Index");
        }

        // Clears Dictionary
        public ActionResult ClearDictionary()
        {
            oDictionary.Clear();
            return View("Index");
        }

        // Searches for item in Dictionary
        public ActionResult SearchDictionary()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (oDictionary.ContainsKey("New Entry #7"))
            {
                ViewBag.SearchResult = "Record Exists: True";
            }
            else
            {
                ViewBag.SearchResult = "Record Exists: False";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = "Search Time: " + ts.Milliseconds + "ms";

            return View("Index");
        }
    }
}