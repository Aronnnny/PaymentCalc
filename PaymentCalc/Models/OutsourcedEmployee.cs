using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalc.Models
{
    public class OutsourcedEmployee : Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, bool isOutsourced, double additionalCharge) : base(name, hours, valuePerHour, isOutsourced)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            return (base.Payment() + AdditionalCharge) * 1.16;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {AdditionalCharge}";
        }
    }
}
