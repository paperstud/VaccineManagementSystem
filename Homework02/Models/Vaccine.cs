using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02.Models
{
    public class Vaccine
    {

        public string Name { get; set; }
        public int TotalDosesRecieved { get; set; }
        public int TotalDosesLeft { get; set; }

        public int Id { get; set; }
        public int? daysBetween;
        public int dosesRequired;


        public int DosesRequired
        {
            get { return dosesRequired; }
            set
            {
                if (value == 1)
                    DaysBetween = null;

                dosesRequired = value;
            }
        }

        public int? DaysBetween
        {
            get { return daysBetween; }
            set
            {
                if (DosesRequired <= 1)
                    daysBetween = null;
                else
                    daysBetween = value;
            }
        }


        public Vaccine() { }
        public Vaccine(int id, string name, int totalDosesRecieved , int totalDosesLeft , int dosesRequired, int? daysBetween)
        {
            Id = id;
            Name = name;
            TotalDosesRecieved = totalDosesRecieved;
            TotalDosesLeft = totalDosesLeft;
            DosesRequired = dosesRequired;
            DaysBetween = daysBetween;

        }

        public override string ToString()
        {
            string s = $"Name: {Name}\nDoses Required: {DosesRequired}\nDays Between: ";

            if (DaysBetween == null)
                s += "None";
            else
                s += DaysBetween.ToString();

            s += $"\nTotal Doses Recieved: {TotalDosesRecieved}\n";
            s += $"\nTotal Doses Left: {TotalDosesLeft}\n";
            return s;
        }

    }
}
