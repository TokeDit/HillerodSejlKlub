using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Booking
    {
        public DateTime DateTimeBegin { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public Member Member { get; set; }
        public Boat Boat { get; set; }
        public string Guests { get; set; }
        public Booking(DateTime dateTimeBegin, DateTime dateTimeEnd, Member member, Boat boat, string guests) 
            => (DateTimeBegin, DateTimeEnd, Member, Boat, Guests) = (dateTimeBegin, dateTimeEnd, member, boat, guests);
        public override string ToString()
        {
            return $"{Boat.Name} er booket af {Member.Name}\nDato: fra {DateTimeBegin} til {DateTimeEnd}\nAndre på båden: {Guests}";
        }
    }
}
