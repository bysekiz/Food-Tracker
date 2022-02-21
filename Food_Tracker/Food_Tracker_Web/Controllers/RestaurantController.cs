using Food_Tracker_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Food_Tracker_Web.Controllers
{
    public class RestaurantController : ApiController
    {



        FoodTrackerDBEntities _ent = new FoodTrackerDBEntities();


        [HttpGet]
        public List<tblRestaurant> GetByRestaurants()
        {
            return _ent.tblRestaurant.ToList();
        }

        [HttpGet]
        public List<tblRestaurant> FindRestaurant(string text)
        {

            return _ent.tblRestaurant.Where(p => p.Name.Contains(text)).ToList();

        }
        [HttpGet]
        public bool DeleteRestaurant(int RestaurantId)
        {
            try
            {
                tblRestaurant r = _ent.tblRestaurant.Find(RestaurantId);

                if (r != null)
                {
                    _ent.tblRestaurant.Remove(r);
                    _ent.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpPost]
        public dynamic UpdateRestaurant(tblRestaurant uRest) {

            try
            {
                tblRestaurant oldRest = _ent.tblRestaurant.Find(uRest.Id);
                oldRest.Name = uRest.Name;
                oldRest.Adress = uRest.Adress;
                oldRest.PhoneNumber = uRest.PhoneNumber;
                oldRest.Since = uRest.Since;
                oldRest.City = uRest.City;
                oldRest.District = uRest.District;
                oldRest.Bio = uRest.Bio;
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        
        }
    }
}