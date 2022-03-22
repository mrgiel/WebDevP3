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
        public IEnumerable<Uitgave> Get()
        {
            const string sql = @"
            SELECT naam,versie.versie_id , isbn, status 
            FROM uitgave
            LEFT JOIN versie on uitgave.uitgave_id = versie.uitgave_id
            LEFT JOIN statusuitgave s on versie.Versie_id = s.versie_id
            WHERE versie.versie_id IS NOT null and s.status IS NOT NULL
            ORDER BY versie.Versie_id";

            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Query<Uitgave, Versie, StatusUitgave, Uitgave>(sql, (uitgave, versie, statusUitgave) =>
                {
                    uitgave.Versie = versie;
                    uitgave.Versie.StatusUitgave = statusUitgave;
                    return uitgave;
                }, splitOn: "versie_id, status");

            return stripboeken;
        }

        public void Verwijderen(int id)
        {
            using IDbConnection verbinding = Connect();
            var stripboeken = verbinding
                .Execute(@"DELETE FROM statusuitgave WHERE versie_id = @Id;
                                 DELETE FROM bezit WHERE versie_id = @Id;
                                 DELETE FROM isgemaaktdoor WHERE versie_id = @Id;
                                 DELETE FROM versie WHERE versie_id = @Id",
                    new {Id = id,});
        }
    }
}