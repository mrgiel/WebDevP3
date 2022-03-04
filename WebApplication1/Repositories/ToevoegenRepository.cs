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
                "Server=127.0.0.1;Database=DbExample;Uid=root;Pwd=Test1234!@;Port=3306");

        }


        public bool VoegToe(string reeksUser,int ISBN,string naam,int jaar,int hoogte,string uitgever,bool NSFW,float prijs)
        {
            using var connection = Connect();

            int reeksNummer;
            
            try
            {
                string zoekNummer = "SELECT reeks_nummer FROM Reeks WHERE lower(reeks_naam) = lower(@reeksUser)";
                reeksNummer = connection.QuerySingle<int>(zoekNummer, new {reeksUser});
                
            }
            catch (Exception e)
            {
                return false;

            }

            try
            {
                string sql = "INSERT INTO uitgave(ISBN,naam,jaar,hoogte,uitgever,reeks_nummer,NSFW,prijs,categorie_nummer)VALUES(@ISBN,@naam,@jaar,@hoogte,@uitgever,@reeksNummer,@NSFW,@prijs,12)";

                connection.Execute(sql, new {ISBN,naam,jaar,hoogte,uitgever, reeksNummer,NSFW,prijs});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;



        }
    }
}