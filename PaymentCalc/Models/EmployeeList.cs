using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalc.Models
{
    public class EmployeeList
    {
        public static void DisplayEmployeeList()
        {
            foreach (Employee employee in Employee.Employees)
            {
                Console.WriteLine($"===================\nEmployee Name: {employee.Name} \nPayment: ${employee.Payment():F2}\n===================");
            }
            Console.Write("Add more Employees? [Y/N]: ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.Clear();
                RegisterEmployee.AddEmployee();
            }
            else
            {
                Console.Clear();
                foreach (Employee employee in Employee.Employees)
                {
                    Console.WriteLine($"===================\nEmployee Name: {employee.Name} \nPayment: ${employee.Payment():F2}\n===================");
                }
            }
        }
    }
}
