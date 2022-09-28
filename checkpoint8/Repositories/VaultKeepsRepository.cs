using System.Data;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultKeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
        }

        internal List<VaultKeep> Get(int vaultId)
        {
            string sql = @"
            SELECT
            vk.*,
            k.*,
            a.*
            FROM vaultKeeps vk
                JOIN keeps k ON vk.keepId = k.id
                JOIN accounts a ON k.creatorId = a.id
            WHERE vk.vaultId = @vaultId;
            ";
            List<VaultKeep> keep = _db.Query<VaultKeep, VaultKeep, Account, VaultKeep>(sql, (vk, k, a) =>
            {
                k.Creator = a;
                k.VaultKeepId = vk.Id;
                return k;
            }, new { vaultId }).ToList();
            return keeps;
        }



        // internal ActionResult<string> Delete(int id)
        // {
        //     string sql = @"
        //     DELETE FROM vaultKeeps
        //     WHERE id = @id
        //     ";
        //     _db.Execute(sql, new { id });
        //     return "deleted";
        // }








    }
}