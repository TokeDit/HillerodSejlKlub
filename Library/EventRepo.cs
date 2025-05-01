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
        private static List<Event> events;
        private static List<Event> filteredEvents;

        public EventRepo()
        {
            events = new List<Event>();
            filteredEvents = new List<Event>();
        }

        public List<Event> GetEvents() { return events; }
        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public Event? GetEventById(int id)
        {
            Event? ev = null;
            foreach (Event e in events)
            {
                if (e.Id == id) 
                {  
                    return e; 
                }

            }
            if (ev == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen begivenheder med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return ev;
        }

        public List<Event> GetEventByName(string name)
        {
            foreach (Event e in events)
            {
                if (e.Name == name)
                {
                    filteredEvents.Add(e);
                    return filteredEvents;
                }
            }
            if (filteredEvents == null || filteredEvents.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen begivenhed med det angivne navn";
                throw new NoSearhResultException(msg);
            }
            return filteredEvents;
        }

        public void UpdateEvent(Event updatedEvent)
        {
            RemoveEvent(updatedEvent.Id);
            AddEvent(updatedEvent);
        }

        public bool RemoveEvent(int id)
        {
            Event eventToRemove = GetEventById(id);
            if (eventToRemove != null)
            {
                events.Remove(eventToRemove);
                return true;
            }
            return false;
        }
    }
}

