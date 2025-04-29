using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Event
    {
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Member> Members { get; set; }
        public Member CordCoordinator { get; set; }

        public Event(string name, DateTime startdate, DateTime enddate, List<Member> members, Member cordCoordinator)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            Members = members;
            CordCoordinator = cordCoordinator;
        }

        public override string ToString()
        {
            return $"Navn: {Name}\nStart dato: {StartDate}\nSlut dato: {EndDate}\nMembers: {Members}\nKoordinator: {CordCoordinator}.";
        }
    }
}
