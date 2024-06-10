using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalc.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Hours { get; set; }
        public double ValuePerHour { get; set; }
        public bool IsOutsourced { get; set; }
        public static List<Employee> Employees { get; set; } = new List<Employee>();

        public Employee(string name, int hours, double valuePerHour, bool isOutsourced)
        {
            Name = name;
            Hours = hours;
            ValuePerHour = valuePerHour;
            IsOutsourced = isOutsourced;
        }

        public virtual double Payment()
        {
            return Hours * ValuePerHour;
        }
    }
}
