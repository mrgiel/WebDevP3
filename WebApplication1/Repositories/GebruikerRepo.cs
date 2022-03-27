#nullable enable
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Data van de gebruiker kan je hier ophalen
    /// </summary>
    public class GebruikerRepo : DbConnection
    {
        private readonly IActionContextAccessor actionContextAccessor = new ActionContextAccessor();

        /// <summary>
        /// Haal ID op van gebruiker
        /// </summary>
        /// <returns>string</returns>
        public string? HaalIdOp()
        {
            //id
            var id = actionContextAccessor.ActionContext.HttpContext.User.Claims.ToList();

            //Zoek in user naar value (value --> het id van gebruiker), return null als gebruiker niet bestaat
            return id.Any() ? id.First().Value : null;
        }

        /// <summary>
        /// Haal rol van gebruiker op, als gebruiker niet is ingelogd --> null
        /// </summary>
        /// <returns>nullable string</returns>
        public string? HaalRolOp()
        {
            //haal rol op van gebruiker
            const string sql = @"SELECT rol FROM gebruiker WHERE Id = @id";

            //param
            var param = new {id = HaalIdOp()};

            //connect to database
            using var connection = Connect();

            //haalt de rol op van gebruiker, als er geen gebruiker is --> null
            var rol = connection.QuerySingleOrDefault<Gebruiker>(sql, param);
            return rol?.rol.ToString();
        }

        public IEnumerable<Gebruiker> Verwijderen(string id)
        {
            using IDbConnection verbinding = Connect();
            var gebruiker = verbinding
                .Query<Gebruiker>(@"DELETE FROM bezit WHERE gebruiker_id = @Id;
                                   DELETE FROM statusuitgave WHERE gebruiker_id = @Id",
                    new {Id = id,});
            return gebruiker;
        }

        private string? id { get; set; } = null;

        public GebruikerRepo()
        {
        }
        public GebruikerRepo(string id)
        {
            this.id = id;
        }

        public IEnumerable<Gebruiker> Get()
        {
            string sql = id != null ? @"SELECT * FROM Gebruiker WHERE Id = @idUser" : @"SELECT * FROM Gebruiker";
            var param = id != null ? new {idUser = id} : null;
            using IDbConnection verbinding = Connect();
            var Gebruiker = verbinding
                .Query<Gebruiker>(sql, param);
            return Gebruiker;
        }

        public void GebruikerAanpassen(Gebruiker gebruiker)
        {
            const string sql = "GebruikerAanpassen";

            var param = new
            {
                //Versie
                Id_ = gebruiker.Id,
                rol_ = gebruiker.rol,
                UserName_ = gebruiker.UserName,
                Email_ = gebruiker.Email,
                
            };
            using var connection = Connect();

            connection.Execute(sql, param, commandType: CommandType.StoredProcedure);
        }
    }
}