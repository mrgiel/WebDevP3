using System.Collections.Generic;
using System.Data;
using Dapper;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{

    public class StripboekenAanpassenRepository : DbConnection
    {
        /// <summary>
        /// Stripboek aanpassen met de bijbehoorden versie
        /// </summary>
        /// <param name="versie"></param>
        public void StripboekAanpassen(Versie versie)
        {
            //stored procedure van aanpassen
            const string sql = "StripboekAanpassen";

            var param = new
            {
                //Versie
                versie_idVAR = versie.versie_id,
                afbeelding_urlVAR = versie.afbeelding_url,
                isbnVAR = versie.isbn,
                datumVAR = versie.datum,
                drukVAR = versie.druk,
                prijsVAR = versie.prijs,

                //Uitgave
                naamVAR = versie.Uitgave.naam,
                beschrijvingVAR = versie.Uitgave.beschrijving,
                hoogteVAR = versie.Uitgave.hoogte,
                nsfwVAR = versie.Uitgave.nsfw,

                //Uitgever
                uitgever_naamVAR = versie.Uitgever.uitgever_naam,

                //Categorie
                cat_naamVAR = versie.Uitgave.Categorie.cat_naam,

                //Reeks
                reeks_naamVAR = versie.Uitgave.Reeks.reeks_naam
            };

            //connect to database
            using var connection = Connect();

            //update stripboek
            connection.Execute(sql, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Haalt alle stripboek informatie op van een versie
        /// </summary>
        /// <param name="versie_id"></param>
        /// <returns>IEnumerable van Versie</returns>
        public IEnumerable<Versie> HaalStripboekInformatieOp(int versie_id)
        {
            //stored procedure van stripboeken informatie
            const string sql = "HaalStripboekInformatieOp";

            //param
            var param = new
            {
                //Versie
                versie_idVAR = versie_id
            };

            //connect to database
            using var connection = Connect();

            //haal alles op
            var result = connection.Query<Versie, Uitgave, Uitgever, Categorie, Reeks ,Versie>(
                sql,
                (versie, uitgave, uitgever, categorie, reeks) =>
                {
                    versie.Uitgave = uitgave;
                    versie.Uitgever = uitgever;
                    versie.Uitgave.Categorie = categorie;
                    versie.Uitgave.Reeks = reeks;
                    return versie;
                }, param, splitOn: "naam, uitgever_naam, cat_naam, reeks_naam",
                commandType: CommandType.StoredProcedure);

            //return
            return result;
        }
    }
}