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




        [HttpGet] //ACTION COM O MESMO NOME CADASTRAR, A MESMA AUTOMATICAMENTE ESTÁ RETORNANDO O METODO GET
        public IActionResult Cadastrar()
        {
            return View();
        }










        [HttpPost] //ADICIONANDO O HTTPPOST EM CIMA DA ACTION, DECLARAMOS QUE A MESMA ESTÁ ENVIANDO DADOS, ENTÃO ESTÁ RETORNANDO UM METODO POST
        public IActionResult Cadastrar(QuartoModel quartoCadastro)
        {
            if (ModelState.IsValid)//Se o status da model for valido (se a conexão do banco de dados for valida) 
            {


                _db.QuartoReserva.Add(quartoCadastro); //Entrando no banco de dados, na tabela QuartoReserva e adicionado novas informações
                _db.SaveChanges(); //Entrando no banco de dados e salvando as novas informações adicionadas

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";//MENSAGEM DE SUCESSO DA EXCLUSÃO, EDIÇÃO E CADASTRO


                return RedirectToAction("Index"); //Depois de tudo salvo, redireciona o usuario para a pagina index
            }
            TempData["MensagemError"] = "Cadastro não foi realizado com sucesso!";

            return View(); //CASO O IF NÃO FOR VALIDO, O MESMO RETORNA O USUARIO PARA A VIEW(CADASTRAR) 

        }
    } //Cadastrar Quarto 






}



