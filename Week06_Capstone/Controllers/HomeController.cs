using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Week06_Capstone.Models;

namespace Week06_Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TaskByID(int? id)
        {
            TaskListEntities orm = new TaskListEntities();
            List<Task> taskList = orm.Tasks.ToList();
            List<Task> newList = new List<Task>();

            foreach (Task i in taskList)
            {
                if (i.TaskID == id)
                {
                    newList.Add(i);
                }
            }

            ViewBag.Item = newList.ToList();

            return View();

        }

        public ActionResult TasksByUser(int? id)
        {
            TaskListEntities orm = new TaskListEntities();
            List<Task> taskList = orm.Tasks.ToList();
            List<Task> newList = new List<Task>();
           

            foreach (Task i in taskList)
            {
                if (i.Owner == id)
                {
                    newList.Add(i);
                }
            }            

           
            ViewBag.Item = newList.ToList();

            return View();



        }
    }
}