using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Member
    {
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public int MemberCertificateType { get; set; }
        public int MemberAccesLevel { get; set; }
        
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
        
        public Member(string name, string adresse, string telephoneNumber, string email, int memberCertificationType, int memberAccesLevel)
        {
            Name = name;
            Adresse = adresse;
            TelephoneNumber = telephoneNumber;
            Email = email;
            MemberCertificateType = memberCertificationType;
            MemberAccesLevel = memberAccesLevel;

            //Thrower en exception hvis int værdien er under 1 eller over 3 for memberCertification
            try
            {
                if (memberCertificationType < 1 || memberCertificationType > 3)
                {
                    throw new Exception("Member certificat må ikke være under 1 eller over 3");
                }
            }
            catch (Exception MemberCertificationError)
            {
                Console.WriteLine(MemberCertificationError.Message);
            }
            //Thrower en exception hvis int værdien er under 1 eller over 2 for MemberAccesLevel
            try
            {
                if (memberAccesLevel < 1 || memberAccesLevel > 2)
                {
                    throw new Exception("Adgangs niveau ikke fundet!!");
                }
            }
            catch (Exception MemberAccesLevelError)
            {
                Console.WriteLine(MemberAccesLevelError.Message);
            }
        }
       
        public override string ToString()
        {
            //2 Switch statements 
            string memberCertification = "";
            switch (MemberCertificateType)
            {
                case (int)BoatSize.small:
                    memberCertification = "lille båd";
                    break;
                case (int)BoatSize.medium:
                    memberCertification = "Medium båd";
                    break;
                case (int)BoatSize.large:
                    memberCertification = "Stor båd";
                    break;
                    
            }
            string memberAcceslevel = "";
            switch (MemberAccesLevel)
            {
                case (int)Acceslevel.admin:
                    memberAcceslevel = "Admin";
                    break;
                case (int)Acceslevel.medlem:
                    memberAcceslevel = "Medlem";
                    break;
            }


            return $"Name: {Name}\nAdresse: {Adresse}\nTelephone number: {TelephoneNumber}\nEmail: {Email}\nBåd certificat: {memberCertification}\nMedlems niveau: {memberAcceslevel}";
        }
    
    }

}
