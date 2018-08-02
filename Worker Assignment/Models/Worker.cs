using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker_Assignment.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
    }
}