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
            var listado_instancias = API.API_ListarInstancias();                     
            
            return View(listado_instancias);            
        }

        public IActionResult Detalle(string id)
        {                       
            return View(API.API_DetalleDeInstancia(id));
        }
    }
}
