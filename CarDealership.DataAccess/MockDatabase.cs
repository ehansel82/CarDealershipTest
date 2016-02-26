using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarDealership.Objects;

namespace CarDealership.DataRepository
{
    public class MockDatabase
    {
        /// <summary>
        /// In memory representation of current dealership inventory.
        /// </summary>
        private List<Vehicle> _currentInventory;
        /// <summary>
        /// In memory representation of availalbe features.
        /// </summary>
        private List<Feature> _availableFeatures;
        /// <summary>
        /// In memory representation of current markup percentage.
        /// </summary>
        private decimal _currentMarkupPercentage;

        /// <summary>
        /// Get/Set Markup Percentage. Also updates current inventory with new retail prices. 
        /// </summary>
        public decimal MarkupPercentage
        {
            get
            {
                return _currentMarkupPercentage;
            }
            set
            {
                _currentMarkupPercentage = value;
                UpdateInventoryRetailPrices();
            }
        }

        /// <summary>
        /// Create new instance of MockDatabase and initialize with base data. 
        /// </summary>
        public MockDatabase()
        {
            _initVehicles();
            _initFeatures();
        }

        /// <summary>
        /// Gets the current inventory from the repository.
        /// </summary>
        /// <returns>List of Vehciles in inventory.</returns>
        public List<Vehicle> GetInventory()
        {
            return _currentInventory;
        }

        /// <summary>
        /// Gets the current features from the repository.
        /// </summary>
        /// <returns>List of available features in database.</returns>
        public List<Feature> GetFeatures()
        {
            return _availableFeatures;
        }

        //Remove the vehicle with the ID parameter from the list.
        public void DeleteVehicle(string ID)
        {
            Vehicle VehicleToDelete = _currentInventory.Single(car => car.ID == ID);
            _currentInventory.Remove(VehicleToDelete);
        }

        //Get Feature From Repository by Lookup on ID
        public Feature GetFeature(string ID)
        {
            return _availableFeatures.Where(x => x.ID == ID).Single();
        }

        //Add car to current inventory
        public void AddVehicle(Vehicle vehicle)
        {
            //Can't forget to add the mcurrent markup percentage to new cars...
            vehicle.MarkupPct = _currentMarkupPercentage;
            _currentInventory.Add(                   
                new Vehicle()
                    {
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        RetailPrice = vehicle.RetailPrice,
                        Year = vehicle.Year,
                        VehicleType = vehicle.VehicleType,
                        Features = vehicle.Features
                    });
        }

        /// <summary>
        /// Update markup percentage (and thus retail price) on all vehicles in inventory. 
        /// </summary>
        private void UpdateInventoryRetailPrices()
        {
            foreach (Vehicle vehicle in _currentInventory)
            {
                vehicle.MarkupPct = _currentMarkupPercentage;
            }
        }

        /// <summary>
        /// Initialize current inventory with base data. 
        /// </summary>
        private void _initVehicles()
        {
            _currentInventory = new List<Vehicle>();

         
            _currentInventory.Add(new Vehicle {
                Make = "Ford",
                Model = "Focus",
                Year = 2015,
                VehicleType = "Car",
                RetailPrice = 16500m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Ford",
                Model = "Fusion",
                Year = 2015,
                VehicleType = "Car",
                RetailPrice = 22000,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Ford",
                Model = "F-150",
                Year = 2015,
                VehicleType = "Truck",
                RetailPrice = 24500m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Lincoln",
                Model = "MKZ",
                Year = 2014,
                VehicleType = "Car",
                RetailPrice = 34500m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Lincoln",
                Model = "Navigator",
                Year = 2015,
                VehicleType = "SUV",
                RetailPrice = 56000m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Dodge",
                Model = "Avenger",
                Year = 2015,
                VehicleType = "Car",
                RetailPrice = 20500m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Dodge",
                Model = "Dart",
                Year = 2014,
                VehicleType = "Car",
                RetailPrice = 16000m,
                MarkupPct = 0
            });
            _currentInventory.Add(new Vehicle
            {
                Make = "Dodge",
                Model = "Durango",
                Year = 2015,
                VehicleType = "SUV",
                RetailPrice = 29500m,
                MarkupPct = 0
            });
        }

        /// <summary>
        /// Initialize available features with base data. 
        /// </summary>
        private void _initFeatures()
        {
            _availableFeatures = new List<Feature>();

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Doors",
                Description = "2-door",
                RetailPrice = 0m
            });
            _availableFeatures.Add(new Feature
            {
                FeatureType = "Doors",
                Description = "4-door",
                RetailPrice = 2500m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Fuel",
                Description = "Gas",
                RetailPrice = 0m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Fuel",
                Description = "Hybrid",
                RetailPrice = 10000m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Fuel",
                Description = "Electric",
                RetailPrice = 15000m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Transmission",
                Description = "Automatic",
                RetailPrice = 1000m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Transmission",
                Description = "Manual",
                RetailPrice = 0m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Interior",
                Description = "Cloth",
                RetailPrice = 0m
            });

            _availableFeatures.Add(new Feature
            {
                FeatureType = "Interior",
                Description = "Leather",
                RetailPrice = 1500m
            });
        }

    }
}
