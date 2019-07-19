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

            // criar a Role 'Administrador'
            if (!roleManager.RoleExists("Administrador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }


            // criar a Role 'RecursosHumanos'
            if (!roleManager.RoleExists("RecursosHumanos"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "RecursosHumanos";
                roleManager.Create(role);
            }

            // criar a Role 'GestorReservas'
            if (!roleManager.RoleExists("GestorReservas"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "GestorReservas";
                roleManager.Create(role);
            }

            // criar a Role 'Cliente'
            if (!roleManager.RoleExists("Cliente"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);
            }

            // criar um utilizador 'Tecnico'
            var user = new ApplicationUser();
            user.UserName = "tecnico@example.com";
            user.Email = "tecnico@example.com";
            string userPWD = "123_Asd";
            var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Recursos Humanos-
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Tecnico");
            }

            // criar um utilizador 'Administrador'
            user = new ApplicationUser();
            user.UserName = "admin@example.com";
            user.Email = "admin@example.com";
            userPWD = "123_Asd";   //  wuH4)al
            chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Recursos Humanos-

            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Administrador");
            }
        }

    }
}

