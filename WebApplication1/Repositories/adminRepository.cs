using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{

    public class AdminRepository : DbConnection
    {
        public List<Uitgave> Get()
        {
            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Query<Uitgave>(@"SELECT * 
                             FROM uitgave uitgave 
                             INNER JOIN versie versie on uitgave.uitgave_id = versie.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             INNER JOIN statusuitgave s on versie.Versie_id = s.versie_id
                             ORDER BY versie.Versie_id");

            return stripboeken.ToList();
        }

        public IEnumerable<Uitgave> Verwijderen(int id)
        {
            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Query<Uitgave>(@"DELETE FROM statusuitgave WHERE versie_id = @Id;
                                 DELETE FROM bezit WHERE versie_id = @Id;
                                 DELETE FROM isgemaaktdoor WHERE versie_id = @Id;
                                 DELETE FROM versie WHERE versie_id = @Id",
                    new {Id = id,});
            return stripboeken;
        }
    }
}