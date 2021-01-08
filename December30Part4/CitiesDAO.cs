using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December30Part4
{
    static class CitiesDAO
    {
        public static void AddCity(City city)
        {
            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                db.Cities.Add(city);

                db.SaveChanges();
            }
        }

        public static void UpdateCity (City city)
        {
            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                City cityToUpdate = db.Cities.Where(c => c.ID == city.ID).First();
                cityToUpdate.Name = city.Name;
                cityToUpdate.District_ID = city.District_ID;
                cityToUpdate.Mayor = city.Mayor;
                cityToUpdate.Population = city.Population;

                db.SaveChanges();
            }
        }
        
        public static void RemoveCity (int id)
        {
            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                City cityToRemove = db.Cities.Where(c => c.ID == id).First();
                db.Cities.Remove(cityToRemove);
                db.SaveChanges();
            }
        }

        public static List<MyCity> GetAllCities ()
        {
            List <MyCity> resultList= null;

            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                resultList = db.Cities.Select(city => new MyCity
                {
                    ID = city.ID,
                    District_ID = city.District_ID,
                    Name = city.Name,
                    Mayor = city.Mayor,
                    Population = city.Population
                }).ToList();

                db.SaveChanges();
            }
            return resultList;
        }

        public static MyCity GetCityByID (int id)
        {
            MyCity result;

            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                result = db.Cities.Where(cc => cc.ID == id).Select(city => new MyCity
                {
                    ID = city.ID,
                    District_ID = city.District_ID,
                    Name = city.Name,
                    Mayor = city.Mayor,
                    Population = city.Population
                }).First();

                

                db.SaveChanges();
            }

            return result;
        }

        public static List<MyCity> GetAllCitiesFilteredByPopulation(int levelMark)
        {
            List<MyCity> resultList = null;

            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                resultList = db.Cities.Where(c => c.Population >= levelMark).Select(city => new MyCity
                {
                    ID = city.ID,
                    District_ID = city.District_ID,
                    Name = city.Name,
                    Mayor = city.Mayor,
                    Population = city.Population
                }).ToList();

                db.SaveChanges();
            }
            return resultList;
        }

        public static void UpdateDistrictsPopulation (int disctrictID)
        {
            List<int> populationsInEachCity = null;
            int totalPopulationOfDistrict = 0;

            using (December30Part4DBEntities db = new December30Part4DBEntities())
            {
                int totalNumberOfDistricts =  db.Districts.Select(d => d.ID).Count();
                
                foreach (var item in db.Cities)
                {
                    if (item.District_ID == disctrictID)
                    {
                        totalPopulationOfDistrict = (int)item.Population + totalPopulationOfDistrict;
                        
                    }
                    //if (item.District_ID == 2)
                    //{
                    //    totalPopulationOfDistrict2 = (int)item.Population + totalPopulationOfDistrict2;
                    //    db.Districts.First(d => d.ID == 1).Population = totalPopulationOfDistrict2;
                    //}
                    
                }
                db.Districts.First(d => d.ID == disctrictID).Population = totalPopulationOfDistrict;
                db.SaveChanges();
            }
        }
    }
}
