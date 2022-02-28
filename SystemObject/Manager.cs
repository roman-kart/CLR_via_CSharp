using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemObject
{
    internal class Manager : Employee
    {
        public List<Employee> Subordinates { get; set; }
        public Manager(int id, string name, decimal salary, List<Employee> subordinates) : base(id, name, salary)
        {
            Subordinates = subordinates;
        }
    }
}
