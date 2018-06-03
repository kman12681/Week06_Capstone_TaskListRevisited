using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Week06_Capstone.Models;

namespace Week06_Capstone.Controllers
{
    public class SearchController : Controller
    {
        private TaskListEntities db = new TaskListEntities();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskSearch(string word)
        {

            TaskListEntities orm = new TaskListEntities();

            ViewBag.Items = orm.Tasks.Where(x => x.Description.Contains(word)).ToList();
            if (ViewBag.Items == null)
            {
                ViewBag.Message = "No tasks matching that description";
                return View();
            }
            else
            {
                return View();
            }

        }

        public ActionResult ShowStatus(string status)
        {
            TaskListEntities orm = new TaskListEntities();

            if (status == "c")
            {

                ViewBag.Item = orm.Tasks.Where(x => x.Status == true).ToList();
                ViewBag.Message = "Completed Tasks";
                return View();
            }
            else if (status == "i")
            {
                ViewBag.Item = orm.Tasks.Where(x => x.Status == false).ToList();
                ViewBag.Message = "Incomplete Tasks";
                return View();
            }
            else
            {
                ViewBag.Item = orm.Tasks.Where(x => x.Description == null).ToList();
                ViewBag.Message = "Invalid entry: Enter 'c' or 'i'";
                return View();
            }
        }

        public ActionResult FilterTask(string filter)
        {
            TaskListEntities orm = new TaskListEntities();

            if (filter == "last")
            {
                ViewBag.Item = orm.Tasks.OrderByDescending(x => x.DueDate).ToList();
                ViewBag.Message = "Tasks arranged in descending order (later due dates first)";
                return View();
            }
            else if (filter == "first")
            {
                ViewBag.Item = orm.Tasks.OrderBy(x => x.DueDate).ToList();
                ViewBag.Message = "Tasks arranged in ascending order (later due dates last)";
                return View();
            }
            else 
            {
                ViewBag.Item = orm.Tasks.ToList();
                ViewBag.Message = "List not sorted. Choose 'first' or 'last' to sort";
                return View();
            }
            
        }
        
    }
}