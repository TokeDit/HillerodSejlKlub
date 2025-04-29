using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Boat
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int SailingNumber { get; set; }
        public string MotorInformation { get; set; }
        public int Measurement { get; set; }
        public int MinimumCertificationRequirement { get; set; }
        public List<Reperation> Reperations { get; set; } 

        public Boat(string name, string model, string type, DateOnly productionDate, int sailingNumber, string motorInformation, int measurement, int minimumCertificationRequirement)
        {
            Name = name; Model = model; Type = type; ProductionDate = productionDate; SailingNumber = sailingNumber; MotorInformation = motorInformation; Measurement = measurement; MinimumCertificationRequirement = minimumCertificationRequirement;
            Reperations = new List<Reperation>();
        }

        public override string ToString()
        {
            return $"Navn: {Name}\nModel: {Model}\nType: {Type}\nProduktions dato: {ProductionDate}\nSejlnummer: {SailingNumber}\nMotor information: {MotorInformation}\nMål i fod: {Measurement}\nMinimum certifikat krav: Level{MinimumCertificationRequirement}\n";
        }

    }
}
