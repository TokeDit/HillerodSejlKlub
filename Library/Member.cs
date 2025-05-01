using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Member
    {
        private static int idNext = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public BoatSize MemberCertificateType { get; set; }
        public Acceslevel MemberAccesLevel { get; set; }
        
        public enum BoatSize
        {
            small = 1,
            medium,
            large
        }
        public enum Acceslevel
        {
            admin = 1,
            medlem
        }
        
        public Member(string name, string address, string telephoneNumber, string email, BoatSize memberCertificationType, Acceslevel memberAccesLevel)
        {
            Id = idNext++;
            Name = name;
            Address = address;
            TelephoneNumber = telephoneNumber;
            Email = email;
            MemberCertificateType = memberCertificationType;
            MemberAccesLevel = memberAccesLevel;

            //MemberRepo.AllMembers.Add(this);

            //thrower en exception hvis Int værdien er under 1 eller over 3 for membercertification,
            //try
            //{
            //    if (memberCertificationType < 1 || memberCertificationType > 3)
            //    {
            //        throw new Exception("Member certificat må ikke være under 1 eller over 3");
            //    }
            //}
            //catch (Exception MemberCertificationError)
            //{
            //    Console.WriteLine(MemberCertificationError.Message);
            //}
            ////Thrower en exception hvs Int værdien er under 1 eller over 2 for MemberAccesLevel
            //try
            //{
            //    if (memberAccesLevel < 1 || memberAccesLevel > 2)
            //    {
            //        throw new Exception("Adgangs niveau ikke fundet!!");
            //    }
            //}
            //catch (Exception MemberAccesLevelError)
            //{
            //    Console.WriteLine(MemberAccesLevelError.Message);
            //}
        }

        public override string ToString()
        {
            
            string memberCertification = "";
            switch (MemberCertificateType)
            {
                case BoatSize.small:
                    memberCertification = "lille båd";
                    break;
                case BoatSize.medium:
                    memberCertification = "Medium båd";
                    break;
                case BoatSize.large:
                    memberCertification = "Stor båd";
                    break;
                    
            }
            string memberAcceslevel = "";
            switch (MemberAccesLevel)
            {
                case Acceslevel.admin:
                    memberAcceslevel = "Admin";
                    break;
                case Acceslevel.medlem:
                    memberAcceslevel = "Medlem";
                    break;
            }


            return $"Name: {Name}\nMember Id: {Id}\nAdresse: {Address}\nTelephone number: {TelephoneNumber}\nEmail: {Email}\nBåd certificat: {memberCertification}\nMedlems niveau: {memberAcceslevel}\n";
        }
    
    }

}
