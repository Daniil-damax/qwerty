using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class Complex
    {


        public int ID { get; private set; }
        public int ComplexValueAdded { get; private set; }
        public string Status { get; private set; }
        public int BuildingCost { get; private set; }
        public string City { get; private set; }
        public string Name { get; private set; }


        public Complex(int iD, int complexValueAdded, string status, int buildingCost, string city,string name)
        {
            ID = iD;
            ComplexValueAdded = complexValueAdded;
            Status = status;
            BuildingCost = buildingCost;
            City = city;
            Name = name;
        }
    }

}
