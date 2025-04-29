using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reperation
    {
        public string Description { get; set; }
        public DateOnly Date {  get; set; }
        public Reperation(string description, DateOnly date)
            => (Description, Date) = (description, date);

        public override string ToString()
        {
            return $"Reperationer: {Description}\n{Date}";
        }
    }
}
