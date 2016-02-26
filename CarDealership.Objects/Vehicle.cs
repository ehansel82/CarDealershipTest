using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.Objects
{
    public class Vehicle
    {
        private decimal _FactoryPrice;
        private decimal _MarkupPct;

        public string ID { get; private set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VehicleType { get; set; }
        public decimal RetailPrice
        {
            get
            {
                return _FactoryPrice;
            }
            set
            {
                _FactoryPrice = value;
                CalculateRetailPrice();
            }
        }
        public decimal MarkupPct
        {
            get
            {
                return _MarkupPct;
            }
            set
            {
                _MarkupPct = value;
                CalculateRetailPrice();
            }
        }
        public decimal MarkupPrice { get; private set; }
        public List<Feature> Features;
        

        public Vehicle()
        {
            ID = Guid.NewGuid().ToString();
            Features = new List<Feature>();
        }

        private void CalculateRetailPrice() {
            MarkupPrice = RetailPrice * (1 + (MarkupPct / 100));
        }
    }
}
