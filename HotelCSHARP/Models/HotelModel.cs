using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;


namespace HotelCSHARP.Models
{
    public class HotelModel  //ESTRUTURA QUE VAMOS UTILIZAR NO BANCO DE DADOS
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string SobreNome { get; set; }
        public required string NumeroQuarto { get; set; }
        public  required decimal PrecoPorNoite { get; set; }
        public  required string StatusReserva { get; set; }
        public required DateTime CheckIn { get; set; }
        public required DateTime CheckOut { get; set; }
        public required string Contato { get; set; }


    }
}
