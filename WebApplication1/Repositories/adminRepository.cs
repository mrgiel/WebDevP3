using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class adminRepository : DbConnection
{
    public List<Uitgave> Get()
    {
        using IDbConnection verbinding = Connect();
        var stripboeken = verbinding
            .Query<Uitgave>(@"SELECT * 
                             FROM uitgave uitgave 
                             INNER JOIN versie versie on uitgave.uitgave_id = versie.uitgave_id
                             INNER JOIN uitgever uitgever on versie.uitgever_id = uitgever.uitgever_id
                             ORDER BY versie.isbn");
                                
        return stripboeken.ToList();
    }

    public IEnumerable<Uitgave> Verwijderen(string isbn)
    {
        using IDbConnection verbinding = Connect();
        var stripboeken = verbinding
            .Query<Uitgave>("DELETE FROM versie WHERE isbn = @Isbn",
                new {Isbn = isbn, });
        return stripboeken;
    }
}