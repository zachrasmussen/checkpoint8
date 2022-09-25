using checkpoint8.Models;
using checkpoint8.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _pRepo;
        public ProfilesService(ProfilesRepository pRepo)
        {
            _pRepo = pRepo;
        }

        internal ActionResult<ProfilesService> Get(string id)
        {
            Profile original = _pRepo.Get(id);
            if (original == null)
            {
                throw new System.Exception("Invalid profile Id");
            }
            return original;
        }
    }
}