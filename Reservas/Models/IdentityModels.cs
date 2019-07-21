using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reservas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
    /// <summary>
    /// apresenta a criação da base de dados
    /// - dos utilizadores
    /// - dos dados do 'negócio'
    /// </summary>
    public class ReservasDB : IdentityDbContext<ApplicationUser>
    {
        public ReservasDB() 
                : base("ReservasDBConnectionString", throwIfV1Schema: false)
        {
        }

        static ReservasDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ReservasDB>(new ApplicationDbInitializer());
        }

        public static ReservasDB Create()
        {
            return new ReservasDB();
        }

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados
        public DbSet<ReservaLugar> ReservaLugar { get; set; } // tabela Reservas
        public DbSet<Tecnicos> Tecnicos { get; set; } // tabela Tecnicos
        public DbSet<Clientes> Clientes { get; set; } // tabela Clientes
        public DbSet<Lugares> Lugares { get; set; } // tabela lugares


        // método a ser executado no início da criação do Modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // eliminar a convenção de atribuir automaticamente o 'on Delete Cascade' nas FKs
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }

}