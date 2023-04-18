using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace HistoriaClinica.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult registro(FormCollection form)
        {
            if (form["submitButton"] != null)
            {
                Console.WriteLine("Holaaa");
            }
            else
            {
                // El formulario se envió sin hacer clic en el botón
            }
            return View();
        }
    }
}