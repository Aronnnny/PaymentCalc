using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PaymentCalc.Models
{
    public class WriteList
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public void CreateList(List<Employee> employees)
        {
            string formatDate = CreationDate.ToString("dd-MM-yyyy");
            string path = $@"C:\EmployeeList\";
            string fileName = $"{formatDate}.txt";
            string fullPath = Path.Combine(path, fileName);

            ListDirectory.VerifyDirectory();

            List<string> list = new List<string>();
            foreach (var employee in employees)
            {
                list.Add(employee.ToString());
            }
            if (File.Exists(fullPath))
            {
                File.AppendAllLines(fullPath, list);
                Console.WriteLine($"File updated with success at {fullPath}.");
            }
            else
            {
                try
                {
                    File.WriteAllLines(fullPath, list);
                    Console.WriteLine($"File created with success at {fullPath}.");
                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"Error: {ex.Message}.");
                }
            }
        }
    }
}   
