using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{

    public class SearchRepository
    {
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                @"Server=127.0.0.1;
            Database=stripboekendb;
            Uid=root;Pwd=Test123;"
            );
        }
        
        //Basic search function, only searching for a stripbook name.
        public List<Uitgave> Get(string searchString)
        {
            using var connection = Connect();
            var stripboeken = connection
                .Query<Uitgave>("SELECT * FROM uitgave WHERE Naam LIKE CONCAT('%',@SearchString,'%'); ",
                    new {SearchString = searchString});
            return stripboeken.ToList();
        }

        //Advanced search. User gives 2 types of input. 
        //searchString's is the users input
        //advSearch is the value of the droplist
        public List<Uitgave> AdvSearch(string advSearch, string searchString)
        {

            //Start of the searchquery
            var sql = $"SELECT * FROM uitgave ";
            
            //Complete the searchQuery by the following depending on the user input.
            if (advSearch == "isbn")
            {
                sql += "WHERE isbn = @SearchString";
            } else if (advSearch == "uitgever")
            {
                sql += "WHERE uitgever = @SearchString";
            } else if (advSearch == "prijs")
            {
                sql += "WHERE prijs = @SearchString";
            } else if (advSearch == "naam")
            {
                sql += "WHERE naam LIKE CONCAT ('%',@SearchString,'%');";
            }

            using var connection = Connect();
            var stripboeken = connection
                .Query<Uitgave>(sql,
                    new {SearchString = searchString, });
            return stripboeken.ToList();
        }
    }
}