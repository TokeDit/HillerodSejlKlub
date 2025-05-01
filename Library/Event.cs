using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Event
    {
        private static int idNext = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Member> Members { get; set; }
        public Member CordCoordinator { get; set; }

        public Event(string name, DateTime startdate, DateTime enddate, Member cordCoordinator)
        {
            Id = idNext++;
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            Members = new List<Member>();
            CordCoordinator = cordCoordinator;
        }

        public override string ToString()
        {
            return $"Navn: {Name}\nStart dato: {StartDate}\nSlut dato: {EndDate}\nMembers: {Members}\nKoordinator: {CordCoordinator}.";
        }
    }
}
