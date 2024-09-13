using HotelCSHARP.Data;
using HotelCSHARP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelCSHARP.Controllers
{
    public class QuartoController : Controller
    {

        readonly private ApplicationDbContext _db; //Criando uma propiedade privada

        public QuartoController(ApplicationDbContext db)
        {
            _db = db;
        } //INICIANDO A CONEXÃO COM O BANCO DE DADOS


        public IActionResult Index()
        {
            IEnumerable<QuartoModel> quartoReserva = _db.QuartoReserva;//entrando no banco de dados e pegando a tabela inteira do Quartos
            return View(quartoReserva);
        }//RETORNANDO NOSSA INDEX E IMPRIMINDO A TABELAS COM OS DADOS


        [HttpGet]
        public IActionResult Quartos()
        {
            return View();
        }

    }
}
