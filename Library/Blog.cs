using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Blog
    {
        private static int idNext = 1;
        public int Id { get; private set; }
        public string Name {get; set;}
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public string Description {get; set;}
        public Event Event {get; set;}
        public Member Writer {get; set;}

        public Blog(string name, DateTime startdate, DateTime enddate, string description, Event e, Member writer)
        {
            Id = idNext;
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            Description = description;
            Event = e;
            Writer = writer;
            
        }

        public override string ToString()
        {
            return $"Navn: {Name}\nStart dato: {StartDate}\nSlut dato: {EndDate}\nBeskrivelse: {Description}\nBegivenhed: {Event}\nMedlemmer: {Writer}.";
        }
    }
}
