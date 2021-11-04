using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Reports.Entities;
namespace EmprendeUCR.Domain.ProfileContext.Repositories
{
    public interface IProfileRepository
    {
        Task<User> GetUserAsync(string email);

        Task<IList<Entrepreneur>> GetUsersAsync();
        Task<Members> GetMemberAsync(string email);
        Task<Client> GetClientAsync(string email);
        Task<Entrepreneur> GetEntrepreneurAsync(string email);
        Task<Administrator> GetAdministratorAsync(string email);
        Task<IList<Likes>> GetLikes(string email);
        Task<Phones> GetPhoneAsync(string email);
        string GetCategoryTitleAsync(int categoryId);
        IList<Category> GetFatherCategories();
        IList<Category> GetChildCategories(int parentId);
        IList<Category> GetAllCategories();
        IList<Province> GetAllProvinces();
        IList<Canton> GetProvinceCantons(string province);
        IList<District> GetCantonDistricts(string canton);
        Task<bool> PhoneUpdate(string email, string phone);
        Task<bool> UserUpdate(User u);
        Task<bool> AdministratorUpdate(Administrator a);
        Task<bool> MemberUpdate(Members m);
        Task<bool> ClientUpdate(Client c);
        Task<bool> EntrepreneurUpdate(Entrepreneur e);
        Task<bool> AddMemberLikes(Likes l);
        Task<bool> RemoveMemberLikes(Likes l);
        Task<bool> AddReport(Report r);
        Task<bool> RemoveReport(Report r);
    }
}
