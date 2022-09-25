using checkpoint8.Models;
using Dapper;
using System.Data;
using System.Linq;

namespace checkpoint8.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Vault Create(Vault vaultData)
        {
            string sql = @"
            INSERT INTO vaults
            (creatorId, name, description, isPrivate)
            VALUES
            (@CreatorId, @Name, @Description, @IsPrivate;
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal Vault GetById(int id)
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM vaults v
            JOIN accounts a ON v.creatorId = a.id
            WHERE v.id = @id
            ";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }).FirstOrDefault();
        }

        internal Vault Update(Vault update)
        {
            string sql = @"
           UPDATE vaults SET
           name = @Name,
           description = @Description,
           isPrivate = @IsPrivate
           WHERE id = @Id;
           ";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM keep WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }
    }
}