using System.Data;
using Microsoft.AspNetCore.Connections;
using MySql.Data.MySqlClient;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// De database connector klasse.
    /// </summary>
    public class DbConnection
    {
        /// <summary>
        /// Maakt een verbinding met de aangegeven database.
        /// </summary>
        /// <returns>IDbConnection</returns>
        protected IDbConnection Connect()
        {
            return new MySqlConnection(
                @"Server=127.0.0.1;
                Port=3306;
                Database=stripboeken_collectie;
                Uid=ruho;
                Pwd=toegangTotKernwapens123!;");
        }
    }
}