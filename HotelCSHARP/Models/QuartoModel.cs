namespace HotelCSHARP.Models
{
    public class QuartoModel//ESTRUTURA QUE VAMOS UTILIZAR NO BANCO DE DADOS
    {
        public int Id { get; set; }
        public string NumeroQuarto { get; set; } 
        public string Tipo { get; set; } // Ex: Standard, Deluxe, Suite
        public int Capacidade { get; set; } 
        public decimal PrecoPorNoite { get; set; } 
        public bool EstaDisponivel { get; set; } 
        public string  Descricao { get; set; } // Descrição adicional do quarto

    }
}
