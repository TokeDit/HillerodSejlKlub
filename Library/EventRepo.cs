using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class EventRepo
    {
        public static List<Event> AllEvents { get; private set; } = new List<Event>();
        private static List<Event> filteredEvents = new List<Event>();

       

        public static void AddEvent(Event newEvent)
        {
            AllEvents.Add(newEvent);
        }


        public static Event? GetEventById(int id)
        {
            Event? ev = null;
            foreach (Event e in AllEvents)
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

        public static List<Event> GetEventByName(string name)
        {
            foreach (Event e in AllEvents)
            {
                if (e.EventName == name)
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

        public static void UpdateEvent(Event updatedEvent)
        {
            RemoveEvent(updatedEvent.Id);
            AddEvent(updatedEvent);
        }

        public static bool RemoveEvent(int id)
        {
            Event eventToRemove = GetEventById(id);
            if (eventToRemove != null)
            {
                AllEvents.Remove(eventToRemove);
                return true;
            }
            return false;
        }
    }
}

