using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PaymentCalc.Models;

namespace PaymentCalc.Entyties
{
    public class RegisterEmployee
    {
        List<Employee> employees = new List<Employee>();
        public static void AddEmployee()
        {
            bool registerEmployees = true;

            while (registerEmployees)
            {
                bool isOutsourced = GetIsOutsourced();
                string name = GetEmployeeName();
                int hours = GetEmployeeHours();
                double valuePerHour = GetEmployeeValuePerHour();
                Guid id = Guid.NewGuid();

                if (isOutsourced)
                {
                    double additionalCharge = GetAdditionalCharge();
                    Employee.Employees.Add(new OutsourcedEmployee(id, name, hours, valuePerHour, isOutsourced, additionalCharge));
                }
                else
                {
                    Employee.Employees.Add(new Employee(id, name, hours, valuePerHour, isOutsourced));
                }
                registerEmployees = GetRegisterEmployees();
                Console.Clear();
            }
            EmployeeList.DisplayEmployeeList();
        }

        private static bool GetIsOutsourced()
        {
            while (true)
            {
                Console.Write("Is the Employee Outsourced? [Y/N]: ");
                string isOutsourcedInput = Console.ReadLine().ToLower();
                if (isOutsourcedInput == "y")
                {
                    return true;
                }
                else if (isOutsourcedInput == "n")
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            }
        }

        private static string GetEmployeeName()
        {
            Console.Write("Employee name: ");
            return Console.ReadLine();
        }

        private static int GetEmployeeHours()
        {
            while (true)
            {
                Console.Write("Employee hours worked: ");
                if (int.TryParse(Console.ReadLine(), out int hours))
                {
                    return hours;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please insert a valid number.");
                }
            }
        }

        private static double GetEmployeeValuePerHour()
        {
            while (true)
            {
                Console.Write("Employee value per hour: ");
                if (double.TryParse(Console.ReadLine(), out double valuePerHour))
                {
                    return valuePerHour;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please insert a valid number.");
                }
            }
        }

        private static double GetAdditionalCharge()
        {
            while (true)
            {
                Console.Write("Outsourced additional charge value: ");
                if (double.TryParse(Console.ReadLine(), out double additionalCharge))
                {
                    return additionalCharge;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please insert a valid number.");
                }
            }
        }

        public static bool GetRegisterEmployees()
        {
            while (true)
            {
                Console.Write("Add more Employees? [Y/N]: ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            }
        }
    }
}
