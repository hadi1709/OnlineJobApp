using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineJobApplication.Models;

namespace OnlineJobApplication
{
    public class CommonHelper
    {
        public static List<CountryModel> GetCountryList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var obj = (from country in db.Countries
                              select new CountryModel {
                                  CountryId = country.CountryID,
                                  CountryName = country.CountryName,
                                  Nationality = country.Nationality                               
                              }).ToList();

                    return obj;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static List<ReligionModel> GetReligionList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var obj = (from religion in db.Religions
                               select new ReligionModel
                               {
                                   Id = religion.Id,
                                   Name = religion.Name
                               }).ToList();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}