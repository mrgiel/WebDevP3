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
        public IEnumerable<Uitgave> AdvSearch(string advSearch, string searchString)
        {

            //Start of the searchquery
            var sql = $"SELECT * FROM ";

            switch (advSearch)
            {
                //Complete the searchQuery by the following depending on the user input.
                case "isbn":
                    sql += "Versie WHERE isbn = @SearchString";
                    break;
                case "uitgever":
                    sql += "Uitgever WHERE uitgever = @SearchString";
                    break;
                case "prijs":
                    sql += "Versie WHERE prijs = @SearchString";
                    break;
                case "naam":
                    sql += "Uitgever WHERE naam LIKE CONCAT ('%',@SearchString,'%');";
                    break;
            }

            using var connection = Connect();
            var stripboeken = connection
                .Query<Uitgave>(sql,
                    new {SearchString = searchString, });
            return stripboeken;
        }
    }
}