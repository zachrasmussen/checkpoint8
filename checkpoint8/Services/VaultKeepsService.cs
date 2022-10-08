using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;
using Microsoft.AspNetCore.Mvc;
using static checkpoint8.Models.Keep;

namespace checkpoint8.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vkRepo;
        private readonly VaultsService _vService;
        private readonly VaultsRepository _vRepo;
        private readonly KeepsRepository _kRepo;

        public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vService, VaultsRepository vRepo, KeepsRepository kRepo)
        {
            _vkRepo = vkRepo;
            _vService = vService;
            _vRepo = vRepo;
            _kRepo = kRepo;
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
            // _kService.AddKept(vaultKeepData);
            Keep foundKeep = _kRepo.GetById(vaultKeepData.KeepId);
            foundKeep.Kept++;
            _kRepo.Update(foundKeep);
            return _vkRepo.Create(vaultKeepData);

        }

        internal List<VaultKeepViewModel> GetKeepsByVaultId(int id, string userId)
        {
            Vault original = _vService.GetById(id, userId);
            List<VaultKeepViewModel> keeps = _vkRepo.GetKeepsByVaultId(id);
            return keeps;
        }

        internal ActionResult<string> Delete(int id, Account user)
        {
            VaultKeep original = _vkRepo.GetById(id);
            if (original.CreatorId != user.Id)
            {
                throw new Exception("You cannot delete someone else's vault");
            }
            return _vkRepo.Delete(id);
        }
    }
}