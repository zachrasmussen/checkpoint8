using checkpoint8.Repositories;

namespace checkpoint8.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _pRepo;
        public ProfilesService(ProfilesRepository pRepo)
        {
            _pRepo = pRepo;

        }
    }
}

