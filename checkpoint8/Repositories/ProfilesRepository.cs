using System.Data;
using checkpoint8.Models;

namespace checkpoint8.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal ProfilesRepository Get(string id)
        {
            string sql = @"
            SELECT *
            FROM accounts
            WHERE id = @id
            ";
            return _db.QueryFistOrDefault<Profile>(sql, new { id });
        }
    }
}