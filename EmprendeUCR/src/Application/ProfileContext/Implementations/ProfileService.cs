using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.ProfileContext.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Application.ProfileContext.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<User> GetUser(string email)
        {
            return await _profileRepository.GetUserAsync(email);
        }
        public async Task<IList<Entrepreneur>>GetUsers()
        {
            return  await _profileRepository.GetUsersAsync();
        }

        public async Task<Members> GetMember(string email)
        {
            return await _profileRepository.GetMemberAsync(email);
        }

        public async Task<Client> GetClient(string email)
        {
            return await _profileRepository.GetClientAsync(email);
        }

        public async Task<Entrepreneur> GetEntrepreneur(string email)
        {
            return await _profileRepository.GetEntrepreneurAsync(email);
        }

        public async Task<Administrator> GetAdministrator(string email)
        {
            return await _profileRepository.GetAdministratorAsync(email);
        }

        public async Task<IList<Likes>> GetLikes(string email)
        {
            return await _profileRepository.GetLikes(email);
        }

        public async Task<Phones> GetPhone(string email)
        {
            return await _profileRepository.GetPhoneAsync(email);
        }

        public string GetCategoryTitle(int categoryId)
        {
            return _profileRepository.GetCategoryTitleAsync(categoryId);
        }

        public IList<Category> GetParentCategories()
        {
            return _profileRepository.GetFatherCategories();
        }

        public IList<Category> GetCategoryChildren(int parentId)
        {
            return _profileRepository.GetChildCategories(parentId);
        }

        public IList<Category> GetCategories()
        {
            return _profileRepository.GetAllCategories();
        }

        public IList<Province> GetProvinces()
        {
            return _profileRepository.GetAllProvinces();
        }

        public IList<Canton> GetCantons(string province)
        {
            return _profileRepository.GetProvinceCantons(province);
        }

        public IList<District> GetDistricts(string canton)
        {
            return _profileRepository.GetCantonDistricts(canton);
        }

        public async Task<bool> UpdatePhone(string email, string phone)
        {
            return await _profileRepository.PhoneUpdate(email, phone);
        }

        public async Task<bool> UpdateUser(User u)
        {
            return await _profileRepository.UserUpdate(u);
        }

        public async Task<bool> UpdateAdministrator(Administrator a)
        {
            return await _profileRepository.AdministratorUpdate(a);
        }

        public async Task<bool> UpdateMember(Members m)
        {
            return await _profileRepository.MemberUpdate(m);
        }

        public async Task<bool> UpdateClient(Client c)
        {
            return await _profileRepository.ClientUpdate(c);
        }

        public async Task<bool> UpdateEntrepreneur(Entrepreneur e)
        {
            return await _profileRepository.EntrepreneurUpdate(e);
        }

        public async Task<bool> AddLikes(Likes l)
        {
            return await _profileRepository.AddMemberLikes(l);
        }
        public async Task<bool> AddReport(Report r)
        {
            return await _profileRepository.AddReport(r);
        }


        public async Task<bool> RemoveLikes(Likes l)
        {
            return await _profileRepository.RemoveMemberLikes(l);
        }

    }
}
