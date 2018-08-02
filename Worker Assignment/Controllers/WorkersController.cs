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
    public class WorkersController : Controller
    {
        private ApplicationDbContext _context;

        public WorkersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Workers
        public ActionResult Index()
        {
            var viewModel = new WorkerFormSalaryViewModel()
            {
                Workers = _context.Workers.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new WorkerFormSalaryViewModel
            {
                Worker = _context.Workers.SingleOrDefault(w => w.Id == id),
                ChangeSalaries = _context.ChangeSalaries.Include(m=>m.Worker).Where(c=>c.WorkerId == id).ToList(),
                Workers = _context.Workers.Where(c=>c.Id==id).ToList()
            };
            if (viewModel.Worker == null)
                return HttpNotFound();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new WorkerFormSalaryViewModel();
            return View(viewModel);
        }

        public ActionResult Save(Worker worker)
        {
            if(worker.Id == 0)
                _context.Workers.Add(worker);
            else
            {
                var workerInDb = _context.Workers.Single(c => c.Id == worker.Id);
                workerInDb.Name = worker.Name;
                workerInDb.Salary = worker.Salary;
                workerInDb.Location = workerInDb.Location;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var worker = _context.Workers.SingleOrDefault(c => c.Id == id);
            if (worker == null)
                return HttpNotFound();
            var viewModel = new WorkerFormSalaryViewModel()
            {
                Worker = worker
            };
            return View("New", viewModel);
        }

        public ActionResult ViewDelete(int id)
        {
            var worker = _context.Workers.SingleOrDefault(c => c.Id == id);
            return View(worker);
        }

        public ActionResult Delete(Worker worker)
        {
            var viewModel = new WorkerFormSalaryViewModel()
            {
                Worker = _context.Workers.SingleOrDefault(m=>m.Id == worker.Id),
                ChangeSalaries = _context.ChangeSalaries.Where(c=>c.WorkerId == worker.Id)
            };
            if (viewModel.Worker == null)
                return HttpNotFound();
            _context.ChangeSalaries.RemoveRange(viewModel.ChangeSalaries);
            _context.Workers.Remove(viewModel.Worker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Seach(string input)
        {
            Int32.TryParse(input, out int val);
            var viewModel = new WorkerFormSalaryViewModel()
            {
                Workers = _context.Workers.Where(c=>c.Id == val ||c.Name == input || c.Location == input).ToList(),
                          
                    
                Input = input
            };
            return View(viewModel);
        }
    }
}