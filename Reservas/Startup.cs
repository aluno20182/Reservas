using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reservas.Models;
using Owin;

namespace Reservas
{
    // classe a ser acedida e 'executada' a quando da 1ª execução da aplicação
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // invocar a execução do método que carrega os dados na BD
            iniciaAplicacao();
        }

        /// <summary>
        /// cria, caso não existam, as Roles de suporte à aplicação: Tecnico, Funcionario, Condutor
        /// cria, nesse caso, também, um utilizador...
        /// </summary>
        private void iniciaAplicacao()
        {

            // identifica a base de dados de serviço à aplicação
            ReservasDB db = new ReservasDB();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Tecnicos'
            if (!roleManager.RoleExists("Tecnico"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Tecnico";
                roleManager.Create(role);
            }

            // criar a Role 'RecursosHumanos'
            if (!roleManager.RoleExists("Recursos Humanos"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Recursos Humanos";
                roleManager.Create(role);
            }

            // criar a Role 'GestorReservas'
            if (!roleManager.RoleExists("Gestor Reservas"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Gestor Reservas";
                roleManager.Create(role);
            }


            // criar um utilizador 'Tecnico'
            var user = new ApplicationUser();
            user.UserName = "tecnico@mail.pt";
            user.Email = "tecnico@mail.pt";
            // user.Nome = "Luís Freitas";
            string userPWD = "123_Asd";   //  wuH4)al
            var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Recursos Humanos-

            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Recursos Humanos");
            }
        }

    }
}

