using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{

    public class StripboekGoedkeurenRepository : DbConnection
    {
        public IEnumerable<Versie> Goedkeuren(int id)
        {
            using IDbConnection verbinding = Connect();
            IEnumerable<Versie> stripboeken = verbinding
                .Query<Versie>(@"UPDATE statusuitgave
                                 SET status = '1', datum_goedkeuring = now()
                                 WHERE versie_id = @Id",
                    new {Id = id});
            return stripboeken;
        }
    }
}