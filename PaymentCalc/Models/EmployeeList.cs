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

            bool addMoreEmployees = RegisterEmployee.GetRegisterEmployees();
            if (addMoreEmployees)
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
                WriteList writeList = new WriteList();
                writeList.CreateList(Employee.Employees);
                Environment.Exit(0);
            }
        }
    }
}
