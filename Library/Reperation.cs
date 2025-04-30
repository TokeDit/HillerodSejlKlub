using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reperation
    {
        public int Id {  get; private set; }
        public string Description { get; set; }
        public DateOnly Date {  get; set; }
        public bool IsRepaired { get; set; }
        public Reperation(string description, bool isRepaired, Boat boat)
        {
            Description = description;
            IsRepaired = isRepaired;
            Id = boat.ReperationIdNext;
        }

        public override string ToString()
        {
            return $"Reperation: {Description}\nDato: {Date}";
        }
    }
}
