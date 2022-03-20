using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Dapper;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{
    public class QueryOmOverzichtTeCreerenRepository : DbConnection
    {
        public IEnumerable<Versie> HaalCollectieOpRepo()
        {
            //stored procedure van haal collectie op
            const string sql = "HaalCollectieOp";

            //connect to database
            using var connection = Connect();

            //multi-mapping
            var results = connection.Query<Versie, Uitgave, Reeks, Versie>(sql, (versie, uitgave, reeks) =>
            {
                versie.Uitgave = uitgave;
                versie.Uitgave.Reeks = reeks;
                return versie;
            }, splitOn: "naam, reeks_naam");
            return results;
        }
    }
}