using System.Data;
using System.Linq;
using Dapper;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories;

public class CollectieToevoegenRepository : DbConnection
{
    /// <summary>
    /// haalt de statusuitgave op
    /// </summary>
    /// <param name="versie_id"></param>
    /// <param name="gebruiker_id"></param>
    /// <returns>bool</returns>
    public bool StatusUitgave(int versie_id, string gebruiker_id)
    {
        const string sql = @"SELECT status FROM statusuitgave where @versie_idVAR = versie_id";
        var param = new
        {
            gebruiker_idVAR = gebruiker_id,
            versie_idVAR = versie_id
        };
        
        //connect to database
        using var connection = Connect();

        var result = connection.QuerySingleOrDefault<bool>(sql, param);
        return result;
    }

    /// <summary>
    /// Haalt stripboeken infomatie op (staat ook in aanpassen kan in 1 file)
    /// </summary>
    /// <param name="versie_id"></param>
    /// <returns>versie</returns>
    public Versie HaalStripboekInformatieOp(int versie_id)
    {
        //stored procedure van stripboeken informatie
        const string sql = @"
        SELECT
        
        
        s.versie_id,
        afbeelding_url,
        isbn,
        druk,
        datum,
        
        naam,
        
        reeks_naam
        
            FROM versie v
        INNER JOIN statusuitgave s on v.Versie_id = s.versie_id
        INNER JOIN uitgave u on v.uitgave_id = u.uitgave_id
        INNER JOIN reeks r ON r.reeks_id = u.reeks_id
        WHERE s.status = true and s.versie_id = @versie_idVAR";

        //param
        var param = new
        {
            //Versie
            @versie_idVAR = versie_id
        };

        //connect to database
        using var connection = Connect();

        //haal alles op
        var result =  connection.Query<Versie, Uitgave, Reeks, Versie>(
            sql,
            (versie, uitgave, reeks) =>
            {
                versie.Uitgave = uitgave;
                versie.Uitgave.Reeks = reeks;
                return versie;
            }, param, splitOn: "naam, reeks_naam").Last();

        //return
        return result;
    }   


    public void VoegToeAanCollectie(Bezit bezit)
    {
        //stored procedure van haal collectie op
        const string sql = "ColletieToevoegen";
            
        //connect to database
        using var connection = Connect();
        
        //vul collectie
        var param = new
        {
           gebruiker_idVAR = bezit.gebruiker_id,
            versie_idVAR = bezit.Versie.versie_id,
            ratingVAR = bezit.rating,
            staatVAR = bezit.staat,
            beschrijvingVAR = bezit.beschrijving,
            prijs_betaaldVAR = bezit.prijs_betaald,
            hoeveelheidVAR = bezit.hoeveelheid,
        };

        //Stop alle in de bijbehoorende tables en columns 
        var result = connection.Execute(sql, param, commandType: CommandType.StoredProcedure);
    }
}