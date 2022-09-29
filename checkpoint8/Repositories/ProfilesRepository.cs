using System.Data;
using System.Linq;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Profile Get(string id)
        {
            string sql = @"
            SELECT *
            FROM accounts
            WHERE id = @id;
            ";
            return _db.Query<Profile>(sql, new { id }).FirstOrDefault();
        }
    }
}