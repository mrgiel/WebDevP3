using System;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ToevoegenRepository : DbConnection
    {
        /// <summary>
        /// zoeks reeks nummer voor reeks naam
        /// </summary>
        /// <param name="reeks"></param>
        /// <returns></returns>
        public int? ZoekReeksNummer(Reeks reeks)
        {
            //query
            var sql = "SELECT reeks_nr FROM Reeks WHERE lower(reeks_naam) = lower(@reeksUser)";

            //param
            var param = new {reeksUser = reeks.reeks_naam};

            //connect to database
            using var connection = Connect();

            //als database niet bestaat of null --> return null anders return int
            return !connection.ExecuteScalar<bool>(sql, param) ? null : connection.QuerySingleOrDefault<int>(sql, param);
        }

        /// <summary>
        /// stuur data naar database
        /// </summary>
        /// <param name="uitgave"></param>
        /// <param name="reeksNummer"></param>
        public void VoegToe(Uitgave uitgave, int? reeksNummer)
        {

            //param
            var param = new
            {
                uitgave.isbn,
                uitgave.naam,
                uitgave.jaar,
                uitgave.hoogte,
                uitgave.uitgever_naam,
                uitgave.nsfw,
                prijs = Math.Round(uitgave.prijs, 2),
                reeksNummer
            };

            //query
            var sql =
                "INSERT INTO uitgave(isbn,naam,jaar,hoogte,uitgever,nsfw,prijs, reeks_nr)VALUES(@isbn,@naam,@jaar,@hoogte,@uitgever,@nsfw,@prijs,@reeksNummer)";

            //connect to database
            using var connection = Connect();
            
            //check if database exists
            if (!connection.ExecuteScalar<bool>(sql, param))
                return;

            //execute
            connection.Execute(sql, param);
        }
    }
}