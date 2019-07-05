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
            AutomaticMigrationsEnabled = true;
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
            // adiciona VIATURAS
            var viaturas = new List<Viaturas> {
               new Viaturas {ID=1, Matricula="AT-47-45",  Marca="Ford",  Modelo="Focus WRC", NomeDono="Tiago Lopes",  MoradaDono="Rua de Coimbra",  CodPostalDono="2300-471 TOMAR" },
               new Viaturas {ID=2, Matricula="BM-72-65",  Marca="Seat",  Modelo="Toledo",  NomeDono="Henrique Soares",  MoradaDono="Azinhaga de Bacelos",  CodPostalDono="2300-439 TOMAR" },
               new Viaturas {ID=3, Matricula="CI-57-04",  Marca="Ferrari",  Modelo="Testarossa",  NomeDono="Luciano Fernandes",  MoradaDono="Travessa dos Arcos",  CodPostalDono="2300-602 TOMAR" },
               new Viaturas {ID=4, Matricula="CQ-07-12",  Marca="Renault",  Modelo="Clio",  NomeDono="Mara Fernandes",  MoradaDono="Rua da Saboaria",  CodPostalDono="2300-559 TOMAR" },
               new Viaturas {ID=5, Matricula="DM-21-48",  Marca="Ford",  Modelo="Mondeo",  NomeDono="Luciana Rocha",  MoradaDono="Rua Infantaria 15",  CodPostalDono="2300-583 TOMAR" },
               new Viaturas {ID=6, Matricula="EU-59-11",  Marca="Renault",  Modelo="Espace",  NomeDono="Isabel Rosa",  MoradaDono="Rua Paulo Oliveira",  CodPostalDono="2300-514 TOMAR" },
               new Viaturas {ID=7, Matricula="FJ-74-85",  Marca="Audi",  Modelo="TT",  NomeDono="Alexandre Vieira",  MoradaDono="Rua do Centro Republicano",  CodPostalDono="2300-359 TOMAR" },
               new Viaturas {ID=8, Matricula="HC-41-61",  Marca="Fiat",  Modelo="Bravo",  NomeDono="Guilherme Rodrigues",  MoradaDono="Rua do Teatro",  CodPostalDono="2300-573 TOMAR" },
               new Viaturas {ID=9, Matricula="HO-15-18",  Marca="Renault",  Modelo="Twingo",  NomeDono="Paulo Vieira",  MoradaDono="Rua da Cascalheira",  CodPostalDono="2300-464 TOMAR" },
               new Viaturas {ID=10, Matricula="HV-21-24",  Marca="BMW",  Modelo="Serie 5",  NomeDono="João  Vieira",  MoradaDono="Rua Torres Pinheiro",  CodPostalDono="2300-538 TOMAR" },
               new Viaturas {ID=11, Matricula="KK-71-88",  Marca="Renault",  Modelo="4L",  NomeDono="João Simões Lopes",  MoradaDono="Rua S. João",  CodPostalDono="2300-001 TOMAR" },
               new Viaturas {ID=12, Matricula="LL-21-07",  Marca="Seat",  Modelo="Marbelha",  NomeDono="Henrique Dias",  MoradaDono="Caminho Água das Maias",  CodPostalDono="2300-632 TOMAR" },
               new Viaturas {ID=13, Matricula="MJ-87-82",  Marca="Seat",  Modelo="Ibisa",  NomeDono="Tânia Fernandes",  MoradaDono="Avenida Doutor Vieira Guimarães",  CodPostalDono="2300-534 TOMAR" },
               new Viaturas {ID=14, Matricula="NG-96-34",  Marca="Renault",  Modelo="Megane",  NomeDono="Guilherme Pinto",  MoradaDono="Rua de Leiria",  CodPostalDono="2300-565 TOMAR" },
               new Viaturas {ID=15, Matricula="NS-21-62",  Marca="Fiat",  Modelo="Panda",  NomeDono="Rodrigo Vieira",  MoradaDono="Rua Doutor Oliveira Salazar",  CodPostalDono="2305-123 ASSEICEIRA TMR" },
               new Viaturas {ID=16, Matricula="OI-17-31",  Marca="Fiat",  Modelo="Punto 75 SX",  NomeDono="Manuel Rodrigues",  MoradaDono="Rua Fernando Lopes Graça",  CodPostalDono="2300-493 TOMAR" },
               new Viaturas {ID=17, Matricula="SM-38-87",  Marca="Porshe",  Modelo="911 Carrera",  NomeDono="Simone Vieira",  MoradaDono="Rua 1º de Maio",  CodPostalDono="2300-448 TOMAR" },
               new Viaturas {ID=18, Matricula="TV-35-04",  Marca="Audi",  Modelo="A4",  NomeDono="Luciano Vieira",  MoradaDono="Largo da Saboaria",  CodPostalDono="2300-327 TOMAR" },
               new Viaturas {ID=19, Matricula="UE-92-24",  Marca="Audi",  Modelo="A3",  NomeDono="Marcos Vieira",  MoradaDono="Avenida Dom Nuno Álvares Pereira",  CodPostalDono="2300-532 TOMAR" },
               new Viaturas {ID=20, Matricula="XD-71-88",  Marca="BMW",  Modelo="Serie3",  NomeDono="Renato Vieira",  MoradaDono="Rua do Orfeão Tomarense",  CodPostalDono="2300-480 TOMAR" },
               new Viaturas {ID=21, Matricula="ZG-74-16",  Marca="Skoda",  Modelo="Superb",  NomeDono="Fábio Ribeiro",  MoradaDono="Rua Dom Diogo Torralva",  CodPostalDono="2300-477 TOMAR" }
            };
            viaturas.ForEach(vv => context.Viaturas.AddOrUpdate(v => v.Matricula, vv));
            context.SaveChanges();

            //*********************************************************************
            // adiciona Clientes
            var clientes = new List<Clientes> {
               new Clientes {ID=1, Nome=" João Santos", BI="123456", Telemovel="912039720", DataNascimento=new DateTime(1965,2,21), NumCartaConducao="SA-12345", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2022,1,22) },
               new Clientes {ID=2, Nome=" Daniel Soares", BI="259608283", Telemovel="928155823", DataNascimento=new DateTime(1966,7,19), NumCartaConducao="LX-244056", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2029,9,24) },
               new Clientes {ID=3, Nome=" Adriana Rodrigues", BI="588141871", Telemovel="922775155", DataNascimento=new DateTime(1981,12,3), NumCartaConducao="LX-847226", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2025,2,9) },
               new Clientes {ID=4, Nome=" Rosa Fernandes", BI="728246437", Telemovel="913055221", DataNascimento=new DateTime(1977,9,24), NumCartaConducao="SA-89573", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2027,9,6) },
               new Clientes {ID=5, Nome=" Carolina Oliveira", BI="858156342", Telemovel="938070118", DataNascimento=new DateTime(1953,8,17), NumCartaConducao="AC-738163", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2022,8,1) },
               new Clientes {ID=6, Nome=" César Sousa", BI="507261086", Telemovel="916118589", DataNascimento=new DateTime(1964,8,22), NumCartaConducao="FA-321287", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2027,1,26) },
               new Clientes {ID=7, Nome=" Maria Teixeira", BI="618881552", Telemovel="913789865", DataNascimento=new DateTime(1956,3,23), NumCartaConducao="BE-782268", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2025,3,11) },
               new Clientes {ID=8, Nome=" Maria Melo", BI="819229141", Telemovel="939473033", DataNascimento=new DateTime(1955,11,21), NumCartaConducao="EV-409189", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2026,6,15) },
               new Clientes {ID=9, Nome=" Francisco Vieira", BI="468921645", Telemovel="933935364", DataNascimento=new DateTime(1965,8,12), NumCartaConducao="PO-26600", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2021,11,2) },
               new Clientes {ID=10, Nome=" Leonardo Marques", BI="110562475", Telemovel="919566682", DataNascimento=new DateTime(1937,8,19), NumCartaConducao="AC-488808", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2021,11,13) },
               new Clientes {ID=11, Nome=" Fábio Carvalho", BI="241857636", Telemovel="929532699", DataNascimento=new DateTime(1977,4,6), NumCartaConducao="EV-196487", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2026,10,10) },
               new Clientes {ID=12, Nome=" Tiago Vieira", BI="192262426", Telemovel="923560516", DataNascimento=new DateTime(1945,10,4), NumCartaConducao="EV-115244", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2019,3,20) },
               new Clientes {ID=13, Nome=" Rosana Soares", BI="233334917", Telemovel="921904819", DataNascimento=new DateTime(1951,4,4), NumCartaConducao="EV-257116", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2019,10,11) },
               new Clientes {ID=14, Nome=" Rui Freitas", BI="251617767", Telemovel="928275227", DataNascimento=new DateTime(1985,4,25), NumCartaConducao="PO-611668", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2027,1,3) },
               new Clientes {ID=15, Nome=" César Soares", BI="151965324", Telemovel="926122269", DataNascimento=new DateTime(1961,12,4), NumCartaConducao="VI-815500", LocalEmissao="Viseu", DataValidadeCarta=new DateTime(2030,11,2) },
               new Clientes {ID=16, Nome=" Márcio Sousa", BI="74975648", Telemovel="920273918", DataNascimento=new DateTime(1971,6,12), NumCartaConducao="AC-680776", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2019,6,4) },
               new Clientes {ID=17, Nome=" Eduardo Vieira", BI="254872277", Telemovel="911426580", DataNascimento=new DateTime(1973,11,19), NumCartaConducao="FA-812863", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2025,5,24) },
               new Clientes {ID=18, Nome=" Adriana Oliveira", BI="686190303", Telemovel="928341652", DataNascimento=new DateTime(1950,9,16), NumCartaConducao="BE-100918", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2030,9,25) },
               new Clientes {ID=19, Nome=" Beatriz Soares", BI="163679850", Telemovel="919470029", DataNascimento=new DateTime(1985,1,6), NumCartaConducao="AC-374173", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2029,1,13) },
               new Clientes {ID=20, Nome=" Adriana Sousa", BI="845941950", Telemovel="927173964", DataNascimento=new DateTime(1957,6,20), NumCartaConducao="MA-107861", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2025,6,14) },
               new Clientes {ID=21, Nome=" Patrícia Gonçalves", BI="185717766", Telemovel="914848986", DataNascimento=new DateTime(1934,4,20), NumCartaConducao="MA-949155", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2023,2,3) },
               new Clientes {ID=22, Nome=" Paula Martins", BI="782184726", Telemovel="920456771", DataNascimento=new DateTime(1984,11,6), NumCartaConducao="BE-743939", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2028,11,23) },
               new Clientes {ID=23, Nome=" Andreia Vieira", BI="994307613", Telemovel="927778208", DataNascimento=new DateTime(1967,10,25), NumCartaConducao="FA-165555", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2027,3,28) },
               new Clientes {ID=24, Nome=" Elisabete Morais", BI="270424301", Telemovel="929350747", DataNascimento=new DateTime(1933,7,26), NumCartaConducao="FA-583994", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2029,11,8) },
               new Clientes {ID=25, Nome=" Marlene Melo", BI="270120676", Telemovel="927108995", DataNascimento=new DateTime(1937,7,14), NumCartaConducao="FA-751427", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2029,4,6) },
               new Clientes {ID=26, Nome=" Marlene Pinto", BI="751512767", Telemovel="915698893", DataNascimento=new DateTime(1942,2,20), NumCartaConducao="LX-963025", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2021,12,20) },
               new Clientes {ID=27, Nome=" Luís Lopes", BI="497555127", Telemovel="912266256", DataNascimento=new DateTime(1967,3,15), NumCartaConducao="MA-512423", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2029,11,7) },
               new Clientes {ID=28, Nome=" Denise Vieira", BI="264427182", Telemovel="923857727", DataNascimento=new DateTime(1977,5,28), NumCartaConducao="PO-887507", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2029,8,2) },
               new Clientes {ID=29, Nome=" Cristina Rosa", BI="461453252", Telemovel="938685713", DataNascimento=new DateTime(1960,10,19), NumCartaConducao="MA-257694", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2030,9,11) },
               new Clientes {ID=30, Nome=" Carmem Lopes", BI="91728054", Telemovel="913797694", DataNascimento=new DateTime(1942,5,3), NumCartaConducao="SA-324795", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2025,6,12) },
               new Clientes {ID=31, Nome=" Rosana Carvalho", BI="279887145", Telemovel="933692261", DataNascimento=new DateTime(1956,6,9), NumCartaConducao="LX-182393", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2026,8,25) },
               new Clientes {ID=32, Nome=" Paula Silva", BI="372845332", Telemovel="917633750", DataNascimento=new DateTime(1972,5,27), NumCartaConducao="VI-966301", LocalEmissao="Viseu", DataValidadeCarta=new DateTime(2029,4,9) },
               new Clientes {ID=33, Nome=" Mara Vieira", BI="682215833", Telemovel="910890721", DataNascimento=new DateTime(1976,7,3), NumCartaConducao="LX-753375", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2026,2,27) },
               new Clientes {ID=34, Nome=" Adão Pinto", BI="263833191", Telemovel="919161492", DataNascimento=new DateTime(1933,9,28), NumCartaConducao="AC-380383", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2024,3,5) },
               new Clientes {ID=35, Nome=" Daniel Rodrigues", BI="785025953", Telemovel="931603084", DataNascimento=new DateTime(1940,2,16), NumCartaConducao="BE-173356", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2022,6,2) },
               new Clientes {ID=36, Nome=" Sandra Rodrigues", BI="639730253", Telemovel="913795825", DataNascimento=new DateTime(1932,7,25), NumCartaConducao="AC-232544", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2022,11,13) },
               new Clientes {ID=37, Nome=" Cláudio Vieira", BI="556447530", Telemovel="916327284", DataNascimento=new DateTime(1982,4,2), NumCartaConducao="AC-488152", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2029,8,25) }
            };
            clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();


            //*********************************************************************
            // adiciona Reservas
            var reservas = new List<Reservas> {
               new Reservas {ID=7, LocalDaReserva="Abrantes", DataDaEntrada=new DateTime(2017, 3, 9, 3, 57, 11), ViaturaFK=10, ClienteFK=17, TecnicoFK=1   },
               new Reservas {ID=23, LocalDaReserva="Abrantes", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,8,9), ViaturaFK=15, ClienteFK=23, TecnicoFK=1  },
               new Reservas {ID=26, LocalDaReserva="Abrantes", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,8,18), ViaturaFK=17, ClienteFK=6, TecnicoFK=1 },
               new Reservas {ID=64, LocalDaReserva="Abrantes", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,3,24), ViaturaFK=5, ClienteFK=16, TecnicoFK=1 },
               new Reservas {ID=14, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,2,12), ViaturaFK=9, ClienteFK=15, TecnicoFK=2 },
               new Reservas {ID=20, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,4,27), ViaturaFK=11, ClienteFK=29, TecnicoFK=2 },
               new Reservas {ID=46, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,5,3), ViaturaFK=9, ClienteFK=22, TecnicoFK=2 },
               new Reservas {ID=65, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,3,18), ViaturaFK=6, ClienteFK=25, TecnicoFK=2 },
               new Reservas {ID=67, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,2,20), ViaturaFK=19, ClienteFK=2, TecnicoFK=2 },
               new Reservas {ID=113, LocalDaReserva="Tomar", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,8,27), ViaturaFK=6, ClienteFK=22, TecnicoFK=2 },
               new Reservas {ID=52, LocalDaReserva="Leiria", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,8,16), ViaturaFK=18, ClienteFK=2, TecnicoFK=3 },
               new Reservas {ID=61, LocalDaReserva="Leiria", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,1,19), ViaturaFK=13, ClienteFK=13, TecnicoFK=3 },
               new Reservas {ID=77, LocalDaReserva="Leiria", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,5,6), ViaturaFK=11, ClienteFK=10, TecnicoFK=3 },
               new Reservas {ID=109, LocalDaReserva="Leiria", DataDaSaida= new DateTime(2018,5,3, 15,05,32), DataDaEntrada=new DateTime(2017,6,15), ViaturaFK=16, ClienteFK=23, TecnicoFK=3 },
               new Reservas {ID=12, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,3,24), ViaturaFK=6, ClienteFK=19, TecnicoFK=5 },
               new Reservas {ID=31, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,4,16), ViaturaFK=11, ClienteFK=1, TecnicoFK=5 },
               new Reservas {ID=44, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,9,15), ViaturaFK=19, ClienteFK=17, TecnicoFK=5 },
               new Reservas {ID=47, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,7,13), ViaturaFK=9, ClienteFK=28, TecnicoFK=5 },
               new Reservas {ID=55, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,7,2), ViaturaFK=11, ClienteFK=21, TecnicoFK=5 },
               new Reservas {ID=72, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,6,17), ViaturaFK=1, ClienteFK=7, TecnicoFK=5 },
               new Reservas {ID=90, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,7,21), ViaturaFK=4, ClienteFK=29, TecnicoFK=5 },
               new Reservas {ID=105, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,4,16), ViaturaFK=6, ClienteFK=11, TecnicoFK=5 },
               new Reservas {ID=5, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,2,22), ViaturaFK=11, ClienteFK=13, TecnicoFK=6 },
               new Reservas {ID=6, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,8,2), ViaturaFK=16, ClienteFK=5, TecnicoFK=6 },
               new Reservas {ID=43, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,2,5), ViaturaFK=2, ClienteFK=6, TecnicoFK=6 },
               new Reservas {ID=48, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,6,20), ViaturaFK=3, ClienteFK=12, TecnicoFK=6 },
               new Reservas {ID=50, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,1,6), ViaturaFK=16, ClienteFK=15, TecnicoFK=6 },
               new Reservas {ID=53, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,4,7), ViaturaFK=15, ClienteFK=16, TecnicoFK=6 },
               new Reservas {ID=54, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,8,21), ViaturaFK=11, ClienteFK=4, TecnicoFK=6 },
               new Reservas {ID=66, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,6,28), ViaturaFK=10, ClienteFK=3, TecnicoFK=6 },
               new Reservas {ID=70, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,7,14), ViaturaFK=18, ClienteFK=26, TecnicoFK=6 },
               new Reservas {ID=80, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,1,16), ViaturaFK=1, ClienteFK=27, TecnicoFK=6 },
               new Reservas {ID=81, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,9,22), ViaturaFK=19, ClienteFK=18, TecnicoFK=6 },
               new Reservas {ID=85, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,2,27), ViaturaFK=17, ClienteFK=10, TecnicoFK=6 },
               new Reservas {ID=1, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,2,4), ViaturaFK=14, ClienteFK=8, TecnicoFK=7 },
               new Reservas {ID=25, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,6,21), ViaturaFK=6, ClienteFK=11, TecnicoFK=7 },
               new Reservas {ID=34, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,4,10), ViaturaFK=8, ClienteFK=11, TecnicoFK=7 },
               new Reservas {ID=40, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,8,24), ViaturaFK=14, ClienteFK=17, TecnicoFK=7 },
               new Reservas {ID=83, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,5,15), ViaturaFK=8, ClienteFK=13, TecnicoFK=7 },
               new Reservas {ID=106, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,8,21), ViaturaFK=16, ClienteFK=15, TecnicoFK=7 },
               new Reservas {ID=9, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,6,18), ViaturaFK=5, ClienteFK=6, TecnicoFK=9 },
               new Reservas {ID=21, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,8,14), ViaturaFK=7, ClienteFK=8, TecnicoFK=9 },
               new Reservas {ID=73, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,7,5), ViaturaFK=19, ClienteFK=6, TecnicoFK=9 },
               new Reservas {ID=74, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,2,25), ViaturaFK=19, ClienteFK=22, TecnicoFK=9 },
               new Reservas {ID=99, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,6,8), ViaturaFK=18, ClienteFK=11, TecnicoFK=9 },
               new Reservas {ID=102, LocalDaReserva="Entroncamento", DataDaEntrada=new DateTime(2017,3,25), ViaturaFK=13, ClienteFK=21, TecnicoFK=9 },
               new Reservas {ID=11, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,8,14), ViaturaFK=6, ClienteFK=13, TecnicoFK=4 },
               new Reservas {ID=18, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,1,5), ViaturaFK=4, ClienteFK=7, TecnicoFK=4 },
               new Reservas {ID=38, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,7,9), ViaturaFK=9, ClienteFK=30, TecnicoFK=4 },
               new Reservas {ID=51, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,2,28), ViaturaFK=7, ClienteFK=19, TecnicoFK=4 },
               new Reservas {ID=76, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,2,10), ViaturaFK=15, ClienteFK=4, TecnicoFK=4 },
               new Reservas {ID=108, LocalDaReserva="Porto", DataDaEntrada=new DateTime(2017,6,2), ViaturaFK=11, ClienteFK=20, TecnicoFK=4 },
               new Reservas {ID=100, LocalDaReserva="Ourém", DataDaEntrada=new DateTime(2017,9,23), ViaturaFK=17, ClienteFK=13, TecnicoFK=7 },
               new Reservas {ID=107, LocalDaReserva="Ourém", DataDaEntrada=new DateTime(2017,4,9), ViaturaFK=11, ClienteFK=3, TecnicoFK=7 },
               new Reservas {ID=112, LocalDaReserva="Ourém", DataDaEntrada=new DateTime(2017,4,18), ViaturaFK=11, ClienteFK=6, TecnicoFK=7 },
               new Reservas {ID=27, LocalDaReserva="Torres Novas", DataDaEntrada =new DateTime(2017,3,21), ViaturaFK=15, ClienteFK=15, TecnicoFK=7 },
               new Reservas {ID=111, LocalDaReserva="Torres Novas", DataDaEntrada=new DateTime(2017,8,22), ViaturaFK=3, ClienteFK=7, TecnicoFK=7 },
               new Reservas {ID=30, LocalDaReserva="Torres Novas", DataDaEntrada=new DateTime(2017,6,23), ViaturaFK=4, ClienteFK=16, TecnicoFK=10 },
               new Reservas {ID=75, LocalDaReserva="Torres Novas", DataDaEntrada=new DateTime(2017,5,20), ViaturaFK=8, ClienteFK=20, TecnicoFK=10 },
               new Reservas {ID=2, LocalDaReserva="Torres Novas", DataDaEntrada=new DateTime(2017,7,1), ViaturaFK=6, ClienteFK=26, TecnicoFK=9 },
               new Reservas {ID=8, LocalDaReserva="Torres Novas", DataDaEntrada=new DateTime(2017,6,9), ViaturaFK=5, ClienteFK=3, TecnicoFK=5 },
               new Reservas {ID=22, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,5,1), ViaturaFK=15, ClienteFK=3, TecnicoFK=8 },
               new Reservas {ID=35, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,5,17), ViaturaFK=10, ClienteFK=26, TecnicoFK=8 },
               new Reservas {ID=37, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,3,3), ViaturaFK=2, ClienteFK=17, TecnicoFK=8 },
               new Reservas {ID=39, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,9,19), ViaturaFK=8, ClienteFK=11, TecnicoFK=8 },
               new Reservas {ID=49, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,9,17), ViaturaFK=5, ClienteFK=22, TecnicoFK=8 },
               new Reservas {ID=78, LocalDaReserva="Leiria", DataDaEntrada=new DateTime(2017,3,13), ViaturaFK=5, ClienteFK=14, TecnicoFK=8 },
               new Reservas {ID=10, LocalDaReserva="Santarém", DataDaEntrada=new DateTime(2017,2,18), ViaturaFK=11, ClienteFK=19, TecnicoFK=8 },
               new Reservas {ID=103, LocalDaReserva="Santarém", DataDaEntrada=new DateTime(2017,8,28), ViaturaFK=12, ClienteFK=5, TecnicoFK=8 },
               new Reservas {ID=97, LocalDaReserva="Tomar", DataDaEntrada=new DateTime(2017,7,8), ViaturaFK=6, ClienteFK=26, TecnicoFK=6 },
               new Reservas {ID=115, LocalDaReserva="Tomar", DataDaEntrada=new DateTime(2017,8,4, 14,58,13), ViaturaFK=3, ClienteFK=4, TecnicoFK=6 }
            };
            reservas.ForEach(mm => context.Reservas.AddOrUpdate(m => m.ID, mm));
            context.SaveChanges();

        }
    }
}
