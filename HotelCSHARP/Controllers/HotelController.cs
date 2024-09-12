using HotelCSHARP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using HotelCSHARP.Models;

namespace HotelCSHARP.Controllers
{
    public class HotelController : Controller
    {
        readonly private ApplicationDbContext _db; //Criando uma propiedade privada

        public HotelController(ApplicationDbContext db)
        {
            _db = db;
        } //INICIANDO A CONEXÃO COM O BANCO DE DADOS

        public IActionResult Index()
        {
            IEnumerable<HotelModel> hotelReserva = _db.HotelReserva;//entrando no banco de dados e pegando a tabela inteira do Reservas
            return View(hotelReserva);
        }//RETORNANDO NOSSA INDEX E IMPRIMINDO A TABELAS COM OS DADOS


        [HttpGet] //ACTION COM O MESMO NOME CADASTRAR, A MESMA AUTOMATICAMENTE ESTÁ RETORNANDO O METODO GET
        public IActionResult Reservar()
        {
            return View();
        }//RESERVAR HTTPGET, RETORNANDO A TELA DE CADASTRO


        [HttpPost]//ADICIONANDO O HTTPPOST EM CIMA DA ACTION, DECLARAMOS QUE A MESMA ESTÁ ENVIANDO DADOS, ENTÃO ESTÁ RETORNANDO UM METODO POST
        public IActionResult Reservar(HotelModel hotelReserva)
        {
            if (!ModelState.IsValid)
            {
                // Adicione esta linha para verificar quais são os erros de validação
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                TempData["MensagemError"] = "Erro(s) de validação: " + string.Join(", ", erros);
                return View(hotelReserva);
            }

            try
            {
                // Adiciona a reserva ao banco de dados
                _db.HotelReserva.Add(hotelReserva);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, exibe a mensagem de erro
                TempData["MensagemError"] = $"Erro ao realizar reserva: {ex.Message}";
                return View(hotelReserva);
            }
        } //RESERVAR 








    }
}
