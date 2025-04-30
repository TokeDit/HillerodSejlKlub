using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BoatRepo
    {
        private List<Boat> boats;
        public BoatRepo()
        {
            boats = new List<Boat>();
        }
        public void AddBoat(Boat boat) {  boats.Add(boat); }
        public bool DeleteBoat(Boat boat) {  return boats.Remove(boat); }
        
    }
}
