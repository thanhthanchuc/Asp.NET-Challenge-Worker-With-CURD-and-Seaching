using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Worker_Assignment.Models;

namespace Worker_Assignment.ViewModel
{
    public class WorkerFormSalaryViewModel
    {
        public Worker Worker { get; set; }
        public IEnumerable<ChangeSalary> ChangeSalaries { get; set; }
        public ChangeSalary ChangeSalary { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
        public string Input { get; set; }
    }
}