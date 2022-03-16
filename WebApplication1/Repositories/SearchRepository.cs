using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{

    public class SearchRepository : DbConnection
    {

        /// <summary>
        /// Basis zoekfunctie, zoekt alleen op naam.
        /// Haalt gegevens uit de tabellen: uitgever, uitgave en versie
        /// </summary>
        /// <param name="strZoekterm">strZoekterm is de zoekterm die de gebruiker invult in de zoekbalk</param>
        /// <returns></returns>
        public List<Uitgave> Get(string strZoekterm)
        {
            using var connection = Connect();
            var stripboeken = connection
                .Query<Uitgave>(@"SELECT * 
                             FROM uitgave uitgave 
                             INNER JOIN versie versie on uitgave.uitgave_id = versie.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             WHERE naam LIKE CONCAT ('%',@StrZoekterm,'%');",
                    new {StrZoekterm = strZoekterm});
            return stripboeken.ToList();
        }
        /// <summary>
        /// Geavanceerd zoeken. Gebruiker geeft 2 verschillende input
        /// </summary>
        /// <param name="zoekCategorie">zoekCategorie wordt geselecteerd in een droplist en bepaald in wel tabel van de database gezocht wordt.</param>
        /// <param name="strZoekterm"> strZoekterm is de waarde die wordt ingevuld in de textbalk</param>
        /// <returns></returns>
        public IEnumerable<Uitgave> GeavanceerdZoeken(string zoekCategorie, string strZoekterm)
        {
            var sql = $"";

            switch (zoekCategorie)
            {
                //Afhankelijk van gebruikersinput wordt een case uitgevoerd.
                case "isbn":
                    sql += @"SELECT * 
                             FROM versie versie
                             INNER JOIN uitgave uitgave on versie.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             WHERE isbn = @StrZoekterm";
                    break;
                case "uitgever":
                    sql += @"SELECT * 
                             FROM uitgever uitgever 
                             INNER JOIN versie versie on uitgever.uitgever_id = versie.uitgever_id
                             INNER JOIN uitgave uitgave on uitgave.uitgave_id = versie.uitgave_id
                             WHERE uitgever_naam LIKE CONCAT ('%',@StrZoekterm,'%');";
                    break;
                case "prijs":
                    sql += @"SELECT * 
                             FROM versie versie
                             INNER JOIN uitgave uitgave on versie.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             WHERE prijs = @StrZoekterm";
                    break;
                case "naam":
                    sql += @"SELECT *
                             FROM uitgave uitgave 
                             INNER JOIN versie versie on uitgave.uitgave_id = versie.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             WHERE naam LIKE CONCAT ('%',@StrZoekterm,'%');";
                    break;
            }

            using var connection = Connect();
            var stripboeken = connection
                .Query<Uitgave>(sql,
                    new {StrZoekterm = strZoekterm, });
            return stripboeken;
        }
    }
}