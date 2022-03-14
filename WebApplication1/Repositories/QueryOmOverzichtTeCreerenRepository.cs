using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class QueryOmOverzichtTeCreerenRepository : DbConnection
    {
        public IEnumerable<Bezit> HaalCollectieOp()
        {
            //query
            var sql = "SELECT * FROM Bezit";
            
            //connect to database
            using var connection = Connect();

            //check if database exists
            return !connection.ExecuteScalar<bool>(sql) ? null : connection.Query(sql) != null ? connection.Query<Bezit>(sql) : null;
            

            
        }
    }
}