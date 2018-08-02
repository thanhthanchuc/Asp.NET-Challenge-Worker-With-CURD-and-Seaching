using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worker_Assignment.Models;
using System.Data.Entity;
using Worker_Assignment.ViewModel;

namespace Worker_Assignment.Controllers
{
    public class ChangeSalarysController : Controller
    {
        private ApplicationDbContext _context;

        public ChangeSalarysController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ChangeSalarys
        public ActionResult ChangeSalary(int id)
        {
            var viewModel = new WorkerFormSalaryViewModel
            {
                ChangeSalaries = _context.ChangeSalaries.Where(c=>c.WorkerId == id).ToList(),
                Worker = _context.Workers.SingleOrDefault(c=>c.Id == id),
                Workers = _context.Workers.Where(c=>c.Id == id).ToList()
            };
            
            return View(viewModel);
        }

        public ActionResult Save(ChangeSalary changeSalary)
        {
            var id = changeSalary.WorkerId;
            var viewModel = new WorkerFormSalaryViewModel()
            {
                Worker = _context.Workers.Single(c => c.Id == changeSalary.WorkerId)
            };
               
            changeSalary.DateChanged = DateTime.Now;
            changeSalary.Status = changeSalary.UporDownSalary >= 0;
            _context.ChangeSalaries.Add(changeSalary);
            int salary = Convert.ToInt32(viewModel.Worker.Salary) + Convert.ToInt32(changeSalary.UporDownSalary);
            viewModel.Worker.Salary = salary.ToString();
            _context.SaveChanges();
            return RedirectToAction("Details", "Workers", new { id });
        }

        public ActionResult Changed(int id)
        {
            var viewModel = new WorkerFormSalaryViewModel()
            {
                ChangeSalary = _context.ChangeSalaries.SingleOrDefault(c=>c.Id == id)
            };
            return View("ChangeSalary", viewModel);
        }
    }
}