using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ToevoegenRepository
    {
        private MySqlConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Database=stripboeken_collectie;Uid=root;Pwd=Test1234!@;Port=3306");
        }


        public void VoegToe(Reeks reeks, Uitgave uitgave)
        {

            using var connection = Connect();

            string zoekNummer = "SELECT reeks_nr FROM Reeks WHERE lower(reeks_naam) = lower(@reeksUser)";
            int? reeksNummer = connection.QuerySingle<int?>(zoekNummer,
                new
                {
                    reeksUser = reeks.reeks_naam
                });

            string sql =
                "INSERT INTO uitgave(isbn,naam,jaar,hoogte,uitgever,nsfw,prijs, reeks_nr)VALUES(@isbn,@naam,@jaar,@hoogte,@uitgever,@nsfw,@prijs,@reeksNummer)";

            connection.Execute(sql,
                new
                {
                    isbn = uitgave.isbn,
                    naam = uitgave.naam,
                    jaar = uitgave.jaar,
                    hoogte = uitgave.hoogte,
                    uitgever = uitgave.uitgever,
                    nsfw = uitgave.nsfw,
                    prijs = Math.Round(uitgave.prijs, 2),
                    reeksNummer = reeksNummer
                });
        }
    }
}