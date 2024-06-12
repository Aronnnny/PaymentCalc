using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalc.Models
{
    public class ReadEmployee
    {
        private static string GetFileDate()
        {
            while (true)
            {
                Console.Write("Insert the date of creation of the file [yyyyMMdd] or type Cancel to return: ");
                string inputDate = Console.ReadLine().ToLower();
                string fileName = $@"C:\EmployeeList\{inputDate}.txt";
                if(inputDate == "cancel")
                {
                    Console.Clear();
                    FileManager.LoadOrCreate();
                }
                else
                {
                    if (File.Exists(fileName))
                    {
                        return fileName;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"File {fileName}.txt not found.");
                    }
                }
            }
        }
        public static void LoadEmployeesFromFile()
        {
            string filePath = GetFileDate();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] fields =  line.Split(',');

                    Guid id = Guid.Parse(fields[0].Trim());
                    string name = fields[1].Trim();
                    int hours = int.Parse(fields[2].Trim());
                    double valuePerHour = double.Parse(fields[3].Trim());
                    bool isOutsourced = bool.Parse(fields[4].Trim());

                    if(isOutsourced)
                    {
                        double additionalCharge = double.Parse(fields[5].Trim());
                        Employee.Employees.Add(new OutsourcedEmployee(id, name, hours, valuePerHour, isOutsourced, additionalCharge));
                    }
                    else
                    {
                        Employee.Employees.Add(new Employee(id, name, hours, valuePerHour, isOutsourced));
                    }
                }
                EmployeeList.DisplayEmployeeList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}.");
            }
        }
    }
}
