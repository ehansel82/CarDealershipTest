using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.Objects
{
    public class Feature
    {
        public string ID { get; private set; }
        public string Description { get; set; }
        public string FeatureType { get; set; }
        public decimal RetailPrice { get; set; }

        public Feature()
        {
            ID = Guid.NewGuid().ToString();
        }
        public Feature(string description, string type, decimal price)
        {
            ID = Guid.NewGuid().ToString();
            Description = description;
            FeatureType = type;
            RetailPrice = price;
        }
    }
}
