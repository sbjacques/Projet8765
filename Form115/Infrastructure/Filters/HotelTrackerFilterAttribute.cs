using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form115.Infrastructure.Filters
{
    using System.Web.Mvc;
    using DataLayer.Models;

    public class HotelTrackerFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new Form115Entities();

            // Accès au paramètre : id vaut IdHotel
            var ap = filterContext.ActionParameters.First();
            // var parmName = ap.Key // normalement id
            // var paramValue = (int)ap.Value;

            var ht = new HotelTracking
            {
                DateHT = DateTime.Now,
                IdHotel = (int)ap.Value
            };

            db.HotelTracking.Add(ht);

            db.SaveChanges();
        }
    }
}