namespace Reservas.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Reservas.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservasDB>
    {
        public Configuration()
        {
            // é possível fazer automaticamente o RECRIAR da base de dados
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ReservasDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //*********************************************************************
            // adiciona Tecnicos
            var tecnicos = new List<Tecnicos> {
               new Tecnicos {ID=1, Nome="Tânia Vieira", Cidade="Ourém", Fotografia="TaniaVieira.jpg", UserNameID="tania" },
               new Tecnicos {ID=2, Nome="António Rocha", Cidade="Ourém", Fotografia="AntonioRocha.jpg", UserNameID="rh" },
               new Tecnicos {ID=3, Nome="André Silveira", Cidade="Abrantes", Fotografia="AndreSilveira.jpg" },
               new Tecnicos {ID=4, Nome="Lurdes Vieira", Cidade="Leiria", Fotografia="LurdesVieira.jpg" },
               new Tecnicos {ID=5, Nome="Cláudia Pinto", Cidade="Porto", Fotografia="ClaudiaPinto.jpg" },
               new Tecnicos {ID=6, Nome="Rui Vieira", Cidade="Tomar", Fotografia="RuiVieira.jpg" },
               new Tecnicos {ID=7, Nome="Paulo Vieira", Cidade="Torres Novas", Fotografia="PauloVieira.jpg" },
               new Tecnicos {ID=8, Nome="Augusto Carvalho", Cidade="Lisboa", Fotografia="AugustoCarvalho.jpg" },
               new Tecnicos {ID=9, Nome="Beatriz Pinto", Cidade="Porto", Fotografia="BeatrizPinto.jpg" },
               new Tecnicos {ID=10, Nome="José Alves", Cidade="Entroncamento", Fotografia="JoseAlves.jpg" }
            };
            tecnicos.ForEach(aa => context.Tecnicos.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();


            //*********************************************************************
            // adiciona Clientes
            var clientes = new List<Clientes> {
               new Clientes {ID=1, Nome=" João Santos", CC="259608282", NIF="123456700", Telemovel="912039720", DataNascimento=new DateTime(1965,2,21), NumCartaConducao="SA-12345", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2022,1,22), UserNameID="cl"},
               new Clientes {ID=2, Nome=" Daniel Soares", CC="259608283", NIF="123456701", Telemovel="928155823", DataNascimento=new DateTime(1966,7,19), NumCartaConducao="LX-244056", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2029,9,24), UserNameID="cliente"},
               new Clientes {ID=3, Nome=" Adriana Rodrigues", CC="588141871", NIF="123456702", Telemovel="922775155", DataNascimento=new DateTime(1981,12,3), NumCartaConducao="LX-847226", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2025,2,9)},
               new Clientes {ID=4, Nome=" Rosa Fernandes", CC="728246437", NIF="123456703", Telemovel="913055221", DataNascimento=new DateTime(1977,9,24), NumCartaConducao="SA-89573", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2027,9,6)},
               new Clientes {ID=5, Nome=" Carolina Oliveira", CC="858156342", NIF="123456704", Telemovel="938070118", DataNascimento=new DateTime(1953,8,17), NumCartaConducao="AC-738163", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2022,8,1)},
               new Clientes {ID=6, Nome=" César Sousa", CC="507261086", NIF="123456705", Telemovel="916118589", DataNascimento=new DateTime(1964,8,22), NumCartaConducao="FA-321287", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2027,1,26)},
               new Clientes {ID=7, Nome=" Maria Teixeira", CC="618881552", NIF="123456706", Telemovel="913789865", DataNascimento=new DateTime(1956,3,23), NumCartaConducao="BE-782268", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2025,3,11)},
               new Clientes {ID=8, Nome=" Maria Melo", CC="819229141", NIF="123456707", Telemovel="939473033", DataNascimento=new DateTime(1955,11,21), NumCartaConducao="EV-409189", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2026,6,15) },
               new Clientes {ID=9, Nome=" Francisco Vieira", CC="468921645", NIF="123456708", Telemovel="933935364", DataNascimento=new DateTime(1965,8,12), NumCartaConducao="PO-26600", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2021,11,2)},
               new Clientes {ID=10, Nome=" Leonardo Marques", CC="110562475", NIF="123456709", Telemovel="919566682", DataNascimento=new DateTime(1937,8,19), NumCartaConducao="AC-488808", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2021,11,13)}
            };
            clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();


            //*********************************************************************
            // adiciona Reservas
            var reservaLugares = new List<ReservaLugares> {
               new ReservaLugares {ID=1, LocalDaReserva="Abrantes", DataDaReserva=new DateTime(2017,3,9), ClienteFK=1, TecnicoFK=1},
               new ReservaLugares {ID=2, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,8,9), ClienteFK=4, TecnicoFK=2},
               new ReservaLugares {ID=3, LocalDaReserva="Lisboa", DataDaReserva=new DateTime(2017,8,18), ClienteFK=8, TecnicoFK=3},
               new ReservaLugares {ID=4, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,2,12), ClienteFK=10, TecnicoFK=4}
            };
            reservaLugares.ForEach(mm => context.ReservaLugares.AddOrUpdate(m => m.ID, mm));
            context.SaveChanges();


            //*********************************************************************
            // adiciona lugares
            var lugares = new List<Lugares> {
               new Lugares {ID=1, Cidade="Tomar", Livre=true, ReservaLugarFK=1},
               new Lugares {ID=2, Cidade="Lisboa", Livre=true, ReservaLugarFK=2},
               new Lugares {ID=3, Cidade="Porto", Livre=true, ReservaLugarFK=3}
            };
            lugares.ForEach(ll => context.Lugares.AddOrUpdate(l => l.ID, ll));
            context.SaveChanges();


        }
    }
}
