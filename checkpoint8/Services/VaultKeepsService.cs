using System;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vkRepo;
        private readonly VaultsService _vService;

        private readonly VaultsRepository _vRepo;
        // private readonly KeepsService _kService;

        public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vService, VaultsRepository vRepo)
        {
            _vkRepo = vkRepo;
            _vService = vService;
            _vRepo = vRepo;
            // _kService = kService;
        }

        internal VaultKeep GetById(int id, string userId)
        {
            VaultKeep vaultKeep = _vkRepo.GetById(id);
            if (vaultKeep == null)
            {
                throw new Exception("There is no keep at this id");
            }
            return vaultKeep;
        }
        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            Vault original = _vRepo.GetById(vaultKeepData.VaultId);
            if (original.CreatorId != vaultKeepData.CreatorId)
            {
                throw new System.Exception("You cannot add a keep to someone else's vault");
            }
            return _vkRepo.Create(vaultKeepData);
        }

        internal System.Collections.Generic.List<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            throw new NotImplementedException();
        }







        // internal ActionResult<string> Delete(int id, Account user)
        // {
        //     VaultKeep original = _vkRepo.GetById(id);
        //     if (original.CreatorId != user.Id)
        //     {
        //         throw new Exception("You cannot delete someone else's vault");
        //     }
        //     return _vkRepo.Delete(id);
        // }
    }
}