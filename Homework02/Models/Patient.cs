using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FirstDose { get; set; }
        public DateTime? SecondDose { get; set; }
        public virtual Vaccine Vaccine { get; set; }

        public override string ToString()
        {
            return $"[{Id}, {Name}, {FirstDose:d} , {SecondDose:d}]";
        }
    }
}
