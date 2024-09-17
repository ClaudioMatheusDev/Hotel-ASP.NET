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
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            HotelModel hotelReserva = _db.HotelReserva.FirstOrDefault(x => x.Id == id);

            if (hotelReserva == null)
            {
                return NotFound();
            }

            return View(hotelReserva);

        }//EDITAR

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            HotelModel hotelReserva = _db.HotelReserva.FirstOrDefault(x => x.Id == id);

            if (hotelReserva == null)
            {
                return NotFound();
            }

            return View(hotelReserva);

        } //EXCLUIR





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


        [HttpPost]
        public IActionResult Editar(HotelModel hotelReserva)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Encontra a reserva existente com base no ID
                    var existingReserva = _db.HotelReserva.Find(hotelReserva.Id);

                    if (existingReserva == null)
                    {
                        TempData["MensagemError"] = "Reserva não encontrada!";
                        return RedirectToAction("Index");
                    }

                    // Atualiza os valores da reserva existente
                    _db.Entry(existingReserva).CurrentValues.SetValues(hotelReserva);

                    // Salva as mudanças no banco de dados
                    _db.SaveChanges();

                    TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["MensagemError"] = $"Erro ao realizar edição: {ex.Message}";
                    return View(hotelReserva);
                }
            }

            TempData["MensagemError"] = "Edição não foi realizada com sucesso!";
            return View(hotelReserva);

        }//EDITAR


        [HttpPost]
        public IActionResult Excluir(HotelModel hotelReserva)
        {
            if (hotelReserva == null)
            {
                return NotFound();
            }

            _db.HotelReserva.Remove(hotelReserva);
            _db.SaveChanges();


            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");

        }

    }
}
