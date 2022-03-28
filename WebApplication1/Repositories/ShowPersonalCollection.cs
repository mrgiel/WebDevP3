using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{
    public class ShowPersonalCollection : DbConnection
    {
        public List<Bezit> GetCollection(string gebruikerId)
        {
            using IDbConnection verbinding = Connect();
                const string procudure = "HaalPersoonlijkeCollectieOp";

            var param = new
            {
                gebruiker_id = gebruikerId
            };

            IEnumerable<Bezit> personalCollection = verbinding.Query<Bezit, Versie, Uitgave, Bezit>(
                procudure,
                (bezit, versie, uitgave) =>
                {
                    bezit.Versie = versie;
                    bezit.Uitgave = uitgave;
                    return bezit;
                }, param, splitOn:"Versie_id, uitgave_id", commandType: CommandType.StoredProcedure);

            return personalCollection.ToList();
        }

    }
}