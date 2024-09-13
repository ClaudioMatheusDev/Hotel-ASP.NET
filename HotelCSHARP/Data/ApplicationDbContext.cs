using HotelCSHARP.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelCSHARP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<HotelModel> HotelReserva { get; set; } //Criando a tabela reserva

        public DbSet<QuartoModel> QuartoReserva { get; set; } //Criando a tabela reserva

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuração para consertar o erro que está dando na hora de fazer a migração para o banco de dados
            //Na parte que public decimal PrecoPorNoite { get; set; } Definindo um valor do decimal

            modelBuilder.Entity<HotelModel>()
                .Property(h => h.PrecoPorNoite)
                .HasColumnType("decimal(18, 2)"); //Especifica o tipo decimal com precisão 18 e escala 2

        }



    }
}
