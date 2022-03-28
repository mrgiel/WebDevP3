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

        var result =  connection.QuerySingleOrDefault<bool>(sql, param);
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
        const string sql = "HaalStripboekInformatieOp";

        //param
        var param = new
        {
            //Versie
            versie_idVAR = versie_id
        };

        //connect to database
        using var connection = Connect();

        //haal alles op
        var result =  connection.Query<Versie, Uitgave, Uitgever, Categorie, Reeks, Versie>(
            sql,
            (versie, uitgave, uitgever, categorie, reeks) =>
            {
                versie.Uitgave = uitgave;
                versie.Uitgever = uitgever;
                versie.Uitgave.Categorie = categorie;
                versie.Uitgave.Reeks = reeks;
                return versie;
            }, param, splitOn: "naam, uitgever_naam, cat_naam, reeks_naam",
            commandType: CommandType.StoredProcedure).Last();

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
            versie_idVAR = bezit.versie_id,
            ratingVAR = bezit.rating,
            staatVAR = bezit.staat,
            beschrijvingVAR = bezit.beschrijving,
            prijs_betaaldVAR = bezit.prijs_betaald
        };

        //Stop alle in de bijbehoorende tables en columns 
        var result = connection.Execute(sql, param, commandType: CommandType.StoredProcedure);
    }
}