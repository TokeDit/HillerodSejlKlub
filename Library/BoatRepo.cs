using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class BoatRepo
    {
        public static List<Boat> AllBoats { get; private set; } = new List<Boat>()
            {
                new("Tetra", "Tera", "jolle", new(2000, 10, 01), 12345678, "Ingen motor, den har sejl", 3, 0),
                new("Ferva", "Feva", "moderne jolle", new(2010, 9, 26), 87654321, "Har mare sejl", 4, 1)
            };
        private static List<Boat> filteredBoats = new List<Boat>();


        #region Methods
      
        public static void AddBoat(Boat boat) { AllBoats.Add(boat); }
        public static bool DeleteBoat(Boat boat) { return AllBoats.Remove(boat); }
        public static Boat? FindBoatById(int id) 
        {
            Boat? boat = null;
            foreach (Boat b in AllBoats) 
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
        public static List<Boat> FilterBoatByName(string name)
        {
            filteredBoats.Clear();
            foreach (Boat boat in AllBoats)
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
        public static string ReturnListAsString(List<Boat> boats)
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
