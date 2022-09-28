using System.Data;
using System.Linq;
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

        internal VaultKeep GetById(int id)
        {
            string sql = @"
            SELECT * 
            FROM vaultKeeps 
            WHERE id = @id;
            ";
            VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
            return vaultKeep;
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