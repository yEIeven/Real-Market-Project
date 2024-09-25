using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options) { 
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }


   
}
