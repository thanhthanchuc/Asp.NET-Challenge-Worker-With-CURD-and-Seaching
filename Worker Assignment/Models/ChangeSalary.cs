using System;
using System.ComponentModel.DataAnnotations;

namespace Worker_Assignment.Models
{
    public class ChangeSalary
    {
        public int Id { get; set; }
        
        [Display(Name = "Up or Down Salary")]
        public double UporDownSalary { get; set; }
        public DateTime? DateChanged { get; set; }
        public bool Status { get; set; }

        [Display(Name = "Name Worker")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}