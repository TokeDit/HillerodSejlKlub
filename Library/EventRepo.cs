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
        private List<Event> filteredEvents;

        public EventRepo()
        {
            events = new List<Event>();
            filteredEvents = new List<Event>();
        }

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public Event GetEventById(int id)
        {
            foreach (Event e in events)
            {
                if (e.Id == id) 
                {  
                    return e; 
                }
            }
            return null;
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
            return null;
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

