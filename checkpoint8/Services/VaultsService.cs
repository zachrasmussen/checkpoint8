using System;
using System.Collections.Generic;
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
                if (vault.isPrivate == true)
                {
                    throw new Exception("This is a private vault");
                }
                return vault;
            }
            if (vault.isPrivate == true && vault.CreatorId != userId)
            {
                throw new Exception("You don't have access to that vault");
            }
            return vault;

            // TODO check if private or owner
            // if owner, just return
            // if not owner, only return if not private

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

        internal List<Vault> GetMyVaults(string id)
        {

            return _vaultRepo.GetMyVaults(id);


            // vaults = vaults.FindAll(v => v.isPrivate == false || v.CreatorId == id);
            // return vaults;


        }


    }
}