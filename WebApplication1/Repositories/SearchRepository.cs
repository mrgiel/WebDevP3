using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;

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
            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Query<Uitgave>(@"SELECT * 
                             FROM uitgave uitgave 
                             INNER JOIN versie versie on uitgave.uitgave_id = versie.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE naam || r.reeks_naam LIKE CONCAT ('%',@StrZoekterm,'%');",
                    new {StrZoekterm = strZoekterm});
            return stripboeken.ToList();
        }
        /// <summary>
        /// Geavanceerd zoeken. Gebruiker geeft 2 verschillende input
        /// </summary>
        /// <param name="zoekCategorie">zoekCategorie wordt geselecteerd in een droplist en bepaald in wel tabel van de database gezocht wordt.</param>
        /// <param name="strZoekterm"> strZoekterm is de waarde die wordt ingevuld in de textbalk</param>
        /// <returns></returns>
        public List<Uitgave> GeavanceerdZoeken(string zoekCategorie, string strZoekterm)
        {
            var sql = $"";

            switch (zoekCategorie)
            {
                //Afhankelijk van gebruikersinput wordt een case uitgevoerd.
                case "isbn":
                    sql += @"SELECT * 
                             FROM versie v
                             INNER JOIN uitgave uitgave on v.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on v.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE isbn = @StrZoekterm";
                    break;
                case "uitgever":
                    sql += @"SELECT * 
                             FROM uitgever uitgever 
                             INNER JOIN versie v on uitgever.uitgever_id = v.uitgever_id
                             INNER JOIN uitgave uitgave on uitgave.uitgave_id = v.uitgave_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE uitgever_naam LIKE CONCAT ('%',@StrZoekterm,'%');";
                    break;
                case "prijs":
                    sql += @"SELECT * 
                             FROM versie v
                             INNER JOIN uitgave uitgave on v.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on v.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE prijs = @StrZoekterm";
                    break;
                case "naam":
                    sql += @"SELECT *
                             FROM uitgave uitgave 
                             INNER JOIN versie v on uitgave.uitgave_id = v.uitgave_id
                             INNER JOIN uitgever uitgever on v.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE naam || r.reeks_naam LIKE CONCAT ('%',@StrZoekterm,'%');";
                    break;
                case "auteur":
                    sql += @"SELECT *
                             FROM persoon p
                             INNER JOIN isgemaaktdoor i on p.persoon_id = i.persoon_id
                             INNER JOIN versie v on i.versie_id = v.Versie_id
                             INNER JOIN uitgave uitgave on v.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on v.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE i.rol = 'Auteur' && voornaam || achternaam LIKE CONCAT ('%',@StrZoekterm,'%')";
                    break;
                case "tekenaar":
                    sql += @"SELECT *
                             FROM persoon p
                             INNER JOIN isgemaaktdoor i on p.persoon_id = i.persoon_id
                             INNER JOIN versie v on i.versie_id = v.Versie_id
                             INNER JOIN uitgave uitgave on v.uitgave_id = uitgave.uitgave_id
                             INNER JOIN uitgever uitgever on v.uitgever_id = uitgever.uitgever_id
                             INNER JOIN reeks r on uitgave.reeks_id = r.reeks_id
                             WHERE i.rol = 'Tekenaar' && voornaam || achternaam LIKE CONCAT ('%',@StrZoekterm,'%')";
                    break;
            }

            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Query<Uitgave>(sql,
                    new {StrZoekterm = strZoekterm, });
            return stripboeken.ToList();
        }
    }
}