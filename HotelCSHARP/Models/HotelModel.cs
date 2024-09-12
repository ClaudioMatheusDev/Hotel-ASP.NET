using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;


namespace HotelCSHARP.Models
{
    public class HotelModel  //ESTRUTURA QUE VAMOS UTILIZAR NO BANCO DE DADOS
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string NumeroQuarto { get; set; }

        public decimal PrecoPorNoite { get; set; }

        public string StatusReserva { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string Contato { get; set; }


    }
}
