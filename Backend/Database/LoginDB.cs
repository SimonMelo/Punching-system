using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Database
{
    public class LoginDB : DbContext
    {
        public DbSet<User> Users { get; set; } // Adicione esta propriedade para mapear a entidade de usuário

        public LoginDB(DbContextOptions<LoginDB> options) : base(options)
        {
        }

        // Outros códigos e configurações do contexto aqui
    }
}