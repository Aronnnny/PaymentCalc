using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PaymentCalc.Models
{
    public class ListDirectory
    {
        public static void VerifyDirectory()
        {
            string path = @"C:\EmployeeList";

            if (Directory.Exists(path))
            {
                Console.WriteLine($"Saving EmployeeList into {path}.");
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine($"Directory successfully created at {path}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}.");
                }
            }
        }
    }
}
