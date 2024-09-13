using HotelCSHARP.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelCSHARP.Controllers
{
    public class QuartoController : Controller
    {

        readonly private ApplicationDbContext _db; //Criando uma propiedade privada

        public QuartoController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
