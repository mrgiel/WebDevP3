using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class QueryOmOverzichtTeCreerenRepository : DbConnection
    {
        public List<Uitgave> HaalCollectieOpRepo()
        {
            const string sql = "HaalCollectieOp";

            //connect to database
            using var connection = Connect();

            var results = connection.Query<Uitgave>(sql);
            return results.ToList();
        }
    }
}