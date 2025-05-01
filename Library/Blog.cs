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
        public string Title {get; set;}
        public DateOnly CreationDate { get; set;}
        public string Description {get; set;}
        public Event? RelatedEvent {get; set;}
        public Member Writer {get; set;}

        public Blog(string title, DateOnly creationdate, string description, Member writer, Event? relatedEvent = null)
        {
            Id = idNext;
            Title = title;
            CreationDate = creationdate;
            Description = description;
            Writer = writer;
            RelatedEvent = relatedEvent;

            idNext++;
            
        }

        public override string ToString()
        {
            return $"Titel: {Title}\nDato for upload: {CreationDate}\nBeskrivelse: {Description}\nBegivenhed: {RelatedEvent}\nSkribent: {Writer}.";
        }
    }
}
