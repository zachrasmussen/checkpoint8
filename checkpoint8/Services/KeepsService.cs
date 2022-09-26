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


        internal Keep Create(Keep keepData, Account user)
        {
            return _keepRepo.Create(keepData);
        }

        internal List<Keep> GetAll()
        {
            return _keepRepo.GetAll();
        }

        internal Keep GetById(int id)
        {
            Keep keep = _keepRepo.GetById(id);
            if (keep == null)
            {
                throw new Exception("There is no keep at this id");
            }
            return keep;
        }

        internal Keep Update(Keep update, Account user)
        {
            Keep original = GetById(update.Id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception($"you cannot update {original.Name} since you did not create it");
            }
            original.Name = update.Name ?? original.Name;
            original.Img = update.Img ?? original.Img;
            original.Description = update.Description ?? original.Description;

            return _keepRepo.Update(original);
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



        internal VaultKeepViewModel GetViewModelById(object keepId)
        {
            throw new NotImplementedException();
        }

    }
}