using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalc.Models
{
    public class FileManager
    {
        public static string LoadOrCreate()
        {
            while (true)
            {
                Console.Write("Load existing Employee list or Create New? [L/C]: ");
                string input = Console.ReadLine().ToLower();
                if (input == "l")
                {
                    Console.Clear();
                    try
                    {
                        ReadEmployee.LoadEmployeesFromFile();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading file: {ex.Message}");
                    }
                }
                else if (input == "c")
                {
                    Console.Clear();
                    try
                    {
                        RegisterEmployee.AddEmployee();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating new employee: {ex.Message}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter 'L' or 'C'.");
                }
            }
        }
    }
}
