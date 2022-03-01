using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ShowPersonalCollection : DbConnection
    {
        public List<Bezit> GetCollection(Bezit bezit)
        {
            using IDbConnection verbinding = Connect();

            IEnumerable<Bezit> personalCollection = verbinding.Query<Bezit>(
                @"SELECT rating, staat, Bezit.beschrijving, hoeveelheid, prijs_betaald, k.gebruikersnaam, u.* FROM ((Bezit
                        INNER JOIN klant k on Bezit.gebruikersnaam = k.gebruikersnaam)
                        INNER JOIN uitgave u on Bezit.isbn = u.isbn)
                        WHERE k.gebruikersnaam = 'sjonnie4332';", bezit);

            return personalCollection.ToList();
        }

    }
}