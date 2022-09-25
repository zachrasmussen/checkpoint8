using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vkRepo;
        private readonly VaultsService _vService;
        private readonly KeepsService _kService;

        public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vService, KeepsService kService)
        {
            _vkRepo = vkRepo;
            _vService = vService;
            _kService = kService;
        }

        internal List<VaultKeepViewModel> Get(int vaultId)
        {
            return _vkRepo.Get(vaultId);
        }
        internal VaultKeep Create(VaultKeep vaultKeepData, Account user)
        {
            Vault original = _vService.Get(vaultKeepData.VaultId, user);
            if (original.CreatorId != user.Id)
            {
                throw new System.Exception("You cannot add a keep to someone else's vault");
            }
            int id = _vkRepo.Create(newVaultKeep);
            VaultKeepViewModel vaultKeep = _kService.GetViewModelById(newVaultKeep.KeepId);
            vaultKeep.VaultKeepId = id;
            return vaultKeep;
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