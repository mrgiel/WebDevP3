using System.Collections.Generic;
using System.Data;
using Dapper;
using WebApplication1.Models.Klasse;
using WebApplication1.Pages;

namespace WebApplication1.Repositories
{
    public class StripboekToevoegenRepository : DbConnection
    {
        /// <summary>
        /// Haal alle categorieen op
        /// </summary>
        /// <returns>IEnumerable van Categorie</returns>
        public IEnumerable<Categorie> HaalCategorieOp()
        {
            //kan beter via multi-mapping

            const string sql = "HaalAlleCategorieenOp";

            //connect to database
            using var connection = Connect();


            var result = connection.Query<Categorie>(sql);
            return result;
        }

        /// <summary>
        /// Haal alle uitgevers op
        /// </summary>
        /// <returns>IEnumerable van Uitgever</returns>
        public IEnumerable<Uitgever> HaalAlleUitgeverOp()
        {
            //kan beter via multi-mapping

            const string sql = "HaalAlleUitgeverOp";

            //connect to database
            using var connection = Connect();

            var result = connection.Query<Uitgever>(sql);
            return result;
        }

        /// <summary>
        /// Stopt een stripboek met bijbehoordende data in databse
        /// </summary>
        /// <param name="uitgave"></param>
        /// <param name="reeks"></param>
        /// <param name="uitgever"></param>
        /// <param name="versie"></param>
        /// <param name="categorie"></param>
        /// <param name="voornaamArray"></param>
        /// <param name="rolArray"></param>
        /// <param name="achternaamArray"></param>
        /// <param name="count"></param>
        /// <param name="gebruiker_id"></param>
        public async void VerstuurNieuwStripboek(Uitgave uitgave, Reeks reeks, Uitgever uitgever, Versie versie,
            Categorie categorie, string voornaamArray, string rolArray, string achternaamArray, int count,
            string gebruiker_id)
        {
            //Stored Procedure van toevoegen
            const string sql = "StripboekToevoegen";

            //Param
            var param = new
            {
                //versie
                afbeelding_urlVAR = versie.afbeelding_url,
                isbnVAR = versie.isbn,
                datumVAR = versie.datum,
                drukVAR = versie.druk,
                prijsVAR = versie.prijs,

                //uitgave
                naamVAR = uitgave.naam,
                hoogteVAR = uitgave.hoogte,
                beschrijvingVAR = uitgave.beschrijving,
                nsfwVar = uitgave.nsfw,

                //reeks
                reeks_naamVAR = reeks.reeks_naam,

                //categorie
                cat_naamVAR = categorie.cat_naam,

                //uitgever
                uitgever_naamVAR = uitgever.uitgever_naam,

                //gebruiker
                gebruiker_idVAR = gebruiker_id,

                rolARRAY = rolArray,

                //Persoon
                voornaamARRAY = voornaamArray,
                achternaamARRAY = achternaamArray,

                //length
                length = count
            };

            //connect to database
            using var connection = Connect();

            //Stop alle in de bijbehoorende tables en columns 
            var result = await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }
    }
}