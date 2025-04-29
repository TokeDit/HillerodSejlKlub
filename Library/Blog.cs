using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Blog
    {
        public String Name {get; set;}
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public String Description {get; set;}
        public Event Event {get; set;}
        public Member Writer {get; set;}

        public override string ToString()
        {
            return $"Navn: {Name}\nStart dato: {StartDate}\nSlut dato: {EndDate}\nBeskrivelse: {Description}\nBegivenhed: {Event}\nMedlemmer: {Writer}.";
        }
    }
}
