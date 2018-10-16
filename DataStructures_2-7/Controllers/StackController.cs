using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_2_7.Controllers
{
    public class StackController : Controller
    {
        // Static Stack object
        public static Stack<string> oStack = new Stack<string>();


        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        // Add one item to stack
        public ActionResult AddOne() 
        {
            oStack.Push("New Entry #" + (oStack.Count + 1));
            return View("Index");
        }

        // Add huge list to stack
        public ActionResult AddHugeList()
        {
            oStack.Clear();

            for (int i = 0; i < 2000; i++)
            {
                oStack.Push("New Entry #" + (i + 1));
            }
            return View("Index");
        }

        // Displays the stack
        public ActionResult DisplayStack()
        {
            foreach (string item in oStack) {
                ViewBag.Stack += "<li class=\"list-group-item\">" + item + "</li>";
             }

            return View("Index");
        }

        // Deletes item from stack
        public ActionResult DeleteFromStack()
        {
            oStack.Pop();
            return View("Index");
        }

        // Clears stack
        public ActionResult ClearStack()
        {
            oStack.Clear();
            return View("Index");
        }   
        
        // Searches for item in stack
        public ActionResult SearchStack()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (oStack.Contains("New Entry #3"))
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