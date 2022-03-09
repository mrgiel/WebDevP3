using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class SearchRepository
{
    private IDbConnection Connect()
    {
        return new MySqlConnection(
            @"Server=127.0.0.1;
            Database=stripboekendb;
            Uid=root;Pwd=Test123;"
        );
    }

    /*public List<Uitgave> Get()
    {
        using var connection = Connect();
        var naam = "Donald";
        var stripboeken = connection
            .Query<Uitgave>("SELECT * FROM uitgave WHERE Naam LIKE CONCAT('%',@Naam,'%');", new {Naam = naam});
        return stripboeken.ToList();
    }*/
    public List<Uitgave> Get(string searchString)
    {
        using var connection = Connect();
        var stripboeken = connection
            .Query<Uitgave>("SELECT * FROM uitgave WHERE Naam LIKE CONCAT('%',@Naam,'%'); ", new {Naam = searchString});
        return stripboeken.ToList();
    }
}