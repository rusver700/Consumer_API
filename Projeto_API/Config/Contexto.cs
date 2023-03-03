using Microsoft.EntityFrameworkCore;
using Projeto_API.Modelo;

namespace Projeto_API.Config
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //Cria o banco de dados caso não exista 
             Database.EnsureCreated(); 
        }

        public DbSet<Carros> Carro { get; set; } = default!;


    }
}
