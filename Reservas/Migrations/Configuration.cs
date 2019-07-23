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
            // adiciona lugares
            var lugares = new List<Lugares> {
               new Lugares {ID=1, Cidade="Tomar", Livre=true},
               new Lugares {ID=2, Cidade="Tomar", Livre=true},
               new Lugares {ID=3, Cidade="Porto", Livre=true},
               new Lugares {ID=4, Cidade="Porto", Livre=true},
               new Lugares {ID=5, Cidade="Tomar", Livre=true},
               new Lugares {ID=6, Cidade="Porto", Livre=true},
               new Lugares {ID=7, Cidade="Tomar", Livre=true},
               new Lugares {ID=8, Cidade="Porto", Livre=true},
               new Lugares {ID=9, Cidade="Porto", Livre=true},
               new Lugares {ID=10, Cidade="Porto", Livre=true},
               new Lugares {ID=11, Cidade="Coimbra", Livre=true},
               new Lugares {ID=12, Cidade="Tomar", Livre=true},
               new Lugares {ID=14, Cidade="Tomar", Livre=true},
               new Lugares {ID=15, Cidade="Lisboa", Livre=true},
               new Lugares {ID=16, Cidade="Lisboa", Livre=true},
               new Lugares {ID=17, Cidade="Lisboa", Livre=true},
               new Lugares {ID=18, Cidade="Lisboa", Livre=true},
               new Lugares {ID=19, Cidade="Lisboa", Livre=true},
               new Lugares {ID=20, Cidade="Lisboa", Livre=true},
               new Lugares {ID=21, Cidade="Tomar", Livre=true}
            };
            lugares.ForEach(ll => context.Lugares.AddOrUpdate(l => l.ID, ll));
            context.SaveChanges();

            //*********************************************************************
            // adiciona Clientes
            var clientes = new List<Clientes> {
               new Clientes {ID=1, Nome=" João Santos", CC="259608282", NIF="123456700", Telemovel="912039720", DataNascimento=new DateTime(1965,2,21), NumCartaConducao="SA-12345", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2022,1,22), UserNameID="cl" },
               new Clientes {ID=2, Nome=" Daniel Soares", CC="259608283", NIF="123456701", Telemovel="928155823", DataNascimento=new DateTime(1966,7,19), NumCartaConducao="LX-244056", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2029,9,24), UserNameID="cliente" },
               new Clientes {ID=3, Nome=" Adriana Rodrigues", CC="588141871", NIF="123456702", Telemovel="922775155", DataNascimento=new DateTime(1981,12,3), NumCartaConducao="LX-847226", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2025,2,9) },
               new Clientes {ID=4, Nome=" Rosa Fernandes", CC="728246437", NIF="123456703", Telemovel="913055221", DataNascimento=new DateTime(1977,9,24), NumCartaConducao="SA-89573", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2027,9,6) },
               new Clientes {ID=5, Nome=" Carolina Oliveira", CC="858156342", NIF="123456704", Telemovel="938070118", DataNascimento=new DateTime(1953,8,17), NumCartaConducao="AC-738163", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2022,8,1) },
               new Clientes {ID=6, Nome=" César Sousa", CC="507261086", NIF="123456705", Telemovel="916118589", DataNascimento=new DateTime(1964,8,22), NumCartaConducao="FA-321287", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2027,1,26) },
               new Clientes {ID=7, Nome=" Maria Teixeira", CC="618881552", NIF="123456706", Telemovel="913789865", DataNascimento=new DateTime(1956,3,23), NumCartaConducao="BE-782268", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2025,3,11) },
               new Clientes {ID=8, Nome=" Maria Melo", CC="819229141", NIF="123456707", Telemovel="939473033", DataNascimento=new DateTime(1955,11,21), NumCartaConducao="EV-409189", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2026,6,15) },
               new Clientes {ID=9, Nome=" Francisco Vieira", CC="468921645", NIF="123456708", Telemovel="933935364", DataNascimento=new DateTime(1965,8,12), NumCartaConducao="PO-26600", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2021,11,2) },
               new Clientes {ID=10, Nome=" Leonardo Marques", CC="110562475", NIF="123456709", Telemovel="919566682", DataNascimento=new DateTime(1937,8,19), NumCartaConducao="AC-488808", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2021,11,13) },
               new Clientes {ID=11, Nome=" Fábio Carvalho", CC="241857636", NIF="123456710", Telemovel="929532699", DataNascimento=new DateTime(1977,4,6), NumCartaConducao="EV-196487", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2026,10,10) },
               new Clientes {ID=12, Nome=" Tiago Vieira", CC="192262426", NIF="123456711", Telemovel="923560516", DataNascimento=new DateTime(1945,10,4), NumCartaConducao="EV-115244", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2019,3,20) },
               new Clientes {ID=13, Nome=" Rosana Soares", CC="233334917", NIF="123456712", Telemovel="921904819", DataNascimento=new DateTime(1951,4,4), NumCartaConducao="EV-257116", LocalEmissao="Évora", DataValidadeCarta=new DateTime(2019,10,11) },
               new Clientes {ID=14, Nome=" Rui Freitas", CC="251617767", NIF="123456713", Telemovel="928275227", DataNascimento=new DateTime(1985,4,25), NumCartaConducao="PO-611668", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2027,1,3) },
               new Clientes {ID=15, Nome=" César Soares", CC="151965324", NIF="123456714", Telemovel="926122269", DataNascimento=new DateTime(1961,12,4), NumCartaConducao="VI-815500", LocalEmissao="Viseu", DataValidadeCarta=new DateTime(2030,11,2) },
               new Clientes {ID=16, Nome=" Márcio Sousa", CC="74975648", NIF="123456714", Telemovel="920273918", DataNascimento=new DateTime(1971,6,12), NumCartaConducao="AC-680776", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2019,6,4) },
               new Clientes {ID=17, Nome=" Eduardo Vieira", CC="254872277", NIF="123456716", Telemovel="911426580", DataNascimento=new DateTime(1973,11,19), NumCartaConducao="FA-812863", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2025,5,24) },
               new Clientes {ID=18, Nome=" Adriana Oliveira", CC="686190303", NIF="123456717", Telemovel="928341652", DataNascimento=new DateTime(1950,9,16), NumCartaConducao="BE-100918", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2030,9,25) },
               new Clientes {ID=19, Nome=" Beatriz Soares", CC="163679850", NIF="123456718", Telemovel="919470029", DataNascimento=new DateTime(1985,1,6), NumCartaConducao="AC-374173", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2029,1,13) },
               new Clientes {ID=20, Nome=" Adriana Sousa", CC="845941950", NIF="123456719", Telemovel="927173964", DataNascimento=new DateTime(1957,6,20), NumCartaConducao="MA-107861", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2025,6,14) },
               new Clientes {ID=21, Nome=" Patrícia Gonçalves", CC="185717766", NIF="123456720", Telemovel="914848986", DataNascimento=new DateTime(1934,4,20), NumCartaConducao="MA-949155", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2023,2,3) },
               new Clientes {ID=22, Nome=" Paula Martins", CC="782184726", NIF="123456721", Telemovel="920456771", DataNascimento=new DateTime(1984,11,6), NumCartaConducao="BE-743939", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2028,11,23) },
               new Clientes {ID=23, Nome=" Andreia Vieira", CC="994307613", NIF="123456722", Telemovel="927778208", DataNascimento=new DateTime(1967,10,25), NumCartaConducao="FA-165555", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2027,3,28) },
               new Clientes {ID=24, Nome=" Elisabete Morais", CC="270424301", NIF="123456723", Telemovel="929350747", DataNascimento=new DateTime(1933,7,26), NumCartaConducao="FA-583994", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2029,11,8) },
               new Clientes {ID=25, Nome=" Marlene Melo", CC="270120676", NIF="123456724", Telemovel="927108995", DataNascimento=new DateTime(1937,7,14), NumCartaConducao="FA-751427", LocalEmissao="Faro", DataValidadeCarta=new DateTime(2029,4,6) },
               new Clientes {ID=26, Nome=" Marlene Pinto", CC="751512767", NIF="123456725", Telemovel="915698893", DataNascimento=new DateTime(1942,2,20), NumCartaConducao="LX-963025", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2021,12,20) },
               new Clientes {ID=27, Nome=" Luís Lopes", CC="497555127", NIF="123456726", Telemovel="912266256", DataNascimento=new DateTime(1967,3,15), NumCartaConducao="MA-512423", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2029,11,7) },
               new Clientes {ID=28, Nome=" Denise Vieira", CC="264427182", NIF="123456727", Telemovel="923857727", DataNascimento=new DateTime(1977,5,28), NumCartaConducao="PO-887507", LocalEmissao="Porto", DataValidadeCarta=new DateTime(2029,8,2) },
               new Clientes {ID=29, Nome=" Cristina Rosa", CC="461453252", NIF="123456728", Telemovel="938685713", DataNascimento=new DateTime(1960,10,19), NumCartaConducao="MA-257694", LocalEmissao="Madeira", DataValidadeCarta=new DateTime(2030,9,11) },
               new Clientes {ID=30, Nome=" Carmem Lopes", CC="91728054", NIF="123456729", Telemovel="913797694", DataNascimento=new DateTime(1942,5,3), NumCartaConducao="SA-324795", LocalEmissao="Santarém", DataValidadeCarta=new DateTime(2025,6,12) },
               new Clientes {ID=31, Nome=" Rosana Carvalho", CC="279887145", NIF="123456730", Telemovel="933692261", DataNascimento=new DateTime(1956,6,9), NumCartaConducao="LX-182393", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2026,8,25) },
               new Clientes {ID=32, Nome=" Paula Silva", CC="372845332", NIF="123456731", Telemovel="917633750", DataNascimento=new DateTime(1972,5,27), NumCartaConducao="VI-966301", LocalEmissao="Viseu", DataValidadeCarta=new DateTime(2029,4,9) },
               new Clientes {ID=33, Nome=" Mara Vieira", CC="682215833", NIF="123456732", Telemovel="910890721", DataNascimento=new DateTime(1976,7,3), NumCartaConducao="LX-753375", LocalEmissao="Lisboa", DataValidadeCarta=new DateTime(2026,2,27) },
               new Clientes {ID=34, Nome=" Adão Pinto", CC="263833191", NIF="123456733", Telemovel="919161492", DataNascimento=new DateTime(1933,9,28), NumCartaConducao="AC-380383", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2024,3,5) },
               new Clientes {ID=35, Nome=" Daniel Rodrigues", CC="785025953", NIF="123456734", Telemovel="931603084", DataNascimento=new DateTime(1940,2,16), NumCartaConducao="BE-173356", LocalEmissao="Beja", DataValidadeCarta=new DateTime(2022,6,2) },
               new Clientes {ID=36, Nome=" Sandra Rodrigues", CC="639730253", NIF="123456735", Telemovel="913795825", DataNascimento=new DateTime(1932,7,25), NumCartaConducao="AC-232544", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2022,11,13) },
               new Clientes {ID=37, Nome=" Cláudio Vieira", CC="556447530", NIF="123456736", Telemovel="916327284", DataNascimento=new DateTime(1982,4,2), NumCartaConducao="AC-488152", LocalEmissao="Açores", DataValidadeCarta=new DateTime(2029,8,25) }
            ,};
            clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();


            //*********************************************************************
            // adiciona Reservas
            var reservaLugar = new List<ReservaLugar> {
               new ReservaLugar {ID=7, LocalDaReserva="Abrantes", DataDaReserva=new DateTime(2017,3,9), ClienteFK=16, TecnicoFK=1, UserNameID="reserva"},
               new ReservaLugar {ID=23, LocalDaReserva="Abrantes", DataDaReserva=new DateTime(2017,8,9), ClienteFK=16, TecnicoFK=1, UserNameID="rl"  },
               new ReservaLugar {ID=26, LocalDaReserva="Abrantes", DataDaReserva=new DateTime(2017,8,18), ClienteFK=13, TecnicoFK=1 },
               new ReservaLugar {ID=64, LocalDaReserva="Abrantes", DataDaReserva=new DateTime(2017,3,24), ClienteFK=12, TecnicoFK=1 },
               new ReservaLugar {ID=14, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,2,12), ClienteFK=15, TecnicoFK=2 },
               new ReservaLugar {ID=20, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,4,27), ClienteFK=29, TecnicoFK=2 },
               new ReservaLugar {ID=46, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,5,3), ClienteFK=22, TecnicoFK=2 },
               new ReservaLugar {ID=65, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,3,18), ClienteFK=25, TecnicoFK=2 },
               new ReservaLugar {ID=67, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,2,20), ClienteFK=2, TecnicoFK=2 },
               new ReservaLugar {ID=113, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,8,27), ClienteFK=22, TecnicoFK=2 },
               new ReservaLugar {ID=52, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,8,16), ClienteFK=2, TecnicoFK=3 },
               new ReservaLugar {ID=61, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,1,19), ClienteFK=13, TecnicoFK=3 },
               new ReservaLugar {ID=77, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,5,6), ClienteFK=10, TecnicoFK=3 },
               new ReservaLugar {ID=109, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,6,15), ClienteFK=23, TecnicoFK=3 },
               new ReservaLugar {ID=12, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,3,24), ClienteFK=19, TecnicoFK=5 },
               new ReservaLugar {ID=31, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,4,16), ClienteFK=1, TecnicoFK=5 },
               new ReservaLugar {ID=44, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,9,15), ClienteFK=17, TecnicoFK=5 },
               new ReservaLugar {ID=47, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,7,13), ClienteFK=28, TecnicoFK=5 },
               new ReservaLugar {ID=55, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,7,2), ClienteFK=21, TecnicoFK=5 },
               new ReservaLugar {ID=72, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,6,17), ClienteFK=7, TecnicoFK=5 },
               new ReservaLugar {ID=90, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,7,21), ClienteFK=29, TecnicoFK=5 },
               new ReservaLugar {ID=105, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,4,16), ClienteFK=11, TecnicoFK=5 },
               new ReservaLugar {ID=5, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,2,22), ClienteFK=13, TecnicoFK=6 },
               new ReservaLugar {ID=6, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,8,2), ClienteFK=5, TecnicoFK=6 },
               new ReservaLugar {ID=43, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,2,5), ClienteFK=6, TecnicoFK=6 },
               new ReservaLugar {ID=48, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,6,20), ClienteFK=12, TecnicoFK=6 },
               new ReservaLugar {ID=50, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,1,6), ClienteFK=15, TecnicoFK=6 },
               new ReservaLugar {ID=53, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,4,7), ClienteFK=16, TecnicoFK=6 },
               new ReservaLugar {ID=54, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,8,21), ClienteFK=4, TecnicoFK=6 },
               new ReservaLugar {ID=66, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,6,28), ClienteFK=3, TecnicoFK=6 },
               new ReservaLugar {ID=70, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,7,14), ClienteFK=26, TecnicoFK=6 },
               new ReservaLugar {ID=80, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,1,16), ClienteFK=27, TecnicoFK=6 },
               new ReservaLugar {ID=81, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,9,22), ClienteFK=18, TecnicoFK=6 },
               new ReservaLugar {ID=85, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,2,27), ClienteFK=10, TecnicoFK=6 },
               new ReservaLugar {ID=1, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,2,4), ClienteFK=8, TecnicoFK=7 },
               new ReservaLugar {ID=25, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,6,21), ClienteFK=11, TecnicoFK=7 },
               new ReservaLugar {ID=34, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,4,10), ClienteFK=11, TecnicoFK=7 },
               new ReservaLugar {ID=40, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,8,24), ClienteFK=17, TecnicoFK=7 },
               new ReservaLugar {ID=83, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,5,15), ClienteFK=13, TecnicoFK=7 },
               new ReservaLugar {ID=106, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,8,21), ClienteFK=15, TecnicoFK=7 },
               new ReservaLugar {ID=9, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,6,18), ClienteFK=6, TecnicoFK=9 },
               new ReservaLugar {ID=21, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,8,14), ClienteFK=8, TecnicoFK=9 },
               new ReservaLugar {ID=73, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,7,5), ClienteFK=6, TecnicoFK=9 },
               new ReservaLugar {ID=74, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,2,2), ClienteFK=22, TecnicoFK=9 },
               new ReservaLugar {ID=99, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,6,8), ClienteFK=11, TecnicoFK=9 },
               new ReservaLugar {ID=102, LocalDaReserva="Entroncamento", DataDaReserva=new DateTime(2017,3,25), ClienteFK=21, TecnicoFK=9 },
               new ReservaLugar {ID=11, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,8,14), ClienteFK=13, TecnicoFK=4 },
               new ReservaLugar {ID=18, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,1,5), ClienteFK=7, TecnicoFK=4 },
               new ReservaLugar {ID=38, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,7,9), ClienteFK=30, TecnicoFK=4 },
               new ReservaLugar {ID=51, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,2,28), ClienteFK=19, TecnicoFK=4 },
               new ReservaLugar {ID=76, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,2,10), ClienteFK=4, TecnicoFK=4 },
               new ReservaLugar {ID=108, LocalDaReserva="Porto", DataDaReserva=new DateTime(2017,6,2), ClienteFK=20, TecnicoFK=4 },
               new ReservaLugar {ID=100, LocalDaReserva="Ourém", DataDaReserva=new DateTime(2017,9,23), ClienteFK=13, TecnicoFK=7 },
               new ReservaLugar {ID=107, LocalDaReserva="Ourém", DataDaReserva=new DateTime(2017,4,9), ClienteFK=3, TecnicoFK=7 },
               new ReservaLugar {ID=112, LocalDaReserva="Ourém", DataDaReserva=new DateTime(2017,4,18), ClienteFK=6, TecnicoFK=7 },
               new ReservaLugar {ID=27, LocalDaReserva="Torres Novas", DataDaReserva =new DateTime(2017,3,21), ClienteFK=15, TecnicoFK=7 },
               new ReservaLugar {ID=111, LocalDaReserva="Torres Novas", DataDaReserva=new DateTime(2017,8,22), ClienteFK=7, TecnicoFK=7 },
               new ReservaLugar {ID=30, LocalDaReserva="Torres Novas", DataDaReserva=new DateTime(2017,6,23), ClienteFK=16, TecnicoFK=10 },
               new ReservaLugar {ID=75, LocalDaReserva="Torres Novas", DataDaReserva=new DateTime(2017,5,20), ClienteFK=20, TecnicoFK=10 },
               new ReservaLugar {ID=2, LocalDaReserva="Torres Novas", DataDaReserva=new DateTime(2017,7,1), ClienteFK=26, TecnicoFK=9 },
               new ReservaLugar {ID=8, LocalDaReserva="Torres Novas", DataDaReserva=new DateTime(2017,6,9), ClienteFK=3, TecnicoFK=5 },
               new ReservaLugar {ID=22, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,5,1), ClienteFK=3, TecnicoFK=8 },
               new ReservaLugar {ID=35, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,5,17), ClienteFK=26, TecnicoFK=8 },
               new ReservaLugar {ID=37, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,3,3), ClienteFK=17, TecnicoFK=8 },
               new ReservaLugar {ID=39, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,9,19), ClienteFK=11, TecnicoFK=8 },
               new ReservaLugar {ID=49, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,9,17), ClienteFK=22, TecnicoFK=8 },
               new ReservaLugar {ID=78, LocalDaReserva="Leiria", DataDaReserva=new DateTime(2017,3,13), ClienteFK=14, TecnicoFK=8 },
               new ReservaLugar {ID=10, LocalDaReserva="Santarém", DataDaReserva=new DateTime(2017,2,18), ClienteFK=19, TecnicoFK=8 },
               new ReservaLugar {ID=103, LocalDaReserva="Santarém", DataDaReserva=new DateTime(2017,8,28), ClienteFK=5, TecnicoFK=8 },
               new ReservaLugar {ID=97, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,7,8), ClienteFK=26, TecnicoFK=6 },
               new ReservaLugar {ID=115, LocalDaReserva="Tomar", DataDaReserva=new DateTime(2017,8,4), ClienteFK=4, TecnicoFK=6 }
            };
            reservaLugar.ForEach(mm => context.ReservaLugar.AddOrUpdate(m => m.ID, mm));
            context.SaveChanges();

        }
    }
}
