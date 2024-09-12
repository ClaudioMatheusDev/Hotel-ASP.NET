using HotelCSHARP.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelCSHARP.Controllers
{
    public class HotelController : Controller
    {
        readonly private ApplicationDbContext _db; //Criando uma propiedade privada

        public IActionResult Index()
        {
            return View();
        }
    }
}
