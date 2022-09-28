using System;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vaultRepo;

        public VaultsService(VaultsRepository vaultRepo)
        {
            _vaultRepo = vaultRepo;
        }

        internal Vault Create(Vault vaultData)
        {
            return _vaultRepo.Create(vaultData);
        }

        internal Vault GetById(int id, string userId)
        {
            Vault vault = _vaultRepo.GetById(id);
            if (vault == null)
            {
                throw new Exception("There is no vault at this id");
            }
            return vault;
        }



        internal Vault Update(Vault update, Account user)
        {
            Vault original = GetById(update.Id, user.Id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception($"you cannot update {original.Name} since you did not create it");
            }
            original.Name = update.Name ?? original.Name;
            original.Description = update.Description ?? original.Description;


            return _vaultRepo.Update(original);
        }

        internal string Delete(int id, Account user)
        {
            Vault original = GetById(id, user.Id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception("You cannot delte this because its not yours");
            }
            _vaultRepo.Delete(id);
            return $"{original.Name} was delete.";
        }
    }
}