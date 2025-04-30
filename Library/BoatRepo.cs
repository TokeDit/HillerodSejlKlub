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
            boats = new List<Boat>();
            filteredBoats = new List<Boat>();
        }
        #region Methods
        //Adds a boat to the list of boats
        public void AddBoat(Boat boat) { boats.Add(boat); }
        //Removes a specific boat from the list of boats
        public bool DeleteBoat(Boat boat) { return boats.Remove(boat); }
        public List<Boat> FilterBoatById(int id) 
        {
            foreach (Boat boat in boats) 
            {
                if (boat.id == id) filteredBoats.Add(boat);

            }
            string msg = $"Din søgning gav ingen resultater. Vi fandt ingen både med det angivne ID";
            if (filteredBoats.Count <= 0) throw new NoSearhResultException(msg);
            return filteredBoats;
            

        }
        // Finds
        public List<Boat> FilterBoatByName(string name)
        {
            filteredBoats.Clear();
            foreach (Boat boat in boats)
            {
                if (boat.Name == name) filteredBoats.Add(boat);
            }
            string msg = "Din søgning gav ingen resultater. Vi fandt ingen både med det angivne navn.";
            if (filteredBoats.Count <= 0) throw new NoSearhResultException(msg);
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
