using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ToevoegenRepository : DbConnection
    {
        public  IEnumerable<Categorie> HaalCategorieOp()
        {
            const string sql = "HaalAlleCategorieenOp";

            //connect to database
            using var connection = Connect();

            
            
            var result = connection.Query<Categorie>(sql);
            return result;
        }
        
            public  IEnumerable<Uitgever> HaalAlleUitgeverOp()
            {
                const string sql = "HaalAlleUitgeverOp";

                //connect to database
                using var connection = Connect();

                var result = connection.Query<Uitgever>(sql);
                return result;
            }

            /// <summary>
            /// Verstuurd een stripboek met de bijbehorende parameters
            /// </summary>
            /// <param name="uitgave"></param>
            /// <param name="reeks"></param>
            /// <param name="uitgever"></param>
            /// <param name="versie"></param>
            /// <param name="categorie"></param>
            /// <param name="gebruiker_id"></param>
            public async void VerstuurNieuwStripboek(Uitgave uitgave, Reeks reeks, Uitgever uitgever, Versie versie,
                Categorie categorie, string gebruiker_id)
            {

                //string
                const string sql = "StripboekToevoegen";
                
                //param
                var param = new
                {
                    //versie
                    afbeelding_url = versie.afbeelding_url,
                    isbn = versie.isbn,
                    datum = versie.datum,
                    druk = versie.druk,
                    prijs = versie.prijs,
                    
                    //uitgave
                    naam = uitgave.naam,
                    hoogte = uitgave.hoogte,
                    beschrijving = uitgave.beschrijving,
                    
                    //reeks
                    reeks_naam = reeks.reeks_naam,
                    
                    //categorie
                    cat_naam = categorie.cat_naam,
                    
                    //uitgever
                    uitgever_naam = uitgever.uitgever_naam,
                    gebruiker_id = "2"
                };
                
                //connect to database
                using var connection = Connect();
                
                //execute
                var result = await connection.ExecuteAsync(sql,param, commandType: System.Data.CommandType.StoredProcedure);
            }
    }
}