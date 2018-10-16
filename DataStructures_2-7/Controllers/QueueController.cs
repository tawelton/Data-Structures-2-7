using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_2_7.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> myQueue = new Queue<string>();
        public static int i = 0;
        public static int entryNumber = 0;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View();
        }

        public ActionResult AddOne()
        {
            ++i;
            ++entryNumber;
            myQueue.Enqueue("New Entry #" + entryNumber.ToString());
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            myQueue.Clear();
            i = 0;
            entryNumber = 0;
            while (i < 2000)
            {
                ++i;
                ++entryNumber;
                myQueue.Enqueue("New Entry #" + entryNumber.ToString());
            }
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View();
        }

        public ActionResult Delete()
        {
            --i;
            myQueue.Dequeue();
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();
            i = 0;
            entryNumber = 0;
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View("Index");
        }

        public ActionResult Search()
        {
       
            bool isFound = false;
            string searchEntry = "New Entry #1456";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

                if (myQueue.Contains(searchEntry))
                {
                    ViewBag.message = "Record Exists: True";
                }
                else
                {
                    ViewBag.message = "Record Exists: False";
                }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = "Search Time: " + ts.Milliseconds + "ms";
         
            return View("Search");
        }

        /*public ActionResult ReturnToMenu()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.i = i;
            return View("Index");
        }*/
    }
}