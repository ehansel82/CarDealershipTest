using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Objects;
using CarDealership.DataRepository;

namespace CarDealershipWeb.Controllers
{
    /// <summary>
    /// Controller for all Inventory related pages. 
    /// </summary>
    public class InventoryController : Controller
    {
        public ActionResult List()
        {
            //Get "database" from global application cache.
            MockDatabase CarDealershipDB = (MockDatabase)System.Web.HttpContext.Current.Cache["Database"];
            //Get the current markup and add it to the viewbag.
            ViewBag.MarkupPct = CarDealershipDB.MarkupPercentage;
            //Pass the current car inventory to the view ordered by make then model. 
            return View(CarDealershipDB.GetInventory().OrderBy(x=>x.Make).ThenBy(x=>x.Model).ToList());
        }

        public ActionResult Management()
        {
            //Get "database" from global application cache.
            MockDatabase CarDealershipDB = (MockDatabase)System.Web.HttpContext.Current.Cache["Database"];

            //Get Data For Feature Groups
            ViewBag.DoorFeatures = CarDealershipDB.GetFeatures().Where(x => x.FeatureType == "Doors");
            ViewBag.FuelFeatures = CarDealershipDB.GetFeatures().Where(x => x.FeatureType == "Fuel");
            ViewBag.TransmissionFeatures = CarDealershipDB.GetFeatures().Where(x => x.FeatureType == "Transmission");
            ViewBag.InteriorFeatures = CarDealershipDB.GetFeatures().Where(x => x.FeatureType == "Interior");
            //Pass current inventory to the view.
            return View(CarDealershipDB.GetInventory());
        }

        public ActionResult UpdateMarkup(decimal percentage)
        {
            //Get "database" from global application cache.
            MockDatabase CarDealershipDB = (MockDatabase)System.Web.HttpContext.Current.Cache["Database"];
            //Update the database with new percentage.
            CarDealershipDB.MarkupPercentage = percentage;
            //Return the standard list view.
            return RedirectToAction("List", "Inventory");
        }

        public ActionResult DeleteVehicle(string id)
        {
            //Get "database" from global application cache.
            MockDatabase CarDealershipDB = (MockDatabase)System.Web.HttpContext.Current.Cache["Database"];
            //Delete the vehicle specified by the ID
            CarDealershipDB.DeleteVehicle(id);
            //Return the standard list view (which will be sans the car we just deleted)
            return RedirectToAction("List", "Inventory");
        }

        public ActionResult AddVehicle(Vehicle vehicle, int NumberInStock, 
                                       string DoorFeature, string FuelFeature, string TransmissionFeature, string InteriorFeature){
            //Get "database" from global application cache.
            MockDatabase CarDealershipDB = (MockDatabase)System.Web.HttpContext.Current.Cache["Database"];
            //Add features to the database based on the incoming parameters that have the ID of the feature.
            if (!string.IsNullOrWhiteSpace(DoorFeature)){
                vehicle.Features.Add(CarDealershipDB.GetFeature(DoorFeature));
            }
            if (!string.IsNullOrWhiteSpace(FuelFeature))
            {
                vehicle.Features.Add(CarDealershipDB.GetFeature(FuelFeature));
            }
            if (!string.IsNullOrWhiteSpace(TransmissionFeature))
            {
                vehicle.Features.Add(CarDealershipDB.GetFeature(TransmissionFeature));
            }
            if (!string.IsNullOrWhiteSpace(InteriorFeature))
            {
                vehicle.Features.Add(CarDealershipDB.GetFeature(InteriorFeature));
            }            
            //Add as many vehicles as specified by the number in stock
            for (int i=0; i< NumberInStock; i++){
                CarDealershipDB.AddVehicle(vehicle);
            }
            //Redirect to main inventory screen.
            return RedirectToAction("List", "Inventory");
        }

    }
}
