using HotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebApp.Controllers
{
    public class CEOController : Controller
    {
        // GET: CEO
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PresentCeoName()
        {
            return View(CeoArray());
        }
        public ActionResult PresentCeo(int id)
        {
            foreach(var item in CeoArray())
            {
                if (item.id == id)
                {
                 return View(item);
                }
            }
            return View();
        }
        public Ceo[] CeoArray()
        {
            Ceo[] ceos = new Ceo[]
              {
                new Ceo(1,"izhak lijalem",25,"izhak@com",3000),
                new Ceo(2,"malca lijalem",27,"malca@com",4000),
                new Ceo(3,"aliav lijalem",18,"aliav@com",5000),
                new Ceo(4,"kfir lijalem",13,"kfir@com",60000),
                new Ceo(5,"ortal lijalem",29,"ortal@com",8000)
              };
            return ceos;
        }
    }
}