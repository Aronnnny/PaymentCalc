using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PaymentCalc.Models
{
    public class RegisterEmployee
    {
        public static void AddEmployee()
        {
            bool registerEmployees = true;

            while (registerEmployees)
            {
                Console.Write("Is the Employee Outsourced? [Y/N]: ");
                string isOutsourcedInput = Console.ReadLine().ToLower();
                bool isOutsourced = (isOutsourcedInput == "y");

                Console.Write("Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Employee hours worked: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Employee hour value: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if (isOutsourced)
                {
                    Console.Write("Outsourced additional charge value: ");
                    double additionalCharge = double.Parse(Console.ReadLine());
                    Employee.Employees.Add(new OutsourcedEmployee(name, hours, valuePerHour, isOutsourced, additionalCharge));
                }
                else
                {
                    Employee.Employees.Add(new Employee(name, hours, valuePerHour, isOutsourced));
                }
                Console.Write("Add more Employees? [Y/N]: ");
                string input = Console.ReadLine().ToLower();
                registerEmployees = (input == "n") ? registerEmployees = false : registerEmployees;
                Console.Clear();
            }

            EmployeeList.DisplayEmployeeList();
            WriteList writeList = new WriteList();
            writeList.CreateList(Employee.Employees);
        }
    }
}
