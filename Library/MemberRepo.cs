using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library 
{
    public static class MemberRepo
    {
        public static List<Member> AllMembers { get; private set; } = new List<Member>()
            {
                new Member("Toke", "Holte", "12345678", "Toke@toke.toke", Member.BoatSize.large, Member.Acceslevel.admin),
                new Member("Lars", "Albertslund", "87654321", "Lars@lars.lars", Member.BoatSize.small, Member.Acceslevel.medlem),
                new Member("Lars", "Husum", "45678912", "LarsLars@larslars.lars", Member.BoatSize.medium, Member.Acceslevel.admin)
            };
        private static List<Member> filteredMembers = new List<Member>();


        
        public static void AddMember(Member member) { AllMembers.Add(member); }
        //public bool DeleteMember(int) { return allMembers.Remove(int); }

        public static bool DeleteMember(int id)
        {
            foreach (Member m in AllMembers)
            {
                if (m.Id.Equals(id))
                {
                    return AllMembers.Remove(m);
                }
            }
            return false;
        }

        //Filters the List by the Unique Id given to a Member
        public static Member? FindMemberById(int Id)
        {
            Member? member = null;
            foreach (Member m in AllMembers)
            {
                if (m.Id.Equals(Id))
                {
                    return member = m;
                }
            }
            if (member == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen medlemmer med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return member;
           
        }
        //Filters the list by the argument given in this case Name
        public static List<Member> FilterMemberByName(string Name)
        {
            filteredMembers.Clear();
            foreach (Member m in AllMembers)
            {
                if (m.Name.ToLower().Equals(Name.ToLower()))
                {
                    filteredMembers.Add(m);
                  
                }
            }
            if (filteredMembers == null || filteredMembers.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen medlemmer med det angivne navn";
                throw new NoSearhResultException(msg);
            }
            return filteredMembers;
        }
        //Returns a given list from the repo as a string.
        public static string ReturnListAsString(List<Member> members)
        {
            string s = "";
            foreach (Member m in members)
            {
                s += m.ToString() +"\n";
            }
            return s;
        }
    }
}
