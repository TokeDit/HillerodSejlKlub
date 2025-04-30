using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class EventRepo
    {
        private List<Event> events;

        public EventRepo()
        {
            events = new List<Event>();
        }

        // Add events
        public Event event1 = new Event("Boat trip", new DateTime(2025, 05, 01, 12, 00, 00) , new DateTime(2025, 05, 01, 18, 00, 00), "Alice");
        public Event event2 = new Event("Boat party", new DateTime(2025, 05, 08, 12, 00, 00), new DateTime(2025, 05, 08, 18, 00, 00), "Bob");

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public List<Event> GetEventById(int id)
        {
            return events;
        }

        public bool RemoveEvent(int id)
        {
            var eventToDelete = GetEventById(id);
            if (eventToDelete != null)
            {
                events.GetEnumerator();
                return true;
            }
            return false;
        }
    }
}

