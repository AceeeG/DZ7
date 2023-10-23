using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class Task
    {
        private string boss { get; set; }
        private Department department { get; set; }
        private string task { get; set; }
        private string employee { get; set; }
        public Task(string boss, Department department, string task, string employee)
        {
            this.boss = boss;
            this.department = department;
            this.task = task;
            this.employee = employee;
        }
        public void Print()
        {
            Console.WriteLine($"{boss} задаёт: {task}, работнику {employee}");
        }
        public string GetEmployeeName() 
        {
            return employee;
        }
        public string GetBossName()
        {
            return boss;
        }
    }
}
