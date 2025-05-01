using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BoatRepo
    {
        private static List<Boat> boats;
        private static List<Boat> filteredBoats;

       
        public BoatRepo()
        {
            boats = new List<Boat>()
            {
                new("Tetra", "Tera", "jolle", new(2000, 10, 01), 12345678, "Ingen motor, den har sejl", 3, 0),
                new("Ferva", "Feva", "moderne jolle", new(2010, 9, 26), 87654321, "Har mare sejl", 4, 1)
            };
            filteredBoats = new List<Boat>();
        }
        #region Methods
        public List<Boat> GetBoats() { return boats; }
        //Adds a boat to the list of boats
        public void AddBoat(Boat boat) { boats.Add(boat); }
        //Removes a specific boat from the list of boats
        public bool DeleteBoat(Boat boat) { return boats.Remove(boat); }
        public Boat? FindBoatById(int id) 
        {
            Boat? boat = null;
            foreach (Boat b in boats) 
            {
                if (b.Id == id) return boat = b;

            }
            
            if (boat == null) 
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen både med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            
            return boat;
            

        }
        // Finds
        public List<Boat> FilterBoatByName(string name)
        {
            filteredBoats.Clear();
            foreach (Boat boat in boats)
            {
                if (boat.Name == name) filteredBoats.Add(boat);
            }
            if (filteredBoats.Count <= 0)
            {
                string msg = "Din søgning gav ingen resultater. Vi fandt ingen både med det angivne navn.";
                throw new NoSearhResultException(msg);
            }
            return filteredBoats;
        }
        // Returns all objects from the given list as a string
        public string ReturnListAsString(List<Boat> boats)
        {
            string s = "";
            foreach (Boat boat in boats)
            {
                s += boat.ToString() + "\n";
            }
            return s;
        }
        #endregion
    }
}
