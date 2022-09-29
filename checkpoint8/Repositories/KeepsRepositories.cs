using System.Collections.Generic;
using System.Data;
using System.Linq;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Keep Create(Keep keepData)
        {
            string sql = @"
            INSERT INTO keeps
            (creatorId, name, description, img, views, kept)
            VALUES
            (@CreatorId, @Name, @Description, @Img, @Views, @Kept);
            SELECT LAST_INSERT_ID(); 
        ";
            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;
        }

        internal Keep GetById(int id)
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id
            WHERE k.id = @id
            ";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }).FirstOrDefault();
        }

        internal List<Keep> GetAll()
        {
            string sql = @"
           SELECT
           k.*,
           a.*
           FROM keeps k
           JOIN accounts a ON k.creatorId = a.id
           ";
            // List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }).ToList();
            // return keeps;
        }

        internal List<Keep> GetKeepsByProfile(string id)
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id
            WHERE k.creatorId = @id
            ";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }).ToList();
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM keeps WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }

        internal Keep Update(Keep update)
        {
            string sql = @"
           UPDATE keeps SET
           name = @Name,
           description = @Description,
           img = @Img,
           views = @Views,
           kept = @Kept
           WHERE id = @Id;
           ";
            _db.Execute(sql, update);
            return update;
        }
    }
}


