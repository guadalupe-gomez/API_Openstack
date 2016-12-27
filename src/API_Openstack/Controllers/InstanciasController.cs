using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Openstack.Model;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Openstack.Controllers
{
    public class InstanciasController : Controller
    {
        // GET: /Instancias/
        public  IActionResult Index()
        {
            ViewData["mensaje"] = "Listado de instancias";

            var listado_instancias = API.ListarInstancias();                     
            
            return View(listado_instancias);            
        }
    }
}
