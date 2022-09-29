using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _keepRepo;

        public KeepsService(KeepsRepository keepRepo)
        {
            _keepRepo = keepRepo;
        }


        internal Keep Create(Keep keepData)
        {

            return _keepRepo.Create(keepData);
        }

        internal List<Keep> GetAll(string id)
        {
            // List<Keep> keeps = _keepRepo.GetAll();
            // return keeps;
            return _keepRepo.GetAll();
        }

        internal Keep GetById(int id, string userId)
        {
            Keep keep = _keepRepo.GetById(id);
            if (keep == null)
            {
                throw new Exception("There is no keep at this id");
            }
            keep.Views++;
            _keepRepo.Update(keep);
            return keep;
        }

        internal Keep Update(Keep update, Account user)
        {
            Keep original = GetById(update.Id, user.Id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception($"you cannot update {original.Name} since you did not create it");
            }
            original.Name = update.Name ?? original.Name;
            original.Img = update.Img ?? original.Img;
            original.Description = update.Description ?? original.Description;

            return _keepRepo.Update(original);
        }

        internal List<Keep> GetKeepsByProfile(string id)
        {
            return _keepRepo.GetKeepsByProfile(id);
        }

        internal string Delete(int id, Account user)
        {
            Keep original = GetById(id, user.Id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception($"{original.Name} is not yours to delete");
            }
            _keepRepo.Delete(id);
            return $"{original.Name} was deleted.";
        }
    }
}